using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Data;
using HIVBackend.Models.OutputModel;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientCardController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmBlot> blots = new();
            List<FrmSecondDeseases> secondDeseases = new();
            List<FrmStage> stages = new();

            TblPatientCard a = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (a is null)
                return BadRequest("Пациент не найден");

            List<TblPatientBlot>? patientBlots = _context.TblPatientBlots.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientShowIllness>? patientSecondDeseases = _context.TblPatientShowIllnesses.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientDiagnosis>? patientStages = _context.TblPatientDiagnoses.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var pBlot in patientBlots)
            {
                blots.Add(
                    new(){
                        BlotId = pBlot.BlotId,
                        BlotNo = pBlot.BlotNo,
                        BlotDate = pBlot.BlotDate,
                        BlotRes = _context.TblIbResults.FirstOrDefault(e => e.IbResultId == pBlot.IbResultId)?.IbResultShort,
                        CheckPlace = _context.TblCheckPlaces.FirstOrDefault(e => e.CheckPlaceId == pBlot.CheckPlaceId)?.CheckPlaceLong,
                        First = pBlot.First1,
                        Last = pBlot.Last1,
                        Ifa = pBlot.FlgIfa,
                        InputDate = pBlot.Datetime1
                    });
            }

            foreach (var pDesease in patientSecondDeseases)
            {
                secondDeseases.Add(
                    new()
                    {
                        StartDate = pDesease.StartDate,
                        EndDate = pDesease.EndDate,
                        Deseas = _context.TblShowIllnesses.FirstOrDefault(e => e.ShowIllnessId == pDesease.ShowIllnessId)?.ShowIllnessLong
                    });
            }

            foreach (var pStages in patientStages)
            {
                stages.Add(
                    new()
                    {
                    StageDate = pStages.DiagnosisDefDate,
                    Stage = _context.TblDiagnoses.FirstOrDefault(e => e.DiagnosisId == pStages.DiagnosisId)?.DiagnosisLong
                    });
            }

            PatientCardMain patientCardMain = new();

            patientCardMain.PatientId = a.PatientId;
            patientCardMain.InputDate = a.InputDate;
            patientCardMain.FamilyName = a.FamilyName;
            patientCardMain.FirstName = a.FirstName;
            patientCardMain.ThirdName = a.ThirdName;
            patientCardMain.BirthDate = a.BirthDate;
            patientCardMain.Sex = _context.TblSexes.FirstOrDefault(e => e.SexId == a.SexId)?.SexShort;
            patientCardMain.RegOnDate = a.RegOnDate;
            patientCardMain.RegOffDate = a.RegOffDate;
            patientCardMain.RegOffReason = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == a.RegOffReason)?.InfectCourseLong;
            patientCardMain.UnrzFr = a.UnrzFr1;
            patientCardMain.Region = _context.TblRegions.FirstOrDefault(e => e.RegionId == a.RegionId)?.RegionLong;
            patientCardMain.CityName = a.CityName;
            patientCardMain.LocationName = a.LocationName;
            patientCardMain.Phone = a.AddrInd;
            patientCardMain.AddrStreat = a.AddrStreet;
            patientCardMain.AddrExt = a.AddrExt;
            patientCardMain.AddrHouse = a.AddrHouse;
            patientCardMain.AddrFlat = a.AddrFlat;
            patientCardMain.RegionFact = _context.TblRegions.FirstOrDefault(e => e.RegionId == a.FactRegionId)?.RegionLong;
            patientCardMain.CityNameFact = a.FactCityName;
            patientCardMain.LocationNameFact = a.FactLocationName;
            patientCardMain.IndexFact = a.FactAddrInd;
            patientCardMain.AddrStreatFact = a.FactAddrStreet;
            patientCardMain.AddrExtFact = a.FactAddrExt;
            patientCardMain.AddrHouseFact = a.FactAddrHouse;
            patientCardMain.AddrFlatFact = a.FactAddrFlat;
            patientCardMain.DtRegBeg = a.DtRegBeg;
            patientCardMain.DtRefEnd = a.DtRegEnd;
            patientCardMain.Country = _context.TblCountries.FirstOrDefault(e => e.CountryId == a.CountryId)?.CountryLong;
            patientCardMain.Comm = a.AddrName;
            patientCardMain.HeightOld = a.HeightOld;
            patientCardMain.WeightOld = a.WeightOld;
            patientCardMain.PlaceCheck = _context.TblCheckPlaces.FirstOrDefault(e => e.CheckPlaceId == a.PlaceCheckId)?.CheckPlaceLong;
            patientCardMain.CodeMKB10 = _context.TblCodeMkb10s.FirstOrDefault(e => e.CodeMkb10Id == a.CodeMkb10Id)?.CodeMkb10Long;
            patientCardMain.CheckCourseShort = _context.TblCheckCourses.FirstOrDefault(e => e.CheckCourseId == a.CheckCourseId)?.CheckCourseShort;
            patientCardMain.CheckCourseLong = _context.TblCheckCourses.FirstOrDefault(e => e.CheckCourseId == a.CheckCourseId)?.CheckCourseLong;
            patientCardMain.InfectCourseShort = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == a.InfectCourseId)?.InfectCourseShort;
            patientCardMain.InfectCourseLong = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == a.InfectCourseId)?.InfectCourseLong;
            patientCardMain.DieCourseShort = _context.TblDieCourses.FirstOrDefault(e => e.DieCourseId == a.DieCourseId)?.DieCourseShort;
            patientCardMain.DieCourseLong = _context.TblDieCourses.FirstOrDefault(e => e.DieCourseId == a.DieCourseId)?.DieCourseLong;
            patientCardMain.CardNo = a.CardNo;
            patientCardMain.VulnerableGroup = _context.TblListVulnerableGroups.FirstOrDefault(e => e.VulnerableGroupId == a.VulnerableGroupId)?.VulnerableGroupName;
            patientCardMain.RegOn = true;
            patientCardMain.HeadPhysician = a.FlgHeadPhysician;
            patientCardMain.ZamMedPart = a.FlgZamMedPart;
            patientCardMain.TransfArea = true;
            patientCardMain.TransfAreaDate = a.TransfAreaDate;
            patientCardMain.TransfFederDate = a.TransfFederDate;
            patientCardMain.UfsinDate = a.UfsinDate;
            patientCardMain.DieInputDate = a.DieDateInput;
            patientCardMain.DieDate = a.DieDate;
            patientCardMain.DieAidsDate = a.DieAidsDate;
            patientCardMain.FioChange = a.FioChange;
            patientCardMain.Snils = a.Snils;
            patientCardMain.ARVT = _context.TblArvts.FirstOrDefault(e => e.ArvtId == a.ArvtId)?.ArvtLong;
            patientCardMain.Invalid = _context.TblInvalids.FirstOrDefault(e => e.InvalidId == a.InvalidId)?.InvalidLong;
            patientCardMain.Archile = a.SnilsFed;
            patientCardMain.CodeWord = a.Codeword;

            patientCardMain.ListSex = _context.TblSexes.Select(e => e.SexShort)?.ToList();
            patientCardMain.ListRegOffReason = _context.TblInfectCourses
                .Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong)?.ToList();
            patientCardMain.ListRegion = _context.TblRegions.Select(e => e.RegionLong)?.ToList();
            patientCardMain.ListCountry = _context.TblCountries.Select(e => e.CountryLong)?.ToList();
            patientCardMain.ListPlaceCheck = _context.TblListPlaceChecks.Select(e => e.PlaceCheckName)?.ToList();
            patientCardMain.ListCodeMKB = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long)?.ToList();
            patientCardMain.ListCheckCourseShort = _context.TblCheckCourses.Select(e => e.CheckCourseShort)?.ToList();
            patientCardMain.ListCheckCourseLong = _context.TblCheckCourses.Select(e => e.CheckCourseLong)?.ToList();
            patientCardMain.ListInfectCourseShort = _context.TblInfectCourses.Select(e => e.InfectCourseShort)?.ToList();
            patientCardMain.ListInfectCourseLong = _context.TblInfectCourses.Select(e => e.InfectCourseLong)?.ToList();
            patientCardMain.ListDieCourseShort = _context.TblDieCourses.Select(e => e.DieCourseShort)?.ToList();
            patientCardMain.ListDieCourseLong = _context.TblDieCourses.Select(e => e.DieCourseLong)?.ToList();
            patientCardMain.ListVulnerableGroup = _context.TblListVulnerableGroups.Select(e => e.VulnerableGroupName)?.ToList();
            patientCardMain.ListARVT = _context.TblArvts.Select(e => e.ArvtShort)?.ToList();
            patientCardMain.ListInvalid = _context.TblInvalids.Select(e => e.InvalidLong)?.ToList();
            patientCardMain.ListCheckPlace = _context.TblCheckPlaces.Select(e => e.CheckPlaceLong)?.ToList();
            patientCardMain.ListRes = _context.TblIbResults.Select(e => e.IbResultShort)?.ToList();
            patientCardMain.ListDesease = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong)?.ToList();
            patientCardMain.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong)?.ToList();

            patientCardMain.Blots = blots;
            patientCardMain.SecondDeseases = secondDeseases;
            patientCardMain.Stages = stages;

            return Ok(patientCardMain);
        }

        [HttpDelete, Route("DelBlot")]
        [Authorize(Roles = "User")]
        public IActionResult DelBlot(int patientId, int blotId)
        {
            TblPatientBlot item = new() { PatientId = patientId, BlotId = blotId };

            _context.TblPatientBlots.Attach(item);
            _context.TblPatientBlots.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateBlot")]
        [Authorize(Roles = "User")]
        public IActionResult CreateBlot(Blot blot)
        {
            TblPatientBlot item = new()
            {
                PatientId = blot.PatientId,
                BlotId = blot.BlotId,
                BlotNo = blot.BlotNo,
                BlotDate = DateOnly.Parse(blot.BlotDate),
                IbResultId = _context.TblIbResults.First(e => e.IbResultShort == blot.IbResultId).IbResultId,
                CheckPlaceId = _context.TblCheckPlaces.First(e => e.CheckPlaceLong == blot.CheckPlaceId).CheckPlaceId,
                First1 = blot.First1,
                Last1 = blot.Last1,
                FlgIfa = blot.FlgIfa,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblPatientBlots.Attach(item);
            _context.TblPatientBlots.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateBlot")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateBlot(Blot blot)
        {
            TblPatientBlot item = new()
            {
                PatientId = blot.PatientId,
                BlotId = (int)blot.BlotIdOld
            };

            _context.TblPatientBlots.Attach(item);
            _context.TblPatientBlots.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = blot.PatientId,
                BlotId = blot.BlotId,
                BlotNo = blot.BlotNo,
                BlotDate = DateOnly.Parse(blot.BlotDate),
                IbResultId = _context.TblIbResults.First(e => e.IbResultShort == blot.IbResultId).IbResultId,
                CheckPlaceId = _context.TblCheckPlaces.First(e => e.CheckPlaceLong == blot.CheckPlaceId).CheckPlaceId,
                First1 = blot.First1,
                Last1 = blot.Last1,
                FlgIfa = blot.FlgIfa,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };
            _context.TblPatientBlots.Add(item);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete, Route("DelStage")]
        [Authorize(Roles = "User")]
        public IActionResult DelStage(int patientId, string date)
        {
            TblPatientDiagnosis item = new() { PatientId = patientId, DiagnosisDefDate = DateOnly.Parse(date) };

            _context.TblPatientDiagnoses.Attach(item);
            _context.TblPatientDiagnoses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateStage")]
        [Authorize(Roles = "User")]
        public IActionResult CreateStage(Stage stage)
        {
            TblPatientDiagnosis item = new()
            {
                PatientId = stage.PatientId,
                DiagnosisDefDate = DateOnly.Parse(stage.StageDate),
                DiagnosisId = _context.TblDiagnoses.First(e => e.DiagnosisLong == stage.StageName).DiagnosisId
            };

            _context.TblPatientDiagnoses.Attach(item);
            _context.TblPatientDiagnoses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateStage")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateStage(Stage stage)
        {
            TblPatientDiagnosis item = new()
            {
                PatientId = stage.PatientId,
                DiagnosisDefDate = DateOnly.Parse(stage.StageDateOld)
            };

            _context.TblPatientDiagnoses.Attach(item);
            _context.TblPatientDiagnoses.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = stage.PatientId,
                DiagnosisDefDate = DateOnly.Parse(stage.StageDate),
                DiagnosisId = _context.TblDiagnoses.First(e => e.DiagnosisLong == stage.StageName).DiagnosisId
            };
            _context.TblPatientDiagnoses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelSecondDeseases")]
        [Authorize(Roles = "User")]
        public IActionResult DelSecondDeseases(int patientId, string startDate, string deseas)
        {
            TblPatientShowIllness item = new()
            {
                PatientId = patientId,
                StartDate = DateOnly.Parse(startDate),
                ShowIllnessId = _context.TblShowIllnesses.First(e => e.ShowIllnessLong == deseas).ShowIllnessId
            };

            _context.TblPatientShowIllnesses.Attach(item);
            _context.TblPatientShowIllnesses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateSecondDeseases")]
        [Authorize(Roles = "User")]
        public IActionResult CreateSecondDeseases(SecondDesease desease)
        {
            DateOnly? endDate = null;
            try { endDate = DateOnly.Parse(desease.EndDate); } 
            catch { endDate = null; }
            TblPatientShowIllness item = new()
            {
                PatientId = desease.PatientId,
                StartDate = DateOnly.Parse(desease.StartDate),
                EndDate = endDate,
                ShowIllnessId = _context.TblShowIllnesses.First(e => e.ShowIllnessLong == desease.Deseas).ShowIllnessId
            };

            _context.TblPatientShowIllnesses.Attach(item);
            _context.TblPatientShowIllnesses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateSecondDeseases")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateSecondDeseases(SecondDesease desease)
        {
            DateOnly? endDate = null;
            try { endDate = DateOnly.Parse(desease.EndDate); } catch { }
            TblPatientShowIllness item = new()
            {
                PatientId = desease.PatientId,
                StartDate = DateOnly.Parse(desease.StartDateOld),
                ShowIllnessId = _context.TblShowIllnesses.First(e => e.ShowIllnessLong == desease.DeseasOld).ShowIllnessId
            };

            _context.TblPatientShowIllnesses.Attach(item);
            _context.TblPatientShowIllnesses.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = desease.PatientId,
                StartDate = DateOnly.Parse(desease.StartDate),
                ShowIllnessId = _context.TblShowIllnesses.First(e => e.ShowIllnessLong == desease.Deseas).ShowIllnessId,
                EndDate = endDate
            };
            _context.TblPatientShowIllnesses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelPatientPatient")]
        [Authorize(Roles = "User")]
        public IActionResult DelPatientPatient(int patientId)
        {
            TblPatientCard item = new(){ PatientId = patientId };

            _context.TblPatientCards.Attach(item);
            _context.TblPatientCards.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}
