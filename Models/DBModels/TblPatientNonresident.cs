namespace HIVBackend.Models.DBModuls;

public partial class TblPatientNonresident
{
    public int PatientId { get; set; }

    public DateOnly? DateDiagnosis { get; set; }

    public int? PlaceDiagnosis { get; set; }

    public DateOnly? DateRegistrationFrom { get; set; }

    public DateOnly? DateRegistrationTo { get; set; }

    public DateOnly? DateDeparture { get; set; }
}
