using HIVBackend.Data;
using HIVBackend.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchNonresidentForm : BaseSearchForm
    {
        public List<string>? ListSex { get; set; }
        public List<string>? ListRegion { get; set; }
        public List<string>? ListRegionPreset { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListShowIllness { get; set; }

        public SearchNonresidentForm(HivContext _context) : base(_context)
        {
            ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            ListRegionPreset = EnumExtension.EnumToListOfDescription(typeof(RegionPresetEnum));
        }
    }
}
