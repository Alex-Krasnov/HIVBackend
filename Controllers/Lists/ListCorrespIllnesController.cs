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
    public class ListCorrespIllnesController : ControllerBase
    {
        private readonly HivContext _context;
        public ListCorrespIllnesController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblCorrespIllnesses.OrderBy(e => e.CorrespIllnessLong)
                .Select(e => new { id = e.CorrespIllnessId, longName = e.CorrespIllnessLong, shortName = e.CorrespIllnessShort }).ToList();
            return Ok(new { list, maxId = _context.TblCorrespIllnesses.Max(e => e.CorrespIllnessId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblCorrespIllnesses.Where(e => e.CorrespIllnessLong == longName).First();
            _context.TblCorrespIllnesses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblCorrespIllnesses.Any(e => e.CorrespIllnessLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblCorrespIllness item = new()
            {
                CorrespIllnessId = list.Id,
                CorrespIllnessShort = list.ShortName,
                CorrespIllnessLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblCorrespIllnesses.Attach(item);
            _context.TblCorrespIllnesses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblCorrespIllnesses.Any(e => e.CorrespIllnessLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblCorrespIllnesses.Where(e => e.CorrespIllnessId == list.Id).First();

            item.CorrespIllnessShort = list.ShortName;
            item.CorrespIllnessLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
