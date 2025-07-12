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
    public class ListInfectCourseController : ControllerBase
    {
        private readonly HivContext _context;
        public ListInfectCourseController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblInfectCourses.OrderBy(e => e.InfectCourseLong)
                .Select(e => new { id = e.InfectCourseId, longName = e.InfectCourseLong, shortName = e.InfectCourseShort }).ToList();
            return Ok(new { list, maxId = _context.TblInfectCourses.Max(e => e.InfectCourseId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblInfectCourses.Where(e => e.InfectCourseLong == longName).First();
            _context.TblInfectCourses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblInfectCourses.Any(e => e.InfectCourseLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblInfectCourse item = new()
            {
                InfectCourseId = list.Id,
                InfectCourseShort = list.ShortName,
                InfectCourseLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblInfectCourses.Attach(item);
            _context.TblInfectCourses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblInfectCourses.Any(e => e.InfectCourseLong == list.LongName);

            if (!isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblInfectCourses.Where(e => e.InfectCourseId == list.Id).First();

            item.InfectCourseShort = list.ShortName;
            item.InfectCourseLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
