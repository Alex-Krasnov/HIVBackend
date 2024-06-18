namespace HIVBackend.Models.DBModuls;

public partial class TblListSituationDetect
{
    public int SituationDetectId { get; set; }

    public string? SituationDetectName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
