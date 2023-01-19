using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblHepatitResult2
{
    public int HepatitResult2Id { get; set; }

    public string? HepatitResult2Short { get; set; }

    public string? HepatitResult2Long { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientHepatitResult2> TblPatientHepatitResult2s { get; } = new List<TblPatientHepatitResult2>();
}
