namespace HIVBackend.Models.OutputModel
{
    public class PatientCardPregnant
    {
        public int PatientId { get; set; }
        public string PatientFio { get; set; }
        public string? PregCheck { get; set; }
        public int? PregMonth { get; set; }

        public List<string>? ListPregCheck { get; set; }
        public List<string>? ListBirthType { get; set; }
        public List<string>? ListChildCount { get; set; }

        public List<PregnantM>? PregnantMs { get; set; }
    }

    public class PregnantM
    {
        public int PregId { get; set; }
        public bool? PwCheck { get; set; }
        public int? PwMonth { get; set; }
        public DateOnly? PregDate { get; set; }
        public DateOnly? ChildBirthDate { get; set; }
        public string? BirthType { get; set; }
        public string? ChildCount { get; set; }
        public int? ChildId { get; set; }
        public DateOnly? StartMonth { get; set; }
        public string? ChildFamilyName { get; set; }
        public string? ChildFirstName { get; set; }
        public string? ChildThirdName { get; set; }
        public string? PregDescr { get; set; }
        public string? PhpSchema1 { get; set; }
        public string? PhpSchema2 { get; set; }
        public string? PhpSchema3 { get; set; }
    }
}
