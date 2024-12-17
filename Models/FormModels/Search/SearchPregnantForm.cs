namespace HIVBackend.Models.FormModels.Search
{
    public class SearchPregnantForm
    {
        public string dateInpStart { get; set; }
        public string dateInpEnd { get; set; }
        public string patientId { get; set; }
        public string familyName { get; set; }
        public string firstName { get; set; }
        public string thirdName { get; set; }
        public string birthDateStart { get; set; }
        public string birthDateEnd { get; set; }
        public string[]? regionReg { get; set; }
        public string regionPreset { get; set; }
        public string[]? regionFact { get; set; }
        public string factRegionPreset { get; set; }
        public string[]? country { get; set; }
        public string dateRegOnStart { get; set; }
        public string dateRegOnEnd { get; set; }
        public string dateUnRegStart { get; set; }
        public string dateUnRegEnd { get; set; }
        public string[]? stage { get; set; }
        public string[]? checkCourse { get; set; }
        public string[]? infectCourse { get; set; }
        public string[]? showIllnes { get; set; }
        public string dateShowIllnesStart { get; set; }
        public string dateShowIllnesEnd { get; set; }
        public string transfAreaYNA { get; set; }
        public string dateTransfAreaStart { get; set; }
        public string dateTransfAreaEnd { get; set; }
        public string frYNA { get; set; }
        public string zavApoYNA { get; set; }
        public string ufsinYNA { get; set; }
        public string dateUfsinStart { get; set; }
        public string dateUfsinEnd { get; set; }

        public string[]? pregCheck { get; set; }
        public string pregMonthNo { get; set; }
        public string[]? birthType { get; set; }
        public string medecineStartMonthNo { get; set; }
        public string childBirthDateStart { get; set; }
        public string childBirthDateEnd { get; set; }
        public string childFamilyName { get; set; }
        public string childFirstName { get; set; }
        public string childThirdName { get; set; }
        public string cardNo { get; set; }
        public string[]? phpSchema1 { get; set; }
        public string[]? phpSchema2 { get; set; }
        public string[]? phpSchema3 { get; set; }
        public string[]? medecineForSchema1 { get; set; }
        public string[]? medecineForSchema2 { get; set; }
        public string[]? medecineForSchema3 { get; set; }
        public string[]? art { get; set; }
        public string[]? materhome { get; set; }
        public string aclDateStart { get; set; }
        public string aclDateEnd { get; set; }
        public string aclMcnCodeStart { get; set; }
        public string aclMcnCodeEnd { get; set; }

        public bool selectInpDate { get; set; }
        public bool selectPatientId { get; set; }
        public bool selectFio { get; set; }
        public bool selectBirthDate { get; set; }
        public bool selectRegion { get; set; }
        public bool selectRegionFact { get; set; }
        public bool selectCountry { get; set; }
        public bool selectRegOnDate { get; set; }
        public bool selectStage { get; set; }
        public bool selectCheckCourse { get; set; }
        public bool selectInfectCourse { get; set; }
        public bool selectShowIllnes { get; set; }
        public bool selectTransfArea { get; set; }
        public bool selectFr { get; set; }
        public bool selectUfsin { get; set; }

        public bool selectPregCheck { get; set; }
        public bool selectPregMonthNo { get; set; }
        public bool selectBirthType { get; set; }
        public bool selectMedecineStartMonthNo { get; set; }
        public bool selectChildBirthDate { get; set; }
        public bool selectChildFio { get; set; }
        public bool selectCardNo { get; set; }
        public bool selectPhpSchema1 { get; set; }
        public bool selectPhpSchema2 { get; set; }
        public bool selectPhpSchema3 { get; set; }
        public bool selectMedecineForSchema1 { get; set; }
        public bool selectMedecineForSchema2 { get; set; }
        public bool selectMedecineForSchema3 { get; set; }
        public bool selectArt { get; set; }
        public bool selectAddr { get; set; }
        public bool selectMaterhome { get; set; }
        public bool selectAclDate { get; set; }
        public bool selectAclMcnCode { get; set; }

        public int Page { get; set; }
        public bool Excel { get; set; }
    }
}
