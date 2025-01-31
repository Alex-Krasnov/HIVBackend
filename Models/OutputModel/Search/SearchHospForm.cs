using HIVBackend.Data;
using HIVBackend.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchHospForm : BaseSearchForm
    {
        public List<string>? ListSex { get; set; }
        public List<string>? ListRegion { get; set; }
        public List<string>? ListRegionPreset { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListLpu { get; set; }
        public List<string>? ListHospCourse { get; set; }
        public List<string>? ListHospResult { get; set; }

        public SearchHospForm(HivContext _context) : base(_context)
        {
            ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            ListLpu = _context.TblLpus.Select(e => e.LpuLong).OrderBy(e => e).ToList();
            ListHospCourse = _context.TblHospCourses.Select(e => e.HospCourseLong).Select(e => e).OrderBy(e => e).ToList();
            ListHospResult = _context.TblHospResults.Select(e => e.HospResultLong).OrderBy(e => e).ToList();
            ListRegionPreset = EnumExtension.EnumToListOfDescription(typeof(RegionPresetEnum));
        }
    }
}
