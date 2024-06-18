namespace HIVBackend.Models.DBModuls;

public partial class TblCorrespIllness
{
    public int CorrespIllnessId { get; set; }

    public string? CorrespIllnessShort { get; set; }

    public string? CorrespIllnessLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual ICollection<TblPatientCorrespIllness> TblPatientCorrespIllnesses { get; } = new List<TblPatientCorrespIllness>();
}
