using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblInvalid
{
    public int InvalidId { get; set; }

    public string? InvalidShort { get; set; }

    public string? InvalidLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
