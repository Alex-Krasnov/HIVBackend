namespace HIVBackend.Models.DBModuls;

public partial class TblStacionar
{
    public int StacionarId { get; set; }

    public string? StacionarShort { get; set; }

    public string? StacionarLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientStacionar> TblPatientStacionars { get; } = new List<TblPatientStacionar>();
}
