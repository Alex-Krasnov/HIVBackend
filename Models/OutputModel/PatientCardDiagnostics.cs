namespace HIVBackend.Models.OutputModel
{
    public class PatientCardDiagnostics
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public bool IsNonResident { get; set; } = false;

        public List<FrmDiag3Col>? VirusLoads { get; set; }
        public List<FrmDiag3Col>? CMVs { get; set; }
        public List<FrmDiag2Col>? VirusLoadsQuals { get; set; }
        public List<FrmDiag2Col>? IHLs { get; set; }
        public List<FrmImStat>? ImStats { get; set; }
        public List<FrmImStatCD348>? ImStatCD348s { get; set; }
        public List<FrmDrugRemains>? DrugRemains { get; set; }
    }
    public class FrmImStat
    {
        public DateOnly Date { get; set; }
        public string? Result { get; set; }
        public string? ResultPercent { get; set; }
    }

    public class FrmImStatCD348
    {
        public DateOnly? Date { get; set; }
        public string? ResultCD3 { get; set; }
        public string? ResultCD4 { get; set; }
        public string? ResultCD4Percent { get; set; }
        public string? ResultCD8 { get; set; }
        public string? ResultCD8Percent { get; set; }
        public string? ResultCD4CD8 { get; set; }
    }

    public class FrmDiag3Col
    {
        public DateOnly Date { get; set; }
        public string? Result { get; set; }
        public string? ResultDescr { get; set; }
    }

    public class FrmDrugRemains
    {
        public DateOnly CurrentDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly TakeDrugDate { get; set; }
        public string DrugName { get; set; }
        public string DrugCount { get; set; }
    }
}
