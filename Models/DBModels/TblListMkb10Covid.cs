namespace HIVBackend.Models.DBModuls;

public partial class TblListMkb10Covid
{
    public int Mkb10Id { get; set; }

    public string? Mkb10LongName { get; set; }

    public string? Mkb10ShortName { get; set; }

    public virtual ICollection<TblCovid> TblCovids { get; } = new List<TblCovid>();
}
