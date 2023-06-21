using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblCureChange
{
    public int CureChangeId { get; set; }

    public string? CureChangeShort { get; set; }

    public string? CureChangeLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCureSchema> TblPatientCureSchemas { get; } = new List<TblPatientCureSchema>();
}
