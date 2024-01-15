using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportKorvetController : ControllerBase
    {
        private readonly HivContext _context;
        public ImportKorvetController(HivContext context)
        {
            _context = context;
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

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(stream, false))
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

                        DateOnly dateIn;
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
                            TblMedicine item = new() { 
                                MedicineId = maxId,
                                MedicineLong = medicineName,
                                User1 = "base",
                                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
                            };
                            _context.TblMedicines.Add(item);
                            _context.SaveChanges();
                            medicineId = maxId;
                        }

                        DateOnly dateOut;
                        string dateOutStr = sharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(row.ChildElements[25].InnerText)).InnerText;
                        bool isDateOut = DateOnly.TryParse(dateOutStr, out dateOut); // z-25 - date out
                        if (isDateOut)
                            dateOut = dateIn;

                        var count = double.Parse(row.ChildElements[31].InnerText, CultureInfo.GetCultureInfo("en-US")); // af-31 - count med

                        if (_context.TblPatientPrescrMs.Any(e => e.PatientId == patientId && e.PrescrSer == ser && e.PrescrNum == num))
                        {
                            errList.Add($"Cтрока {row.RowIndex} такой первичный ключ уже существует");
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
                            GiveMedId = medicineId,
                            GiveDate = dateOut,
                            GivePackNum = count,
                            KorvetDateImp = DateOnly.FromDateTime(DateTime.Now)
                        };

                        _context.TblPatientPrescrMs.Add(recipe);
                        _context.SaveChanges();

                        if (row.RowIndex == numEndRow - 1)
                            break;
                    }
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
