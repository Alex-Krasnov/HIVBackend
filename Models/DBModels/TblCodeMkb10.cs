namespace HIVBackend.Models.DBModuls;

public partial class TblCodeMkb10
{
    public int CodeMkb10Id { get; set; }

    public string? CodeMkb10Short { get; set; }

    public string? CodeMkb10Long { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
