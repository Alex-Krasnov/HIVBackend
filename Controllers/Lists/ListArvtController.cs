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
    public class ListArvtController : ControllerBase
    {
        private readonly HivContext _context;
        public ListArvtController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblArvts.OrderBy(e => e.ArvtLong)
                .Select(e => new { id = e.ArvtId, longName = e.ArvtLong, shortName = e.ArvtShort }).ToList();
            return Ok(new { list, maxId = _context.TblArvts.Max(e => e.ArvtId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblArvts.Where(e => e.ArvtLong == longName).First();
            _context.TblArvts.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblArvts.Any(e => e.ArvtLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblArvt item = new()
            {
                ArvtId = list.Id,
                ArvtShort = list.ShortName,
                ArvtLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblArvts.Attach(item);
            _context.TblArvts.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblArvts.Any(e => e.ArvtLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblArvts.Where(e => e.ArvtId == list.Id).First();

            item.ArvtShort = list.ShortName;
            item.ArvtLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
