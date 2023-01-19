using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblBiochem
{
    public int BiochemId { get; set; }

    public string? BiochemShort { get; set; }

    public string? BiochemLong { get; set; }

    public double? Min1 { get; set; }

    public double? Max1 { get; set; }

    public string? Comment1 { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientBiochem> TblPatientBiochems { get; } = new List<TblPatientBiochem>();
}
