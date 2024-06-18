using HIVBackend.Data;
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
    public class PatientCardCovidController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardCovidController(HivContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<SubCovid> otherDiags = new();
            List<SubCovid> patDiags = new();
            List<Covid> covids = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            var patientOtherDiags = _context.TblSecDis.Where(e => e.PatientId == patientId)?.ToList();
            var patientPatDiags = _context.TblPatDiagnoses.Where(e => e.PatientId == patientId)?.ToList();
            var patientCovids = _context.TblCovids.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var item in patientOtherDiags)
            {
                otherDiags.Add(new()
                {
                    Id = item.IdSecDis,
                    NameShort = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseId == item.IdMkbSecDis)?.DieCourseShort,
                    NameLong = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseId == item.IdMkbSecDis)?.DieCourseLong,
                    Comm = item.Comment
                });
            }

            foreach (var item in patientPatDiags)
            {
                patDiags.Add(new()
                {
                    Id = item.IdPatDiagnos,
                    NameShort = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseId == item.IdMkbPatDiag)?.DieCourseShort,
                    NameLong = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseId == item.IdMkbPatDiag)?.DieCourseLong,
                    Comm = item.PatDiagCom
                });
            }

            foreach (var item in patientCovids)
            {
                covids.Add(new()
                {
                    IdCovid = item.IdCovid,
                    PeriodDesDate = item.DPeriodDes,
                    PositiveResCovidDate = item.DPositivResCovid,
                    NegativeResCovidDate = item.DNegativeResCovid,
                    HospDate = item.Hospitalization,
                    DischargeDate = item.DDischarge,
                    OutPatTreat = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.OutpatTreat)?.YNName,
                    DeathCovid = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.DeathCovid)?.YNName,
                    Orit = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.Orit)?.YNName,
                    Oxygen = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.Oxygen)?.YNName,
                    Avl = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.Alv)?.YNName,
                    ArterHyper = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.ArterHyper)?.YNName,
                    Deabetes = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.Diabetes)?.YNName,
                    CoronarySynd = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.CoronarySynd)?.YNName,
                    Hobl = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.Hobl)?.YNName,
                    BronhAstma = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.BronhAstma)?.YNName,
                    Cancer = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.Cancer)?.YNName,
                    KidneyDes = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.KidneyDes)?.YNName,
                    OutcomeHosp = _context.TblListOutHosps.FirstOrDefault(e => e.IdHosp == item.OutcomeHospitalization)?.HospName,
                    ClinVarCovid = _context.TblListClinVarCovids.FirstOrDefault(e => e.IdClinVarCovid == item.ClinVarOfCovid)?.ClinVarCovidName,
                    SeverityCovid = _context.TblListCourseCovids.FirstOrDefault(e => e.IdCourseCovid == item.SeverityCourseCovid)?.CourseCovidName,
                    CovidMKB10Short = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10Id == item.CovidMkb10)?.Mkb10ShortName,
                    CovidMKB10Long = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10Id == item.CovidMkb10)?.Mkb10LongName,
                    TubercuosisShort = _context.TblListMkbTuders.FirstOrDefault(e => e.IdTuder == item.Tuberculosis)?.TuberNameShort,
                    TubercuosisLong = _context.TblListMkbTuders.FirstOrDefault(e => e.IdTuder == item.Tuberculosis)?.TuberNameLong,
                    PneumoniaShort = _context.TblListMkbPneumonia.FirstOrDefault(e => e.IdPneumonia == item.Pneumonia)?.PneumoniaNameShort,
                    PneumoniaLong = _context.TblListMkbPneumonia.FirstOrDefault(e => e.IdPneumonia == item.Pneumonia)?.PneumoniaNameLong,
                    TypeAvl = _context.TblListAvlTypes.FirstOrDefault(e => e.IdTypeAvl == item.TypeAlv)?.TypeAvlName,
                    Commitment = _context.TblListCommitments.FirstOrDefault(e => e.IdCommitment == item.CommitmentId)?.CommitmentName,
                    Comm = item.Comment
                });
            }

            PatientCardCovid patientCardCovid = new();

            patientCardCovid.PatientId = patient.PatientId;
            patientCardCovid.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;

            patientCardCovid.ListYN = _context.TblListYns.Select(e => e.YNName).ToList();
            patientCardCovid.ListOutHosp = _context.TblListOutHosps.Select(e => e.HospName).ToList();
            patientCardCovid.ListClinVarCOVID = _context.TblListClinVarCovids.Select(e => e.ClinVarCovidName).ToList();
            patientCardCovid.ListCourseCOVID = _context.TblListCourseCovids.Select(e => e.CourseCovidName).ToList();
            patientCardCovid.ListMkb10COVIDShort = _context.TblListMkb10Covids.Select(e => e.Mkb10ShortName).ToList();
            patientCardCovid.ListMkb10COVIDLong = _context.TblListMkb10Covids.Select(e => e.Mkb10LongName).ToList();
            patientCardCovid.ListMkbTuderShort = _context.TblListMkbTuders.Select(e => e.TuberNameShort).ToList();
            patientCardCovid.ListMkbTuderLong = _context.TblListMkbTuders.Select(e => e.TuberNameLong).ToList(); ;
            patientCardCovid.ListMkbPneumoniaShort = _context.TblListMkbPneumonia.Select(e => e.PneumoniaNameShort).ToList();
            patientCardCovid.ListMkbPneumoniaLong = _context.TblListMkbPneumonia.Select(e => e.PneumoniaNameLong).ToList();
            patientCardCovid.ListCommitment = _context.TblListCommitments.Select(e => e.CommitmentName).ToList();
            patientCardCovid.ListAvlType = _context.TblListAvlTypes.Select(e => e.TypeAvlName).ToList();
            patientCardCovid.ListFullMKB10Short = _context.TblListFullMkb10s.Select(e => e.DieCourseShort).ToList();
            patientCardCovid.ListFullMKB10Long = _context.TblListFullMkb10s.Select(e => e.DieCourseLong).ToList();


            patientCardCovid.OtherDiags = otherDiags;
            patientCardCovid.PatDiags = patDiags;
            patientCardCovid.Covids = covids;

            return Ok(patientCardCovid);
        }

        [HttpDelete, Route("DelOtherDiag")]
        [Authorize(Roles = "User")]
        public IActionResult DelOtherDiag(int id)
        {
            TblSecDi item = new()
            {
                IdSecDis = id
            };

            _context.TblSecDis.Attach(item);
            _context.TblSecDis.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateOtherDiag")]
        [Authorize(Roles = "User")]
        public IActionResult CreateOtherDiag(SubCovidForm oDiag)
        {
            TblSecDi item = new()
            {
                PatientId = (int)oDiag.PatientId,
                IdMkbSecDis = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseShort == oDiag.NameShort)?.DieCourseId,
                Comment = oDiag.Comm
            };

            _context.TblSecDis.Attach(item);
            _context.TblSecDis.Add(item);
            _context.SaveChanges();
            _context.TblSecDis.Attach(item);
            return Ok(item.IdMkbSecDis);
        }

        [HttpPost, Route("UpdateOtherDiag")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateOtherDiag(SubCovidForm oDiag)
        {
            TblSecDi item = new()
            {
                IdSecDis = (int)oDiag.Id
            };
            _context.TblSecDis.Attach(item);

            item.Comment = oDiag.Comm;
            item.IdMkbSecDis = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseShort == oDiag.NameShort)?.DieCourseId;

            _context.Entry(item).Property(e => e.Comment).IsModified = true;
            _context.Entry(item).Property(e => e.IdMkbSecDis).IsModified = true;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelPatDiag")]
        [Authorize(Roles = "User")]
        public IActionResult DelPatDiag(int id)
        {
            TblPatDiagnosis item = new()
            {
                IdPatDiagnos = id
            };

            _context.TblPatDiagnoses.Attach(item);
            _context.TblPatDiagnoses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreatePatDiag")]
        [Authorize(Roles = "User")]
        public IActionResult CreatePatDiag(SubCovidForm pDiag)
        {
            TblPatDiagnosis item = new()
            {
                PatientId = (int)pDiag.PatientId,
                IdMkbPatDiag = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseShort == pDiag.NameShort)?.DieCourseId,
                PatDiagCom = pDiag.Comm
            };

            _context.TblPatDiagnoses.Attach(item);
            _context.TblPatDiagnoses.Add(item);
            _context.SaveChanges();
            _context.TblPatDiagnoses.Attach(item);
            return Ok(item.IdPatDiagnos);
        }

        [HttpPost, Route("UpdatePatDiag")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePatDiag(SubCovidForm pDiag)
        {
            TblPatDiagnosis item = new()
            {
                IdPatDiagnos = (int)pDiag.Id
            };
            _context.TblPatDiagnoses.Attach(item);

            item.PatDiagCom = pDiag.Comm;
            item.IdMkbPatDiag = _context.TblListFullMkb10s.FirstOrDefault(e => e.DieCourseShort == pDiag.NameShort)?.DieCourseId;

            _context.Entry(item).Property(e => e.PatDiagCom).IsModified = true;
            _context.Entry(item).Property(e => e.IdMkbPatDiag).IsModified = true;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelCovid")]
        [Authorize(Roles = "User")]
        public IActionResult DelCovid(int id)
        {
            TblCovid item = new()
            {
                IdCovid = id
            };

            _context.TblCovids.Attach(item);
            _context.TblCovids.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCovid")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCovid(CovidForm covid)
        {
            TblCovid item = new()
            {
                PatientId = covid.PatientId,
                DPeriodDes = covid.PeriodDesDate != null && covid.PeriodDesDate?.Length != 0 ? DateOnly.Parse(covid.PeriodDesDate) : null,
                DPositivResCovid = covid.PositiveResCovidDate != null && covid.PositiveResCovidDate?.Length != 0 ? DateOnly.Parse(covid.PositiveResCovidDate) : null,
                DNegativeResCovid = covid.NegativeResCovidDate != null && covid.NegativeResCovidDate?.Length != 0 ? DateOnly.Parse(covid.NegativeResCovidDate) : null,
                Hospitalization = covid.HospDate != null && covid.HospDate?.Length != 0 ? DateOnly.Parse(covid.HospDate) : null,
                DDischarge = covid.DischargeDate != null && covid.DischargeDate?.Length != 0 ? DateOnly.Parse(covid.DischargeDate) : null,
                OutpatTreat = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.OutPatTreat)?.IdYN,
                DeathCovid = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.DeathCovid)?.IdYN,
                Orit = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Orit)?.IdYN,
                Oxygen = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Oxygen)?.IdYN,
                Alv = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Avl)?.IdYN,
                ArterHyper = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.ArterHyper)?.IdYN,
                Diabetes = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Deabetes)?.IdYN,
                CoronarySynd = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.CoronarySynd)?.IdYN,
                Hobl = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Hobl)?.IdYN,
                BronhAstma = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.BronhAstma)?.IdYN,
                Cancer = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Cancer)?.IdYN,
                KidneyDes = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.KidneyDes)?.IdYN,
                OutcomeHospitalization = _context.TblListOutHosps.FirstOrDefault(e => e.HospName == covid.OutcomeHosp)?.IdHosp,
                ClinVarOfCovid = _context.TblListClinVarCovids.FirstOrDefault(e => e.ClinVarCovidName == covid.ClinVarCovid)?.IdClinVarCovid,
                SeverityCourseCovid = _context.TblListCourseCovids.FirstOrDefault(e => e.CourseCovidName == covid.SeverityCovid)?.IdCourseCovid,
                CovidMkb10 = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10ShortName == covid.CovidMKB10Short)?.Mkb10Id,
                Tuberculosis = _context.TblListMkbTuders.FirstOrDefault(e => e.TuberNameShort == covid.TubercuosisShort)?.IdTuder,
                Pneumonia = _context.TblListMkbPneumonia.FirstOrDefault(e => e.PneumoniaNameShort == covid.PneumoniaShort)?.IdPneumonia,
                TypeAlv = _context.TblListAvlTypes.FirstOrDefault(e => e.TypeAvlName == covid.TypeAvl)?.IdTypeAvl,
                CommitmentId = _context.TblListCommitments.FirstOrDefault(e => e.CommitmentName == covid.Commitment)?.IdCommitment,
                Comment = covid.Comm
            };

            _context.TblCovids.Attach(item);
            _context.TblCovids.Add(item);
            _context.SaveChanges();
            _context.TblCovids.Attach(item);
            return Ok(item.IdCovid);
        }

        [HttpPost, Route("UpdateCovid")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCovid(CovidForm covid)
        {
            TblCovid item = new()
            {
                IdCovid = (int)covid.IdCovid
            };
            _context.TblCovids.Attach(item);

            item.DPeriodDes = covid.PeriodDesDate != null && covid.PeriodDesDate?.Length != 0 ? DateOnly.Parse(covid.PeriodDesDate) : null;
            item.DPositivResCovid = covid.PositiveResCovidDate != null && covid.PositiveResCovidDate?.Length != 0 ? DateOnly.Parse(covid.PositiveResCovidDate) : null;
            item.DNegativeResCovid = covid.NegativeResCovidDate != null && covid.NegativeResCovidDate?.Length != 0 ? DateOnly.Parse(covid.NegativeResCovidDate) : null;
            item.Hospitalization = covid.HospDate != null && covid.HospDate?.Length != 0 ? DateOnly.Parse(covid.HospDate) : null;
            item.DDischarge = covid.DischargeDate != null && covid.DischargeDate?.Length != 0 ? DateOnly.Parse(covid.DischargeDate) : null;
            item.OutpatTreat = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.OutPatTreat)?.IdYN;
            item.DeathCovid = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.DeathCovid)?.IdYN;
            item.Orit = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Orit)?.IdYN;
            item.Oxygen = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Oxygen)?.IdYN;
            item.Alv = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Avl)?.IdYN;
            item.ArterHyper = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.ArterHyper)?.IdYN;
            item.Diabetes = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Deabetes)?.IdYN;
            item.CoronarySynd = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.CoronarySynd)?.IdYN;
            item.Hobl = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Hobl)?.IdYN;
            item.BronhAstma = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.BronhAstma)?.IdYN;
            item.Cancer = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.Cancer)?.IdYN;
            item.KidneyDes = _context.TblListYns.FirstOrDefault(e => e.YNName == covid.KidneyDes)?.IdYN;
            item.OutcomeHospitalization = _context.TblListOutHosps.FirstOrDefault(e => e.HospName == covid.OutcomeHosp)?.IdHosp;
            item.ClinVarOfCovid = _context.TblListClinVarCovids.FirstOrDefault(e => e.ClinVarCovidName == covid.ClinVarCovid)?.IdClinVarCovid;
            item.SeverityCourseCovid = _context.TblListCourseCovids.FirstOrDefault(e => e.CourseCovidName == covid.SeverityCovid)?.IdCourseCovid;
            item.CovidMkb10 = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10ShortName == covid.CovidMKB10Short)?.Mkb10Id;
            item.Tuberculosis = _context.TblListMkbTuders.FirstOrDefault(e => e.TuberNameShort == covid.TubercuosisShort)?.IdTuder;
            item.Pneumonia = _context.TblListMkbPneumonia.FirstOrDefault(e => e.PneumoniaNameShort == covid.PneumoniaShort)?.IdPneumonia;
            item.TypeAlv = _context.TblListAvlTypes.FirstOrDefault(e => e.TypeAvlName == covid.TypeAvl)?.IdTypeAvl;
            item.CommitmentId = _context.TblListCommitments.FirstOrDefault(e => e.CommitmentName == covid.Commitment)?.IdCommitment;
            item.Comment = covid.Comm;

            _context.Entry(item).Property(e => e.DPeriodDes).IsModified = true;
            _context.Entry(item).Property(e => e.DPositivResCovid).IsModified = true;
            _context.Entry(item).Property(e => e.DNegativeResCovid).IsModified = true;
            _context.Entry(item).Property(e => e.Hospitalization).IsModified = true;
            _context.Entry(item).Property(e => e.DDischarge).IsModified = true;
            _context.Entry(item).Property(e => e.OutpatTreat).IsModified = true;
            _context.Entry(item).Property(e => e.DeathCovid).IsModified = true;
            _context.Entry(item).Property(e => e.Orit).IsModified = true;
            _context.Entry(item).Property(e => e.Oxygen).IsModified = true;
            _context.Entry(item).Property(e => e.Alv).IsModified = true;
            _context.Entry(item).Property(e => e.ArterHyper).IsModified = true;
            _context.Entry(item).Property(e => e.Diabetes).IsModified = true;
            _context.Entry(item).Property(e => e.CoronarySynd).IsModified = true;
            _context.Entry(item).Property(e => e.Hobl).IsModified = true;
            _context.Entry(item).Property(e => e.BronhAstma).IsModified = true;
            _context.Entry(item).Property(e => e.Cancer).IsModified = true;
            _context.Entry(item).Property(e => e.KidneyDes).IsModified = true;
            _context.Entry(item).Property(e => e.OutcomeHospitalization).IsModified = true;
            _context.Entry(item).Property(e => e.ClinVarOfCovid).IsModified = true;
            _context.Entry(item).Property(e => e.SeverityCourseCovid).IsModified = true;
            _context.Entry(item).Property(e => e.CovidMkb10).IsModified = true;
            _context.Entry(item).Property(e => e.Tuberculosis).IsModified = true;
            _context.Entry(item).Property(e => e.Pneumonia).IsModified = true;
            _context.Entry(item).Property(e => e.TypeAlv).IsModified = true;
            _context.Entry(item).Property(e => e.CommitmentId).IsModified = true;
            _context.Entry(item).Property(e => e.Comment).IsModified = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
