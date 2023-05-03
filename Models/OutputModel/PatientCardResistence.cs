namespace HIVBackend.Models.OutputModel
{
    public class PatientCardResistence
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public List<FrmResistence>? Resistences { get; set; }
    }

    public class FrmResistence
    {
        public DateOnly Date { get; set; }
        public string? Lr001 { get; set; }
        public string? Lr005 { get; set; }
        public string? Lr010 { get; set; }
        public string? Lr015 { get; set; }
        public string? Lr020 { get; set; }
        public string? Lr025 { get; set; }
        public string? Lr030 { get; set; }
        public string? Lr035 { get; set; }
        public string? Lr040 { get; set; }
        public string? Lr045 { get; set; }
        public string? Lr050 { get; set; }
        public string? Lr055 { get; set; }
        public string? Lr060 { get; set; }
        public string? Lr065 { get; set; }
        public string? Lr070 { get; set; }
        public string? Lr075 { get; set; }
        public string? Lr080 { get; set; }
        public string? Lr085 { get; set; }
        public string? Lr090 { get; set; }
        public string? Lr095 { get; set; }
        public string? Lr100 { get; set; }
        public string? Lr105 { get; set; }
        public string? Lr110 { get; set; }
    }
}
