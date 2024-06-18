namespace HIVBackend.Models.DBModuls;

public partial class TblPatientContactDrug
{
    public int DrugId { get; set; }

    public string? DrugName { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public int? PatientId { get; set; }

    public int? PavType { get; set; }

    public int? YNId { get; set; }
}
