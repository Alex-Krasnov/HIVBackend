namespace HIVBackend.Models.DBModuls;

public partial class TblPatientStacionar
{
    public int PatientId { get; set; }

    public DateOnly DocDate { get; set; }

    public string DocNum { get; set; } = null!;

    public int StacionarId { get; set; }

    public int MedicineId { get; set; }

    public int? DoctorId { get; set; }

    public double? PackNumber { get; set; }

    public DateOnly? GiveDate { get; set; }

    public int? GiveMedId { get; set; }

    public double? GivePackNum { get; set; }

    public string? LetterNum { get; set; }

    public DateOnly? ZayavkaDate { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public virtual TblDoctor? Doctor { get; set; }

    public virtual TblMedicine? GiveMed { get; set; }

    public virtual TblMedicine Medicine { get; set; } = null!;

    public virtual TblPatientCard Patient { get; set; } = null!;

    public virtual TblStacionar Stacionar { get; set; } = null!;
}
