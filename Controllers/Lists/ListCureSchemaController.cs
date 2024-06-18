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
    public class ListCureSchemaController : ControllerBase
    {
        private readonly HivContext _context;
        public ListCureSchemaController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get()
        {
            var list = _context.TblCureSchemas.OrderBy(e => e.CureSchemaLong)
                .Select(e => new { id = e.CureSchemaId, longName = e.CureSchemaLong, shortName = e.CureSchemaShort }).ToList();
            return Ok(new { list, maxId = _context.TblCureSchemas.Max(e => e.CureSchemaId) });
        }

        [HttpGet, Route("GetStructureSchema")]
        [Authorize(Roles = "User")]
        public IActionResult GetStructureSchema(int id)
        {
            var medIncludeSchema = _context.TblSchemaMedicineRs.Where(e => e.CureSchemaId == id).Select(e => e.MedicineId).ToList();
            var medForSchema = _context.TblMedicineForSchemas.Select(e => new MedForSchema
            {
                IncludeFlg = false,
                Name = e.MedforschemaLong,
                Id = e.MedforschemaId
            }).ToList();

            foreach (var item in medForSchema)
            {
                if (medIncludeSchema.Contains(item.Id))
                {
                    var index = medForSchema.FindIndex(e => e.Id == item.Id);
                    medForSchema[index].IncludeFlg = true;
                }
            }
            return Ok(medForSchema.OrderByDescending(e => e.IncludeFlg).ThenBy(e => e.Name).ToList());
        }

        [HttpDelete, Route("Del")]
        [Authorize(Roles = "User")]
        public IActionResult Del(string longName)
        {
            var cureSchema = _context.TblCureSchemas.Where(e => e.CureSchemaLong == longName).First();
            _context.TblCureSchemas.Remove(cureSchema);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create(SchemaMed list)
        {
            var isUniqueName = _context.TblCureSchemas.Any(e => e.CureSchemaLong == list.LongName);

            if (isUniqueName)
                return BadRequest($"Запись {list.LongName} уже существует!");

            List<int> listCureSchemaId = _context.TblCureSchemas.Select(e => e.CureSchemaId).ToList();
            var tblSchemaMedicineRs = _context.TblSchemaMedicineRs.OrderBy(e => e.CureSchemaId).ToList();

            List<string> listSchemaMedId = new();
            foreach (var cureSchemaId in listCureSchemaId)
            {
                var medStr = string.Join(',', tblSchemaMedicineRs.Where(e => e.CureSchemaId == cureSchemaId).Select(e => e.MedicineId).Order().ToList());
                listSchemaMedId.Add(medStr);
            }

            if (listSchemaMedId.Contains(string.Join(',', list.Meds.Order().ToList())))
                return BadRequest($"Запись с такими препаратами уже существует!");

            TblCureSchema tblCureSchema = new()
            {
                CureSchemaId = list.Id,
                CureSchemaShort = list.ShortName,
                CureSchemaLong = list.LongName,
                User1 = User.Identity?.Name,
                Datetime1 = DateOnly.FromDateTime(DateTime.Now)
            };

            List<TblSchemaMedicineR> listSchemas = new();
            foreach (var item in list.Meds)
            {
                listSchemas.Add(new()
                {
                    CureSchemaId = list.Id,
                    MedicineId = item,
                    User1 = User.Identity?.Name,
                    Datetime1 = DateOnly.FromDateTime(DateTime.Now)
                });
            }

            _context.TblSchemaMedicineRs.AddRange(listSchemas);
            _context.TblCureSchemas.Add(tblCureSchema);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(List2Col list)
        {
            var item = _context.TblCureSchemas.Where(e => e.CureSchemaId == list.Id).First();

            if (item.CureSchemaLong != list.LongName)
            {
                var isUniqueName = _context.TblCureSchemas.Any(e => e.CureSchemaLong == list.LongName);

                if (isUniqueName)
                    return BadRequest($"Запись с названием {list.LongName} уже существует!");
            }

            item.CureSchemaShort = list.ShortName;
            item.CureSchemaLong = list.LongName;
            item.User1 = User.Identity?.Name;
            item.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return Ok();

        }

        [HttpPost, Route("UpdateStructureSchema")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateStructureSchema(SchemaMed list)
        {
            var isUniqueName = _context.TblCureSchemas.Any(e => e.CureSchemaLong == list.LongName);

            if (isUniqueName)
                return BadRequest($"Запись {list.LongName} уже существует!");

            List<int> listCureSchemaId = _context.TblCureSchemas.Select(e => e.CureSchemaId).ToList();
            var tblSchemaMedicineRs = _context.TblSchemaMedicineRs.OrderBy(e => e.CureSchemaId).ToList();

            List<string> listSchemaMedId = new();
            foreach (var cureSchemaId in listCureSchemaId)
            {
                var medStr = string.Join(',', tblSchemaMedicineRs.Where(e => e.CureSchemaId == cureSchemaId).Select(e => e.MedicineId).Order().ToList());
                listSchemaMedId.Add(medStr);
            }

            if (listSchemaMedId.Contains(string.Join(',', list.Meds.Order().ToList())))
                return BadRequest($"Запись с такими препаратами уже существует!");

            TblCureSchema tblCureSchema = _context.TblCureSchemas.First(e => e.CureSchemaId == list.Id);
            tblCureSchema.CureSchemaLong = list.LongName;
            tblCureSchema.User1 = User.Identity?.Name;
            tblCureSchema.Datetime1 = DateOnly.FromDateTime(DateTime.Now);

            List<TblSchemaMedicineR> listSchemasForDel = _context.TblSchemaMedicineRs.Where(e => e.CureSchemaId == list.Id).ToList();
            _context.TblSchemaMedicineRs.RemoveRange(listSchemasForDel);

            List<TblSchemaMedicineR> listSchemas = new();
            foreach (var item in list.Meds)
            {
                listSchemas.Add(new()
                {
                    CureSchemaId = list.Id,
                    MedicineId = item,
                    User1 = User.Identity?.Name,
                    Datetime1 = DateOnly.FromDateTime(DateTime.Now)
                });
            }

            _context.TblSchemaMedicineRs.AddRange(listSchemas);
            _context.SaveChanges();
            return Ok();
        }
    }
}
