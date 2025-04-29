namespace HIVBackend.Models.OutputModel
{
    public class PatientCardChild
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public string? FamilyType { get; set; }
        public int? MId { get; set; }
        public string? MFio { get; set; }
        public int? FId { get; set; }
        public string? FFio { get; set; }
        public DateOnly? FirstCheckDate { get; set; }
        public string? ChildPlace { get; set; }
        public float? BreastMonth { get; set; }
        public string? ChildPhp { get; set; }
        public string? MaterHome { get; set; }
        public string? ChildDescr { get; set; }
        public decimal? Growth { get; set; }
        public decimal? Weight { get; set; }
        public string? Forma309 { get; set; }
        public DateOnly? LastCareDate { get; set; }
        public DateOnly? CommunicationParentDate { get; set; }
        public DateOnly? CallingDistrictSpecDate { get; set; }
        public bool RefusalPhp { get; set; }
        public bool RefusalResearch { get; set; }
        public bool RefusalTherapy { get; set; }

        public List<string>? ListFamilyType { get; set; }
        public List<string>? ListChildPlace { get; set; }
        public List<string>? ListChildPhp { get; set; }
        public List<string>? ListMaterHome { get; set; }
        public List<string>? ListForm309 { get; set; }
    }
}
