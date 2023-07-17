namespace HIVBackend.Models.DBModuls;
public partial class QrySearchAcl
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
    public DateOnly? RegOnDate { get; set; }
    public DateOnly? RegOffDate { get; set; }
    public string? RegOff { get; set; }
    public string? DiagnosisLong { get; set; }
    public string? CheckCourseLong { get; set; }
    public string? IbResultShort { get; set; }
    public DateOnly? BlotDate { get; set; }
    public int? BlotNo { get; set; }
    public bool? First1 { get; set; }
    public bool? Last1 { get; set; }
    public DateOnly? Datetime1 { get; set; }
    public string? AclTestCode { get; set; }
    public DateOnly? AclSampleDate { get; set; }
    public string? AclMcnCode { get; set; }
    public string? AclResult { get; set; }
}

