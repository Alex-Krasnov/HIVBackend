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
    public class ListCodeMKB10Controller : ControllerBase
    {
        private readonly HivContext _context;
        public ListCodeMKB10Controller(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblCodeMkb10s.OrderBy(e => e.CodeMkb10Long)
                .Select(e => new {id = e.CodeMkb10Id, longName = e.CodeMkb10Long, shortName = e.CodeMkb10Short}).ToList();
            return Ok(new {list = list, maxId = _context.TblCodeMkb10s.Max(e => e.CodeMkb10Id)});
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblCodeMkb10s.Where(e => e.CodeMkb10Long == longName).First();
            _context.TblCodeMkb10s.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblCodeMkb10s.Any(e => e.CodeMkb10Long == list.LongName);

            if(isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblCodeMkb10 item = new()
            {
                CodeMkb10Id = list.Id,
                CodeMkb10Short = list.ShortName,
                CodeMkb10Long = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblCodeMkb10s.Attach(item);
            _context.TblCodeMkb10s.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblCodeMkb10s.Any(e => e.CodeMkb10Long == list.LongName);

            if(isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblCodeMkb10s.Where(e => e.CodeMkb10Id == list.Id).First();

            item.CodeMkb10Short = list.ShortName;
            item.CodeMkb10Long = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();
            
        }
    }
}
