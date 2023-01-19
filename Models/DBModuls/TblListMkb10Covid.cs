using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblListMkb10Covid
{
    public int Mkb10Id { get; set; }

    public string? Mkb10LongName { get; set; }

    public string? Mkb10SortName { get; set; }

    public virtual ICollection<TblCovid> TblCovids { get; } = new List<TblCovid>();
}
