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
    public class ListTransmisionMechController : ControllerBase
    {
        private readonly HivContext _context;
        public ListTransmisionMechController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListTransmisionMeches.OrderBy(e => e.TransmisiomMechName)
                .Select(e => new { id = e.TransmissionMechId, longName = e.TransmisiomMechName }).ToList();
            return Ok(new { list, maxId = _context.TblListTransmisionMeches.Max(e => e.TransmissionMechId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListTransmisionMeches.Where(e => e.TransmisiomMechName == longName).First();
            _context.TblListTransmisionMeches.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListTransmisionMeches.Any(e => e.TransmisiomMechName == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListTransmisionMech item = new()
            {
                TransmissionMechId = list.Id,
                TransmisiomMechName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListTransmisionMeches.Attach(item);
            _context.TblListTransmisionMeches.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListTransmisionMeches.Any(e => e.TransmisiomMechName == list.LongName);

            if (!isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListTransmisionMeches.Where(e => e.TransmissionMechId == list.Id).First();

            item.TransmisiomMechName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}