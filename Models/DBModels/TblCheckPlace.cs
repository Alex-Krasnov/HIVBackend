using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblCheckPlace
{
    public int CheckPlaceId { get; set; }

    public string? CheckPlaceShort { get; set; }

    public string? CheckPlaceLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientBlot> TblPatientBlots { get; } = new List<TblPatientBlot>();
}
