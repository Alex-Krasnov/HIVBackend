using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblMonth
{
    public short MonthId { get; set; }

    public string? MonthShort { get; set; }

    public string? MonthLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
