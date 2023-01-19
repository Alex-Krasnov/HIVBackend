using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientBlot
{
    public int PatientId { get; set; }

    public int BlotId { get; set; }

    public int? BlotNo { get; set; }

    public DateOnly? BlotDate { get; set; }

    public int? IbResultId { get; set; }

    public int? CheckPlaceId { get; set; }

    public int? First1 { get; set; }

    public int? Last1 { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? FlgIfa { get; set; }

    public int? VnResultId { get; set; }

    public virtual TblCheckPlace? CheckPlace { get; set; }

    public virtual TblIbResult? IbResult { get; set; }
}
