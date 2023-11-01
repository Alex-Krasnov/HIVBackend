using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using HIVBackend.Models.FormModels;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly HivContext _context;
        public ListsController(HivContext context)
        {
            _context = context;
        }

        [HttpPost, Route("GetInListSex")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListSex(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList =_context.TblSexes.Any(e => e.SexShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListRegion")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListRegion(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblRegions.Any(e => e.RegionLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListInfectCourses")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInfectCourses(InList data)
        {
            if(data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblInfectCourses.Any(e => e.InfectCourseLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListCountries")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCountries(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCountries.Any(e => e.CountryLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListPlaceChecks")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListPlaceChecks(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListPlaceChecks.Any(e => e.PlaceCheckName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListCodeMkb10s")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCodeMkb10s(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCodeMkb10s.Any(e => e.CodeMkb10Long == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListCheckCourseLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCheckCourseLong(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCheckCourses.Any(e => e.CheckCourseLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListCheckCourseShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCheckCourseShort(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCheckCourses.Any(e => e.CheckCourseShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListInfectCourseLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInfectCourseLong(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblInfectCourses.Any(e => e.InfectCourseLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListInfectCourseShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInfectCourseShort(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblInfectCourses.Any(e => e.InfectCourseShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListDieCourseLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDieCourseLong(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTempDieCureMkb10lists.Any(e => e.DieCourseLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListDieCourseShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDieCourseShort(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTempDieCureMkb10lists.Any(e => e.DieCourseShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListVulnerableGroup")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListVulnerableGroup(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListVulnerableGroups.Any(e => e.VulnerableGroupName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListArvt")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListArvt(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblArvts.Any(e => e.ArvtLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListInvalid")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInvalid(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblInvalids.Any(e => e.InvalidLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListCheckPlace")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCheckPlace(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCheckPlaces.Any(e => e.CheckPlaceLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListIbResult")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListIbResult(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblIbResults.Any(e => e.IbResultShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListDeseases")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDeseases(InList data)
        {
            var inList = _context.TblShowIllnesses.Any(e => e.ShowIllnessLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListStage")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListStage(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblDiagnoses.Any(e => e.DiagnosisLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListCorrespIllnesses")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCorrespIllnesses(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCorrespIllnesses.Any(e => e.CorrespIllnessLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListCureSchemaName")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCureSchemaName(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCureSchemas.Any(e => e.CureSchemaLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListCureChangeName")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCureChangeName(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCureChanges.Any(e => e.CureChangeLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListRangeTherapy")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListRangeTherapy(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblRangeTherapies.Any(e => e.RangeTherapyLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListLpuName")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListLpuName(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblLpus.Any(e => e.LpuLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListHospCourseName")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListHospCourseName(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblHospCourses.Any(e => e.HospCourseLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListHospResult")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListHospResult(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblHospResults.Any(e => e.HospResultLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListEducation")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListEducation(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListEducations.Any(e => e.EduName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListFammilyStatus")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListFammilyStatus(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListFamilyStatuses.Any(e => e.FammilyStatusName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListEmployment")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListEmployment(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListEmloyments.Any(e => e.EmploymentName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListTrans")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListTrans(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListTrans.Any(e => e.TransName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListVac")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListVac(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListVacs.Any(e => e.VacName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMkb10Covid")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMkb10Covid(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListMkb10Covids.Any(e => e.Mkb10LongName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListTransmisionMech")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListTransmisionMech(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListTransmisionMeches.Any(e => e.TransmisiomMechName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListSituationDetect")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListSituationDetect(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListSituationDetects.Any(e => e.SituationDetectName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListEpidDoctor")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListEpidDoctor(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListEpidDoctors.Any(e => e.DoctorName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListYn")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListYn(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListYns.Any(e => e.YNName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListPatientCard")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListPatientCard(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblPatientCards.Any(e => e.PatientId == int.Parse(data.Str));
            return Ok(inList);
        }

        [HttpPost, Route("getInListSpecs")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListSpecs(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblSpecs.Any(e => e.SpecLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListDoctors")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDoctors(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblDoctors.Any(e => e.DoctorLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListCabinets")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCabinets(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblCabinets.Any(e => e.CabinetLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListRegTimes")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListRegTimes(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblRegTimes.Any(e => e.RegTimeLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList13")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList13(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 13).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList14")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList14(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 14).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList21")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList21(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 21).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList22")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList22(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 22).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList24")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList24(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 24).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList25")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList25(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 25).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList35")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList35(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 35).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInList36")]
        [Authorize(Roles = "User")]
        public IActionResult GetInList36(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblTalonListOfValues.Where(e => e.TalonField == 36).Any(e => e.ValueDescr == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListVl")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListVl(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblVloadResults.Any(e => e.VloadResultLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListHc")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListHc(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblHepatitResults.Any(e => e.HepatitResultLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListHb")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListHb(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblHepatitResult2s.Any(e => e.HepatitResult2Long == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListFinSource")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListFinSource(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblFinSources.Any(e => e.FinSourceLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMedicine")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMedicine(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblMedicines.Any(e => e.MedicineLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListPregCheck")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListPregCheck(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblPregChecks.Any(e => e.PregCheckLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListBirthType")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListBirthType(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblBirthTypes.Any(e => e.BirthTypeLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListChildCount")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListChildCount(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblChildCounts.Any(e => e.ChildCountLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListFamilyType")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListFamilyType(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblFamilyTypes.Any(e => e.FamilyTypeLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListChildPlace")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListChildPlace(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblChildPlaces.Any(e => e.ChildPlaceLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListChildPhp")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListChildPhp(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblChildPhps.Any(e => e.ChildPhpLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMaterHome")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMaterHome(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblMaterHomes.Any(e => e.MaterhomeLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListJail")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListJail(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblJails.Any(e => e.JailLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListOutHosp")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListOutHosp(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListOutHosps.Any(e => e.HospName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListClinVarCovid")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListClinVarCovid(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListClinVarCovids.Any(e => e.ClinVarCovidName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListCourseCovid")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListClinCourseCovid(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListCourseCovids.Any(e => e.CourseCovidName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMkb10CovidShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMkb10CovidShort(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListMkb10Covids.Any(e => e.Mkb10ShortName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMkb10CovidLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMkb10CovidLong(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListMkb10Covids.Any(e => e.Mkb10LongName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMkbTuderShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMkbTuderShort(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListMkbTuders.Any(e => e.TuberNameShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMkbTuderLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMkbTuderLong(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListMkbTuders.Any(e => e.TuberNameLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMkbPneumoniaShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMkbPneumoniaShort(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListMkbPneumonia.Any(e => e.PneumoniaNameShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListMkbPneumoniaLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListMkbPneumoniaLong(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListMkbPneumonia.Any(e => e.PneumoniaNameLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListAvlType")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListAvlType(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListAvlTypes.Any(e => e.TypeAvlName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListCommitment")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCommitment(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListCommitments.Any(e => e.CommitmentName == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListFullMkb10Short")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListFullMkb10Short(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListFullMkb10s.Any(e => e.DieCourseShort == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListFullMkb10Long")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListFullMkb10Long(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblListFullMkb10s.Any(e => e.DieCourseLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListYNA")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListYNA(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);
            List<string> yna = new(){ "Да", "Нет", "Все" };

            var inList = yna.Any(e => data.Str.Contains(e));
            return Ok(inList);
        }

        [HttpPost, Route("getInListAids12")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListAids12(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblAids12s.Any(e => e.Aids12Long == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListChemop")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListChemop(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblChemops.Any(e => e.ChemopLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("getInListPNA")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListPNA(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);
            List<string> yna = new() { "Все", "Пол", "Отр" };

            var inList = yna.Any(e => data.Str.Contains(e));
            return Ok(inList);
        }
    }
}
