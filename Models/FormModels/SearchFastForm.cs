namespace HIVBackend.Models.FormModels
{
    public class SearchFastForm
    {
        public string? PatientId { get; set; }
        public string? CardNo { get; set; }
        public string? FamilyName { get; set;}
        public string? FirstName { get; set; }
        public string? ThirdName { get; set; }
        public string? BirthDateStart { get; set; }
        public string? BirthDateEnd { get; set; }
        public int Page { get; set; }
    }
}
