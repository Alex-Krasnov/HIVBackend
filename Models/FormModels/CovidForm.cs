namespace HIVBackend.Models.FormModels
{
    public class CovidForm
    {
        public int? IdCovid { get; set; }
        public int PatientId { get; set; }
        public string? PeriodDesDate { get; set; }
        public string? PositiveResCovidDate { get; set; }
        public string? NegativeResCovidDate { get; set; }
        public string? HospDate { get; set; }
        public string? DischargeDate { get; set; }
        public string? OutPatTreat { get; set; }
        public string? DeathCovid { get; set; }
        public string? Orit { get; set; }
        public string? Oxygen { get; set; }
        public string? Avl { get; set; }
        public string? ArterHyper { get; set; }
        public string? Deabetes { get; set; }
        public string? CoronarySynd { get; set; }
        public string? Hobl { get; set; }
        public string? BronhAstma { get; set; }
        public string? Cancer { get; set; }
        public string? KidneyDes { get; set; }
        public string? OutcomeHosp { get; set; }
        public string? ClinVarCovid { get; set; }
        public string? SeverityCovid { get; set; }
        public string? CovidMKB10Short { get; set; }
        public string? CovidMKB10Long { get; set; }
        public string? TubercuosisShort { get; set; }
        public string? TubercuosisLong { get; set; }
        public string? PneumoniaShort { get; set; }
        public string? PneumoniaLong { get; set; }
        public string? TypeAvl { get; set; }
        public string? Commitment { get; set; }
        public string? Comm { get; set; }
    }
}
