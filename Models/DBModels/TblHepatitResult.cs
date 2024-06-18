namespace HIVBackend.Models.DBModuls;

public partial class TblHepatitResult
{
    public int HepatitResultId { get; set; }

    public string? HepatitResultShort { get; set; }

    public string? HepatitResultLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientHepatitResult> TblPatientHepatitResults { get; } = new List<TblPatientHepatitResult>();
}
