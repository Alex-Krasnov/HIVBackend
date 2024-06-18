namespace HIVBackend.Models.DBModuls;

public partial class TblAclTestResistence
{
    public string AclTestCode { get; set; } = null!;

    public string? AclTestName { get; set; }

    public string? Desc01 { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
