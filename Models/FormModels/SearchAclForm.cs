namespace HIVBackend.Models.FormModels
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
        public Boolean biochemistry { get; set; }
        public Boolean hematology { get; set; }
        public string aclSampleDateStart { get; set; }
        public string aclSampleDateEnd { get; set; }


        public Boolean selectInpDate { get; set; }
        public Boolean selectPatientId { get; set; }
        public Boolean selectFio { get; set; }
        public Boolean selectSex { get; set; }
        public Boolean selectBirthDate { get; set; }
        public Boolean selectRegion { get; set; }
        public Boolean selectRegionFact { get; set; }
        public Boolean selectRegOnDate { get; set; }
        public Boolean selectStage { get; set; }
        public Boolean selectCheckCourse { get; set; }
        public Boolean selectIb { get; set; }
        public Boolean selectTestCode { get; set; }
        public Boolean selectSampleDate { get; set; }


        public int Page { get; set; }
        public Boolean Excel { get; set; }
    }
}
