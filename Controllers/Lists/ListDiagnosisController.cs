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
    public class ListDiagnosisController : ControllerBase
    {
        private readonly HivContext _context;
        public ListDiagnosisController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblDiagnoses.OrderBy(e => e.DiagnosisLong)
                .Select(e => new { id = e.DiagnosisId, longName = e.DiagnosisLong, shortName = e.DiagnosisShort }).ToList();
            return Ok(new { list, maxId = _context.TblDiagnoses.Max(e => e.DiagnosisId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblDiagnoses.Where(e => e.DiagnosisLong == longName).First();
            _context.TblDiagnoses.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblDiagnoses.Any(e => e.DiagnosisLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblDiagnosis item = new()
            {
                DiagnosisId = list.Id,
                DiagnosisShort = list.ShortName,
                DiagnosisLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblDiagnoses.Attach(item);
            _context.TblDiagnoses.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblDiagnoses.Any(e => e.DiagnosisLong == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblDiagnoses.Where(e => e.DiagnosisId == list.Id).First();

            item.DiagnosisShort = list.ShortName;
            item.DiagnosisLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
