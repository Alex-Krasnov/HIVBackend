using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardJailController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardJailController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<Jail> jails = new();

            TblPatientCard? patient = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == patientId && e.IsActive == true);
            if (patient is null)
                return BadRequest("Пациент не найден");

            var patientJails = _context.TblPatientJails.Where(e => e.PatientId == patient.PatientId).ToList();

            foreach (var item in patientJails)
            {
                jails.Add(new()
                {
                    JailName = _context.TblJails.FirstOrDefault(e => e.JailId == item.JailId)?.JailLong,
                    JailLeavName = _context.TblJails.FirstOrDefault(e => e.JailId == item.JailLeavId)?.JailLong,
                    JailStart = item.JailStart,
                    JailEnd = item.JailEnd
                });
            }

            PatientCardJail patientCardJail = new();

            patientCardJail.PatientId = patient.PatientId;
            patientCardJail.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardJail.JailName = _context.TblJails.FirstOrDefault(e => e.JailId == patient.JailId)?.JailLong;
            patientCardJail.JailOffRegion = _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.JailedOffRegionId)?.RegionLong;
            patientCardJail.JailOffDate = patient.JailedOffDate;

            patientCardJail.ListJail = _context.TblJails.Select(e => e.JailLong).ToList();
            patientCardJail.ListRegion = _context.TblRegions.Select(e => e.RegionLong).ToList();

            patientCardJail.Jails = jails;

            return Ok(patientCardJail);
        }

        [HttpDelete, Route("DelJail")]
        [Authorize(Roles = "User")]
        public IActionResult DelJail(int patientId, string dateStart, string dateEnd)
        {
            TblPatientJail item = new()
            {
                PatientId = patientId,
                JailStart = DateOnly.Parse(dateStart),
                JailEnd = DateOnly.Parse(dateEnd)
            };

            _context.TblPatientJails.Attach(item);
            _context.TblPatientJails.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateJail")]
        [Authorize(Roles = "User")]
        public IActionResult CreateJail(JailForm jail)
        {
            TblPatientJail item = new()
            {
                PatientId = jail.PatientId,
                JailId = _context.TblJails.FirstOrDefault(e => e.JailLong == jail.JailName)?.JailId,
                JailLeavId = _context.TblJails.FirstOrDefault(e => e.JailLong == jail.JailLeavName)?.JailId,
                JailStart = DateOnly.Parse(jail.JailStart),
                JailEnd = DateOnly.Parse(jail.JailEnd)
            };

            _context.TblPatientJails.Attach(item);
            _context.TblPatientJails.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateJail")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateJail(JailForm jail)
        {
            TblPatientJail item = new()
            {
                PatientId = jail.PatientId,
                JailStart = DateOnly.Parse(jail.JailStartOld),
                JailEnd = DateOnly.Parse(jail.JailEndOld)
            };
            _context.TblPatientJails.Attach(item);

            if (jail.JailStartOld == jail.JailStart && jail.JailEndOld == jail.JailEnd)
            {
                item.JailLeavId = _context.TblJails.FirstOrDefault(e => e.JailLong == jail.JailLeavName)?.JailId;
                item.JailId = _context.TblJails.FirstOrDefault(e => e.JailLong == jail.JailName)?.JailId;

                _context.Entry(item).Property(e => e.JailLeavId).IsModified = true;
                _context.Entry(item).Property(e => e.JailId).IsModified = true;
                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientJails.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = jail.PatientId,
                JailId = _context.TblJails.FirstOrDefault(e => e.JailLong == jail.JailName)?.JailId,
                JailLeavId = _context.TblJails.FirstOrDefault(e => e.JailLong == jail.JailLeavName)?.JailId,
                JailStart = DateOnly.Parse(jail.JailStart),
                JailEnd = DateOnly.Parse(jail.JailEnd)
            };
            _context.TblPatientJails.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdatePatient")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePatient(PatientCardJailForm patient)
        {
            TblPatientCard item = _context.TblPatientCards.First(e => e.PatientId == patient.PatientId);
            _context.TblPatientCards.Attach(item);

            item.JailId = _context.TblJails.FirstOrDefault(e => e.JailLong == patient.JailName)?.JailId;
            item.JailedOffRegionId = _context.TblRegions.FirstOrDefault(e => e.RegionLong == patient.JailOffRegion)?.RegionId;
            item.JailedOffDate = patient.JailOffDate != null && patient.JailOffDate?.Length != 0 ? DateOnly.Parse(patient.JailOffDate) : null;

            _context.Entry(item).Property(e => e.JailId).IsModified = true;
            _context.Entry(item).Property(e => e.JailedOffRegionId).IsModified = true;
            _context.Entry(item).Property(e => e.JailedOffDate).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
