namespace HIVBackend.Models.DBModuls;

public partial class TblPatientHospResultR
{
    public int PatientId { get; set; }

    public int LpuId { get; set; }

    public DateOnly DateHospIn { get; set; }

    public DateOnly? DateHospOut { get; set; }

    public int? HospResultId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? HospCourseId { get; set; }

    public virtual TblHospCourse? HospCourse { get; set; }

    public virtual TblHospResult? HospResult { get; set; }

    public virtual TblLpu Lpu { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
