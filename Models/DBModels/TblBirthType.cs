namespace HIVBackend.Models.DBModuls;

public partial class TblBirthType
{
    public int BirthTypeId { get; set; }

    public string? BirthTypeShort { get; set; }

    public string? BirthTypeLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
