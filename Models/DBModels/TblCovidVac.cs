namespace HIVBackend.Models.DBModuls;

public partial class TblCovidVac
{
    public int VacId { get; set; }

    public int PatientId { get; set; }

    public DateOnly? DVac1 { get; set; }

    public DateOnly? DVac2 { get; set; }

    public int? VacName { get; set; }

    public virtual TblListVac? VacNameNavigation { get; set; }
}
