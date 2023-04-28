using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardVisitController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardVisitController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmPatientCheck> checks = new();
            List<FrmPatientCheck> checksOut = new();
            List<FrmRegistry> registries = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            List<TblPatientCheck>? patientChecks = _context.TblPatientChecks.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientCheckOut>? patientChecksOut = _context.TblPatientCheckOuts.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientRegistry>? patientRegistries = _context.TblPatientRegistries.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var item in patientChecks)
            {
                checks.Add(new()
                {
                    CheckDate = item.CheckDate,
                    CheckDateNext = item.CheckDateNext,
                    CheckDoc = _context.TblDoctors.First(e => e.DoctorId == item.CheckDoctorId).DoctorLong,
                    CheckSpec = _context.TblSpecs.First(e => e.SpecId == item.CheckSpecId).SpecLong
                });
            }

            foreach (var item in patientChecksOut)
            {
                checksOut.Add(new()
                {
                    CheckDate = item.CheckDate,
                    CheckDateNext = item.CheckDateNext,
                    CheckDoc = _context.TblDoctors.First(e => e.DoctorId == item.CheckDoctorId).DoctorLong,
                    CheckSpec = _context.TblSpecs.First(e => e.SpecId == item.CheckSpecId).SpecLong
                });
            }

            foreach (var item in patientRegistries)
            {
                registries.Add(new()
                {
                    RegDate = item.RegDate,
                    RegCab = _context.TblCabinets.FirstOrDefault(e => e.CabinetId == item.RegCabinetId)?.CabinetLong,
                    RegTime = _context.TblRegTimes.FirstOrDefault(e => e.RegTimeId == item.RegTimeId)?.RegTimeLong,
                    RegDoc = _context.TblDoctors.FirstOrDefault(e => e.DoctorId == item.RegDoctorId)?.DoctorLong,
                    RegCom = item.RegDescr,
                    RegCheck = item.RegCheck
                });
            }


            PatientCardVisit patientCardVisit = new();

            patientCardVisit.PatientId = patient.PatientId;
            patientCardVisit.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;

            patientCardVisit.ListCab = _context.TblCabinets.Select(e => e.CabinetShort)?.ToList();
            patientCardVisit.ListDoctor = _context.TblDoctors.Select(e => e.DoctorLong)?.ToList();
            patientCardVisit.ListSpec = _context.TblSpecs.Select(e => e.SpecLong)?.ToList();
            patientCardVisit.ListRegTime = _context.TblRegTimes.Select(e => e.RegTimeLong)?.ToList();

            patientCardVisit.Checks = checks;
            patientCardVisit.ChecksOut = checksOut;
            patientCardVisit.Registries = registries;

            return Ok(patientCardVisit);
        }

        [HttpDelete, Route("DelCheck")]
        [Authorize(Roles = "User")]
        public IActionResult DelCheck(int patientId, string date, string spec)
        {
            TblPatientCheck item = new()
            {
                PatientId = patientId,
                CheckDate = DateOnly.Parse(date),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == spec).SpecId
            };

            _context.TblPatientChecks.Attach(item);
            _context.TblPatientChecks.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCheck")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCheck(Check check)
        {
            TblPatientCheck item = new()
            {
                PatientId = check.PatientId,
                CheckDate = DateOnly.Parse(check.CheckDate),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == check.SpecName).SpecId,
                CheckDoctorId = _context.TblDoctors.First(e => e.DoctorLong == check.CheckDocName).DoctorId,
                CheckDateNext = check.CheckDateNetx != null && check.CheckDateNetx?.Length != 0 ? DateOnly.Parse(check.CheckDateNetx) : null
            };

            _context.TblPatientChecks.Attach(item);
            _context.TblPatientChecks.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateCheck")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCheck(Check check)
        {
            string checkDate = check.CheckDate,
                checkDateOld = check.CheckDateOld,
                spec = check.SpecName,
                specOld = check.SpecNameOld;

            TblPatientCheck item = new()
            {
                PatientId = check.PatientId,
                CheckDate = DateOnly.Parse(check.CheckDateOld),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == check.SpecNameOld).SpecId
            };
            _context.TblPatientChecks.Attach(item);

            if (checkDate == checkDateOld && spec == specOld)
            {
                item.CheckDateNext = check.CheckDateNetx != null && check.CheckDateNetx?.Length != 0 ? DateOnly.Parse(check.CheckDateNetx) : null;
                _context.Entry(item).Property(e => e.CheckDateNext).IsModified = true;
                item.CheckDoctorId = _context.TblDoctors.First(e => e.DoctorLong == check.CheckDocName).DoctorId;
                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientChecks.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = check.PatientId,
                CheckDate = DateOnly.Parse(check.CheckDate),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == check.SpecName).SpecId,
                CheckDateNext = check.CheckDateNetx != null && check.CheckDateNetx?.Length != 0 ? DateOnly.Parse(check.CheckDateNetx) : null,
                CheckDoctorId = _context.TblDoctors.First( e => e.DoctorLong == check.CheckDocName).DoctorId
            };
            _context.TblPatientChecks.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelCheckOut")]
        [Authorize(Roles = "User")]
        public IActionResult DelCheckOut(int patientId, string date, string spec)
        {
            TblPatientCheckOut item = new()
            {
                PatientId = patientId,
                CheckDate = DateOnly.Parse(date),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == spec).SpecId
            };

            _context.TblPatientCheckOuts.Attach(item);
            _context.TblPatientCheckOuts.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCheckOut")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCheckOut(Check check)
        {
            TblPatientCheckOut item = new()
            {
                PatientId = check.PatientId,
                CheckDate = DateOnly.Parse(check.CheckDate),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == check.SpecName).SpecId,
                CheckDoctorId = _context.TblDoctors.First(e => e.DoctorLong == check.CheckDocName).DoctorId,
                CheckDateNext = check.CheckDateNetx != null && check.CheckDateNetx?.Length != 0 ? DateOnly.Parse(check.CheckDateNetx) : null
            };

            _context.TblPatientCheckOuts.Attach(item);
            _context.TblPatientCheckOuts.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateCheckOut")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCheckOut(Check check)
        {
            string checkDate = check.CheckDate,
                checkDateOld = check.CheckDateOld,
                spec = check.SpecName,
                specOld = check.SpecNameOld;

            TblPatientCheckOut item = new()
            {
                PatientId = check.PatientId,
                CheckDate = DateOnly.Parse(check.CheckDateOld),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == check.SpecNameOld).SpecId
            };
            _context.TblPatientCheckOuts.Attach(item);

            if (checkDate == checkDateOld && spec == specOld)
            {
                item.CheckDateNext = check.CheckDateNetx != null && check.CheckDateNetx?.Length != 0 ? DateOnly.Parse(check.CheckDateNetx) : null;
                _context.Entry(item).Property(e => e.CheckDateNext).IsModified = true;
                item.CheckDoctorId = _context.TblDoctors.First(e => e.DoctorLong == check.CheckDocName).DoctorId;
                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientCheckOuts.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = check.PatientId,
                CheckDate = DateOnly.Parse(check.CheckDate),
                CheckSpecId = _context.TblSpecs.First(e => e.SpecLong == check.SpecName).SpecId,
                CheckDateNext = check.CheckDateNetx != null && check.CheckDateNetx?.Length != 0 ? DateOnly.Parse(check.CheckDateNetx) : null,
                CheckDoctorId = _context.TblDoctors.First(e => e.DoctorLong == check.CheckDocName).DoctorId
            };
            _context.TblPatientCheckOuts.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        //[HttpDelete, Route("DelRegistry")]
        //[Authorize(Roles = "User")]
        //public IActionResult DelRegistry(int patientId, string date, string cab)
        //{
        //    TblPatientRegistry item = new()
        //    {
        //        PatientId = patientId,
        //        RegDate = DateOnly.Parse(date),
        //        RegCabinetId = _context.TblCabinets.First(e => e.CabinetLong == cab).CabinetId
        //    };

        //    _context.TblPatientRegistries.Attach(item);
        //    _context.TblPatientRegistries.Remove(item);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        //[HttpPost, Route("CreateRegistry")]
        //[Authorize(Roles = "User")]
        //public IActionResult CreateRegistry(RegistryIn registry)
        //{
        //    TblPatientRegistry item = new()
        //    {
        //        PatientId = registry.PatientId,
        //        RegDate = DateOnly.Parse(registry.RegDate),
        //        RegCabinetId = _context.TblCabinets.First(e => e.CabinetLong == registry.RegCab).CabinetId,
        //        RegTimeId = _context.TblRegTimes.FirstOrDefault( e => e.RegTimeLong == registry.RegTime)?.RegTimeId,
        //        RegDoctorId = _context.TblDoctors.FirstOrDefault( e => e.DoctorLong == registry.RegDoc)?.DoctorId,
        //        RegDescr = registry.RegCom,
        //        RegCheck = registry.RegCheck
        //    };

        //    _context.TblPatientRegistries.Attach(item);
        //    _context.TblPatientRegistries .Add(item);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        [HttpPost, Route("UpdateRegistry")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateRegistry(RegistryIn registry)
        {
            string regDate = registry.RegDate,
                regDateOld = registry.RegDateOld,
                regCab = registry.RegCab,
                regCabOld = registry.RegCabOld;

            TblPatientRegistry item = new()
            {
                PatientId = registry.PatientId,
                RegDate = DateOnly.Parse(registry.RegDateOld),
                RegCabinetId = _context.TblCabinets.First(e => e.CabinetLong == registry.RegCabOld).CabinetId
            };
            _context.TblPatientRegistries.Attach(item);

            if (regDate == regDateOld && regCab == regCabOld)
            {
                item.RegTimeId = _context.TblRegTimes.FirstOrDefault(e => e.RegTimeLong == registry.RegTime)?.RegTimeId;
                _context.Entry(item).Property(e => e.RegTimeId).IsModified = true;
                item.RegDoctorId = _context.TblDoctors.FirstOrDefault(e => e.DoctorLong == registry.RegDoc)?.DoctorId;
                _context.Entry(item).Property(e => e.RegDoctorId).IsModified = true;
                item.RegDescr = registry.RegCom;
                _context.Entry(item).Property(e => e.RegDescr).IsModified = true;
                item.RegCheck = registry.RegCheck;
                _context.Entry(item).Property(e => e.RegCheck).IsModified = true;
                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientRegistries.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = registry.PatientId,
                RegDate = DateOnly.Parse(registry.RegDate),
                RegCabinetId = _context.TblCabinets.First(e => e.CabinetLong == registry.RegCab).CabinetId,
                RegTimeId = _context.TblRegTimes.FirstOrDefault(e => e.RegTimeLong == registry.RegTime)?.RegTimeId,
                RegDoctorId = _context.TblDoctors.FirstOrDefault(e => e.DoctorLong == registry.RegDoc)?.DoctorId,
                RegDescr = registry.RegCom,
                RegCheck = registry.RegCheck
            };
            _context.TblPatientRegistries.Add(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}
