namespace HIVBackend.Models.DBModuls;

public partial class TblPatientShowIllness
{
    public int PatientId { get; set; }

    public int ShowIllnessId { get; set; }

    public DateOnly StartDate { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Comment { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;

    public virtual TblShowIllness ShowIllness { get; set; } = null!;
}
