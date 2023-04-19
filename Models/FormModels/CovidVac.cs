namespace HIVBackend.Models.FormModels
{
    public class CovidVac
    {
        public int? VacId { get; set; }
        public int PatientId { get; set; }
        public string? DVac1 { get; set; }
        public string? DVac2 { get; set; }
        public string? VacName { get; set; }
    }
}
