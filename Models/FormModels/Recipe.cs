namespace HIVBackend.Models.FormModels
{
    public class Recipe
    {
        public int PatientId { get; set; }
        public string Ser { get; set; }
        public string Num { get; set; }
        public string? PrescrDate { get; set; }
        public string? Doctor { get; set; }
        public string? Medicine { get; set; }
        public int? PackNum { get; set; }
        public string? FinSource { get; set; }
        public string? GiveDate { get; set; }
        public bool? GiveDateCheck { get; set; }
        public string? MedicineGive { get; set; }
        public int? PackNumGive { get; set; }
        public string? SerOld { get; set; }
        public string? NumOld { get; set; }
    }
}
