namespace HIVBackend.Models.FormModels.Search
{
    public class SearchAclForm
    {
        public string dateInpStart { get; set; }
        public string dateInpEnd { get; set; }
        public string patientId { get; set; }
        public string familyName { get; set; }
        public string firstName { get; set; }
        public string thirdName { get; set; }
        public string sex { get; set; }
        public string birthDateStart { get; set; }
        public string birthDateEnd { get; set; }
        public string[]? regionReg { get; set; }
        public string regionPreset { get; set; }
        public string[]? regionFact { get; set; }
        public string factRegionPreset { get; set; }
        public string dateRegOnStart { get; set; }
        public string dateRegOnEnd { get; set; }
        public string dateUnRegStart { get; set; }
        public string dateUnRegEnd { get; set; }
        public string[]? stage { get; set; }
        public string[]? checkCourse { get; set; }
        public string ibRes { get; set; }
        public string dateIbResStart { get; set; }
        public string dateIbResEnd { get; set; }
        public string ibNum { get; set; }
        public string dateInpIbStart { get; set; }
        public string dateInpIbEnd { get; set; }
        public string ibSelect { get; set; }

        public string aclTestCode1 { get; set; }
        public string aclTestCode2 { get; set; }
        public string aclTestCode3 { get; set; }
        public string aclTestCode4 { get; set; }
        public string aclTestCode5 { get; set; }
        public string aclTestCode6 { get; set; }
        public string aclTestCode7 { get; set; }
        public bool biochemistry { get; set; }
        public bool hematology { get; set; }
        public string aclSampleDateStart { get; set; }
        public string aclSampleDateEnd { get; set; }


        public bool selectInpDate { get; set; }
        public bool selectPatientId { get; set; }
        public bool selectFio { get; set; }
        public bool selectSex { get; set; }
        public bool selectBirthDate { get; set; }
        public bool selectRegion { get; set; }
        public bool selectRegionFact { get; set; }
        public bool selectRegOnDate { get; set; }
        public bool selectStage { get; set; }
        public bool selectCheckCourse { get; set; }
        public bool selectIb { get; set; }
        public bool selectTestCode { get; set; }
        public bool selectSampleDate { get; set; }


        public int Page { get; set; }
        public bool Excel { get; set; }
    }
}
