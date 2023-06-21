using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblJail
{
    public int JailId { get; set; }

    public string? JailShort { get; set; }

    public string? JailLong { get; set; }

    public int? SizoYn { get; set; }

    public int? MosregYn { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
