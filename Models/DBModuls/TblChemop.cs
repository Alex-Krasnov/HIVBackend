using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblChemop
{
    public int ChemopId { get; set; }

    public string? ChemopShort { get; set; }

    public string? ChemopLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientChemop> TblPatientChemops { get; } = new List<TblPatientChemop>();
}
