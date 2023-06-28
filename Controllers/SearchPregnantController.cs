using HIVBackend.Data;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchPregnantController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchPregnantController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchPregnant outModel = new();

            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseShort != null ).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => e.CheckCourseLong).OrderBy(e => e).ToList();
            outModel.ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };
            outModel.ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            outModel.ListPregCheck = _context.TblPregChecks.Select(e => e.PregCheckLong).OrderBy(e => e).ToList();
            outModel.ListBirthType = _context.TblBirthTypes.Select(e => e.BirthTypeLong).OrderBy(e => e).ToList();
            outModel.ListSchema = _context.TblCureSchemas.Select(e => e.CureSchemaLong).OrderBy(e => e).ToList();
            outModel.ListMedecineForSchema = _context.TblMedicineForSchemas.Select(e => e.MedforschemaLong).OrderBy(e => e).ToList();
            outModel.ListMaterHome = _context.TblMaterHomes.Select(e => e.MaterhomeLong).OrderBy(e => e).ToList();

            return Ok(outModel);
        }
    }
}
