namespace HIVBackend.Models.DBModuls;

public partial class TblPatientMedicine
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int MedicineId { get; set; }

    public DateOnly GiveDate { get; set; }

    public short? PackNumber { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblDoctor Doctor { get; set; } = null!;

    public virtual TblMedicine Medicine { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;
}
