namespace HIVBackend.Models.DBModuls;

public partial class TblInfectCourse
{
    public int InfectCourseId { get; set; }

    public string? InfectCourseShort { get; set; }

    public string? InfectCourseLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
