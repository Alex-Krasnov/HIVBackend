namespace HIVBackend.Models.FormModels
{
    public class TalonIn
    {
        public int PatientId { get; set; }
        public string RegCab { get; set; }
        public string RegDate { get; set; }
        public int TalonNum { get; set; }

        public string? Field01 { get; set; }
        public string? Field12 { get; set; }
        public string? Field13 { get; set; }
        public string? Field14 { get; set; }
        public string? Field21 { get; set; }
        public string? Field22 { get; set; }
        public string? Field24 { get; set; }
        public string? Field25 { get; set; }
        public string? Field35 { get; set; }
        public string? Field36 { get; set; }
    }
}
