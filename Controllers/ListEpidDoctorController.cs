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
    public class ListEpidDoctorController : ControllerBase
    {
        private readonly HivContext _context;
        public ListEpidDoctorController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListEpidDoctors.OrderBy(e => e.DoctorName)
                .Select(e => new {id = e.IdDoctor, longName = e.DoctorName, shortName = e.DoctorSnils}).ToList();
            return Ok(new {list = list, maxId = _context.TblListEpidDoctors.Max(e => e.IdDoctor)});
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListEpidDoctors.Where(e => e.DoctorName == longName).First();
            _context.TblListEpidDoctors.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListEpidDoctors.Any(e => e.DoctorName == list.LongName);

            if(isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListEpidDoctor item = new()
            {
                IdDoctor = list.Id,
                DoctorSnils = list.ShortName,
                DoctorName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListEpidDoctors.Attach(item);
            _context.TblListEpidDoctors.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListEpidDoctors.Any(e => e.DoctorName == list.LongName);

            if(isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListEpidDoctors.Where(e => e.IdDoctor == list.Id).First();

            item.DoctorSnils = list.ShortName;
            item.DoctorName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();
            
        }
    }
}
