using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblRegtype
{
    public int RegtypeId { get; set; }

    public string? RegtypeShort { get; set; }

    public string? RegtypeLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblRegion> TblRegions { get; } = new List<TblRegion>();
}
