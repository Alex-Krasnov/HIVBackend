using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportKorvetController : ControllerBase
    {
        private readonly HivContext _context;
        IWebHostEnvironment _appEnvironment;
        public ImportKorvetController(HivContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetFinSourse()
        {
            List<string?> ListFinSource = _context.TblFinSources.Where(e => e.FinSourceLong != null).Select(e => e.FinSourceLong).ToList();
            return Ok(ListFinSource);
        }

        [HttpPost, Route("SetFile")]
        [Authorize(Roles = "User")]
        public IActionResult SetFile(IFormFile file, [FromForm] string finSource)
        {
            const int firstRow = 27;
            int numEndRow = 0;
            List<string> errList = new();

            if (file == null && file.Length == 0)
                return BadRequest("Ошибка файла");

            var finSourceId = _context.TblFinSources.FirstOrDefault(e => e.FinSourceLong == finSource)?.FinSourceId;

            if (finSourceId == null)
                return BadRequest("Ошибка Источника финансирования");

            string path = _appEnvironment.WebRootPath + "/Files/" + file.FileName;
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(path, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                SharedStringTable sharedStringTable = spreadsheetDocument.WorkbookPart.SharedStringTablePart.SharedStringTable;

                foreach (var item in sheetData.Elements<Row>())
                {
                    var b = item.ChildElements.ElementAt(0).InnerText;
                    int indStr;
                    bool isInt = int.TryParse(item.ChildElements.ElementAt(0).InnerText, out indStr);
                    if (!isInt)
                        continue;

                    if (sharedStringTable.Elements<SharedStringItem>().ElementAt(indStr).InnerText.Contains("ИТОГО:"))
                    {
                        numEndRow = int.Parse(item.RowIndex);
                        break;
                    }
                }

                //numEndRow = 100;//int.Parse(endRow.RowIndex);

                foreach (Row row in sheetData.Elements<Row>())
                {
                    if (row.RowIndex <= firstRow)
                        continue;

                    if (row.RowIndex == numEndRow - 1)
                        break;

                    DateOnly dateIn = DateOnly.Parse("1900-01-01");
                    string dateInStr = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[2].InnerText)).InnerText;
                    bool isDateIn = DateOnly.TryParse(dateInStr, out dateIn); // c-2 - date inp


                    if (!isDateIn)
                    {
                        errList.Add($"Cтрока {row.RowIndex} некорректная дата");
                        continue;
                    }


                    string docCode = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[4].InnerText)).InnerText.Substring(0, 4);
                    int? doctorId = _context.TblDoctors.Where(e => e.Ext1Pcod == docCode).FirstOrDefault()?.DoctorId; // e-4 - doctor
                    if (doctorId == null)
                    {
                        errList.Add($"Cтрока {row.RowIndex} неверный код врача");
                        continue;
                    }

                    var snils = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[16].InnerText)).InnerText.Replace("-", "").Replace(" ", ""); // q-16 - snils
                    var fioPatient = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[8].InnerText)).InnerText.ToLower(); // i-8 - fio patient
                    int? patientId = _context.TblPatientCards.FirstOrDefault(e => e.Snils.Replace("-", "").Replace(" ", "") == (string)snils)?.PatientId;
                    if (patientId == null)
                    {
                        errList.Add($"Cтрока {row.RowIndex} пациент не найден");
                        continue;
                    }

                    string serNum = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[19].InnerText)).InnerText; // t-19 - ser num
                    var ser = serNum.Substring(0, 5);
                    var num = serNum.Substring(6, serNum.Length - 7);//

                    string medicineName = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[21].InnerText)).InnerText;
                    int? medicineId = _context.TblMedicines.Where(e => e.MedicineLong == medicineName).FirstOrDefault()?.MedicineId; // v-21 - medicine
                    if (medicineId == null)
                    {
                        int maxId = _context.TblMedicines.Max(e => e.MedicineId) + 1;
                        TblMedicine item = new()
                        {
                            MedicineId = maxId,
                            MedicineLong = medicineName,
                            User1 = "base",
                            Datetime1 = DateOnly.FromDateTime(DateTime.Now)
                        };
                        _context.TblMedicines.Add(item);
                        _context.SaveChanges();
                        medicineId = maxId;
                    }

                    string giveMedicineName = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[26].InnerText)).InnerText;
                    int? giveMedicineId = _context.TblMedicines.Where(e => e.MedicineLong == giveMedicineName).FirstOrDefault()?.MedicineId; // аа-27 - give medicine
                    if (giveMedicineId == null)
                    {
                        int maxId = _context.TblMedicines.Max(e => e.MedicineId) + 1;
                        TblMedicine item = new()
                        {
                            MedicineId = maxId,
                            MedicineLong = giveMedicineName,
                            User1 = "base",
                            Datetime1 = DateOnly.FromDateTime(DateTime.Now)
                        };
                        _context.TblMedicines.Add(item);
                        _context.SaveChanges();
                        giveMedicineId = maxId;
                    }

                    DateOnly dateOut;
                    string dateOutStr = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[25].InnerText)).InnerText;
                    bool isDateOut = DateOnly.TryParse(dateOutStr, out dateOut); // z-25 - date out
                    if (isDateOut)
                        dateOut = dateIn;

                    var count = double.Parse(row.ChildElements[31].InnerText, CultureInfo.GetCultureInfo("en-US")); // af-31 - count med

                    if (_context.TblPatientPrescrMs.Any(e => e.PatientId == patientId && e.PrescrSer == ser && e.PrescrNum == num))
                    {
                        var item = _context.TblPatientPrescrMs.First(e => e.PatientId == patientId && e.PrescrSer == ser && e.PrescrNum == num);

                        item.DoctorId = doctorId;
                        _context.Entry(item).Property(e => e.DoctorId).IsModified = true;
                        item.PrescrDate = dateIn;
                        _context.Entry(item).Property(e => e.PrescrDate).IsModified = true;
                        item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);
                        _context.Entry(item).Property(e => e.Datetime1).IsModified = true;
                        item.FinSourceId = finSourceId;
                        _context.Entry(item).Property(e => e.FinSourceId).IsModified = true;
                        item.MedicineId = medicineId;
                        _context.Entry(item).Property(e => e.MedicineId).IsModified = true;
                        item.PackNumber = count;
                        _context.Entry(item).Property(e => e.PackNumber).IsModified = true;
                        item.GiveMedId = giveMedicineId;
                        _context.Entry(item).Property(e => e.GiveMedId).IsModified = true;
                        item.GiveDate = dateOut;
                        _context.Entry(item).Property(e => e.GiveDate).IsModified = true;
                        item.GivePackNum = count;
                        _context.Entry(item).Property(e => e.GivePackNum).IsModified = true;
                        item.KorvetDateImp = DateOnly.FromDateTime(DateTime.Now);
                        _context.Entry(item).Property(e => e.KorvetDateImp).IsModified = true;

                        _context.SaveChanges();

                        errList.Add($"Cтрока {row.RowIndex} такой первичный ключ уже существует, запись обновлена");
                        continue;
                    }

                    TblPatientPrescrM recipe = new()
                    {
                        PatientId = (int)patientId,
                        PrescrSer = ser,
                        PrescrNum = num,
                        DoctorId = doctorId,
                        PrescrDate = dateIn,
                        Datetime1 = DateOnly.FromDateTime(DateTime.Now),
                        FinSourceId = finSourceId,
                        MedicineId = medicineId,
                        PackNumber = count,
                        GiveMedId = giveMedicineId,
                        GiveDate = dateOut,
                        GivePackNum = count,
                        KorvetDateImp = DateOnly.FromDateTime(DateTime.Now)
                    };

                    _context.TblPatientPrescrMs.Add(recipe);
                    _context.SaveChanges();
                }
            }

            byte[] fileBytes = Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, errList));

            string fileName = "errList.txt";
            string contentType = "text/plain";

            var streamFile = new MemoryStream(fileBytes);
            return File(streamFile, contentType, fileName);
        }
    }
}
