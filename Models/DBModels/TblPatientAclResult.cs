namespace HIVBackend.Models.DBModuls;

public partial class TblPatientAclResult
{
    public int PatientId { get; set; }

    public string AclTestCode { get; set; } = null!;

    public DateTime AclSampleDate { get; set; }

    public string? AclMcnCode { get; set; }

    public string? AclResult { get; set; }

    public string? AclUnits { get; set; }

    public string? AclRefmin { get; set; }

    public string? AclRefmax { get; set; }

    public string? AclSpecimen { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
