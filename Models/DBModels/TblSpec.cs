namespace HIVBackend.Models.DBModuls;

public partial class TblSpec
{
    public int SpecId { get; set; }

    public string? SpecShort { get; set; }

    public string? SpecLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCheckOut> TblPatientCheckOuts { get; } = new List<TblPatientCheckOut>();

    public virtual ICollection<TblPatientCheck> TblPatientChecks { get; } = new List<TblPatientCheck>();
}
