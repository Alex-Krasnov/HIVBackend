namespace HIVBackend.Models.OutputModel
{
    public class PatientCardVisit
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }

        public List<string>? ListSpec { get; set; }
        public List<string>? ListDoctor { get; set; }
        public List<string>? ListCab { get; set; }
        public List<string>? ListRegTime { get; set; }

        public List<FrmPatientCheck>? Checks { get; set; }
        public List<FrmPatientCheck>? ChecksOut { get; set; }
        public List<FrmRegistry>? Registries { get; set; }
    }

    public class FrmPatientCheck
    {
        public DateOnly CheckDate { get; set; }
        public DateOnly? CheckDateNext { get; set; }
        public string CheckSpec { get; set; }
        public string CheckDoc { get; set; }
    }

    public class FrmRegistry
    {
        public DateOnly RegDate { get; set; }
        public string RegCab { get; set; }
        public string? RegTime { get; set; }
        public string? RegDoc { get; set; }
        public string? RegCom { get; set; }
        public bool? RegCheck { get; set; }
    }
}