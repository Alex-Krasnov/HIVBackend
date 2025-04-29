using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HIVBackend.Controllers.PatientCard
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
        public IActionResult Get(int? patientId)
        {
            PatientCardMain patientCardMain = new();

            List<FrmBlot> blots = new();
            List<FrmSecondDeseases> secondDeseases = new();
            List<FrmStage> stages = new();

            patientCardMain.ListSex = _context.TblSexes.Select(e => e.SexShort)?.ToList();
            patientCardMain.ListRegOffReason = _context.TblInfectCourses
                .Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong)?.ToList();
            patientCardMain.ListRegion = _context.TblRegions.Select(e => e.RegionLong)?.ToList();
            patientCardMain.ListCountry = _context.TblCountries.Select(e => e.CountryLong)?.ToList();
            patientCardMain.ListPlaceCheck = _context.TblListPlaceChecks.Select(e => e.PlaceCheckName)?.ToList();
            patientCardMain.ListCodeMKB = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long)?.ToList();
            patientCardMain.ListCheckCourseShort = _context.TblCheckCourses.Select(e => e.CheckCourseShort)?.ToList();
            patientCardMain.ListCheckCourseLong = _context.TblCheckCourses.Select(e => e.CheckCourseLong)?.ToList();
            patientCardMain.ListInfectCourseShort = _context.TblInfectCourses.Where(e => e.InfectCourseShort != null).Select(e => e.InfectCourseShort)?.ToList();
            patientCardMain.ListInfectCourseLong = _context.TblInfectCourses.Where(e => e.InfectCourseShort != null).Select(e => e.InfectCourseLong)?.ToList();
            patientCardMain.ListDieCourseLong = _context.TblTempDieCureMkb10lists.Select(e => new Selector2Col { Short = e.DieCourseShort, Long = e.DieCourseLong })?.ToList();
            patientCardMain.ListVulnerableGroup = _context.TblListVulnerableGroups.Select(e => e.VulnerableGroupName)?.ToList();
            patientCardMain.ListARVT = _context.TblArvts.Select(e => e.ArvtLong)?.ToList();
            patientCardMain.ListInvalid = _context.TblInvalids.Select(e => e.InvalidLong)?.ToList();
            patientCardMain.ListCheckPlace = _context.TblCheckPlaces.Select(e => e.CheckPlaceLong)?.ToList();
            patientCardMain.ListRes = _context.TblIbResults.Select(e => e.IbResultShort)?.ToList();
            patientCardMain.ListDesease = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong)?.ToList();
            patientCardMain.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong)?.ToList();
            patientCardMain.ListReferenceMo = _context.TblListReferenceMos.Select(e => e.ReferenceMoName).ToList();

            patientCardMain.Blots = blots;
            patientCardMain.SecondDeseases = secondDeseases;
            patientCardMain.Stages = stages;

            if (patientId == null)
            {
                return Ok(patientCardMain);
            }

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            List<TblPatientBlot>? patientBlots = _context.TblPatientBlots.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientShowIllness>? patientSecondDeseases = _context.TblPatientShowIllnesses.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientDiagnosis>? patientStages = _context.TblPatientDiagnoses.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var pBlot in patientBlots)
            {
                blots.Add(
                    new()
                    {
                        BlotId = pBlot.BlotId,
                        BlotNo = pBlot.BlotNo,
                        BlotDate = pBlot.BlotDate,
                        BlotRes = _context.TblIbResults.FirstOrDefault(e => e.IbResultId == pBlot.IbResultId)?.IbResultShort,
                        CheckPlace = _context.TblCheckPlaces.FirstOrDefault(e => e.CheckPlaceId == pBlot.CheckPlaceId)?.CheckPlaceLong,
                        First = pBlot.First1,
                        Last = pBlot.Last1,
                        Ifa = pBlot.FlgIfa,
                        InputDate = pBlot.Datetime1,
                        ReferenceMo = _context.TblListReferenceMos.FirstOrDefault(e => e.ReferenceMoId == pBlot.ReferenceMoId)?.ReferenceMoName
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


            patientCardMain.PatientId = patient.PatientId;
            patientCardMain.InputDate = patient.InputDate;
            patientCardMain.FamilyName = patient.FamilyName;
            patientCardMain.FirstName = patient.FirstName;
            patientCardMain.ThirdName = patient.ThirdName;
            patientCardMain.BirthDate = patient.BirthDate;
            patientCardMain.Sex = _context.TblSexes.FirstOrDefault(e => e.SexId == patient.SexId)?.SexShort;
            patientCardMain.RegOnDate = patient.RegOnDate;
            patientCardMain.RegOffDate = patient.RegOffDate;
            patientCardMain.RegOffReason = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == patient.RegOffReason)?.InfectCourseLong;
            patientCardMain.UnrzFr = patient.UnrzFr1;
            patientCardMain.Region = _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.RegionId)?.RegionLong;
            patientCardMain.CityName = patient.CityName;
            patientCardMain.LocationName = patient.LocationName;
            patientCardMain.Phone = patient.AddrInd;
            patientCardMain.AddrStreat = patient.AddrStreet;
            patientCardMain.AddrExt = patient.AddrExt;
            patientCardMain.AddrHouse = patient.AddrHouse;
            patientCardMain.AddrFlat = patient.AddrFlat;
            patientCardMain.RegionFact = _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.FactRegionId)?.RegionLong;
            patientCardMain.CityNameFact = patient.FactCityName;
            patientCardMain.LocationNameFact = patient.FactLocationName;
            patientCardMain.IndexFact = patient.FactAddrInd;
            patientCardMain.AddrStreatFact = patient.FactAddrStreet;
            patientCardMain.AddrExtFact = patient.FactAddrExt;
            patientCardMain.AddrHouseFact = patient.FactAddrHouse;
            patientCardMain.AddrFlatFact = patient.FactAddrFlat;
            patientCardMain.DtRegBeg = patient.DtRegBeg;
            patientCardMain.DtRefEnd = patient.DtRegEnd;
            patientCardMain.Country = _context.TblCountries.FirstOrDefault(e => e.CountryId == patient.CountryId)?.CountryLong;
            patientCardMain.Comm = patient.AddrName;
            patientCardMain.HeightOld = patient.HeightOld;
            patientCardMain.WeightOld = patient.WeightOld;
            patientCardMain.PlaceCheck = _context.TblListPlaceChecks.FirstOrDefault(e => e.PlaceCheckId == patient.PlaceCheckId)?.PlaceCheckName;
            patientCardMain.CodeMKB10 = _context.TblCodeMkb10s.FirstOrDefault(e => e.CodeMkb10Id == patient.CodeMkb10Id)?.CodeMkb10Long;
            patientCardMain.CheckCourseShort = _context.TblCheckCourses.FirstOrDefault(e => e.CheckCourseId == patient.CheckCourseId)?.CheckCourseShort;
            patientCardMain.CheckCourseLong = _context.TblCheckCourses.FirstOrDefault(e => e.CheckCourseId == patient.CheckCourseId)?.CheckCourseLong;
            patientCardMain.InfectCourseShort = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == patient.InfectCourseId)?.InfectCourseShort;
            patientCardMain.InfectCourseLong = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == patient.InfectCourseId)?.InfectCourseLong;
            patientCardMain.DieCourseShort = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId)?.DieCourseShort;
            patientCardMain.DieCourseLong = _context.TblTempDieCureMkb10lists.FirstOrDefault(e => e.DieCourseId == patient.DieCourseId)?.DieCourseLong;
            patientCardMain.CardNo = patient.CardNo;
            patientCardMain.VulnerableGroup = _context.TblListVulnerableGroups.FirstOrDefault(e => e.VulnerableGroupId == patient.VulnerableGroupId)?.VulnerableGroupName;
            patientCardMain.RegOn = true;
            patientCardMain.HeadPhysician = patient.FlgHeadPhysician;
            patientCardMain.ZamMedPart = patient.FlgZamMedPart;
            patientCardMain.TransfArea = true;
            patientCardMain.TransfAreaDate = patient.TransfAreaDate;
            patientCardMain.TransfFederDate = patient.TransfFederDate;
            patientCardMain.UfsinDate = patient.UfsinDate;
            patientCardMain.DieInputDate = patient.DieDateInput;
            patientCardMain.DieDate = patient.DieDate;
            patientCardMain.DieAidsDate = patient.DieAidsDate;
            patientCardMain.FioChange = patient.FioChange;
            patientCardMain.Snils = patient.Snils;
            patientCardMain.ARVT = _context.TblArvts.FirstOrDefault(e => e.ArvtId == patient.ArvtId)?.ArvtLong;
            patientCardMain.Invalid = _context.TblInvalids.FirstOrDefault(e => e.InvalidId == patient.InvalidId)?.InvalidLong;
            patientCardMain.Archive = patient.SnilsFed;
            patientCardMain.CodeWord = patient.Codeword;
            patientCardMain.FlgDiagnosisAfterDeath = patient.FlgDiagnosisAfterDeath;
            patientCardMain.DeathTransferSub = patient.DeathTransferSub;

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
            DateOnly? blotDate = null;
            try { blotDate = DateOnly.Parse(blot.BlotDate); } catch { }

            TblPatientBlot item = new()
            {
                PatientId = blot.PatientId,
                BlotId = blot.BlotId,
                BlotNo = blot.BlotNo,
                BlotDate = blotDate,
                IbResultId = _context.TblIbResults.FirstOrDefault(e => e.IbResultShort == blot.IbResultId)?.IbResultId,
                CheckPlaceId = _context.TblCheckPlaces.FirstOrDefault(e => e.CheckPlaceLong == blot.CheckPlaceId)?.CheckPlaceId,
                First1 = blot.First1,
                Last1 = blot.Last1,
                FlgIfa = blot.FlgIfa,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now),
                ReferenceMoId = _context.TblListReferenceMos.FirstOrDefault(e => e.ReferenceMoName == blot.ReferenceMo)?.ReferenceMoId
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
            DateOnly? blotDate = null;
            try { blotDate = DateOnly.Parse(blot.BlotDate); } catch { }

            var item = _context.TblPatientBlots.Where(e => e.PatientId == blot.PatientId && e.BlotId == (int)blot.BlotIdOld).First();
            var datetime1 = item.Datetime1;

            if ((int)blot.BlotIdOld == blot.BlotId)
            {
                item.PatientId = blot.PatientId;
                item.BlotId = blot.BlotId;
                item.BlotNo = blot.BlotNo;
                item.BlotDate = blotDate;
                item.IbResultId = _context.TblIbResults.FirstOrDefault(e => e.IbResultShort == blot.IbResultId)?.IbResultId;
                item.CheckPlaceId = _context.TblCheckPlaces.FirstOrDefault(e => e.CheckPlaceLong == blot.CheckPlaceId)?.CheckPlaceId;
                item.First1 = blot.First1;
                item.Last1 = blot.Last1;
                item.FlgIfa = blot.FlgIfa;
                item.ReferenceMoId = _context.TblListReferenceMos.FirstOrDefault(e => e.ReferenceMoName == blot.ReferenceMo)?.ReferenceMoId;
                _context.SaveChanges();
                return Ok();
            }
            _context.TblPatientBlots.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = blot.PatientId,
                BlotId = blot.BlotId,
                BlotNo = blot.BlotNo,
                BlotDate = blotDate,
                IbResultId = _context.TblIbResults.FirstOrDefault(e => e.IbResultShort == blot.IbResultId)?.IbResultId,
                CheckPlaceId = _context.TblCheckPlaces.FirstOrDefault(e => e.CheckPlaceLong == blot.CheckPlaceId)?.CheckPlaceId,
                First1 = blot.First1,
                Last1 = blot.Last1,
                FlgIfa = blot.FlgIfa,
                Datetime1 = datetime1,
                ReferenceMoId = _context.TblListReferenceMos.FirstOrDefault(e => e.ReferenceMoName == blot.ReferenceMo)?.ReferenceMoId
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
                DiagnosisId = _context.TblDiagnoses.First(e => e.DiagnosisLong == stage.StageName)?.DiagnosisId
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

            if (stage.StageDate == stage.StageDateOld)
            {
                item.DiagnosisId = _context.TblDiagnoses.First(e => e.DiagnosisLong == stage.StageName)?.DiagnosisId;
                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientDiagnoses.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = stage.PatientId,
                DiagnosisDefDate = DateOnly.Parse(stage.StageDate),
                DiagnosisId = _context.TblDiagnoses.First(e => e.DiagnosisLong == stage.StageName)?.DiagnosisId
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

            //_context.TblPatientShowIllnesses.Attach(item);
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

            if (desease.Deseas == desease.DeseasOld && desease.StartDate == desease.StartDateOld)
            {
                item.EndDate = endDate;
                _context.SaveChanges();
                return Ok();
            }

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
            TblPatientCard item = _context.TblPatientCards.First(e => e.PatientId == patientId);
            _context.TblPatientCards.Attach(item);
            item.IsActive = false;
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdatePatient")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePatient(PatientCardMainForm patient)
        {
            TblPatientCard item;

            if (patient.PatientId == null)
            {
                int MaxPatientId = _context.TblPatientCards.Max(e => e.PatientId) + 1;

                item = new() { 
                    PatientId = MaxPatientId, 
                    IsActive = true, 
                    InputDate = DateOnly.FromDateTime(DateTime.Now) 
                };

                _context.TblPatientCards.Add(item);
            }
            else
            {
                item = _context.TblPatientCards.First(e => e.PatientId == patient.PatientId);
            }

            if (_context.Entry(item).State == EntityState.Detached)
            {
                _context.TblPatientCards.Attach(item);
            }

            item.FamilyName = patient.FamilyName;
            _context.Entry(item).Property(e => e.FamilyName).IsModified = true;
            item.FirstName = patient.FirstName;
            _context.Entry(item).Property(e => e.FirstName).IsModified = true;
            item.ThirdName = patient.ThirdName;
            _context.Entry(item).Property(e => e.ThirdName).IsModified = true;
            item.UnrzFr1 = patient.UnrzFr1;
            _context.Entry(item).Property(e => e.UnrzFr1).IsModified = true;
            item.CityName = patient.CityName;
            _context.Entry(item).Property(e => e.CityName).IsModified = true;
            item.LocationName = patient.LocationName;
            _context.Entry(item).Property(e => e.LocationName).IsModified = true;
            item.AddrInd = patient.AddrIndPhone;
            _context.Entry(item).Property(e => e.AddrInd).IsModified = true;
            item.AddrStreet = patient.AddrStreet;
            _context.Entry(item).Property(e => e.AddrStreet).IsModified = true;
            item.AddrHouse = patient.AddrHouse;
            _context.Entry(item).Property(e => e.AddrHouse).IsModified = true;
            item.AddrExt = patient.AddrExt;
            _context.Entry(item).Property(e => e.AddrExt).IsModified = true;
            item.AddrFlat = patient.AddrFlat;
            _context.Entry(item).Property(e => e.AddrFlat).IsModified = true;
            item.FactCityName = patient.FactCityName;
            _context.Entry(item).Property(e => e.FactCityName).IsModified = true;
            item.FactLocationName = patient.FactLocationName;
            _context.Entry(item).Property(e => e.FactLocationName).IsModified = true;
            item.FactAddrInd = patient.FactAddrInd;
            _context.Entry(item).Property(e => e.FactAddrInd).IsModified = true;
            item.FactAddrStreet = patient.FactAddrStreet;
            _context.Entry(item).Property(e => e.FactAddrStreet).IsModified = true;
            item.FactAddrHouse = patient.FactAddrHouse;
            _context.Entry(item).Property(e => e.FactAddrHouse).IsModified = true;
            item.FactAddrExt = patient.FactAddrExt;
            _context.Entry(item).Property(e => e.FactAddrExt).IsModified = true;
            item.FactAddrFlat = patient.FactAddrFlat;
            _context.Entry(item).Property(e => e.FactAddrFlat).IsModified = true;
            item.AddrName = patient.AddrNameComm;
            _context.Entry(item).Property(e => e.AddrName).IsModified = true;
            item.CardNo = patient.CardNo;
            _context.Entry(item).Property(e => e.CardNo).IsModified = true;
            item.HeightOld = patient.HeightOld;
            _context.Entry(item).Property(e => e.HeightOld).IsModified = true;
            item.WeightOld = patient.WeightOld;
            _context.Entry(item).Property(e => e.WeightOld).IsModified = true;
            item.FlgZamMedPart = patient.FlgZamMedPart;
            _context.Entry(item).Property(e => e.FlgZamMedPart).IsModified = true;
            item.FlgHeadPhysician = patient.FlgHeadPhysician;
            _context.Entry(item).Property(e => e.FlgHeadPhysician).IsModified = true;
            item.SnilsFed = patient.SnilsFedArchive;
            _context.Entry(item).Property(e => e.SnilsFed).IsModified = true;
            item.Codeword = patient.Codeword;
            _context.Entry(item).Property(e => e.Codeword).IsModified = true;
            item.Snils = patient.Snils;
            _context.Entry(item).Property(e => e.Snils).IsModified = true;
            item.FioChange = patient.FioChange;
            _context.Entry(item).Property(e => e.FioChange).IsModified = true;
            item.FlgDiagnosisAfterDeath = patient.FlgDiagnosisAfterDeath;
            _context.Entry(item).Property(e => e.FlgDiagnosisAfterDeath).IsModified = true;
            item.DeathTransferSub = patient.DeathTransferSub;
            _context.Entry(item).Property(e => e.DeathTransferSub).IsModified = true;

            DateOnly? dieDate = null, dieAidsDate = null;
            try { dieDate = DateOnly.Parse(patient.DieDate); } catch { }
            try { dieAidsDate = DateOnly.Parse(patient.DieAidsDate); } catch { }

            if (dieDate != item.DieDate)
            {
                item.DieDate = dieDate;
                _context.Entry(item).Property(e => e.DieDate).IsModified = true;
                item.DieDateInput = DateOnly.FromDateTime(DateTime.Now);
            }

            if (dieAidsDate != item.DieAidsDate)
            {
                item.DieAidsDate = dieAidsDate;
                _context.Entry(item).Property(e => e.DieAidsDate).IsModified = true;
                item.DieDateInput = DateOnly.FromDateTime(DateTime.Now);
            }

            item.BirthDate = patient.BirthDate != null && patient.BirthDate?.Length != 0 ? DateOnly.Parse(patient.BirthDate) : null;
            _context.Entry(item).Property(e => e.BirthDate).IsModified = true;

            item.RegOnDate = patient.RegOnDate != null && patient.RegOnDate?.Length != 0 ? DateOnly.Parse(patient.RegOnDate) : null;
            _context.Entry(item).Property(e => e.RegOnDate).IsModified = true;

            item.RegOffDate = patient.RegOffDate != null && patient.RegOffDate?.Length != 0 ? DateOnly.Parse(patient.RegOffDate) : null;
            _context.Entry(item).Property(e => e.RegOffDate).IsModified = true;

            item.TransfAreaDate = patient.TransfAreaDate != null && patient.TransfAreaDate?.Length != 0 ? DateOnly.Parse(patient.TransfAreaDate) : null;
            _context.Entry(item).Property(e => e.TransfAreaDate).IsModified = true;

            item.TransfFederDate = patient.TransfFederDate != null && patient.TransfFederDate?.Length != 0 ? DateOnly.Parse(patient.TransfFederDate) : null;
            _context.Entry(item).Property(e => e.TransfFederDate).IsModified = true;

            item.UfsinDate = patient.UfsinDate != null && patient.UfsinDate?.Length != 0 ? DateOnly.Parse(patient.UfsinDate) : null;
            _context.Entry(item).Property(e => e.UfsinDate).IsModified = true;

            item.DtRegBeg = patient.DtRegBeg != null && patient.DtRegBeg?.Length != 0 ? DateOnly.Parse(patient.DtRegBeg) : null;
            _context.Entry(item).Property(e => e.DtRegBeg).IsModified = true;

            item.DtRegEnd = patient.DtRegEnd != null && patient.DtRegEnd?.Length != 0 ? DateOnly.Parse(patient.DtRegEnd) : null;
            _context.Entry(item).Property(e => e.DtRegEnd).IsModified = true;

            if (patient.SexId != null)
                if (patient.SexId.Length != 0)
                {
                    var id = _context.TblSexes.First(e => e.SexShort == patient.SexId)?.SexId;
                    if (id != item.SexId)
                        item.SexId = id;
                }
                else
                {
                    item.SexId = null;
                    _context.Entry(item).Property(e => e.SexId).IsModified = true;
                }

            if (patient.FactRegionId != null)
                if (patient.FactRegionId.Length != 0)
                {
                    var id = _context.TblRegions.First(e => e.RegionLong == patient.FactRegionId)?.RegionId;
                    if (id != item.FactRegionId)
                        item.FactRegionId = id;
                }
                else
                {
                    item.FactRegionId = null;
                    _context.Entry(item).Property(e => e.FactRegionId).IsModified = true;
                }

            if (patient.CheckCourseId != null)
                if (patient.CheckCourseId.Length != 0)
                {
                    var id = _context.TblCheckCourses.First(e => e.CheckCourseShort == patient.CheckCourseId)?.CheckCourseId;
                    if (id != item.CheckCourseId)
                        item.CheckCourseId = id;
                }
                else
                {
                    item.CheckCourseId = null;
                    _context.Entry(item).Property(e => e.CheckCourseId).IsModified = true;
                }

            if (patient.InfectCourseId != null)
                if (patient.InfectCourseId.Length != 0)
                {
                    var id = _context.TblInfectCourses.First(e => e.InfectCourseShort == patient.InfectCourseId)?.InfectCourseId;
                    if (id != item.InfectCourseId)
                        item.InfectCourseId = id;
                }
                else
                {
                    item.InfectCourseId = null;
                    _context.Entry(item).Property(e => e.InfectCourseId).IsModified = true;
                }

            if (patient.DieCourseId != null)
                if (patient.DieCourseId.Length != 0)
                {
                    var id = _context.TblTempDieCureMkb10lists.First(e => e.DieCourseShort == patient.DieCourseId)?.DieCourseId;
                    if (id != item.DieCourseId)
                        item.DieCourseId = id;
                }
                else
                {
                    item.DieCourseId = null;
                    _context.Entry(item).Property(e => e.DieCourseId).IsModified = true;
                }

            if (patient.InvalidId != null)
                if (patient.InvalidId.Length != 0)
                {
                    var id = _context.TblInvalids.First(e => e.InvalidLong == patient.InvalidId)?.InvalidId;
                    if (id != item.InvalidId)
                        item.InvalidId = id;
                }
                else
                {
                    item.InvalidId = null;
                    _context.Entry(item).Property(e => e.InvalidId).IsModified = true;
                }

            if (patient.VulnerableGroupId != null)
                if (patient.VulnerableGroupId.Length != 0)
                {
                    var id = _context.TblListVulnerableGroups.First(e => e.VulnerableGroupName == patient.VulnerableGroupId)?.VulnerableGroupId;
                    if (id != item.VulnerableGroupId)
                        item.VulnerableGroupId = id;
                }
                else
                {
                    item.VulnerableGroupId = null;
                    _context.Entry(item).Property(e => e.VulnerableGroupId).IsModified = true;
                }

            if (patient.CodeMkb10Id != null)
                if (patient.CodeMkb10Id.Length != 0)
                {
                    var id = _context.TblCodeMkb10s.First(e => e.CodeMkb10Long == patient.CodeMkb10Id)?.CodeMkb10Id;
                    if (id != item.CodeMkb10Id)
                        item.CodeMkb10Id = id;
                }
                else
                {
                    item.CodeMkb10Id = null;
                    _context.Entry(item).Property(e => e.CodeMkb10Id).IsModified = true;
                }

            if (patient.ArvtId != null)
                if (patient.ArvtId.Length != 0)
                {
                    var id = _context.TblArvts.First(e => e.ArvtLong == patient.ArvtId)?.ArvtId;
                    if (id != item.ArvtId)
                        item.ArvtId = id;
                }
                else
                {
                    item.ArvtId = null;
                    _context.Entry(item).Property(e => e.ArvtId).IsModified = true;
                }

            if (patient.CountryId != null)
                if (patient.CountryId.Length != 0)
                {
                    var id = _context.TblCountries.First(e => e.CountryLong == patient.CountryId).CountryId;
                    if (id != item.CountryId)
                        item.CountryId = id;
                }
                else
                {
                    item.CountryId = null;
                    _context.Entry(item).Property(e => e.CountryId).IsModified = true;
                }

            if (patient.PlaceCheckId != null)
                if (patient.PlaceCheckId.Length != 0)
                {
                    var id = _context.TblListPlaceChecks.First(e => e.PlaceCheckName == patient.PlaceCheckId)?.PlaceCheckId;
                    if (id != item.PlaceCheckId)
                        item.PlaceCheckId = id;
                }
                else
                {
                    item.PlaceCheckId = null;
                    _context.Entry(item).Property(e => e.PlaceCheckId).IsModified = true;
                }

            if (patient.RegionId != null)
                if (patient.RegionId.Length != 0)
                {
                    var id = _context.TblRegions.First(e => e.RegionLong == patient.RegionId)?.RegionId;
                    if (id != item.RegionId)
                        item.RegionId = id;
                }
                else
                {
                    item.RegionId = null;
                    _context.Entry(item).Property(e => e.RegionId).IsModified = true;
                }

            if (patient.RegOffReason != null)
                if (patient.RegOffReason.Length != 0)
                {
                    var id = _context.TblInfectCourses.First(e => e.InfectCourseLong == patient.RegOffReason)?.InfectCourseId;
                    if (id != item.RegOffReason)
                        item.RegOffReason = id;
                }
                else
                {
                    item.RegOffReason = null;
                    _context.Entry(item).Property(e => e.RegOffReason).IsModified = true;
                }

            _context.SaveChanges();
            return Ok(item.PatientId);
        }
    }
}
