using HIVBackend.Models.DBModels;
using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblSex
{
    public int SexId { get; set; }

    public string? SexShort { get; set; }

    public string? SexLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();

    public virtual ICollection<TblPatientEpidChild> TblPatientEpidChildren { get; } = new List<TblPatientEpidChild>();
}
