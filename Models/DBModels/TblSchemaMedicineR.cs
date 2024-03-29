﻿using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblSchemaMedicineR
{
    public int CureSchemaId { get; set; }

    public int MedicineId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblCureSchema CureSchema { get; set; } = null!;

    public virtual TblMedicineForSchema Medicine { get; set; } = null!;
}
