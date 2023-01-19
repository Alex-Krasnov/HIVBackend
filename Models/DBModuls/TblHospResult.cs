using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblHospResult
{
    public int HospResultId { get; set; }

    public string? HospResultShort { get; set; }

    public string? HospResultLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientHospResultR> TblPatientHospResultRs { get; } = new List<TblPatientHospResultR>();
}
