namespace HIVBackend.Models.FormModels
{
    public class HospResult
    {
        public int PatientId { get; set; }
        public string LpuName { get; set;}
        public string DateHospIn { get; set;}
        public string? LpuNameOld { get; set; }
        public string? DateHospInOld { get; set; }
        public string? DateHospOut { get; set; }
        public string? HospResultName { get; set; }
        public string? HospCourseName { get; set; }
    }
}
