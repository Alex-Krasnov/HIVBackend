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
    public class ListSituationDetectController : ControllerBase
    {
        private readonly HivContext _context;
        public ListSituationDetectController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListSituationDetects.OrderBy(e => e.SituationDetectName)
                .Select(e => new { id = e.SituationDetectId, longName = e.SituationDetectName }).ToList();
            return Ok(new { list, maxId = _context.TblListSituationDetects.Max(e => e.SituationDetectId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListSituationDetects.Where(e => e.SituationDetectName == longName).First();
            _context.TblListSituationDetects.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListSituationDetects.Any(e => e.SituationDetectName == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListSituationDetect item = new()
            {
                SituationDetectId = list.Id,
                SituationDetectName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListSituationDetects.Attach(item);
            _context.TblListSituationDetects.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListSituationDetects.Any(e => e.SituationDetectName == list.LongName);

            if (!isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListSituationDetects.Where(e => e.SituationDetectId == list.Id).First();

            item.SituationDetectName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}