namespace HIVBackend.Models.OutputModel
{
    public class PatientCardRecipe
    {
        public int PatientId { get; set; }
        public string PatientFio { get; set; }

        public List<string>? ListDoctor { get; set; }
        public List<string>? ListMedicine { get; set; }
        public List<string>? ListFinSource { get; set; }

        public List<FrmRecipe>? Recipes { get; set; }
    }
    public class FrmRecipe
    {
        public string Ser { get; set; }
        public string Num { get; set; }
        public DateOnly? PrescrDate { get; set; }
        public string? Doctor { get; set; }
        public string? Medicine { get; set; }
        public string? PackNum { get; set; }
        public string? FinSource { get; set; }
        public DateOnly? GiveDate { get; set; }
        public bool? GiveDateCheck { get; set; }
        public string? MedicineGive { get; set; }
        public string? PackNumGive { get; set; }
    }
}
