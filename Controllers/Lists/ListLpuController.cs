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
    public class ListLpuController : ControllerBase
    {
        private readonly HivContext _context;
        public ListLpuController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblLpus.OrderBy(e => e.LpuLong)
                .Select(e => new { id = e.LpuId, longName = e.LpuLong, shortName = e.LpuShort }).ToList();
            return Ok(new { list, maxId = _context.TblLpus.Max(e => e.LpuId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblLpus.Where(e => e.LpuLong == longName).First();
            _context.TblLpus.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblLpus.Any(e => e.LpuLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblLpu item = new()
            {
                LpuId = list.Id,
                LpuShort = list.ShortName,
                LpuLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblLpus.Attach(item);
            _context.TblLpus.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblLpus.Any(e => e.LpuLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblLpus.Where(e => e.LpuId == list.Id).First();

            item.LpuShort = list.ShortName;
            item.LpuLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
