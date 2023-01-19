using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblDtype
{
    public short DtypeId { get; set; }

    public string? DtypeName { get; set; }

    public DateOnly? DtChanged { get; set; }

    public string? DtypeTbl { get; set; }

    public virtual ICollection<TblQuestDimeR> TblQuestDimeRs { get; } = new List<TblQuestDimeR>();
}
