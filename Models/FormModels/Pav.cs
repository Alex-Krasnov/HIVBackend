namespace HIVBackend.Models.FormModels
{
    public class Pav
    {
        public int? DrugId { get; set; }
        public int PatientId { get; set; } 
        public string? YnName { get; set; }
        public string? DrugName { get; set; }
        public string? DateStart { get; set; }
        public string? DateEnd { get; set; }
    }
}
