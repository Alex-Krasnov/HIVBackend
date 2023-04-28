namespace HIVBackend.Models.FormModels
{
    public class Check
    {
        public int PatientId { get; set; }
        public string CheckDate { get; set;}
        public string SpecName { get; set;}
        public string? CheckDateNetx { get; set;}
        public string CheckDocName { get; set;}

        public string? CheckDateOld { get; set; }
        public string? SpecNameOld { get; set; }
        public string? CheckDocNameOld { get; set; }
    }
}
