namespace HIVBackend.Models.DBModuls;

public partial class TblHospCourse
{
    public int HospCourseId { get; set; }

    public string? HospCourseShort { get; set; }

    public string? HospCourseLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientHospResultR> TblPatientHospResultRs { get; } = new List<TblPatientHospResultR>();

    public virtual ICollection<TblPatientHosp> TblPatientHosps { get; } = new List<TblPatientHosp>();
}
