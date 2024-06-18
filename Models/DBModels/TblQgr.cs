namespace HIVBackend.Models.DBModuls;

public partial class TblQgr
{
    public int QgrId { get; set; }

    public string? QgrName { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblQuest> TblQuests { get; } = new List<TblQuest>();
}
