namespace HIVBackend.Models.DBModuls;

public partial class TblPatientDiagnosis
{
    public int PatientId { get; set; }

    public DateOnly DiagnosisDefDate { get; set; }

    public int? DiagnosisId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblDiagnosis? Diagnosis { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
