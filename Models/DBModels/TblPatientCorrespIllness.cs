using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientCorrespIllness
{
    public int PatientId { get; set; }

    public int CorrespIllnessId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblCorrespIllness CorrespIllness { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
