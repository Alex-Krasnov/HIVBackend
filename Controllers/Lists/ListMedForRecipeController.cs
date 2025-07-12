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
    public class ListMedForRecipeController : ControllerBase
    {
        private readonly HivContext _context;
        public ListMedForRecipeController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblMedicines.OrderBy(e => e.MedicineLong)
                .Select(e => new { id = e.MedicineId, longName = e.MedicineLong, IsActive = e.IsHivMed })
                .ToList();
            return Ok(new { list, maxId = _context.TblMedicines.Max(e => e.MedicineId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblMedicines.Where(e => e.MedicineLong == longName).First();
            _context.TblMedicines.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List3Col list)
        {
            var isUnique = _context.TblMedicines.Any(e => e.MedicineLong == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblMedicine item = new()
            {
                MedicineId = list.Id,
                MedicineLong = list.LongName,
                User1 = User.Identity?.Name,
                IsHivMed = list.IsActive,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblMedicines.Attach(item);
            _context.TblMedicines.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List3Col list)
        {
            var isExist = _context.TblMedicines.Any(e => e.MedicineLong == list.LongName);

            if (!isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblMedicines.Where(e => e.MedicineId == list.Id).First();

            item.MedicineLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);
            item.IsHivMed = list.IsActive;

            _context.SaveChanges();
            return Ok();

        }
    }
}