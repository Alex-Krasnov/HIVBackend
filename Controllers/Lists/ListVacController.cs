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
    public class ListVacController : ControllerBase
    {
        private readonly HivContext _context;
        public ListVacController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListVacs.OrderBy(e => e.VacName)
                .Select(e => new { id = e.VacId, longName = e.VacName }).ToList();
            return Ok(new { list, maxId = _context.TblListVacs.Max(e => e.VacId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListVacs.Where(e => e.VacName == longName).First();
            _context.TblListVacs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListVacs.Any(e => e.VacName == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListVac item = new()
            {
                VacId = list.Id,
                VacName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListVacs.Attach(item);
            _context.TblListVacs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListVacs.Any(e => e.VacName == list.LongName);

            if (!isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListVacs.Where(e => e.VacId == list.Id).First();

            item.VacName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}