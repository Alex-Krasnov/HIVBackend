namespace HIVBackend.Models.DBModuls;

public partial class TblPatientBiochem
{
    public int PatientId { get; set; }

    public int BiochemId { get; set; }

    public float? BiochemValue { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblBiochem Biochem { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
