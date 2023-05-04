namespace HIVBackend.Models.OutputModel
{
    public class PatientCardDiagnosticManual
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }

        public List<string>? ListVLResult { get; set; }
        public List<string>? ListHCResult { get; set; }
        public List<string>? ListHBResult { get; set; }

        public List<FrmDiag3Col>? VirusLoads { get; set; }
        public List<FrmDiag3Col>? HepCs { get; set; }
        public List<FrmDiag3Col>? HepBs { get; set; }
    }
}
