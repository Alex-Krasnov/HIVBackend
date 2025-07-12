using HIVBackend.Data;
using HIVBackend.Models.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchTreatmentForm : BaseSearchForm
    {
        public List<string?>? ListSex { get; set; }
        public List<string?>? ListRegion { get; set; }
        public List<string> ListRegionPreset { get; set; }
        public List<string?>? ListCountry { get; set; }
        public List<string?>? ListRegOff { get; set; }
        public List<string?>? ListStage { get; set; }
        public List<string?>? ListDieCourse { get; set; }
        public List<string>? ListDiePreset { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string?>? ListInfectCourse { get; set; }
        public List<string?>? ListShowIllness { get; set; }
        public List<string?>? ListInvalid { get; set; }
        public List<string?>? ListCorrespIllness { get; set; }
        public List<string?>? ListSchema { get; set; }
        public List<string?>? ListSchemaMedecine { get; set; }
        public List<string?>? ListMedecine { get; set; }
        public List<string?>? ListDoctor { get; set; }
        public List<string?>? ListSchemaChange { get; set; }
        public List<string?>? ListFinSourse { get; set; }
        public List<string?>? ListArvt { get; set; }
        public List<string?>? ListRangeTherapy { get; set; }
        public List<string?>? ListYN { get; set; }
        public List<string?>? ListResIb { get; set; }
        public List<string>? ListSelectBlot { get; set; }

        public SearchTreatmentForm(HivContext _context) : base(_context)
        {
            ListSex = _context.TblSexes.Select(e => e.SexShort).ToList();
            ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            ListRegOff = _context.TblInfectCourses.Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong).ToList();
            ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            ListSchema = _context.TblCureSchemas.Select(e => e.CureSchemaLong).OrderBy(e => e).ToList();
            ListInvalid = _context.TblInvalids.Select(e => e.InvalidLong).OrderBy(e => e).ToList();
            ListCorrespIllness = _context.TblCorrespIllnesses.Select(e => e.CorrespIllnessLong).OrderBy(e => e).ToList();
            ListSchemaMedecine = _context.TblMedicineForSchemas.Select(e => e.MedforschemaLong).OrderBy(e => e).ToList();
            ListMedecine = _context.TblMedicines.Where(e => e.IsHivMed).Select(e => e.MedicineLong).OrderBy(e => e).ToList();
            ListDoctor = _context.TblDoctors.Select(e => e.DoctorLong).OrderBy(e => e).ToList();
            ListSchemaChange = _context.TblCureChanges.Select(e => e.CureChangeLong).OrderBy(e => e).ToList();
            ListFinSourse = _context.TblFinSources.Select(e => e.FinSourceLong).OrderBy(e => e).ToList();
            ListRangeTherapy = _context.TblRangeTherapies.Select(e => e.RangeTherapyLong).OrderBy(e => e).ToList();
            ListDieCourse = _context.TblTempDieCureMkb10lists.Select(e => e.DieCourseLong).OrderBy(e => e).ToList();
            ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();

            ListRegionPreset = EnumExtension.EnumToListOfDescription(typeof(RegionPresetEnum));
            ListDiePreset = EnumExtension.EnumToListOfDescription(typeof(DiePresetEnum));
            ListSelectBlot = EnumExtension.EnumToListOfDescription(typeof(SelectBlotEnum));
        }
    }
}
