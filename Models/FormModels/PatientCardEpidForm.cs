namespace HIVBackend.Models.FormModels
{
    public class PatientCardEpidForm
    {
        public int PatientId { get; set; }
        public string? DtMailReg { get; set; }
        public string? NumMail { get; set; }
        public string? EduName { get; set; }
        public string? FamilyStatusName { get; set; }
        public string? EmploymentName { get; set; }
        public string? TransName { get; set; }
        public string? EpidemCom { get; set; }
        public string? TransmitionMechName { get; set; }
        public string? SituationDetectName { get; set; }
        public string? EpidTimeInfectStart { get; set; }
        public string? EpidTimeInfectEnd { get; set; }
        public string? EpidDocName { get; set; }
    }
}
