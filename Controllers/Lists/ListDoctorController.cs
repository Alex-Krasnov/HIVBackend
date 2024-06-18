using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using DocumentFormat.OpenXml.Bibliography;
using System;
using DocumentFormat.OpenXml.Wordprocessing;

namespace HIVBackend.Controllers.Lists
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListDoctorController : ControllerBase
    {
        private readonly HivContext _context;
        public ListDoctorController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblDoctors.OrderBy(e => e.DoctorLong)
                .Select(e => new
                {
                    Id = e.DoctorId,
                    ShortName = e.DoctorShort,
                    LongName = e.DoctorLong,
                    DoctorCode = e.Ext1Pcod,
                    e.DoctorSnils
                }).ToList();
            return Ok(new { list, maxId = _context.TblDoctors.Max(e => e.DoctorId) });
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(int doctroId)
        {
            var item = _context.TblDoctors.Where(e => e.DoctorId == doctroId).First();
            _context.TblDoctors.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(Doctor list)
        {
            var isUnique = _context.TblDoctors.Any(e => e.DoctorId == list.Id);

            if (isUnique)
                return BadRequest($"Запись {list.Id} уже существует!");

            TblDoctor item = new()
            {
                DoctorId = list.Id,
                DoctorShort = list.ShortName,
                DoctorLong = list.LongName,
                Ext1Pcod = list.DoctorCode,
                DoctorSnils = list.DoctorSnils,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.TblDoctors.Attach(item);
            _context.TblDoctors.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(Doctor list)
        {
            var isExist = _context.TblDoctors.Any(e => e.DoctorId == list.Id);

            if (!isExist)
                return BadRequest($"Запись {list.Id} не найдена!");

            var item = _context.TblDoctors.Where(e => e.DoctorId == list.Id).First();

            item.DoctorId = list.Id;
            item.DoctorShort = list.ShortName;
            item.DoctorLong = list.LongName;
            item.Ext1Pcod = list.DoctorCode;
            item.DoctorSnils = list.DoctorSnils;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }
    }
}