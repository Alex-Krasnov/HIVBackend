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
    public class ListCabinetController : ControllerBase
    {
        private readonly HivContext _context;
        public ListCabinetController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblCabinets.OrderBy(e => e.CabinetLong)
                .Select(e => new { id = e.CabinetId, longName = e.CabinetLong, shortName = e.CabinetShort }).ToList();
            return Ok(new { list, maxId = _context.TblCabinets.Max(e => e.CabinetId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblCabinets.Where(e => e.CabinetLong == longName).First();
            _context.TblCabinets.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblCabinets.Any(e => e.CabinetLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblCabinet item = new()
            {
                CabinetId = list.Id,
                CabinetShort = list.ShortName,
                CabinetLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblCabinets.Attach(item);
            _context.TblCabinets.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblCabinets.Any(e => e.CabinetLong == list.LongName);

            if (!isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblCabinets.Where(e => e.CabinetId == list.Id).First();

            item.CabinetShort = list.ShortName;
            item.CabinetLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
