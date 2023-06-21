using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblQuestDimeR
{
    public int QuestId { get; set; }

    public int DimeId { get; set; }

    public short DtypeId { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblDtype Dtype { get; set; } = null!;

    public virtual TblQuest Quest { get; set; } = null!;
}
