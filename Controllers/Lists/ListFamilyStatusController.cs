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
    public class ListFamilyStatusController : ControllerBase
    {
        private readonly HivContext _context;
        public ListFamilyStatusController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListFamilyStatuses.OrderBy(e => e.FammilyStatusName)
                .Select(e => new { id = e.FamilyStatusId, longName = e.FammilyStatusName }).ToList();
            return Ok(new { list, maxId = _context.TblListFamilyStatuses.Max(e => e.FamilyStatusId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListFamilyStatuses.Where(e => e.FammilyStatusName == longName).First();
            _context.TblListFamilyStatuses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListFamilyStatuses.Any(e => e.FammilyStatusName == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListFamilyStatus item = new()
            {
                FamilyStatusId = list.Id,
                FammilyStatusName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListFamilyStatuses.Attach(item);
            _context.TblListFamilyStatuses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListFamilyStatuses.Any(e => e.FammilyStatusName == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListFamilyStatuses.Where(e => e.FamilyStatusId == list.Id).First();

            item.FammilyStatusName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
