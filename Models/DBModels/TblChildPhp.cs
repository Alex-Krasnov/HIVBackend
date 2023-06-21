using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblChildPhp
{
    public int ChildPhpId { get; set; }

    public string? ChildPhpShort { get; set; }

    public string? ChildPhpLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
