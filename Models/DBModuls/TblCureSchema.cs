using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblCureSchema
{
    public int CureSchemaId { get; set; }

    public string? CureSchemaShort { get; set; }

    public string? CureSchemaLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? CureSchemaNoact { get; set; }

    public virtual ICollection<TblPatientCureSchema> TblPatientCureSchemas { get; } = new List<TblPatientCureSchema>();

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMPhpschemaId1Navigations { get; } = new List<TblPatientPregnantM>();

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMPhpschemaId2Navigations { get; } = new List<TblPatientPregnantM>();

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMPhpschemaId3Navigations { get; } = new List<TblPatientPregnantM>();

    public virtual ICollection<TblSchemaMedicineR> TblSchemaMedicineRs { get; } = new List<TblSchemaMedicineR>();
}
