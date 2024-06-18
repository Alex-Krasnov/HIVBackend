namespace HIVBackend.Models.DBModuls;

public partial class TblChildPlace
{
    public int ChildPlaceId { get; set; }

    public string? ChildPlaceShort { get; set; }

    public string? ChildPlaceLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
