namespace HIVBackend.Models.DBModuls;
public partial class QrySearchChild
{
    public int PatientId { get; set; }
    public DateOnly? InputDate { get; set; }
    public string? FamilyName { get; set; }
    public string? FirstName { get; set; }
    public string? ThirdName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int? AgeDay { get; set; }
    public string? RegionLong { get; set; }
    public int? RegtypeId { get; set; }
    public string? RegionLongFact { get; set; }
    public int? FactRegtypeId { get; set; }
    public string? CountryLong { get; set; }
    public DateOnly? RegOnDate { get; set; }
    public DateOnly? RegOffDate { get; set; }
    public string? RegOff { get; set; }
    public string? DiagnosisLong { get; set; }
    public DateOnly? DiagnosisDefDate { get; set; }
    public string? CheckCourseLong { get; set; }
    public string? InfectCourseLong { get; set; }
    public string? ShowIllnessLong { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? TransfAreaDate { get; set; }
    public bool? FlgZamMedPart { get; set; }
    public bool? FlgHeadPhysician { get; set; }
    public string? CodeMkb10Long { get; set; }
    public string? FamilyTypeLong { get; set; }
    public DateOnly? CheckFirstDate { get; set; }
    public string? ChildPlaceLong { get; set; }
    public double? BreastMonthNo { get; set; }
    public string? ChildPhpLong { get; set; }
    public string? SexShort { get; set; }
    public string? CardNo { get; set; }
    public int? MotherPatientId { get; set; }
    public int? FatherPatientId { get; set; }
    public string? CityName { get; set; }
    public string? LocationName { get; set; }
    public string? AddrInd { get; set; }
    public string? AddrStreet { get; set; }
    public string? AddrHouse { get; set; }
    public string? AddrExt { get; set; }
    public string? AddrFlat { get; set; }
    public string? ArvtLong { get; set; }
    public DateOnly? DieDate { get; set; }
    public DateOnly? DieAidsDate { get; set; }
    public string? MaterHomeLong { get; set; }
    public int? Form309 { get; set; }
}

