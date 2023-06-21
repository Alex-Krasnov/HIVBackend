using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblZzztempSnil
{
    public int PatientId { get; set; }

    public string? Snils { get; set; }

    public string? SnilsFed { get; set; }

    public DateOnly? Datetime1 { get; set; }
}
