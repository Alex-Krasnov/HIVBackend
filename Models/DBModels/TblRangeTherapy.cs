namespace HIVBackend.Models.DBModuls;

public partial class TblRangeTherapy
{
    public int RangeTherapyId { get; set; }

    public string? RangeTherapyShort { get; set; }

    public string? RangeTherapyLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
