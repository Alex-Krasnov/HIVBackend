namespace HIVBackend.Models.DBModuls;

public partial class TblArvt
{
    public int ArvtId { get; set; }

    public string? ArvtShort { get; set; }

    public string? ArvtLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
