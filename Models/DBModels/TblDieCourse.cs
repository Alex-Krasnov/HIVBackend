﻿namespace HIVBackend.Models.DBModuls;

public partial class TblDieCourse
{
    public int DieCourseId { get; set; }

    public string? DieCourseShort { get; set; }

    public string? DieCourseLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
