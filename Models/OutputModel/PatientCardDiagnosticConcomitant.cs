namespace HIVBackend.Models.OutputModel
{
    public class PatientCardDiagnosticConcomitant
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }

        public List<FrmHepCPcr>? HepCPcrs { get; set; }
        public List<FrmDiag3Col>? HepBPcrs { get; set; }
        public List<FrmDiag2Col>? HepCIfas { get; set; }
        public List<FrmDiag2Col>? HepBIfas { get; set; }
        public List<FrmDiag2Col>? SiphilisIfas { get; set; }
        public List<FrmDiag2Col>? ToxIggs { get; set; }
        public List<FrmDiag2Col>? ToxIgms { get; set; }
        public List<FrmDiag3Col>? Vpchs { get; set; }
    }

    public class FrmHepCPcr
    {
        public DateOnly Date { get; set; }
        public string? Result { get; set; }
        public string? ResultDescr { get; set; }
        public string? P0025 { get; set; }
        public string? P0025R { get; set; }
    }

    public class FrmDiag2Col
    {
        public DateOnly Date { get; set; }
        public string? Result { get; set; }
    }

}
