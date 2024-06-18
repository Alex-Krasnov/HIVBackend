namespace HIVBackend.Models.DBModuls;

public partial class TblPregCheck
{
    public int PregCheckId { get; set; }

    public string? PregCheckShort { get; set; }

    public string? PregCheckLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
