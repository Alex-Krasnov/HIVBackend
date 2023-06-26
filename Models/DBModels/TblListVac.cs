﻿using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblListVac
{
    public int VacId { get; set; }

    public string? VacName { get; set; }

    public virtual ICollection<TblCovidVac> TblCovidVacs { get; } = new List<TblCovidVac>();
}