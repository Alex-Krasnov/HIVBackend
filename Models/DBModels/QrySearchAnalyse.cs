namespace HIVBackend.Models.DBModuls;
public partial class QrySearchAnalyse
{
    public int PatientId { get; set; }
    public DateOnly? InputDate { get; set; }
    public string? FamilyName { get; set; }
    public string? FirstName { get; set; }
    public string? ThirdName { get; set; }
    public string? SexShort { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? RegionLong { get; set; }
    public int? RegtypeId { get; set; }
    public string? RegionLongFact { get; set; }
    public int? FactRegtypeId { get; set; }
    public string? CountryLong { get; set; }
    public string? CityName { get; set; }
    public string? LocationName { get; set; }
    public string? AddrInd { get; set; }
    public string? AddrStreet { get; set; }
    public string? AddrHouse { get; set; }
    public string? AddrExt { get; set; }
    public string? AddrFlat { get; set; }
    public DateOnly? RegOnDate { get; set; }
    public DateOnly? RegOffDate { get; set; }
    public string? RegOff { get; set; }
    public string? DiagnosisLong { get; set; }
    public DateOnly? DieDate { get; set; }
    public DateOnly? DieAidsDate { get; set; }
    public string? DieCourseShort { get; set; }
    public string? DieCourseLong { get; set; }
    public int? DethtypeId { get; set; }
    public string? CheckCourseLong { get; set; }
    public string? InfectCourseLong { get; set; }
    public string? ShowIllnessLong { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? TransfAreaDate { get; set; }
    public bool? FlgZamMedPart { get; set; }
    public bool? FlgHeadPhysician { get; set; }
    public string? IbResultShort { get; set; }
    public DateOnly? BlotDate { get; set; }
    public int? BlotNo { get; set; }
    public bool? First1 { get; set; }
    public bool? Last1 { get; set; }
    public DateOnly? Datetime1 { get; set; }
    public DateOnly? UfsinDate { get; set; }
    public DateOnly? VlDate { get; set; }
    public int? VlResult { get; set; }
    public DateOnly? ImDate { get; set; }
    public int? I0015 { get; set; }
    public int? I0025 { get; set; }
    public int? I0035 { get; set; }
    public string? HepBRes { get; set; }
    public DateOnly? HepBDate { get; set; }
    public string? HepCRes { get; set; }
    public DateOnly? HepCDate { get; set; }
    public string? HepBIfaRes { get; set; }
    public DateOnly? HepBIfaDate { get; set; }
    public string? HepCIfaRes { get; set; }
    public DateOnly? HepCIfaDate { get; set; }
    public string? HepSyphIfaRes { get; set; }
    public DateOnly? HepSyphIfaDate { get; set; }
    public string? CardNo { get; set; }
    public string? ArvtLong { get; set; }

}

