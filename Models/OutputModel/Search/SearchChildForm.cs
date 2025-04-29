using HIVBackend.Data;
using HIVBackend.Models.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchChildForm : BaseSearchForm
    {
        public List<string>? ListRegion { get; set; }
        public List<string>? ListRegionPreset { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListRegOff { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListShowIllness { get; set; }
        public List<string>? ListCodeMKB10 { get; set; }
        public List<string>? ListFamilyType { get; set; }
        public List<string>? ListChildPlace { get; set; }
        public List<string>? ListPhp { get; set; }
        public List<string>? ListSex { get; set; }
        public List<string>? ListArvt { get; set; }
        public List<string>? ListMaterhome { get; set; }
        public List<string>? ListYN { get; set; }

        public SearchChildForm(HivContext _context) : base(_context)
        {
            ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            ListRegOff = _context.TblInfectCourses.Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            ListCodeMKB10 = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long).OrderBy(e => e).ToList();
            ListFamilyType = _context.TblFamilyTypes.Select(e => e.FamilyTypeLong).OrderBy(e => e).ToList();
            ListChildPlace = _context.TblChildPlaces.Select(e => e.ChildPlaceLong).OrderBy(e => e).ToList();
            ListPhp = _context.TblChildPhps.Select(e => e.ChildPhpLong).OrderBy(e => e).ToList();
            ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            ListMaterhome = _context.TblMaterHomes.Select(e => e.MaterhomeLong).OrderBy(e => e).ToList();
            ListYN = _context.TblListYns.Select(e => e.YNName).OrderBy(e => e).ToList();

            ListRegionPreset = EnumExtension.EnumToListOfDescription(typeof(RegionPresetEnum));
        }
    }
}
