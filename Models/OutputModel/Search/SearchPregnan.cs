using HIVBackend.Data;
using HIVBackend.Models.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchPregnantForm : BaseSearchForm
    {
        public List<string>? ListRegion { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListShowIllness { get; set; }
        public List<string>? ListPregCheck { get; set; }
        public List<string>? ListBirthType { get; set; }
        public List<string>? ListSchema { get; set; }
        public List<string>? ListMedecineForSchema { get; set; }
        public List<string>? ListArvt { get; set; }
        public List<string>? ListMaterHome { get; set; }
        public List<string>? ListDiePreset { get; set; }
        public List<string>? ListRegionPreset { get; set; }

        public SearchPregnantForm(HivContext _context) : base(_context)
        {
            ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            ListPregCheck = _context.TblPregChecks.Select(e => e.PregCheckLong).OrderBy(e => e).ToList();
            ListBirthType = _context.TblBirthTypes.Select(e => e.BirthTypeLong).OrderBy(e => e).ToList();
            ListSchema = _context.TblCureSchemas.Select(e => e.CureSchemaLong).OrderBy(e => e).ToList();
            ListMedecineForSchema = _context.TblMedicineForSchemas.Select(e => e.MedforschemaLong).OrderBy(e => e).ToList();
            ListMaterHome = _context.TblMaterHomes.Select(e => e.MaterhomeLong).OrderBy(e => e).ToList();

            ListRegionPreset = EnumExtension.EnumToListOfDescription(typeof(RegionPresetEnum));
            ListDiePreset = EnumExtension.EnumToListOfDescription(typeof(DiePresetEnum));
        }
    }
}
