using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientResist
{
    public int PatientId { get; set; }

    public int RmedicId { get; set; }

    public int? ResistId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;

    public virtual TblResist? Resist { get; set; }

    public virtual TblRmedic Rmedic { get; set; } = null!;
}
