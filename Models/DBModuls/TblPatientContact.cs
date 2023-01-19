using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientContact
{
    public int PatientId { get; set; }

    public int PatientContactId { get; set; }

    public string? PatientContactDescr { get; set; }

    public int? InfectCourseId { get; set; }

    public int? ContactType { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
