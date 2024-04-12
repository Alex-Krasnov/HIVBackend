namespace HIVBackend.Models.FormModels
{
    public class EpidChild
    {
        public int? Id { get; set; }
        public int PatientId { get; set; }
        public string? SexName { get; set; }
        public string? ChildFamilyName { get; set; }
        public string? ChildFirstName { get; set; }
        public string? ChildThirdName { get; set; }
        public string? BirthDate { get; set; }
        public bool Exam { get; set; }
    }
}
