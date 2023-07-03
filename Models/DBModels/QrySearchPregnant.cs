namespace HIVBackend.Models.DBModuls;
public partial class QrySearchPregnant
{
    public int PatientId { get; set; }
    public DateOnly? InputDate { get; set; }
    public string? FamilyName { get; set; }
    public string? FirstName { get; set; }
    public string? ThirdName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? RegionLong { get; set; }
    public int? RegtypeId { get; set; }
    public string? RegionLongFact { get; set; }
    public int? FactRegtypeId { get; set; }
    public string? CountryLong { get; set; }
    public DateOnly? RegOnDate { get; set; }
    public DateOnly? RegOffDate { get; set; }
    public string? DiagnosisLong { get; set; }
    public DateOnly? DiagnosisDefDate { get; set; }
    public string? CheckCourseLong { get; set; }
    public string? InfectCourseLong { get; set; }
    public string? ShowIllnessLong { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? TransfAreaDate { get; set; }
    public string? ArvtLong { get; set; }
    public DateOnly? UfsinDate { get; set; }
    public bool? FlgZamMedPart { get; set; }
    public bool? FlgHeadPhysician { get; set; }
    public string? CityName { get; set; }
    public string? LocationName { get; set; }
    public string? AddrInd { get; set; }
    public string? AddrStreet { get; set; }
    public string? AddrHouse { get; set; }
    public string? AddrExt { get; set; }
    public string? AddrFlat { get; set; }


    public string? PregCheckLong { get; set; }
    public int? PregMonthNo { get; set; }
    public string? BirthTypeLong { get; set; }
    public int? MedecineStartMonthNo { get; set; }
    public DateOnly? ChildBirthDate { get; set; }
    public DateOnly? PregDate { get; set; }
    public string? ChildFamilyName { get; set; }
    public string? ChildFirstName { get; set; }
    public string? ChildThirdName { get; set; }
    public string? CardNo { get; set; }
    public string? Php1Name { get; set; }
    public string? Php2Name { get; set; }
    public string? Php3Name { get; set; }
    public string? MedecineForSchemaLong1 { get; set; }
    public string? MedecineForSchemaLong2 { get; set; }
    public string? MedecineForSchemaLong3 { get; set; }
    public DateOnly? DateStart1 { get; set; }
    public DateOnly? DateEnd1 { get; set; }
    public string? MaterhomeLong { get; set; }
    public int? ChildId { get; set; }
    public DateOnly? AclSampleDate { get; set; }
    public int? AclMcnCode { get; set; }
}