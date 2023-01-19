using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblDiagnosis
{
    public int DiagnosisId { get; set; }

    public string? DiagnosisShort { get; set; }

    public string? DiagnosisLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientDiagnosis> TblPatientDiagnoses { get; } = new List<TblPatientDiagnosis>();
}
