namespace HIVBackend.Models.FormModels
{
    public class Stage
    {
        public int PatientId { get; set; }
        public string StageDate { get; set; }
        public string? StageName { get; set; }
        public string? StageDateOld { get; set; }
    }
}
