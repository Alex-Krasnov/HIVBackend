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
    public class ListEmploymentController : ControllerBase
    {
        private readonly HivContext _context;
        public ListEmploymentController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListEmployments.OrderBy(e => e.EmploymentName)
                .Select(e => new { id = e.EmploymentId, longName = e.EmploymentName }).ToList();
            return Ok(new { list, maxId = _context.TblListEmployments.Max(e => e.EmploymentId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListEmployments.Where(e => e.EmploymentName == longName).First();
            _context.TblListEmployments.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListEmployments.Any(e => e.EmploymentName == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListEmployment item = new()
            {
                EmploymentId = list.Id,
                EmploymentName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListEmployments.Attach(item);
            _context.TblListEmployments.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListEmployments.Any(e => e.EmploymentName == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListEmployments.Where(e => e.EmploymentId == list.Id).First();

            item.EmploymentName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}