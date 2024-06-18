namespace HIVBackend.Models.DBModuls;

public partial class TblListEpidDoctor
{
    public int IdDoctor { get; set; }

    public string? DoctorName { get; set; }

    public string? DoctorSnils { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
