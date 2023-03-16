namespace HIVBackend.Models.FormModels
{
    public class Blot
    {
        public int PatientId { get; set; }
        public int BlotId { get; set; }
        public int? BlotIdOld { get; set; }
        public int? BlotNo { get; set; }
        public string? BlotDate { get; set; }
        public string? IbResultId { get; set; }
        public string? CheckPlaceId { get; set; }
        public bool? First1 { get; set; }
        public bool? Last1 { get; set; }
        public bool? FlgIfa { get; set; }
    }
}
