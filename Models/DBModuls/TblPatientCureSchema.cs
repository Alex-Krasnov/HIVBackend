using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientCureSchema
{
    public int PatientId { get; set; }

    public int CureSchemaId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? SchemaDescr { get; set; }

    public int? CureChangeId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public string? ProtNum { get; set; }

    public int? LastYn { get; set; }

    public int? RangeTherapyId { get; set; }

    public virtual TblCureChange? CureChange { get; set; }

    public virtual TblCureSchema CureSchema { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
