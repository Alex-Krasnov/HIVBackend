namespace HIVBackend.Models.OutputModel
{
    public class PatientCardCovid
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }

        public List<string>? ListYN { get; set; }
        public List<string>? ListOutHosp { get; set; }
        public List<string>? ListClinVarCOVID { get; set; }
        public List<string>? ListCourseCOVID { get; set; }
        public List<string>? ListMkb10COVIDShort { get; set; }
        public List<string>? ListMkb10COVIDLong { get; set; }
        public List<string>? ListMkbTuderShort { get; set; }
        public List<string>? ListMkbTuderLong { get; set; }
        public List<string>? ListMkbPneumoniaShort { get; set; }
        public List<string>? ListMkbPneumoniaLong { get; set; }
        public List<string>? ListCommitment { get; set; }
        public List<string>? ListAvlType { get; set; }
        public List<string>? ListFullMKB10Short { get; set; }
        public List<string>? ListFullMKB10Long { get; set; }

        public List<Covid>? Covids { get; set; }
        public List<SubCovid>? OtherDiags { get; set; }
        public List<SubCovid>? PatDiags { get; set; }
    }
    public class Covid
    {
        public int IdCovid { get; set; }
        public DateOnly? PeriodDesDate { get; set; }
        public DateOnly? PositiveResCovidDate { get; set; }
        public DateOnly? NegativeResCovidDate { get; set; }
        public DateOnly? HospDate { get; set; }
        public DateOnly? DischargeDate { get; set; }
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
    public class SubCovid
    {
        public int Id { get; set; }
        public string? NameShort { get; set; }
        public string? NameLong { get; set; }
        public string? Comm { get; set; }

    }
}
