using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardFilesController : ControllerBase
    {
        private readonly string uploadFolderPath = "/app/uploads"; //$"D:\\work\\HIV\\patient_files";

        private readonly HivContext _context;
        public PatientCardFilesController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            var files = _context.TblPatientFileses.Where(e => e.PatientId == patientId)?.Select(e => e.FilePath).ToList();

            PatientCardFiles patientCardFiles = new();

            patientCardFiles.PatientId = patient.PatientId;
            patientCardFiles.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardFiles.Files = files;
            return Ok(patientCardFiles);
        }

        [HttpPost, Route("UploadFile")]
        [Authorize(Roles = "User")]
        public IActionResult UploadFile(IFormFile file, [FromForm] string patientId)
        {
            if (file == null && file?.Length == 0)
                return BadRequest(new { message = "Ошибка загрузки файла. Файл повреждён" });

            var filePath = Path.Combine(uploadFolderPath, file.FileName);

            if (System.IO.File.Exists(filePath))
                return BadRequest(new { message = "Ошибка: файл с таким названием уже существует. Переименуйте файл и повторите отправку" });

            using (var stream = new FileStream(filePath, FileMode.Create))
                file.CopyTo(stream);

            if (System.IO.File.Exists(filePath))
            {
                var patientFile = new TblPatientFiles
                {
                    PatientId = int.Parse(patientId),
                    FilePath = filePath
                };
                _context.TblPatientFileses.Add(patientFile);
                _context.SaveChanges();
                return Ok(new { message = "Файл успешно сохранен", fileName = filePath });
            }

            return BadRequest(new { message = "Ошибка сохранения файла" });
        }

        [HttpPost, Route("DeleteFile")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteFile([FromForm] string patientId, [FromForm] string filePath)
        {
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            if (System.IO.File.Exists(filePath))
                return BadRequest(new { message = "Ошибка удаления файла. Повторите попытку" });

            var item = new TblPatientFiles { FilePath = filePath, PatientId = int.Parse(patientId) };
            _context.TblPatientFileses.Attach(item);
            _context.TblPatientFileses.Remove(item);
            _context.SaveChanges();
            return Ok(new { message = "Файл успешно удалён" });
        }

        [HttpPost, Route("DownloadFile")]
        [Authorize(Roles = "User")]
        public IActionResult DownloadFile([FromForm] string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                return BadRequest(new { message = "Файл не найден" });

            return PhysicalFile(filePath, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}