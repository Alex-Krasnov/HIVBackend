namespace HIVBackend.Models.FormModels
{
    public class Contact
    {
        public int PatientId { get; set; }
        public int ContactId { get; set; }
        public string? InfectCourseName { get; set; }
        public int? Type { get; set; }
        public int? ContactIdOld { get; set; }
    }
}
