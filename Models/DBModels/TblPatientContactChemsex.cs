namespace HIVBackend.Models.DBModuls;

public partial class TblPatientContactChemsex
{
    public int DrugId { get; set; }

    public string? DrugName { get; set; }

    public int? PatientId { get; set; }

    public int? YNId { get; set; }

    public int? ContactType { get; set; }
}
