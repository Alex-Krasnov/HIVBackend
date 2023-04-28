namespace HIVBackend.Models.FormModels
{
    public class RegistryIn
    {
        public int PatientId { get; set; }
        public string RegDate { get; set; }
        public string RegCab { get; set; }
        public string? RegTime { get; set; }
        public string? RegDoc { get; set; }
        public string? RegCom { get; set; }
        public bool? RegCheck { get; set; }
        public string? RegDateOld { get; set; }
        public string? RegCabOld { get; set; }
    }
}
