using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientHepatitResult
{
    public int PatientId { get; set; }

    public DateOnly DefineResultDate { get; set; }

    public int? HepatitResultId { get; set; }

    public float? HepatitLoad { get; set; }

    public virtual TblHepatitResult? HepatitResult { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
