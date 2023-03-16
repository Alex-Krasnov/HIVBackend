using System;

namespace HIVBackend.Models.OutputModel
{
    public class PatientCardMain
    {
        public int PatientId { get; set; }
        public DateOnly? InputDate { get; set; }
        public string? FamilyName { get; set; }
        public string? FirstName { get; set; }
        public string? ThirdName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Sex { get; set; }
        public DateOnly? RegOnDate { get; set; }
        public DateOnly? RegOffDate { get; set;}
        public string? RegOffReason { get; set; }
        public string? UnrzFr { get; set; }
        public string? Region { get; set; }
        public string? CityName { get; set; }
        public string? LocationName { get; set; }
        public string? Phone { get; set; }
        public string? AddrStreat { get; set; }
        public string? AddrExt { get; set; }
        public string? AddrHouse { get; set; }
        public string? AddrFlat { get; set; }
        public string? RegionFact { get; set; }
        public string? CityNameFact { get; set; }
        public string? LocationNameFact { get; set; }
        public string? IndexFact { get; set; }
        public string? AddrStreatFact { get; set; }
        public string? AddrExtFact { get; set; }
        public string? AddrHouseFact { get; set; }
        public string? AddrFlatFact { get; set; }
        public DateOnly? DtRegBeg { get; set; }
        public DateOnly? DtRefEnd { get; set; }
        public string? Country { get; set; }
        public string? Comm { get; set; }
        public decimal? HeightOld { get; set; }
        public decimal? WeightOld { get; set; }
        public string? PlaceCheck { get; set; }
        public string? CodeMKB10 { get; set; }
        public string? CheckCourseShort { get; set; }
        public string? CheckCourseLong { get; set;}
        public string? InfectCourseShort { get; set; }
        public string? InfectCourseLong { get;set; }
        public string? DieCourseShort { get; set; }
        public string? DieCourseLong { get; set; }
        public string? CardNo { get; set; }
        public string? VulnerableGroup { get; set; }
        public bool RegOn { get; set; }
        public bool? HeadPhysician { get; set; }
        public bool? ZamMedPart { get; set; }
        public bool TransfArea { get; set; }
        public DateOnly? TransfAreaDate { get; set; }
        public DateOnly? TransfFederDate { get; set; }
        public DateOnly? UfsinDate { get; set; }
        public DateOnly? DieInputDate { get; set; }
        public DateOnly? DieDate { get; set; }
        public DateOnly? DieAidsDate { get; set; }
        public string? FioChange { get; set; }
        public string? Snils { get; set; }
        public string? ARVT { get; set; }
        public string? Invalid { get; set; }
        public string? Archile { get; set; }
        public string? CodeWord { get; set; }

        public List<string>? ListSex { get; set; }
        public List<string>? ListRegOffReason { get; set; }
        public List<string>? ListRegion { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListPlaceCheck { get; set; }
        public List<string>? ListCodeMKB { get; set; }
        public List<string>? ListCheckCourseShort { get; set; }
        public List<string>? ListCheckCourseLong { get; set; }
        public List<string>? ListInfectCourseShort { get; set; }
        public List<string>? ListInfectCourseLong { get; set; }
        public List<string>? ListDieCourseShort { get; set; }
        public List<string>? ListDieCourseLong { get; set; }
        public List<string>? ListVulnerableGroup { get; set; }
        public List<string>? ListARVT { get; set; }
        public List<string>? ListInvalid { get; set; }
        public List<string>? ListCheckPlace { get; set; }
        public List<string>? ListRes { get; set; }
        public List<string>? ListDesease { get; set; }
        public List<string>? ListStage { get; set; }

        public List<FrmBlot>? Blots { get; set; }
        public List<FrmSecondDeseases>? SecondDeseases { get; set; }
        public List<FrmStage>? Stages { get; set; }
    }

    public class FrmBlot
    {
        public int BlotId { get; set; }
        public int? BlotNo { get; set; }
        public DateOnly? BlotDate { get; set; }
        public string? BlotRes { get; set; }
        public string? CheckPlace { get; set; }
        public bool? First { get; set; }
        public bool? Last { get; set; }
        public bool? Ifa { get; set; }
        public DateOnly? InputDate { get; set; }
    }

    public class FrmStage
    {
        public DateOnly StageDate { get; set; }
        public string? Stage { get; set; }
    }

    public class FrmSecondDeseases
    {
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Deseas { get; set; }
    }
}
