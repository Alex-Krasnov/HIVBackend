using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblMedicineForSchema
{
    public int MedforschemaId { get; set; }

    public string? MedforschemaShort { get; set; }

    public string? MedforschemaLong { get; set; }

    public int? MedforschemaChild { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblSchemaMedicineR> TblSchemaMedicineRs { get; } = new List<TblSchemaMedicineR>();
}
