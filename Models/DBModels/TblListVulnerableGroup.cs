namespace HIVBackend.Models.DBModuls;

public partial class TblListVulnerableGroup
{
    public int VulnerableGroupId { get; set; }

    public string? VulnerableGroupName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
