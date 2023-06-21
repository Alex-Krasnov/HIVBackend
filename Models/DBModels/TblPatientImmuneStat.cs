using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientImmuneStat
{
    public int PatientId { get; set; }

    public DateOnly ImmuneDefineDate { get; set; }

    public float? ImmuneValue2 { get; set; }

    public float? ImmuneValue3 { get; set; }

    public float? ImmuneValue5 { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public float? ImmuneValue4 { get; set; }

    public float? ImmuneValue6 { get; set; }

    public float? ImmuneValue7 { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
