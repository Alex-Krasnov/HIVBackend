using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientChemop
{
    public int PatientId { get; set; }

    public int ChemopId { get; set; }

    public DateOnly ChemopDateFrom { get; set; }

    public DateOnly? ChemopDateTo { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblChemop Chemop { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
