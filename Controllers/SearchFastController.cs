using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore;

namespace HIVBackend.Controllers
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
                    join s in _context.TblSexes on p.SexId equals s.SexId
                    join r in _context.TblRegions on p.RegionId equals r.RegionId
                    where( 
                        (form.PatientId != null ? p.PatientId == form.PatientId : true) &&
                        (form.FamilyName != null ? p.FamilyName.ToLower().StartsWith(form.FamilyName.ToLower()) : true) &&
                        (form.FirstName != null ? p.FirstName.ToLower().StartsWith(form.FirstName.ToLower()) : true) &&
                        (form.ThirdName != null ? p.ThirdName.ToLower().StartsWith(form.ThirdName.ToLower()) : true) &&
                        (form.BirthDateStart != null ? p.BirthDate >= DateOnly.Parse(form.BirthDateStart) : true) &&
                        (form.BirthDateEnd != null ? p.BirthDate <= DateOnly.Parse(form.BirthDateEnd) : true) &&
                        (form.CardNo != null ? p.CardNo.ToLower().StartsWith(form.CardNo.ToLower()) : true)
                    )
                    orderby p.FamilyName, p.FirstName, p.ThirdName
                    select new { 
                        p.PatientId,
                        p.CardNo,
                        p.FamilyName,
                        p.FirstName,
                        p.ThirdName,
                        s.SexShort,
                        p.BirthDate,
                        r.RegionLong,
                        p.CityName,
                        p.AddrInd,
                        p.AddrStreet,
                        p.AddrHouse,
                        p.AddrFlat,
                        p.Snils
                    }).ToList();

            int resCount = resQry.Count();

            var resPage = resQry.Select((x, i) => new { Index = i, Value = x })
                        .GroupBy(x => x.Index / pageSize)
                        .Select(x => x.Select(v => v.Value).ToList())
                        .ToList().ElementAt(form.Page-1);

            return Ok(new { columName, resPage, resCount });
        }
    }
}
