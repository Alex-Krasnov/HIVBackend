namespace HIVBackend.Models.DTOs.Responses
{
    public class AnalysisDto
    {
        public int PatientId { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string AnalysisCode { get; set; }
        public string Result { get; set; }
    }
}
