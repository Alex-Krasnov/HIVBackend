﻿namespace HIVBackend.Models.DBModuls;
public partial class QrySearchMainInf
{
    public int PatientId { get; set; }
    public DateOnly? InputDate { get; set; }
    public string? Snils { get; set; }
    public string? FamilyName { get; set; }
    public string? FirstName { get; set; }
    public string? ThirdName { get; set; }
    public string? SexShort { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? RegionLong { get; set; }
    public string? RegionLongFact { get; set; }
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
    public string? CheckPlaceLong { get; set; }
    public string? DiagnosisLong { get; set; }
    public DateOnly? DiagnosisDefDate { get; set; }
    public DateOnly? DieDate { get; set; }
    public DateOnly? DieAidsDate { get; set; }
    public DateOnly? DieDateInput { get; set; }
    public string? CheckCourseLong { get; set; }
    public string? DieCourseShort { get; set; }
    public string? DieCourseLong { get; set; }
    public int? DethtypeId { get; set; }
    public string? InfectCourseLong { get; set; }
    public string? ShowIllnessLong { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? IbResultShort { get; set; }
    public DateOnly? BlotDate { get; set; }
    public int? BlotNo { get; set; }
    public bool? First1 { get; set; }
    public bool? Last1 { get; set; }
    public DateOnly? Datetime1 { get; set; }
    public string? HospCourseLong { get; set; }
    public string? CardNo { get; set; }
    public string? ArvtLong { get; set; }
    public string? CodeMkb10Long { get; set; }
    public string? Archive { get; set; }
    public DateOnly? TransfAreaDate { get; set; }
    public bool? FlgZamMedPart { get; set; }
    public bool? FlgHeadPhysician { get; set; }
    public DateOnly? TransfFederDate { get; set; }
    public DateOnly? UfsinDate { get; set; }
    public string? Aids12Long { get; set; }
    public string? UnrzFr { get; set; }
    public string? ChemopLong { get; set; }
    public DateOnly? ChemopDateFrom { get; set; }
    public DateOnly? ChemopDateTo { get; set; }
    public DateOnly? DtRegBeg { get; set; }
    public DateOnly? DtRegEnd { get; set; }
    public string? PasSer { get; set; }
    public string? PasNum { get; set; }
    public DateOnly? PasWhen { get; set; }
    public string? PasWhom { get; set; }
    public string? FioChange { get; set; }
    public int? Age { get; set; }
    public int? RegtypeId { get; set; }
    public int? FactRegtypeId { get; set; }   
}
