using HIVBackend.Data;
using HIVBackend.Models.FormModels.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchFastController : ControllerBase
    {
        private readonly HivContext _context;
        public SearchFastController(HivContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchFastForm form)
        {
            int pageSize = 100;
            List<string> columName = new()
            {
                "Ид пациента",
                "№ карты",
                "Фамилия",
                "Имя",
                "Отчество",
                "Пол",
                "Дата рождения",
                "Регион",
                "Город",
                "Телефон",
                "Улица",
                "Дом",
                "Корпус",
                "Кв."
            };

            var resQry = (from p in _context.TblPatientCards
                          join sex in _context.TblSexes on p.SexId equals sex.SexId into sexes
                          from s in sexes.DefaultIfEmpty()
                          join region in _context.TblRegions on p.RegionId equals region.RegionId into regions
                          from r in regions.DefaultIfEmpty()
                          where p.IsActive == true &&
                        (form.PatientId != null && form.PatientId.Length != 0 ? p.PatientId == int.Parse(form.PatientId) : true) &&
                        (form.FamilyName != null ? p.FamilyName.ToLower().StartsWith(form.FamilyName.ToLower()) : true) &&
                        (form.FirstName != null ? p.FirstName.ToLower().StartsWith(form.FirstName.ToLower()) : true) &&
                        (form.ThirdName != null ? p.ThirdName.ToLower().StartsWith(form.ThirdName.ToLower()) : true) &&
                        (form.BirthDateStart != null ? p.BirthDate >= DateOnly.Parse(form.BirthDateStart) : true) &&
                        (form.BirthDateEnd != null ? p.BirthDate <= DateOnly.Parse(form.BirthDateEnd) : true) &&
                        (form.CardNo != null ? p.CardNo.ToLower().StartsWith(form.CardNo.ToLower()) : true)

                          orderby p.FamilyName, p.FirstName, p.ThirdName
                          select new Dictionary<string, object>{
                        { "PatientId", p.PatientId },
                        { "CardNo", p.CardNo },
                        { "FamilyName", p.FamilyName},
                        { "FirstName", p.FirstName },
                        { "ThirdName", p.ThirdName },
                        { "SexShort", s.SexShort},
                        { "BirthDate", p.BirthDate},
                        { "RegionLong", r.RegionLong},
                        { "CityName", p.CityName},
                        { "AddrInd", p.AddrInd},
                        { "AddrStreet", p.AddrStreet},
                        { "AddrHouse", p.AddrHouse},
                        { "AddrFlat", p.AddrFlat},
                        { "Snils", p.Snils}
                    }).ToList();


            int resCount = resQry.Count();

            if (resCount == 0)
            {
                return Ok(new { columName, resCount });
            }

            var resPage = resQry.Skip(pageSize * (form.Page - 1)).Take(pageSize).ToList();

            return Ok(new { columName, resPage, resCount });
        }
    }
}
