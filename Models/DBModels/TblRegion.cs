namespace HIVBackend.Models.DBModuls;

public partial class TblRegion
{
    public int RegionId { get; set; }

    public string? RegionShort { get; set; }

    public string? RegionLong { get; set; }

    public int? MosregYn { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? RegtypeId { get; set; }

    public string? Index1 { get; set; }

    public int? SubjectRf { get; set; }

    public virtual TblRegtype? Regtype { get; set; }

    public virtual ICollection<TblPatientCard> TblPatientCardJailedOffRegions { get; } = new List<TblPatientCard>();

    public virtual ICollection<TblPatientCard> TblPatientCardRegions { get; } = new List<TblPatientCard>();

    public virtual ICollection<TblUser> TblUsers { get; } = new List<TblUser>();
}
