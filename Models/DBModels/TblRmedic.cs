using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblRmedic
{
    public int RmedicId { get; set; }

    public string? RmedicShort { get; set; }

    public string? RmedicLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientResist> TblPatientResists { get; } = new List<TblPatientResist>();
}
