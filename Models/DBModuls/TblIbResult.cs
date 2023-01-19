using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblIbResult
{
    public int IbResultId { get; set; }

    public string? IbResultShort { get; set; }

    public string? IbResultLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientBlot> TblPatientBlots { get; } = new List<TblPatientBlot>();
}
