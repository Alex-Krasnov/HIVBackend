namespace HIVBackend.Models.FormModels
{
    public class Diag3Col
    {
        public int PatientId { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public float? Result { get; set; }
        public string? ResultDescr { get; set; }
        public string? DateOld { get; set; }
    }
}
