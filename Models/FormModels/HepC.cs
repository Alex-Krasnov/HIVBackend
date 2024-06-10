namespace HIVBackend.Models.FormModels
{
    public class HepC
    {
        public int? Id { get; set; }
        public int PatientId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public string? Descr { get; set; }
    }
}
