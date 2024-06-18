namespace HIVBackend.Models.DBModuls;

public partial class TblPatientPrescrM
{
    public int PatientId { get; set; }

    public string PrescrSer { get; set; } = null!;

    public string PrescrNum { get; set; } = null!;

    public int? DoctorId { get; set; }

    public DateOnly? PrescrDate { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public Guid? Uidprescr { get; set; }

    public int? FinSourceId { get; set; }

    public int? MedicineId { get; set; }

    public double? PackNumber { get; set; }

    public int? GiveMedId { get; set; }

    public DateOnly? GiveDate { get; set; }

    public double? GivePackNum { get; set; }

    public bool? GiveDateCheck1 { get; set; }

    public DateOnly? KorvetDateImp { get; set; }

    public virtual TblFinSource? FinSource { get; set; }

    public virtual TblMedicine? GiveMed { get; set; }

    public virtual TblMedicine? Medicine { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;
}
