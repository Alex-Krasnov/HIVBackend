using HIVBackend.Data;
using HIVBackend.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchEpidForm : BaseSearchForm
    {
        public List<string>? ListSex { get; set; }
        public List<string>? ListRegion { get; set; }
        public List<string>? ListRegionPreset { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListCheckPlace { get; set; }//blot
        public List<string>? ListRegOff { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListDieCourse { get; set; }
        public List<string>? ListDiePreset { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListShowIllness { get; set; }
        public List<string>? ListResIb { get; set; }
        public List<string>? ListSelectBlot { get; set; }
        public List<string>? ListHospCourse { get; set; }
        public List<string>? ListAge { get; set; }
        public List<string>? ListArvt { get; set; }
        public List<string>? ListCodeMKB10 { get; set; }
        public List<string>? ListAids12 { get; set; }
        public List<string>? ListEducation { get; set; }
        public List<string>? ListFamilyStatus { get; set; }
        public List<string>? ListEmployment { get; set; }
        public List<string>? ListTrans { get; set; }
        public List<string>? ListPlaceCheck { get; set; }
        public List<string>? ListSituationDetected { get; set; }
        public List<string>? ListTransmisionMech { get; set; }
        public List<string>? ListVulnerableGroup { get; set; }
        public List<string>? ListCovidVac { get; set; }
        public List<string>? ListMkb10Covid { get; set; }
        public List<string>? ListContactType { get; set; }
        public List<string>? ListCallStatus { get; set; }

        public SearchEpidForm(HivContext _context) : base(_context)
        {
            ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            ListCheckPlace = _context.TblCheckPlaces.Select(e => e.CheckPlaceLong).OrderBy(e => e).ToList();
            ListRegOff = _context.TblInfectCourses.Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong).ToList();
            ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            ListDieCourse = _context.TblTempDieCureMkb10lists.Select(e => e.DieCourseLong).OrderBy(e => e).ToList();
            ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();
            ListHospCourse = _context.TblHospCourses.Select(e => e.HospCourseLong).OrderBy(e => e).ToList();
            ListAge = _context.TblAgegrs.Select(e => e.AgegrLong).ToList();
            ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            ListCodeMKB10 = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long).OrderBy(e => e).ToList();
            ListAids12 = _context.TblAids12s.Select(e => e.Aids12Long).OrderBy(e => e).ToList();
            ListEducation = _context.TblListEducations.Select(e => e.EduName).OrderBy(e => e).ToList();
            ListFamilyStatus = _context.TblListFamilyStatuses.Select(e => e.FammilyStatusName).OrderBy(e => e).ToList();
            ListEmployment = _context.TblListEmployments.Select(e => e.EmploymentName).OrderBy(e => e).ToList();
            ListTrans = _context.TblListTrans.Select(e => e.TransName).OrderBy(e => e).ToList();
            ListPlaceCheck = _context.TblListPlaceChecks.Select(e => e.PlaceCheckName).OrderBy(e => e).ToList();
            ListSituationDetected = _context.TblListSituationDetects.Select(e => e.SituationDetectName).OrderBy(e => e).ToList();
            ListTransmisionMech = _context.TblListTransmisionMeches.Select(e => e.TransmisiomMechName).OrderBy(e => e).ToList();
            ListVulnerableGroup = _context.TblListVulnerableGroups.Select(e => e.VulnerableGroupName).OrderBy(e => e).ToList();
            ListCovidVac = _context.TblListVacs.Select(e => e.VacName).OrderBy(e => e).ToList();
            ListMkb10Covid = _context.TblListMkb10Covids.Select(e => e.Mkb10ShortName).OrderBy(e => e).ToList();
            ListContactType = _context.TblInfectCourses.Where(e => e.InfectCourseId == 104 || e.InfectCourseId == 100).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            ListCallStatus = _context.TblListCallStatuses.Where(e => e.LongName != null).Select(e => e.LongName).OrderBy(e => e).ToList();
            
            ListRegionPreset = EnumExtension.EnumToListOfDescription(typeof(RegionPresetEnum));
            ListDiePreset = EnumExtension.EnumToListOfDescription(typeof(DiePresetEnum));
            ListSelectBlot = EnumExtension.EnumToListOfDescription(typeof(SelectBlotEnum));
        }
    }
}
