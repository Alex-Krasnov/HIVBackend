namespace HIVBackend.Models.DBModuls;

public partial class TblRegist
{
    public int RegistId { get; set; }

    public string? RegistShort { get; set; }

    public string? RegistLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
