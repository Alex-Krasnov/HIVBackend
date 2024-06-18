namespace HIVBackend.Models.DBModuls;

public partial class TblAids12
{
    public int Aids12Id { get; set; }

    public string? Aids12Short { get; set; }

    public string? Aids12Long { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
