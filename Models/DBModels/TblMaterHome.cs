namespace HIVBackend.Models.DBModuls;

public partial class TblMaterHome
{
    public int MaterhomeId { get; set; }

    public string? MaterhomeShort { get; set; }

    public string? MaterhomeLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
