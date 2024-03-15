using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListShowillnesController : ControllerBase
    {
        private readonly HivContext _context;
        public ListShowillnesController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblShowIllnesses.OrderBy(e => e.ShowIllnessLong)
                .Select(e => new {id = e.ShowIllnessId, longName = e.ShowIllnessLong, shortName = e.ShowIllnessShort}).ToList();
            return Ok(new {list = list, maxId = _context.TblShowIllnesses.Max(e => e.ShowIllnessId)});
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblShowIllnesses.Where(e => e.ShowIllnessLong == longName).First();
            _context.TblShowIllnesses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblShowIllnesses.Any(e => e.ShowIllnessLong == list.LongName);

            if(isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblShowIllness item = new()
            {
                ShowIllnessId = list.Id,
                ShowIllnessShort = list.ShortName,
                ShowIllnessLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblShowIllnesses.Attach(item);
            _context.TblShowIllnesses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblShowIllnesses.Any(e => e.ShowIllnessLong == list.LongName);

            if(isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblShowIllnesses.Where(e => e.ShowIllnessId == list.Id).First();

            item.ShowIllnessShort = list.ShortName;
            item.ShowIllnessLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();
            
        }
    }
}
