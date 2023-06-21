using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientRegistry
{
    public DateOnly RegDate { get; set; }

    public int RegCabinetId { get; set; }

    public int PatientId { get; set; }

    public int? RegTimeId { get; set; }

    public int? RegDoctorId { get; set; }

    public string? RegDescr { get; set; }

    public Boolean? RegCheck { get; set; }

    public int? Numpp { get; set; }
}
