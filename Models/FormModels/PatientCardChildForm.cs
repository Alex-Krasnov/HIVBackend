namespace HIVBackend.Models.FormModels
{
    public class PatientCardChildForm
    {
        public int PatientId { get; set; }
        public string? FamilyType { get; set; }
        public int? MId { get; set; }
        public int? FId { get; set; }
        public string? FirstCheckDate { get; set; }
        public string? ChildPlace { get; set; }
        public float? BreastMonth { get; set; }
        public string? ChildPhp { get; set; }
        public string? MaterHome { get; set; }
        public string? ChildDescr { get; set; }
        public decimal? Growth { get; set; }
        public decimal? Weight { get; set; }
        public string? Forma309 { get; set; }
        public string? LastCareDate { get; set; }
        public string? CommunicationParentDate { get; set; }
        public string? CallingDistrictSpecDate { get; set; }
        public bool? RefusalPhp { get; set; }
        public bool? RefusalResearch { get; set; }
        public bool? RefusalTherapy { get; set; }
    }
}
