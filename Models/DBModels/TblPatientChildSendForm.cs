using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientChildSendForm
{
    public int PatientId { get; set; }

    public DateOnly Datesendform { get; set; }

    public string? SendformDescr { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
