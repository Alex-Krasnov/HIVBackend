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
    public class ListCureChangeController : ControllerBase
    {
        private readonly HivContext _context;
        public ListCureChangeController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblCureChanges.OrderBy(e => e.CureChangeLong)
                .Select(e => new { id = e.CureChangeId, longName = e.CureChangeLong, shortName = e.CureChangeShort }).ToList();
            return Ok(new { list, maxId = _context.TblCureChanges.Max(e => e.CureChangeId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblCureChanges.Where(e => e.CureChangeLong == longName).First();
            _context.TblCureChanges.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblCureChanges.Any(e => e.CureChangeLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblCureChange item = new()
            {
                CureChangeId = list.Id,
                CureChangeShort = list.ShortName,
                CureChangeLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblCureChanges.Attach(item);
            _context.TblCureChanges.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblCureChanges.Any(e => e.CureChangeLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblCureChanges.Where(e => e.CureChangeId == list.Id).First();

            item.CureChangeShort = list.ShortName;
            item.CureChangeLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
