using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DieCourseController : ControllerBase
    {

        private readonly HivContext _context;
        public DieCourseController(HivContext context)
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

            DieCourseAdvanced die = new();

            die.PatientId = patient.PatientId;
            die.DieCourseLong1 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId1)?.DieCourseLong;
            die.DieCourseLong2 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId2)?.DieCourseLong;
            die.DieCourseLong3 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId3)?.DieCourseLong;
            die.DieCourseLong4 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId4)?.DieCourseLong;
            die.DieCourseLong5 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId5)?.DieCourseLong;
            die.DieCourseShort1 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId1)?.DieCourseShort;
            die.DieCourseShort2 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId2)?.DieCourseShort;
            die.DieCourseShort3 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId3)?.DieCourseShort;
            die.DieCourseShort4 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId4)?.DieCourseShort;
            die.DieCourseShort5 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId5)?.DieCourseShort;

            return Ok(die);
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(DieCourseAdvanced die)
        {
            TblPatientCard item = new()
            {
                PatientId = die.PatientId,
            };
            _context.TblPatientCards.Attach(item);

            item.DieCourseId1 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseShort == die.DieCourseShort1)?.DieCourseId;
            _context.Entry(item).Property(e => e.DieCourseId1).IsModified = true;
            item.DieCourseId2 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseShort == die.DieCourseShort2)?.DieCourseId;
            _context.Entry(item).Property(e => e.DieCourseId2).IsModified = true;
            item.DieCourseId3 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseShort == die.DieCourseShort3)?.DieCourseId;
            _context.Entry(item).Property(e => e.DieCourseId3).IsModified = true;
            item.DieCourseId4 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseShort == die.DieCourseShort4)?.DieCourseId;
            _context.Entry(item).Property(e => e.DieCourseId4).IsModified = true;
            item.DieCourseId5 = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseShort == die.DieCourseShort5)?.DieCourseId;
            _context.Entry(item).Property(e => e.DieCourseId5).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
