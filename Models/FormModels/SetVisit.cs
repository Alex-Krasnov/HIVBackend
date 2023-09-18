namespace HIVBackend.Models.FormModels
{
    public class SetVisit
    {
        public int PatientId { get; set; }
        public int DocId { get; set; }
        public int CabId { get; set; }
        public DateTime Date { get; set; }
        public string TimeName { get; set; }
    }
}
