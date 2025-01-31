using HIVBackend.Data;
using HIVBackend.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchMainInfForm : BaseSearchForm
    {
        public List<string>? ListSex { get; set; }
        public List<string>? ListRegion { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListRegOff { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListCheckPlace { get; set; }//blot
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListDieCourse { get; set; }
        public List<string>? ListShowIllness { get; set; }
        public List<string>? ListResIb { get; set; }
        public List<string>? ListSelectBlot { get; set; }
        public List<string>? ListHospCourse { get; set; }
        public List<string>? ListAge { get; set; }
        public List<string>? ListArvt { get; set; }
        public List<string>? ListCodeMKB10 { get; set; }
        public List<string>? ListYN { get; set; }
        public List<string>? ListAids12 { get; set; }
        public List<string>? ListChemop { get; set; }
        public List<string>? ListDiePreset { get; set; }
        public List<string>? ListRegionPreset { get; set; }

        public SearchMainInfForm(HivContext _context) : base(_context)
        {
            ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            ListRegOff = _context.TblInfectCourses.Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListCheckPlace = _context.TblCheckPlaces.Select(e => e.CheckPlaceLong).OrderBy(e => e).ToList();
            ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            ListDieCourse = _context.TblTempDieCureMkb10lists.Select(e => e.DieCourseLong).OrderBy(e => e).ToList();
            ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();
            ListHospCourse = _context.TblHospCourses.Select(e => e.HospCourseLong).OrderBy(e => e).ToList();
            ListAge = _context.TblAgegrs.Select(e => e.AgegrLong).ToList();
            ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            ListCodeMKB10 = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long).OrderBy(e => e).ToList();
            ListYN = _context.TblListYns.Select(e => e.YNName).OrderBy(e => e).ToList();
            ListAids12 = _context.TblAids12s.Select(e => e.Aids12Long).OrderBy(e => e).ToList();
            ListChemop = _context.TblChemops.Select(e => e.ChemopLong).OrderBy(e => e).ToList();

            ListRegionPreset = EnumExtension.EnumToListOfDescription(typeof(RegionPresetEnum));
            ListDiePreset = EnumExtension.EnumToListOfDescription(typeof(DiePresetEnum));
            ListSelectBlot = EnumExtension.EnumToListOfDescription(typeof(SelectBlotEnum));
        }
    }
}
