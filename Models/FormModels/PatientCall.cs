namespace HIVBackend.Models.FormModels
{
    public class PatientCall
    {
        public int? Id { get; set; }
        public string? CallStatusName { get; set; }
        public int PatientId { get; set; }
        public string? CallDate { get; set; }
    }
}
