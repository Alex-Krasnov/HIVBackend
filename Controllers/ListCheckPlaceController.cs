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
    public class ListCheckPlaceController : ControllerBase
    {
        private readonly HivContext _context;
        public ListCheckPlaceController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblCheckPlaces.OrderBy(e => e.CheckPlaceLong)
                .Select(e => new {id = e.CheckPlaceId, longName = e.CheckPlaceLong, shortName = e.CheckPlaceShort}).ToList();
            return Ok(new {list = list, maxId = _context.TblCheckPlaces.Max(e => e.CheckPlaceId)});
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblCheckPlaces.Where(e => e.CheckPlaceLong == longName).First();
            _context.TblCheckPlaces.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblCheckPlaces.Any(e => e.CheckPlaceLong == list.LongName);

            if(isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblCheckPlace item = new()
            {
                CheckPlaceId = list.Id,
                CheckPlaceShort = list.ShortName,
                CheckPlaceLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblCheckPlaces.Attach(item);
            _context.TblCheckPlaces.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblCheckPlaces.Any(e => e.CheckPlaceLong == list.LongName);

            if(isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblCheckPlaces.Where(e => e.CheckPlaceId == list.Id).First();

            item.CheckPlaceShort = list.ShortName;
            item.CheckPlaceLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();
            
        }
    }
}
