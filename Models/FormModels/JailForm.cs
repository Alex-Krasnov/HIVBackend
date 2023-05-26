namespace HIVBackend.Models.FormModels
{
    public class JailForm
    {
        public int PatientId { get; set; }
        public string? JailName { get; set; }
        public string? JailLeavName { get; set; }
        public string JailStart { get; set; }
        public string JailEnd { get; set; }
        public string? JailStartOld { get; set; }
        public string? JailEndOld { get; set; }
    }
}
