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
    public class ListMedForSchemaController : ControllerBase
    {
        private readonly HivContext _context;
        public ListMedForSchemaController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblMedicineForSchemas.OrderBy(e => e.MedforschemaLong)
                .Select(e => new {id = e.MedforschemaId, longName = e.MedforschemaLong, shortName = e.MedforschemaShort}).ToList();
            return Ok(new { list, maxId = _context.TblMedicineForSchemas.Max(e => e.MedforschemaId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblMedicineForSchemas.Where(e => e.MedforschemaLong == longName).First();
            _context.TblMedicineForSchemas.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblMedicineForSchemas.Any(e => e.MedforschemaLong == list.LongName);

            if(isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblMedicineForSchema item = new()
            {
                MedforschemaId = list.Id,
                MedforschemaShort = list.ShortName,
                MedforschemaLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblMedicineForSchemas.Attach(item);
            _context.TblMedicineForSchemas.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblMedicineForSchemas.Any(e => e.MedforschemaLong == list.LongName);

            if(isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblMedicineForSchemas.Where(e => e.MedforschemaId == list.Id).First();

            item.MedforschemaShort = list.ShortName;
            item.MedforschemaLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();
            
        }
    }
}
