namespace HIVBackend.Models.FormModels
{
    public class ReferalAnalysis
    {
        public bool IsExtended { get; set; }
        public int PatientId { get; set; }
        public string DocName { get; set; }
        public List<string>? ListResearch { get; set; }
    }
}
