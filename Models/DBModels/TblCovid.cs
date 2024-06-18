namespace HIVBackend.Models.DBModuls;

public partial class TblCovid
{
    public int IdCovid { get; set; }

    public int PatientId { get; set; }

    public int? ArterHyper { get; set; }

    public int? Diabetes { get; set; }

    public int? CoronarySynd { get; set; }

    public int? Hobl { get; set; }

    public int? BronhAstma { get; set; }

    public int? Cancer { get; set; }

    public int? KidneyDes { get; set; }

    public int? CommitmentId { get; set; }

    public DateOnly? DPositivResCovid { get; set; }

    public DateOnly? DNegativeResCovid { get; set; }

    public DateOnly? Hospitalization { get; set; }

    public DateOnly? DDischarge { get; set; }

    public int? OutpatTreat { get; set; }

    public int? DeathCovid { get; set; }

    public int? SeverityCourseCovid { get; set; }

    public string? Comment { get; set; }

    public int? Orit { get; set; }

    public int? Oxygen { get; set; }

    public int? TypeAlv { get; set; }

    public int? CovidMkb10 { get; set; }

    public int? Tuberculosis { get; set; }

    public int? Pneumonia { get; set; }

    public int? ClinVarOfCovid { get; set; }

    public int? OutcomeHospitalization { get; set; }

    public int? Alv { get; set; }

    public DateOnly? DPeriodDes { get; set; }

    public int? PatDiagn { get; set; }

    public int? SecDisId { get; set; }

    public virtual TblListMkb10Covid? CovidMkb10Navigation { get; set; }

    public virtual TblPatDiagnosis? PatDiagnNavigation { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
