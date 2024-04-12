namespace HIVBackend.Models.OutputModel
{
    public class PatientCardEpid
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public DateOnly? DtMailReg { get; set; }
        public string? NumMail { get; set; }
        public string? EduName { get; set; }
        public string? FamilyStatusName { get; set; }
        public string? EmploymentName { get; set; }
        public string? TransName { get; set; }
        public string? EpidemCom { get; set; }
        public string? TransmitionMechName { get; set; }
        public string? SituationDetectName { get; set; }
        public DateOnly? EpidTimeInfectStart { get; set; }
        public DateOnly? EpidTimeInfectEnd { get; set; }
        public string? EpidDocName { get; set; }
        public int MaxIdEpidChil { get; set; }
        public int MaxIdCall { get; set; }

        public List<string>? ListTypeContacts { get; set; }
        public List<string>? ListYn { get; set; }
        public List<string>? ListEdu { get; set; }
        public List<string>? ListFamilyStatus { get; set; }
        public List<string>? ListEmployment { get; set; }
        public List<string>? ListTrans { get; set; }
        public List<string>? ListVac { get; set; }
        public List<string>? ListCovidMKB { get; set; }
        public List<string>? ListTransmitionMech { get; set; }
        public List<string>? ListSituationDetect { get; set; }
        public List<string>? ListEpidDoc { get; set; }
        public List<string>? ListSex { get; set; }
        public List<string>? ListCallStatus { get; set; }

        public List<FrmPatientContact>? ConstantContact { get; set; }
        public List<FrmPatientContact>? RandomContact { get; set; }
        public List<FrmPatientContact>? OtherContact { get; set; }
        public List<FrmChemsex>? Chemsex { get; set; }
        public List<FrmPav>? PavInj { get; set; }
        public List<FrmPav>? PavNotInj { get; set; }
        public List<FrmCovidVac>? CovidVac { get; set; }
        public List<FrmCovid>? Covid { get; set; }
        public List<FrmEpidChild>? EpidChild { get; set; }
        public List<FrmCallStatus>? CallStatuses { get; set; }
    }
    public class FrmPatientContact
    {
        public int ContactId { get; set; }
        public string? InfectCourseName { get; set; }
        public string? Fio { get; set; }
        public int? Type { get; set; }
    }

    public class FrmChemsex
    {
        public int DrugId { get; set; }
        public string? YnName { get; set; }
        public string? DrugName { get; set; }
        public string? ContactTypeName { get; set; }
    }

    public class FrmPav
    {
        public int DrugId { get; set; }
        public string? YnName { get; set; }
        public string? DrugName { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
    }

    public class FrmCovidVac
    {
        public int VacId { get; set; }
        public DateOnly? DVac1 { get; set; }
        public DateOnly? DVac2 { get; set; }
        public string? VacName { get; set; }
        
    }

    public class FrmCovid
    {
        public int CovidId { get; set; }
        public DateOnly? DPositivRes { get; set; }
        public DateOnly? DNegativeRes { get; set; }
        public string? CovidMKB { get; set; }

    }

    public class FrmEpidChild
    {
        public int Id { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? SexName { get; set; }
        public string? FamilyName { get; set; }
        public string? FirstName { get; set; }
        public string? ThirdName { get; set; }
        public bool Exam { get; set; }
    }

    public class FrmCallStatus
    {
        public int Id { get; set; }
        public DateOnly? CallDate { get; set; }
        public string? CallStatus { get; set; }
    }
}
