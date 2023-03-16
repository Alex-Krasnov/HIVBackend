namespace HIVBackend.Models.FormModels
{
    public class SecondDesease
    {
        public int PatientId { get; set; }
        public string StartDate { get; set; }
        public string? EndDate { get; set; }
        public string Deseas { get; set; }
        public string? StartDateOld { get; set; }
        public string? DeseasOld { get; set; }
    }
}
