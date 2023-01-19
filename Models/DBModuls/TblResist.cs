using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblResist
{
    public int ResistId { get; set; }

    public string? ResistShort { get; set; }

    public string? ResistLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientResist> TblPatientResists { get; } = new List<TblPatientResist>();
}
