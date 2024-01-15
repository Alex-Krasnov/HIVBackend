using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientFiles
{
    public int PatientId { get; set; }

    public string FilePath { get; set; } = null!;
}
