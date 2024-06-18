using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.Lists
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListInvalidController : ControllerBase
    {
        private readonly HivContext _context;
        public ListInvalidController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblInvalids.OrderBy(e => e.InvalidLong)
                .Select(e => new { id = e.InvalidId, longName = e.InvalidLong, shortName = e.InvalidShort }).ToList();
            return Ok(new { list, maxId = _context.TblInvalids.Max(e => e.InvalidId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblInvalids.Where(e => e.InvalidLong == longName).First();
            _context.TblInvalids.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblInvalids.Any(e => e.InvalidLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblInvalid item = new()
            {
                InvalidId = list.Id,
                InvalidShort = list.ShortName,
                InvalidLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblInvalids.Attach(item);
            _context.TblInvalids.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblInvalids.Any(e => e.InvalidLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblInvalids.Where(e => e.InvalidId == list.Id).First();

            item.InvalidShort = list.ShortName;
            item.InvalidLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
