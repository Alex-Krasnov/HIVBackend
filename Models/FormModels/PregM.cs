namespace HIVBackend.Models.FormModels
{
    public class PregM
    {
        public int PatientId { get; set; }
        public int PregId { get; set; }
        public int? OldPregId { get; set; }
        public bool? PwCheck { get; set; }
        public int? PwMonth { get; set; }
        public string? PregDate { get; set; }
        public string? ChildBirthDate { get; set; }
        public string? BirthType { get; set; }
        public string? ChildCount { get; set; }
        public int? ChildId { get; set; }
        public int? StartMonth { get; set; }
        public string? ChildFamilyName { get; set; }
        public string? ChildFirstName { get; set; }
        public string? ChildThirdName { get; set; }
        public string? PregDescr { get; set; }
        public string? PhpSchema1 { get; set; }
        public string? PhpSchema2 { get; set; }
        public string? PhpSchema3 { get; set; }
    }
}
