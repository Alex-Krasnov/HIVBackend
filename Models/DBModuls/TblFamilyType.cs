using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblFamilyType
{
    public int FamilyTypeId { get; set; }

    public string? FamilyTypeShort { get; set; }

    public string? FamilyTypeLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCards { get; } = new List<TblPatientCard>();
}
