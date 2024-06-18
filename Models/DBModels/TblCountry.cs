namespace HIVBackend.Models.DBModuls;

public partial class TblCountry
{
    public int CountryId { get; set; }

    public string? CountryShort { get; set; }

    public string? CountryLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
