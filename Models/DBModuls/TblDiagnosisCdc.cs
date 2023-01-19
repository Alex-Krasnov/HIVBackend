using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblDiagnosisCdc
{
    public int DiagnosisCdcId { get; set; }

    public string? DiagnosisCdcShort { get; set; }

    public string? DiagnosisCdcLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
