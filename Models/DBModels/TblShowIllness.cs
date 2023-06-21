using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblShowIllness
{
    public int ShowIllnessId { get; set; }

    public string? ShowIllnessShort { get; set; }

    public string? ShowIllnessLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientShowIllness> TblPatientShowIllnesses { get; } = new List<TblPatientShowIllness>();
}
