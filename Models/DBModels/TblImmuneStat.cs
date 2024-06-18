namespace HIVBackend.Models.DBModuls;

public partial class TblImmuneStat
{
    public int ImmuneStatId { get; set; }

    public string? ImmuneStatShort { get; set; }

    public string? ImmuneStatLong { get; set; }

    public double? Min1 { get; set; }

    public double? Max1 { get; set; }

    public string? Comment1 { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
