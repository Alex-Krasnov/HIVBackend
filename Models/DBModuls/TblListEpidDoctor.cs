using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblListEpidDoctor
{
    public int IdDoctor { get; set; }

    public string? DoctorName { get; set; }

    public string? DoctorSnils { get; set; }
}
