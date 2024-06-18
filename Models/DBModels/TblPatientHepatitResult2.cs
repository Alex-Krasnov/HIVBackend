namespace HIVBackend.Models.DBModuls;

public partial class TblPatientHepatitResult2
{
    public int PatientId { get; set; }

    public DateOnly DefineResultDate { get; set; }

    public int? HepatitResult2Id { get; set; }

    public float? Hepatit2Load { get; set; }

    public virtual TblHepatitResult2? HepatitResult2 { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
