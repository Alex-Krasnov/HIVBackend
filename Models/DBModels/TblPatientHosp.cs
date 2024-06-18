namespace HIVBackend.Models.DBModuls;

public partial class TblPatientHosp
{
    public int PatientId { get; set; }

    public int YearId { get; set; }

    public int HospCourseId { get; set; }

    public int? HospTimes { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblHospCourse HospCourse { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
