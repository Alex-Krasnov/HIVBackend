using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet, Route("GetInListSex")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListSex(string name)
        {
            var inList =_context.TblSexes.Any(e => e.SexShort == name);
            Thread.Sleep(2000);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListRegion")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListRegion(string name)
        {
            var inList = _context.TblRegions.Any(e => e.RegionLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListInfectCourses")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInfectCourses(string name)
        {
            var inList = _context.TblInfectCourses.Any(e => e.InfectCourseLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListCountries")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCountries(string name)
        {
            var inList = _context.TblCountries.Any(e => e.CountryLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListPlaceChecks")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListPlaceChecks(string name)
        {
            var inList = _context.TblListPlaceChecks.Any(e => e.PlaceCheckName == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListCodeMkb10s")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCodeMkb10s(string name)
        {
            var inList = _context.TblCodeMkb10s.Any(e => e.CodeMkb10Long == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListCheckCourseLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCheckCourseLong(string name)
        {
            var inList = _context.TblCheckCourses.Any(e => e.CheckCourseLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListCheckCourseShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCheckCourseShort(string name)
        {
            var inList = _context.TblCheckCourses.Any(e => e.CheckCourseShort == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListInfectCourseLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInfectCourseLong(string name)
        {
            var inList = _context.TblInfectCourses.Any(e => e.InfectCourseLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListInfectCourseShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInfectCourseShort(string name)
        {
            var inList = _context.TblInfectCourses.Any(e => e.InfectCourseShort == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListDieCourseLong")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDieCourseLong(string name)
        {
            var inList = _context.TblDieCourses.Any(e => e.DieCourseLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListDieCourseShort")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDieCourseShort(string name)
        {
            var inList = _context.TblDieCourses.Any(e => e.DieCourseShort == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListVulnerableGroup")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListVulnerableGroup(string name)
        {
            var inList = _context.TblListVulnerableGroups.Any(e => e.VulnerableGroupName == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListArv")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListArv(string name)
        {
            var inList = _context.TblArvts.Any(e => e.ArvtShort == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListInvalid")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListInvalid(string name)
        {
            var inList = _context.TblInvalids.Any(e => e.InvalidLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListCheckPlace")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListCheckPlace(string name)
        {
            var inList = _context.TblCheckPlaces.Any(e => e.CheckPlaceLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListIbResult")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListIbResult(string name)
        {
            var inList = _context.TblIbResults.Any(e => e.IbResultShort == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListDeseases")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListDeseases(string name)
        {
            var inList = _context.TblShowIllnesses.Any(e => e.ShowIllnessLong == name);
            return Ok(inList);
        }

        [HttpGet, Route("GetInListStage")]
        [Authorize(Roles = "User")]
        public IActionResult GetInListStage(string name)
        {
            var inList = _context.TblDiagnoses.Any(e => e.DiagnosisLong == name);
            return Ok(inList);
        }
    }
}
