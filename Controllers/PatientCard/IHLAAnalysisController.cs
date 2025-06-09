using HIVBackend.Data;
using HIVBackend.Models.DBModels;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class IHLAAnalysisController : ControllerBase
    {
        private readonly HivContext _context;
        public IHLAAnalysisController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int patientId)
        {
            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            return Ok(
                new { 
                    Ihla = _context.TblIhlaAnalyses.Where(e => e.PatientId == patientId).OrderByDescending(e => e.AnalysisDate).ToList(), 
                    PatientId = patient.PatientId,
                    PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName
                });
        }

        [HttpDelete, Route("Delete")]
        public IActionResult Delete(int id) 
        {
            var item = _context.TblIhlaAnalyses.FirstOrDefault(e => e.Id == id);

            if (item == null)
                return BadRequest("Запись не найдена");

            _context.TblIhlaAnalyses.Attach(item);
            _context.TblIhlaAnalyses.Remove(item);

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        public IActionResult Create(IhlaAnalysis ihla)
        {
            TblIhlaAnalysis item = new()
            {
                PatientId = ihla.PatientId,
                Result = ihla.Result,
                AnalysisDate = ihla.AnalysisDate,
                User = User.Identity?.Name,
                DateCreate = DateOnly.FromDateTime(DateTime.Now),
                DateChange = DateOnly.FromDateTime(DateTime.Now),
                AnalysisNumber = ihla.AnalysisNumber,
            };

            _context.TblIhlaAnalyses.Add(item);
            _context.SaveChanges();

            _context.Entry(item).Reload();
            return Ok(item);
        }

        [HttpPost, Route("Update")]
        public IActionResult Update(IhlaAnalysis ihla) 
        {
            var item = _context.TblIhlaAnalyses.FirstOrDefault(e => e.Id == ihla.Id);

            if (item == null) 
                return BadRequest("Запись не найдена");

            _context.TblIhlaAnalyses.Attach(item);

            item.Result = ihla.Result;
            _context.Entry(item).Property(e => e.Result).IsModified = true;
            item.AnalysisDate = ihla.AnalysisDate;
            _context.Entry(item).Property(e => e.AnalysisDate).IsModified = true;
            item.DateChange = DateOnly.FromDateTime(DateTime.Now);
            _context.Entry(item).Property(e => e.DateChange).IsModified = true;
            item.AnalysisNumber = ihla.AnalysisNumber;
            _context.Entry(item).Property(e => e.AnalysisNumber).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
