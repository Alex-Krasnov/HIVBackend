namespace HIVBackend.Models.DBModuls;

public partial class TblRegTime
{
    public int RegTimeId { get; set; }

    public string? RegTimeShort { get; set; }

    public string? RegTimeLong { get; set; }

    public int? PatientCount { get; set; }
}
