using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblTempDieCureMkb10list
{
    public int DieCourseId { get; set; }

    public string? DieCourseShort { get; set; }

    public string? DieCourseLong { get; set; }

    public int? DethtypeId { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
