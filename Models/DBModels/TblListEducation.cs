using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblListEducation
{
    public int EducationId { get; set; }

    public string? EduName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
