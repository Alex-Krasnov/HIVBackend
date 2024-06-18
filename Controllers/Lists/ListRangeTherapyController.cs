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
    public class ListRangeTherapyController : ControllerBase
    {
        private readonly HivContext _context;
        public ListRangeTherapyController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblRangeTherapies.OrderBy(e => e.RangeTherapyLong)
                .Select(e => new { id = e.RangeTherapyId, longName = e.RangeTherapyLong, shortName = e.RangeTherapyShort }).ToList();
            return Ok(new { list, maxId = _context.TblRangeTherapies.Max(e => e.RangeTherapyId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblRangeTherapies.Where(e => e.RangeTherapyLong == longName).First();
            _context.TblRangeTherapies.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblRangeTherapies.Any(e => e.RangeTherapyLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblRangeTherapy item = new()
            {
                RangeTherapyId = list.Id,
                RangeTherapyShort = list.ShortName,
                RangeTherapyLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblRangeTherapies.Attach(item);
            _context.TblRangeTherapies.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblRangeTherapies.Any(e => e.RangeTherapyLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblRangeTherapies.Where(e => e.RangeTherapyId == list.Id).First();

            item.RangeTherapyShort = list.ShortName;
            item.RangeTherapyLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
