namespace HIVBackend.Models.DBModuls;

public partial class TblFinSource
{
    public int FinSourceId { get; set; }

    public string? FinSourceShort { get; set; }

    public string? FinSourceLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientPrescrM> TblPatientPrescrMs { get; } = new List<TblPatientPrescrM>();
}
