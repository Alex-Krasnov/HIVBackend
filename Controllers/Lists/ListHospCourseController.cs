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
    public class ListHospCourseController : ControllerBase
    {
        private readonly HivContext _context;
        public ListHospCourseController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblHospCourses.OrderBy(e => e.HospCourseLong)
                .Select(e => new { id = e.HospCourseId, longName = e.HospCourseLong, shortName = e.HospCourseShort }).ToList();
            return Ok(new { list, maxId = _context.TblHospCourses.Max(e => e.HospCourseId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblHospCourses.Where(e => e.HospCourseLong == longName).First();
            _context.TblHospCourses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblHospCourses.Any(e => e.HospCourseLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblHospCourse item = new()
            {
                HospCourseId = list.Id,
                HospCourseShort = list.ShortName,
                HospCourseLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblHospCourses.Attach(item);
            _context.TblHospCourses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblHospCourses.Any(e => e.HospCourseLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblHospCourses.Where(e => e.HospCourseId == list.Id).First();

            item.HospCourseShort = list.ShortName;
            item.HospCourseLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
