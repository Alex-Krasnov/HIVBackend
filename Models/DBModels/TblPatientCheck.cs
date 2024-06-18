namespace HIVBackend.Models.DBModuls;

public partial class TblPatientCheck
{
    public int PatientId { get; set; }

    public DateOnly CheckDate { get; set; }

    public int CheckSpecId { get; set; }

    public int CheckDoctorId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public DateOnly? CheckDateNext { get; set; }

    public virtual TblDoctor CheckDoctor { get; set; } = null!;

    public virtual TblSpec CheckSpec { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
