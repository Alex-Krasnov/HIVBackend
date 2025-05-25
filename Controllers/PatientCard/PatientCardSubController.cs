using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardSubController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardSubController(HivContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetFio")]
        [Authorize(Roles = "User")]
        public IActionResult GetFio(int patientId)
        {
            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");
            return Ok(new { 
                patientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName,
                isNonResident = _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.RegionId)?.RegtypeId != 1
        });
        }
    }
}
