using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblUser
{
    public string Uid { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public string? UserName { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? Excel1 { get; set; }

    public int? Write1 { get; set; }

    public int? RegionId { get; set; }

    public int? Admin1 { get; set; }

    public int? Delete1 { get; set; }

    public int? Klassif1 { get; set; }

    public virtual TblRegion? Region { get; set; }
}
