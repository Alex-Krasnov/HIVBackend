namespace HIVBackend.Models.DBModuls;

public partial class TblListReferenceMo
{
    public int ReferenceMoId { get; set; }

    public string? ReferenceMoName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }

    public virtual ICollection<TblPatientBlot> TblPatientBlots { get; } = new List<TblPatientBlot>();
}
