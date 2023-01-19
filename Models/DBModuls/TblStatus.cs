using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblStatus
{
    public int StatusId { get; set; }

    public string? StatusShort { get; set; }

    public string? StatusLong { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
