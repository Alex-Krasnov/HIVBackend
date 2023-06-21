using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblCabinet
{
    public int CabinetId { get; set; }

    public string? CabinetShort { get; set; }

    public string? CabinetLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? Sort { get; set; }

    public int? FlgTalonnworeg { get; set; }
}
