namespace HIVBackend.Models.FormModels
{
    public class Chemsex
    {
        public int? DrugId { get; set; }
        public int PatientId { get; set; }
        public string? YnName { get; set; }
        public string? DrugName { get; set; }
        public string? ContactTypeName { get; set; }
    }
}
