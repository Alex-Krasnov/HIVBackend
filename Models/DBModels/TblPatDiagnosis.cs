namespace HIVBackend.Models.DBModuls;

public partial class TblPatDiagnosis
{
    public int IdPatDiagnos { get; set; }

    public int? IdMkbPatDiag { get; set; }

    public string? PatDiagCom { get; set; }

    public int? PatientId { get; set; }

    public virtual ICollection<TblCovid> TblCovids { get; } = new List<TblCovid>();
}
