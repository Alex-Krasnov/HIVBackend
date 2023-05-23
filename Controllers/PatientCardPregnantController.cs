using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System.Data;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardPregnantController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardPregnantController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<PregnantM> pregM = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            List<TblPatientPregnantM>? patientPreg = _context.TblPatientPregnantMs.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var item in patientPreg)
            {
                pregM.Add(new()
                {
                    PregId = item.PregId,
                    PwCheck = item.PwcheckYn,
                    PwMonth = item.Pwmonth,
                    PregDate = item.PregDate,
                    ChildBirthDate = item.ChildBirthDate,
                    BirthType = _context.TblBirthTypes.FirstOrDefault(e => e.BirthTypeId == item.BirthTypeId)?.BirthTypeLong,
                    ChildCount = _context.TblChildCounts.FirstOrDefault(e => e.ChildCountId == item.ChildCountId)?.ChildCountLong,
                    ChildId = item.ChildPatientId,
                    StartMonth = item.MedicineStMonthNo,
                    ChildFamilyName = item.ChildFamilyName,
                    ChildFirstName = item.ChildFirstName,
                    ChildThirdName = item.ChildThirdName,
                    PregDescr = item.PregDescr,
                    PhpSchema1 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaId == item.PhpschemaId1)?.CureSchemaLong,
                    PhpSchema2 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaId == item.PhpschemaId2)?.CureSchemaLong,
                    PhpSchema3 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaId == item.PhpschemaId3)?.CureSchemaLong,
                });
            }

            PatientCardPregnant patientCardPreg = new();

            patientCardPreg.PatientId = patient.PatientId;
            patientCardPreg.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardPreg.PregCheck = _context.TblPregChecks.FirstOrDefault(e => e.PregCheckId == patient.PregCheckId)?.PregCheckLong;
            patientCardPreg.PregMonth = patient.PregMonthNo;
            patientCardPreg.ListPregCheck = _context.TblPregChecks.Select(e => e.PregCheckLong).ToList();
            patientCardPreg.ListBirthType = _context.TblBirthTypes.Select(e => e.BirthTypeLong).ToList();
            patientCardPreg.ListChildCount = _context.TblChildCounts.Select(e => e.ChildCountLong).ToList();
            patientCardPreg.PregnantMs = pregM;

            return Ok(patientCardPreg);
        }

        [HttpDelete, Route("DelPregM")]
        [Authorize(Roles = "User")]
        public IActionResult DelPregM(int patientId, int pregId)
        {
            TblPatientPregnantM item = new()
            {
                PatientId = patientId,
                PregId = (short)pregId
            };

            _context.TblPatientPregnantMs.Attach(item);
            _context.TblPatientPregnantMs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreatePregM")]
        [Authorize(Roles = "User")]
        public IActionResult CreatePregM(PregM preg)
        {
            TblPatientPregnantM item = new()
            {
                PatientId = preg.PatientId,
                PregId = (short)preg.PregId,
                PwcheckYn = preg.PwCheck,
                Pwmonth = (short?)preg.PwMonth,
                PregDate = preg.PregDate != null && preg.PregDate?.Length != 0 ? DateOnly.Parse(preg.PregDate) : null,
                ChildBirthDate = preg.ChildBirthDate != null && preg.ChildBirthDate?.Length != 0 ? DateOnly.Parse(preg.ChildBirthDate) : null,
                BirthTypeId = _context.TblBirthTypes.FirstOrDefault(e => e.BirthTypeLong == preg.BirthType)?.BirthTypeId,
                ChildCountId = _context.TblChildCounts.FirstOrDefault(e => e.ChildCountLong == preg.ChildCount)?.ChildCountId,
                ChildPatientId = preg.ChildId.Length == 0 ? null : int.Parse(preg.ChildId),
                MedicineStMonthNo = (short?)preg.StartMonth,
                ChildFamilyName = preg.ChildFamilyName,
                ChildFirstName = preg.ChildFirstName,
                ChildThirdName = preg.ChildThirdName,
                PregDescr = preg.PregDescr,
                PhpschemaId1 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema1)?.CureSchemaId,
                PhpschemaId2 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema2)?.CureSchemaId,
                PhpschemaId3 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema3)?.CureSchemaId
            };

            _context.TblPatientPregnantMs.Attach(item);
            _context.TblPatientPregnantMs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdatePregM")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePregM(PregM preg)
        {
            TblPatientPregnantM item = new()
            {
                PatientId = preg.PatientId,
                PregId = (short)preg.OldPregId
            };
            _context.TblPatientPregnantMs.Attach(item);

            if (preg.PregId == preg.OldPregId)
            {
                item.PwcheckYn = preg.PwCheck;
                _context.Entry(item).Property(e => e.PwcheckYn).IsModified = true;
                item.Pwmonth = (short?)preg.PwMonth;
                _context.Entry(item).Property(e => e.Pwmonth).IsModified = true;
                item.PregDate = preg.PregDate != null && preg.PregDate?.Length != 0 ? DateOnly.Parse(preg.PregDate) : null;
                _context.Entry(item).Property(e => e.PregDate).IsModified = true;
                item.ChildBirthDate = preg.ChildBirthDate != null && preg.ChildBirthDate?.Length != 0 ? DateOnly.Parse(preg.ChildBirthDate) : null;
                _context.Entry(item).Property(e => e.ChildBirthDate).IsModified = true;
                item.ChildCountId = _context.TblChildCounts.FirstOrDefault(e => e.ChildCountLong == preg.ChildCount)?.ChildCountId;
                _context.Entry(item).Property(e => e.ChildCountId).IsModified = true;
                item.ChildPatientId = preg.ChildId.Length == 0 ? null : int.Parse(preg.ChildId);
                _context.Entry(item).Property(e => e.ChildPatientId).IsModified = true;
                item.MedicineStMonthNo = (short?)preg.StartMonth;
                _context.Entry(item).Property(e => e.MedicineStMonthNo).IsModified = true;
                item.ChildFamilyName = preg.ChildFamilyName;
                _context.Entry(item).Property(e => e.ChildFamilyName).IsModified = true;
                item.ChildFirstName = preg.ChildFirstName;
                _context.Entry(item).Property(e => e.ChildFirstName).IsModified = true;
                item.ChildThirdName = preg.ChildThirdName;
                _context.Entry(item).Property(e => e.ChildThirdName).IsModified = true;
                item.PregDescr = preg.PregDescr;
                _context.Entry(item).Property(e => e.PregDescr).IsModified = true;
                item.PhpschemaId1 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema1)?.CureSchemaId;
                _context.Entry(item).Property(e => e.PhpschemaId1).IsModified = true;
                item.PhpschemaId2 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema2)?.CureSchemaId;
                _context.Entry(item).Property(e => e.PhpschemaId2).IsModified = true;
                item.PhpschemaId3 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema3)?.CureSchemaId;
                _context.Entry(item).Property(e => e.PhpschemaId3).IsModified = true;
                item.BirthTypeId = _context.TblBirthTypes.FirstOrDefault(e => e.BirthTypeLong == preg.BirthType)?.BirthTypeId;
                _context.Entry(item).Property(e => e.BirthTypeId).IsModified = true;

                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientPregnantMs.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = preg.PatientId,
                PregId = (short)preg.PregId,
                PwcheckYn = preg.PwCheck,
                Pwmonth = (short?)preg.PwMonth,
                PregDate = preg.PregDate != null && preg.PregDate?.Length != 0 ? DateOnly.Parse(preg.PregDate) : null,
                ChildBirthDate = preg.ChildBirthDate != null && preg.ChildBirthDate?.Length != 0 ? DateOnly.Parse(preg.ChildBirthDate) : null,
                BirthTypeId = _context.TblBirthTypes.FirstOrDefault(e => e.BirthTypeLong == preg.BirthType)?.BirthTypeId,
                ChildCountId = _context.TblChildCounts.FirstOrDefault(e => e.ChildCountLong == preg.ChildCount)?.ChildCountId,
                ChildPatientId = preg.ChildId.Length == 0 ? null : int.Parse(preg.ChildId),
                MedicineStMonthNo = (short?)preg.StartMonth,
                ChildFamilyName = preg.ChildFamilyName,
                ChildFirstName = preg.ChildFirstName,
                ChildThirdName = preg.ChildThirdName,
                PregDescr = preg.PregDescr,
                PhpschemaId1 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema1)?.CureSchemaId,
                PhpschemaId2 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema2)?.CureSchemaId,
                PhpschemaId3 = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaLong == preg.PhpSchema3)?.CureSchemaId
            };

            _context.TblPatientPregnantMs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdatePatient")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePatient(PatientCardPregnantForm preg)
        {
            TblPatientCard item = _context.TblPatientCards.First(e => e.PatientId == preg.patientId);
            _context.TblPatientCards.Attach(item);

            item.PregCheckId = _context.TblPregChecks.FirstOrDefault(e => e.PregCheckLong == preg.pregCheck)?.PregCheckId;
            _context.Entry(item).Property(e => e.PregCheckId).IsModified = true;
            item.PregMonthNo = (short?)preg.pregMonth;
            _context.Entry(item).Property(e => e.PregMonthNo).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
