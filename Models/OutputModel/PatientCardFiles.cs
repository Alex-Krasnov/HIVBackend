namespace HIVBackend.Models.OutputModel
{
    public class PatientCardFiles
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public List<string>? Files { get; set; }
    }
}
