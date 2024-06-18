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
    public class ListVulnerableGroupController : ControllerBase
    {
        private readonly HivContext _context;
        public ListVulnerableGroupController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblListVulnerableGroups.OrderBy(e => e.VulnerableGroupName)
                .Select(e => new { id = e.VulnerableGroupId, longName = e.VulnerableGroupName }).ToList();
            return Ok(new { list, maxId = _context.TblListVulnerableGroups.Max(e => e.VulnerableGroupId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblListVulnerableGroups.Where(e => e.VulnerableGroupName == longName).First();
            _context.TblListVulnerableGroups.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(List2Col list)
        {
            var isUnique = _context.TblListVulnerableGroups.Any(e => e.VulnerableGroupName == list.LongName);

            if (isUnique)
                return BadRequest($"Запись {list.LongName} уже существует!");

            TblListVulnerableGroup item = new()
            {
                VulnerableGroupId = list.Id,
                VulnerableGroupName = list.LongName,
                User = User.Identity?.Name,
                Datetime = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblListVulnerableGroups.Attach(item);
            _context.TblListVulnerableGroups.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var isExist = _context.TblListVulnerableGroups.Any(e => e.VulnerableGroupName == list.LongName);

            if (isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblListVulnerableGroups.Where(e => e.VulnerableGroupId == list.Id).First();

            item.VulnerableGroupName = list.LongName;
            item.User = User.Identity?.Name;
            item.Datetime = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}
