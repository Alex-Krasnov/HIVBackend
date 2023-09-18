namespace HIVBackend.Models.FormModels
{
    public class RegVisitGetUnregTime
    {
        public int PatientId { get; set; }
        public int DocId { get; set; }
        public int CabId { get; set; }
        public string Date { get; set; }
    }
}
