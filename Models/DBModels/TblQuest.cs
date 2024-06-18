namespace HIVBackend.Models.DBModuls;

public partial class TblQuest
{
    public int QuestId { get; set; }

    public int? QgrId { get; set; }

    public string? QuestName { get; set; }

    public string? RepName { get; set; }

    public string? B1 { get; set; }

    public string? B2 { get; set; }

    public string? B3 { get; set; }

    public string? B4 { get; set; }

    public string? B5 { get; set; }

    public string? B6 { get; set; }

    public string? B7 { get; set; }

    public string? B8 { get; set; }

    public string? B9 { get; set; }

    public string? B10 { get; set; }

    public string? B11 { get; set; }

    public string? B12 { get; set; }

    public string? B13 { get; set; }

    public string? B14 { get; set; }

    public string? B15 { get; set; }

    public string? B16 { get; set; }

    public string? B17 { get; set; }

    public string? B18 { get; set; }

    public string? B19 { get; set; }

    public string? B20 { get; set; }

    public string? B21 { get; set; }

    public string? B22 { get; set; }

    public string? B23 { get; set; }

    public short? Trans1 { get; set; }

    public short? Pivot1 { get; set; }

    public short? Blot1 { get; set; }

    public DateOnly? Date1 { get; set; }

    public string? B1c1 { get; set; }

    public string? B1c2 { get; set; }

    public string? B2c1 { get; set; }

    public string? B2c2 { get; set; }

    public string? B2c3 { get; set; }

    public string? B2c4 { get; set; }

    public string? B2c5 { get; set; }

    public string? B2c6 { get; set; }

    public string? B2c7 { get; set; }

    public string? B3c1 { get; set; }

    public string? B3c2 { get; set; }

    public string? B3c3 { get; set; }

    public string? B4c1 { get; set; }

    public string? B5c1 { get; set; }

    public string? B5c2 { get; set; }

    public string? B8c1 { get; set; }

    public string? B8c2 { get; set; }

    public string? B9c1 { get; set; }

    public string? B9c2 { get; set; }

    public string? B9c3 { get; set; }

    public string? B9c4 { get; set; }

    public string? B9c5 { get; set; }

    public string? B12c1 { get; set; }

    public string? B12c2 { get; set; }

    public string? B12c3 { get; set; }

    public string? B12c4 { get; set; }

    public string? B17c1 { get; set; }

    public string? B17c2 { get; set; }

    public string? B17c3 { get; set; }

    public string? B18c1 { get; set; }

    public string? B18c2 { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblQgr? Qgr { get; set; }

    public virtual ICollection<TblQuestDimeR> TblQuestDimeRs { get; } = new List<TblQuestDimeR>();
}
