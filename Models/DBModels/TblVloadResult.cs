namespace HIVBackend.Models.DBModuls;

public partial class TblVloadResult
{
    public int VloadResultId { get; set; }

    public string? VloadResultShort { get; set; }

    public string? VloadResultLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientVirusLoad> TblPatientVirusLoads { get; } = new List<TblPatientVirusLoad>();
}
