namespace HIVBackend.Models.DBModuls;

public partial class TblListEmployment
{
    public int EmploymentId { get; set; }

    public string? EmploymentName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
