using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewPatientController : ControllerBase
    {
        private readonly HivContext _context;
        public NewPatientController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult CreatePatient()
        {
            int MaxPatientId = _context.TblPatientCards.Max(e => e.PatientId) + 1;
            TblPatientCard Patient = new() { PatientId = MaxPatientId, IsActive = true, InputDate = DateOnly.FromDateTime(DateTime.Now) };
            _context.TblPatientCards.Add(Patient);
            _context.SaveChanges();
            return Ok(MaxPatientId);
        }
    }
}
