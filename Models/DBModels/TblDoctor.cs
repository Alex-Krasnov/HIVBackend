namespace HIVBackend.Models.DBModuls;

public partial class TblDoctor
{
    public int DoctorId { get; set; }

    public string? DoctorShort { get; set; }

    public string? DoctorLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public string? Ext1Pcod { get; set; }

    public int? SpecId { get; set; }

    public string? DoctorSnils { get; set; }

    public virtual ICollection<TblPatientCheckOut> TblPatientCheckOuts { get; } = new List<TblPatientCheckOut>();

    public virtual ICollection<TblPatientCheck> TblPatientChecks { get; } = new List<TblPatientCheck>();
}
