using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Text.Json.Nodes;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientCardGeneralInfController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardGeneralInfController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<IEnumerable<TblPatientCard>> Get()
        {
            var r = Request;
            var a = await _context.TblPatientCards.Where(e => e.PatientId == 1).ToListAsync();
            //if (a is null) return Results.NotFound();

            return a;
        }
    }
}
