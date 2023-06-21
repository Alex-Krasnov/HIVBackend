using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblChildCount
{
    public int ChildCountId { get; set; }

    public string? ChildCountShort { get; set; }

    public string? ChildCountLong { get; set; }

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMs { get; } = new List<TblPatientPregnantM>();
}
