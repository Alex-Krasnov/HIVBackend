using HIVBackend.Data;
using HIVBackend.Models.DBModels;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardTreatmentController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardTreatmentController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmCorrespIllnesses> correspIllnesses = new();
            List<FrmCureSchemas> cureSchemas = new();
            List<FrmHospResultRs> hospResultRs = new();
            List<FrmHepC> hepCs = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            List<TblPatientCorrespIllness>? patientCorrespIllness = _context.TblPatientCorrespIllnesses.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientCureSchema>? patientCureSchema = _context.TblPatientCureSchemas.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientHospResultR>? patientHospResultR = _context.TblPatientHospResultRs.Where(e => e.PatientId == patientId)?.ToList();
            List<TblHepC>? tblHepCs = _context.TblHepCs.Where(e => e.PatientId == patientId)?.ToList();


            foreach (var item in patientCorrespIllness)
            {
                correspIllnesses.Add(new()
                {
                    CorrespIllness = _context.TblCorrespIllnesses.First(e => e.CorrespIllnessId == item.CorrespIllnessId)?.CorrespIllnessLong,
                    CorrespIllnessDate = item.Datetime1
                });
            }
            foreach (var item in patientCureSchema)
            {
                cureSchemas.Add(new()
                {
                    CureSchemaName = _context.TblCureSchemas.FirstOrDefault(e => e.CureSchemaId == item.CureSchemaId)?.CureSchemaLong,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    SchemaComm = item.SchemaDescr,
                    CureChangeName = _context.TblCureChanges.FirstOrDefault(e => e.CureChangeId == item.CureChangeId)?.CureChangeLong,
                    ProtNum = item.ProtNum,
                    RangeTherapy = _context.TblRangeTherapies.FirstOrDefault(e => e.RangeTherapyId == item.RangeTherapyId)?.RangeTherapyLong,
                    Last = item.LastYn
                });
            }
            foreach (var item in patientHospResultR)
            {
                hospResultRs.Add(new()
                {
                    DateHospIn = item.DateHospIn,
                    LpuName = _context.TblLpus.FirstOrDefault(e => e.LpuId == item.LpuId)?.LpuLong,
                    HospCourseName = _context.TblHospCourses.FirstOrDefault(e => e.HospCourseId == item.HospCourseId)?.HospCourseLong,
                    DateHospOut = item.DateHospOut,
                    HospResult = _context.TblHospResults.FirstOrDefault(e => e.HospResultId == item.HospResultId)?.HospResultLong
                });
            }
            foreach (var item in tblHepCs)
            {
                hepCs.Add(new()
                {
                    Id = item.Id,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd,
                    Descr = item.Descr,
                    DateCreate = item.DateCreate
                });
            }

            PatientCardTreatment patientCardTreatment = new();

            patientCardTreatment.PatientId = patient.PatientId;
            patientCardTreatment.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardTreatment.StageName = _context.TblDiagnoses.FirstOrDefault(e => e.DiagnosisId == patient.DiagnosisId)?.DiagnosisLong;
            patientCardTreatment.StageCom = patient.StageDescr;
            patientCardTreatment.PatientCom = patient.PatientDescr;
            patientCardTreatment.InvalidName = _context.TblInvalids.FirstOrDefault(e => e.InvalidId == patient.InvalidId)?.InvalidLong;
            patientCardTreatment.HepBdate = patient.HepBDate;
            patientCardTreatment.HepBDescr = patient.HepBDescr;

            patientCardTreatment.ListInvalids = _context.TblInvalids.Select(e => e.InvalidLong)?.ToList();
            patientCardTreatment.ListCorrespIllness = _context.TblCorrespIllnesses.Select(e => e.CorrespIllnessLong)?.ToList();
            patientCardTreatment.ListCureSchemas = _context.TblCureSchemas.Select(e => e.CureSchemaLong)?.ToList();
            patientCardTreatment.ListCureChanges = _context.TblCureChanges.Select(e => e.CureChangeLong)?.ToList();
            patientCardTreatment.ListRangeTherapy = _context.TblRangeTherapies.Select(e => e.RangeTherapyLong)?.ToList();
            patientCardTreatment.ListLpus = _context.TblLpus.Select(e => e.LpuLong)?.ToList();
            patientCardTreatment.ListHospCourses = _context.TblHospCourses.Select(e => e.HospCourseLong)?.ToList();
            patientCardTreatment.ListHospResults = _context.TblHospResults.Select(e => e.HospResultLong)?.ToList();

            patientCardTreatment.CorrespIllnesses = correspIllnesses;
            patientCardTreatment.CureSchemas = cureSchemas.OrderBy(e => e.StartDate).ToList();
            patientCardTreatment.HospResultRs = hospResultRs;
            patientCardTreatment.hepCs = hepCs;

            return Ok(patientCardTreatment);
        }

        [HttpDelete, Route("DelCorrepIllness")]
        [Authorize(Roles = "User")]
        public IActionResult DelCorrepIllness(int patientId, string name)
        {
            TblPatientCorrespIllness item = new()
            {
                PatientId = patientId,
                CorrespIllnessId = _context.TblCorrespIllnesses.First(e => e.CorrespIllnessLong == name).CorrespIllnessId
            };

            _context.TblPatientCorrespIllnesses.Attach(item);
            _context.TblPatientCorrespIllnesses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCorrepIllness")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCorrepIllness(CorrespIllness correspIllness)
        {
            TblPatientCorrespIllness item = new()
            {
                PatientId = correspIllness.PatientId,
                CorrespIllnessId = _context.TblCorrespIllnesses.First(e => e.CorrespIllnessLong == correspIllness.CorrespIllnessName).CorrespIllnessId,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblPatientCorrespIllnesses.Attach(item);
            _context.TblPatientCorrespIllnesses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateCorrepIllness")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCorrepIllness(CorrespIllness correspIllness)
        {
            TblPatientCorrespIllness item = new()
            {
                PatientId = correspIllness.PatientId,
                CorrespIllnessId = _context.TblCorrespIllnesses.First(e => e.CorrespIllnessLong == correspIllness.CorrespIllnessNameOld).CorrespIllnessId
            };

            _context.TblPatientCorrespIllnesses.Attach(item);
            _context.TblPatientCorrespIllnesses.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = correspIllness.PatientId,
                CorrespIllnessId = _context.TblCorrespIllnesses.First(e => e.CorrespIllnessLong == correspIllness.CorrespIllnessName).CorrespIllnessId,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };
            _context.TblPatientCorrespIllnesses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("DelCureSchema")]
        [Authorize(Roles = "User")]
        public IActionResult DelCureSchema(CureSchema cureSchema)
        {
            TblPatientCureSchema item = new()
            {
                PatientId = cureSchema.PatientId,
                CureSchemaId = _context.TblCureSchemas.First(e => e.CureSchemaLong == cureSchema.CureSchemaName).CureSchemaId,
                StartDate = DateOnly.Parse(cureSchema.StartDate)
            };

            _context.TblPatientCureSchemas.Attach(item);
            _context.TblPatientCureSchemas.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCureSchema")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCureSchema(CureSchema cureSchema)
        {
            TblPatientCureSchema item = new()
            {
                PatientId = cureSchema.PatientId,
                CureSchemaId = _context.TblCureSchemas.First(e => e.CureSchemaLong == cureSchema.CureSchemaName).CureSchemaId,
                StartDate = DateOnly.Parse(cureSchema.StartDate),
                EndDate = cureSchema.EndDate != null && cureSchema.EndDate?.Length != 0 ? DateOnly.Parse(cureSchema.EndDate) : null,
                SchemaDescr = cureSchema.SchemaCom,
                CureChangeId = _context.TblCureChanges.FirstOrDefault(e => e.CureChangeLong == cureSchema.CureChangeName)?.CureChangeId,
                ProtNum = cureSchema.ProtNum,
                RangeTherapyId = _context.TblRangeTherapies.FirstOrDefault(e => e.RangeTherapyLong == cureSchema.RangeTherapyName)?.RangeTherapyId
            };

            _context.TblPatientCureSchemas.Attach(item);
            _context.TblPatientCureSchemas.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateCureSchema")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCureSchema(CureSchema cureSchema)
        {
            int cureSchemaId = _context.TblCureSchemas.First(e => e.CureSchemaLong == cureSchema.CureSchemaName).CureSchemaId,
                cureSchemaIdOld = _context.TblCureSchemas.First(e => e.CureSchemaLong == cureSchema.CureSchemaNameOld).CureSchemaId;
            DateOnly startDate = DateOnly.Parse(cureSchema.StartDate),
                 startDateOld = DateOnly.Parse(cureSchema.StartDateOld);

            TblPatientCureSchema item = _context.TblPatientCureSchemas
                .First(e => e.PatientId == cureSchema.PatientId && e.CureSchemaId == cureSchemaIdOld && startDate == startDateOld);

            if (cureSchemaId == cureSchemaIdOld && startDate == startDateOld)
            {
                item.EndDate = cureSchema.EndDate != null && cureSchema.EndDate?.Length != 0 ? DateOnly.Parse(cureSchema.EndDate) : null;
                item.SchemaDescr = cureSchema.SchemaCom;
                item.CureChangeId = _context.TblCureChanges.FirstOrDefault(e => e.CureChangeLong == cureSchema.CureChangeName)?.CureChangeId;
                item.ProtNum = cureSchema.ProtNum;
                item.LastYn = cureSchema.Last;
                item.RangeTherapyId = _context.TblRangeTherapies.FirstOrDefault(e => e.RangeTherapyLong == cureSchema.RangeTherapyName)?.RangeTherapyId;
                item.User1 = User.Identity?.Name;
                item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);
                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientCureSchemas.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = cureSchema.PatientId,
                CureSchemaId = cureSchemaId,
                StartDate = startDate,
                EndDate = cureSchema.EndDate != null && cureSchema.EndDate?.Length != 0 ? DateOnly.Parse(cureSchema.EndDate) : null,
                SchemaDescr = cureSchema.SchemaCom,
                CureChangeId = _context.TblCureChanges.FirstOrDefault(e => e.CureChangeLong == cureSchema.CureChangeName)?.CureChangeId,
                ProtNum = cureSchema.ProtNum,
                LastYn = cureSchema.Last,
                RangeTherapyId = _context.TblRangeTherapies.FirstOrDefault(e => e.RangeTherapyLong == cureSchema.RangeTherapyName)?.RangeTherapyId,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };
            _context.TblPatientCureSchemas.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelHospResult")]
        [Authorize(Roles = "User")]
        public IActionResult DelHospResult(int patientId, string name, string date)
        {
            TblPatientHospResultR item = new()
            {
                PatientId = patientId,
                LpuId = _context.TblLpus.First(e => e.LpuLong == name).LpuId,
                DateHospIn = DateOnly.Parse(date)
            };

            _context.TblPatientHospResultRs.Attach(item);
            _context.TblPatientHospResultRs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateHospResult")]
        [Authorize(Roles = "User")]
        public IActionResult CreateHospResult(HospResult hospResult)
        {
            TblPatientHospResultR item = new()
            {
                PatientId = hospResult.PatientId,
                LpuId = _context.TblLpus.First(e => e.LpuLong == hospResult.LpuName).LpuId,
                DateHospIn = DateOnly.Parse(hospResult.DateHospIn),
                HospCourseId = _context.TblHospCourses.FirstOrDefault(e => e.HospCourseLong == hospResult.HospCourseName)?.HospCourseId,
                DateHospOut = hospResult.DateHospOut != null && hospResult.DateHospOut?.Length != 0 ? DateOnly.Parse(hospResult.DateHospOut) : null,
                HospResultId = _context.TblHospResults.FirstOrDefault(e => e.HospResultLong == hospResult.HospResultName)?.HospResultId,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblPatientHospResultRs.Attach(item);
            _context.TblPatientHospResultRs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateHospResult")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateHospResult(HospResult hospResult)
        {
            int lpuId = _context.TblLpus.First(e => e.LpuLong == hospResult.LpuName).LpuId,
                lpuIdOld = _context.TblLpus.First(e => e.LpuLong == hospResult.LpuNameOld).LpuId;
            DateOnly dateHospIn = DateOnly.Parse(hospResult.DateHospIn),
                 dateHospInOld = DateOnly.Parse(hospResult.DateHospInOld);

            TblPatientHospResultR item = new()
            {
                PatientId = hospResult.PatientId,
                LpuId = lpuIdOld,
                DateHospIn = dateHospInOld
            };
            _context.TblPatientHospResultRs.Attach(item);

            if (lpuId == lpuIdOld && dateHospIn == dateHospInOld)
            {
                item.DateHospOut = hospResult.DateHospOut != null && hospResult.DateHospOut?.Length != 0 ? DateOnly.Parse(hospResult.DateHospOut) : null;
                item.HospResultId = _context.TblHospResults.FirstOrDefault(e => e.HospResultLong == hospResult.HospResultName)?.HospResultId;
                item.HospCourseId = _context.TblHospCourses.FirstOrDefault(e => e.HospCourseLong == hospResult.HospCourseName)?.HospCourseId;
                //item.User1 = ;
                item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientHospResultRs.Remove(item);
            _context.SaveChanges();

            item = new()
            {
                PatientId = hospResult.PatientId,
                LpuId = lpuId,
                DateHospIn = dateHospIn,
                DateHospOut = hospResult.DateHospOut != null && hospResult.DateHospOut?.Length != 0 ? DateOnly.Parse(hospResult.DateHospOut) : null,
                HospResultId = _context.TblHospResults.FirstOrDefault(e => e.HospResultLong == hospResult.HospResultName)?.HospResultId,
                HospCourseId = _context.TblHospCourses.FirstOrDefault(e => e.HospCourseLong == hospResult.HospCourseName)?.HospCourseId
            };

            _context.TblPatientHospResultRs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelHepC")]
        [Authorize(Roles = "User")]
        public IActionResult DelHepC(int Id)
        {
            var item = _context.TblHepCs.First(e => e.Id == Id);
            _context.TblHepCs.Attach(item);
            _context.TblHepCs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateHepC")]
        [Authorize(Roles = "User")]
        public IActionResult CreateHepC(HepC hepC)
        {
            var maxId = _context.TblHepCs.Max(e => e.Id);
            TblHepC item = new()
            {
                Id = maxId + 1,
                PatientId = hepC.PatientId,
                DateStart = hepC.DateStart,
                DateEnd = hepC.DateEnd,
                Descr = hepC.Descr,
                User = User.Identity?.Name,
                DateCreate = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblHepCs.Attach(item);
            _context.TblHepCs.Add(item);
            _context.SaveChanges();
            return Ok(maxId + 1);
        }

        [HttpPost, Route("UpdateHepC")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateHepC(HepC hepC)
        {
            var item = _context.TblHepCs.First(e => e.Id == hepC.Id);

            item.DateStart = hepC.DateStart;
            _context.Entry(item).Property(e => e.DateStart).IsModified = true;
            item.DateEnd = hepC.DateEnd;
            _context.Entry(item).Property(e => e.DateEnd).IsModified = true;
            item.Descr = hepC.Descr;
            _context.Entry(item).Property(e => e.Descr).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdatePatient")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePatient(PatientCardTreatmentForm patient)
        {
            TblPatientCard item = new()
            {
                PatientId = patient.PatientId
            };
            _context.TblPatientCards.Attach(item);

            item.PatientDescr = patient.Com;
            _context.Entry(item).Property(e => e.PatientDescr).IsModified = true;
            item.StageDescr = patient.StageCom;
            _context.Entry(item).Property(e => e.StageDescr).IsModified = true;
            item.StageDescr = patient.StageCom;
            _context.Entry(item).Property(e => e.StageDescr).IsModified = true;
            item.HepBDate = patient.HepBDate;
            _context.Entry(item).Property(e => e.HepBDate).IsModified = true;
            item.HepBDescr = patient.HepBDescr;
            _context.Entry(item).Property(e => e.HepBDescr).IsModified = true;

            if (patient.Invalid != null)
                if (patient.Invalid.Length != 0)
                {
                    var id = _context.TblInvalids.First(e => e.InvalidLong == patient.Invalid)?.InvalidId;
                    if (id != item.InvalidId)
                        item.InvalidId = id;
                }
                else
                {
                    item.InvalidId = null;
                    _context.Entry(item).Property(e => e.InvalidId).IsModified = true;
                }

            _context.SaveChanges();
            return Ok();
        }
    }
}
