namespace HIVBackend.Models.DBModuls;

public partial class TblLpu
{
    public int LpuId { get; set; }

    public string? LpuShort { get; set; }

    public string? LpuLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientHospResultR> TblPatientHospResultRs { get; } = new List<TblPatientHospResultR>();
}
