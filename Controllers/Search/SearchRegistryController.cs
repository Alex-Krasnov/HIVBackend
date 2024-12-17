using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels.Search;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchRegistryController : ControllerBase
    {
        private readonly HivContext _context;
        public SearchRegistryController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            List<string?> outModel = _context.TblDoctors.Where(e => e.DoctorLong != null).Select(e => e.DoctorLong).ToList();
            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchRegistry form)
        {
            List<string> columName = new()
            {
                "Ид пациента",
                "№ карты",
                "Фамилия",
                "Имя",
                "Отчество",
                "Регион",
                "Регион факт",
                "Страна",
                "Город",
                "Населенный пункт",
                "Улица",
                "Дом",
                "архив",
                "смена фио",
                "дата записи"
            };

            List<string> activeColumns = new()
            {
                "PatientId",
                "CardNo",
                "FamilyName",
                "FirstName",
                "ThirdName",
                "RegionLong",
                "RegionLongFact",
                "CountryLong",
                "CityName",
                "LocationName",
                "AddrStreet",
                "AddrHouse",
                "Archive",
                "FioChange",
                "RegDate"
            };

            int? doctorId = _context.TblDoctors.FirstOrDefault(e => e.DoctorLong == form.Doctor)?.DoctorId;
            if (doctorId == null)
                return BadRequest("Доктор не найден");

            DateOnly regDate = DateOnly.Parse(form.Date);

            var qryWhere = _context.QryRegistrys.Where(e => e.RegDate == regDate && e.DocId == doctorId)
                .OrderBy(e => e.FamilyName).ThenBy(e => e.FirstName).ThenBy(e => e.ThirdName);

            var lambda = new CreateLambda<QryRegistry>().CreateLambdaSelect(activeColumns);
            var selected = qryWhere.Select(lambda);
            var resQry = selected.GroupBy(item => item, new DictionaryEqualityComparer()).Select(e => e.First()).ToList();

            string authHeader = Request.Headers["Authorization"].First();
            string jwt = authHeader.Substring("Bearer ".Length);
            var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = jwtHandler.ReadJwtToken(jwt);

            var createExcel = new CreateExcel();
            string fileName = $"search_registry_{form.Doctor}_{token.Claims.First().Value}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            createExcel.CreateSearchExcel(resQry, path, columName);

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            return File(fileBytes, contentType, $"registry_{form.Doctor}.xlsx");
        }
    }
}
