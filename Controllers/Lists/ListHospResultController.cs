using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;

namespace HIVBackend.Controllers.Lists
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListHospResultController : ControllerBase
    {
        private readonly HivContext _context;
        public ListHospResultController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblHospResults.OrderBy(e => e.HospResultLong)
                .Select(e => new { id = e.HospResultId, longName = e.HospResultLong, shortName = e.HospResultShort }).ToList();
            return Ok(new { list, maxId = _context.TblHospResults.Max(e => e.HospResultId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblHospResults.Where(e => e.HospResultLong == longName).First();
            _context.TblHospResults.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblHospResults.Any(e => e.HospResultLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblHospResult item = new()
            {
                HospResultId = list.Id,
                HospResultShort = list.ShortName,
                HospResultLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblHospResults.Attach(item);
            _context.TblHospResults.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblHospResults.Any(e => e.HospResultLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblHospResults.Where(e => e.HospResultId == list.Id).First();

            item.HospResultShort = list.ShortName;
            item.HospResultLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
