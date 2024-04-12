using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.DBModels;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListCallStatusController : ControllerBase
    {
        private readonly HivContext _context;
        public ListCallStatusController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListCallStatuses.OrderBy(e => e.LongName)
                .Select(e => new {id = e.CallStatusId, longName = e.LongName, shortName = e.ShortName}).ToList();
            return Ok(new {list = list, maxId = _context.TblListCallStatuses.Max(e => e.CallStatusId)});
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListCallStatuses.Where(e => e.LongName == longName).First();
            _context.TblListCallStatuses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListCallStatuses.Any(e => e.LongName == list.LongName);

            if(isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListCallStatus item = new()
            {
                CallStatusId = list.Id,
                ShortName = list.ShortName,
                LongName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListCallStatuses.Attach(item);
            _context.TblListCallStatuses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListCallStatuses.Any(e => e.LongName == list.LongName);

            if(isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListCallStatuses.Where(e => e.CallStatusId == list.Id).First();

            item.ShortName = list.ShortName;
            item.LongName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();
        }
    }
}
