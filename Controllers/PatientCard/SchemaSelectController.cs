using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemaSelectController : ControllerBase
    {
        private readonly HivContext _context;
        public SchemaSelectController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            List<SchemaSelect> list = new List<SchemaSelect>();
            foreach (var item in _context.TblMedicineForSchemas.ToList())
            {
                list.Add(new()
                {
                    MedicineName = item.MedforschemaLong,
                    SchemaId = _context.TblSchemaMedicineRs.Where(e => e.MedicineId == item.MedforschemaId).Select(e => e.CureSchemaId).ToArray(),
                    Id = item.MedforschemaId
                });
            }
            return Ok(list.OrderBy(e => e.MedicineName));
        }

        [HttpPost, Route("GetSchema")]
        [Authorize(Roles = "User")]
        public IActionResult GetSchema(ForGetSchema lst)
        {
            var a = (from e in _context.TblSchemaMedicineRs
                     where lst.id.Contains(e.MedicineId)
                     group e by e.CureSchemaId into g
                     select new { g.Key }).ToList();

            foreach (var item in a)
            {
                List<int> meds = _context.TblSchemaMedicineRs.Where(e => e.CureSchemaId == item.Key).Select(e => e.MedicineId).ToList();
                if (lst.id.OrderBy(e => e).SequenceEqual(meds.OrderBy(e => e)))
                {
                    var b = _context.TblCureSchemas.First(e => e.CureSchemaId == item.Key).CureSchemaLong;
                    return Ok(new { b });
                }
            }
            return BadRequest("Ошибка");

        }

        public class ForGetSchema
        {
            public List<int> id { get; set; }
        }

    }
}
