using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblCheckCourse
{
    public int CheckCourseId { get; set; }

    public string? CheckCourseShort { get; set; }

    public string? CheckCourseLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
