namespace HIVBackend.Models.DBModuls;

public partial class TblAgegr
{
    public int AgegrId { get; set; }

    public string? AgegrShort { get; set; }

    public string? AgegrLong { get; set; }

    public float? Start1 { get; set; }

    public float? End1 { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
