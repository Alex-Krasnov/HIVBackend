using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using DocumentFormat.OpenXml.Bibliography;
using System;

namespace HIVBackend.Controllers.Lists
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListUserController : ControllerBase
    {
        private readonly HivContext _context;
        public ListUserController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblUsers.OrderBy(e => e.Uid)
                .Select(e => new User
                {
                    Uid = e.Uid,
                    Pwd = e.Pwd,
                    UserName = e.UserName,
                    Excel = e.Excel1,
                    Write = e.Write1,
                    Admin = e.Admin1,
                    Deleter = e.Delete1,
                    Klassif = e.Klassif1
                }).ToList();
            return Ok(list);
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var item = _context.TblUsers.Where(e => e.Uid == longName).First();
            _context.TblUsers.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(User list)
        {
            var isUnique = _context.TblUsers.Any(e => e.Uid == list.Uid);

            if (isUnique)
                return BadRequest($"Запись {list.Uid} уже существует!");

            TblUser item = new()
            {
                Uid = list.Uid,
                Pwd = list.Pwd,
                UserName = list.UserName,
                Excel1 = list.Excel,
                Write1 = list.Write,
                Admin1 = list.Admin,
                Delete1 = list.Deleter,
                Klassif1 = list.Klassif,
                RefreshTokenExpiryTime = DateTime.Now.ToUniversalTime(),
                User1 = User.Identity?.Name,
                Datetime1 = DateTime.Now.ToUniversalTime()
            };

            _context.TblUsers.Attach(item);
            _context.TblUsers.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(User list)
        {
            var isExist = _context.TblUsers.Any(e => e.Uid == list.Uid);

            if (!isExist)
                return BadRequest($"Запись {list.Uid} не найдена!");

            var item = _context.TblUsers.Where(e => e.Uid == list.Uid).First();

            item.Pwd = list.Pwd;
            item.UserName = list.UserName;
            item.Excel1 = list.Excel;
            item.Write1 = list.Write;
            item.Admin1 = list.Admin;
            item.Delete1 = list.Deleter;
            item.Klassif1 = list.Klassif;
            item.RefreshTokenExpiryTime = DateTime.Now.ToUniversalTime();
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateTime.Now.ToUniversalTime();

            _context.SaveChanges();
            return Ok();

        }
    }
}