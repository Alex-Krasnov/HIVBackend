namespace HIVBackend.Models.DBModuls;

public partial class TblPatientVirusLoad
{
    public int PatientId { get; set; }

    public DateOnly DefineVirusDate { get; set; }

    public float? VirusLoad { get; set; }

    public int? VloadResultId { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;

    public virtual TblVloadResult? VloadResult { get; set; }
}
