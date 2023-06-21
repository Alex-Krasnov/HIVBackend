using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblListMkbTuder
{
    public int IdTuder { get; set; }

    public string? TuberNameShort { get; set; }

    public string? TuberNameLong { get; set; }
}
