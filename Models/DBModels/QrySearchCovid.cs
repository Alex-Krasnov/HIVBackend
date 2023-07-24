namespace HIVBackend.Models.DBModuls;
public partial class QrySearchCovid
{
    public int PatientId { get; set; }
    public DateOnly? InputDate { get; set; }
    public string? FamilyName { get; set; }
    public string? FirstName { get; set; }
    public string? ThirdName { get; set; }
    public string? FioChange { get; set; }
    public string? SexShort { get; set; }
    public DateOnly? BirthDate { get; set; }
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
    public string? IbResultShort { get; set; }
    public DateOnly? BlotDate { get; set; }
    public int? BlotNo { get; set; }
    public bool? First1 { get; set; }
    public bool? Last1 { get; set; }
    public DateOnly? Datetime1 { get; set; }
    public string? HospCourseLong { get; set; }
    public string? ArvtLong { get; set; }
    public string? CodeMkb10Long { get; set; }


    public string? ArterHyperYn { get; set; }
    public string? DiabetesYn { get; set; }
    public string? CoronarySyndYn { get; set; }
    public string? HoblYn { get; set; }
    public string? BronhAstmaYn { get; set; }
    public string? CancerYn { get; set; }
    public string? KidneyDesYn { get; set; }
    public string? OutpatTreatYn { get; set; }
    public string? DeathCovidYn { get; set; }
    public string? OritYn { get; set; }
    public string? OxygenYn { get; set; }
    public string? TypeAlvYn { get; set; }
    public DateOnly? DPeriodDes { get; set; }
    public DateOnly? DPositivResCovid { get; set; }
    public DateOnly? DNegativeResCovid { get; set; }
    public DateOnly? Hospitalization { get; set; }
    public DateOnly? DDischarge { get; set; }
    public string? Mkb10LongName { get; set; }
    public string? TuberNameShort { get; set; }
    public string? PneumoniaNameShort { get; set; }
    public string? HospName { get; set; }
    public string? ClinVarCovidName { get; set; }
    public string? CourseVarCovidName { get; set; }
}

