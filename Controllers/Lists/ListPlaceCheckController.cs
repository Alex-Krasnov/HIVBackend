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
    public class ListPlaceCheckController : ControllerBase
    {
        private readonly HivContext _context;
        public ListPlaceCheckController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListPlaceChecks.OrderBy(e => e.PlaceCheckName)
                .Select(e => new { id = e.PlaceCheckId, longName = e.PlaceCheckName }).ToList();
            return Ok(new { list, maxId = _context.TblListPlaceChecks.Max(e => e.PlaceCheckId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListPlaceChecks.Where(e => e.PlaceCheckName == longName).First();
            _context.TblListPlaceChecks.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListPlaceChecks.Any(e => e.PlaceCheckName == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListPlaceCheck item = new()
            {
                PlaceCheckId = list.Id,
                PlaceCheckName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListPlaceChecks.Attach(item);
            _context.TblListPlaceChecks.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListPlaceChecks.Any(e => e.PlaceCheckName == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListPlaceChecks.Where(e => e.PlaceCheckId == list.Id).First();

            item.PlaceCheckName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}