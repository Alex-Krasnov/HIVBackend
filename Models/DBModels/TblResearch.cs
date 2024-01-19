using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblResearch
{
    public int ResearchId { get; set; }

    public string? ResearchLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }
    public int? SortNum { get; set; }
}
