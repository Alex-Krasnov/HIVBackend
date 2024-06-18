namespace HIVBackend.Models.DBModuls;

public partial class TblListFamilyStatus
{
    public int FamilyStatusId { get; set; }

    public string? FammilyStatusName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
