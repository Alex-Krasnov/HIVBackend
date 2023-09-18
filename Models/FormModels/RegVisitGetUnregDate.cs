namespace HIVBackend.Models.FormModels
{
    public class RegVisitGetUnregDate
    {
        public int PatientId { get; set; }
        public string DocName { get; set; }
        public string CabName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
