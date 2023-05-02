namespace HIVBackend.Models.OutputModel
{
    public class PatientCardDiagnostics
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }

        public List<FrmVirusLoad>? VirusLoads { get; set; }
        public List<FrmVirusLoadQual>? VirusLoadsQuals { get; set; }
        public List<FrmCMV>? CMVs { get; set; }
        public List<FrmImStat>? ImStats { get; set; }
        public List<FrmImStatCD348>? ImStatCD348s { get; set; }
        public List<FrmIHL>? IHLs { get; set; }
    }

    public class FrmVirusLoad
    {
        public DateOnly? Date { get; set; }
        public string? Result { get; set; }
        public string? ResultDescr { get; set; }
    }

    public class FrmVirusLoadQual
    {
        public DateOnly? Date { get; set; }
        public string? Result { get; set; }
    }

    public class FrmCMV
    {
        public DateOnly? Date { get; set; }
        public string? Result { get; set; }
        public string? ResultDescr { get; set; }
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

    public class FrmIHL
    {
        public DateOnly? Date { get; set; }
        public string? Result { get; set; }
    }
}
