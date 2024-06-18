namespace HIVBackend.Models.DBModuls;

public partial class TblPatientJail
{
    public int PatientId { get; set; }

    public DateOnly JailStart { get; set; }

    public DateOnly JailEnd { get; set; }

    public int? JailId { get; set; }

    public int? JailLeavId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
