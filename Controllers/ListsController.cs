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

            var inList = _context.TblDieCourses.Any(e => e.DieCourseLong == data.Str);
            return Ok(inList);
        }

        [HttpPost, Route("GetInListDieCourseShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDieCourseShort(InList data)
        {
            if (data.Str == null || data.Str?.Length == 0)
                return Ok(true);

            var inList = _context.TblDieCourses.Any(e => e.DieCourseShort == data.Str);
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

            var inList = _context.TblArvts.Any(e => e.ArvtShort == data.Str);
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
    }
}
