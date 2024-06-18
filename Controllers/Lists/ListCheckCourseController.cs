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
    public class ListCheckCourseController : ControllerBase
    {
        private readonly HivContext _context;
        public ListCheckCourseController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblCheckCourses.OrderBy(e => e.CheckCourseLong)
                .Select(e => new { id = e.CheckCourseId, longName = e.CheckCourseLong, shortName = e.CheckCourseShort }).ToList();
            return Ok(new { list, maxId = _context.TblCheckCourses.Max(e => e.CheckCourseId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblCheckCourses.Where(e => e.CheckCourseLong == longName).First();
            _context.TblCheckCourses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblCheckCourses.Any(e => e.CheckCourseLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblCheckCourse item = new()
            {
                CheckCourseId = list.Id,
                CheckCourseShort = list.ShortName,
                CheckCourseLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblCheckCourses.Attach(item);
            _context.TblCheckCourses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblCheckCourses.Any(e => e.CheckCourseLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblCheckCourses.Where(e => e.CheckCourseId == list.Id).First();

            item.CheckCourseShort = list.ShortName;
            item.CheckCourseLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
