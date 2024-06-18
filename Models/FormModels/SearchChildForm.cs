namespace HIVBackend.Models.FormModels
{
    public class SearchChildForm
    {
        public string dateInpStart { get; set; }
        public string dateInpEnd { get; set; }
        public string patientId { get; set; }
        public string familyName { get; set; }
        public string firstName { get; set; }
        public string thirdName { get; set; }
        public string birthDateStart { get; set; }
        public string birthDateEnd { get; set; }
        public string ageDayStart { get; set; }
        public string ageDayEnd { get; set; }
        public string[]? regionReg { get; set; }
        public string regionPreset { get; set; }
        public string[]? regionFact { get; set; }
        public string factRegionPreset { get; set; }
        public string[]? country { get; set; }
        public string dateRegOnStart { get; set; }
        public string dateRegOnEnd { get; set; }
        public string dateUnRegStart { get; set; }
        public string dateUnRegEnd { get; set; }
        public string unRegCourse { get; set; }
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

        public string[]? familyType { get; set; }
        public string firstCheckDateStart { get; set; }
        public string firstCheckDateEnd { get; set; }
        public string[]? childPlace { get; set; }
        public string breastMonthNoStart { get; set; }
        public string breastMonthNoEnd { get; set; }
        public string[]? childPhp { get; set; }
        public string sex { get; set; }
        public string cardNo { get; set; }
        public string motherPatientId { get; set; }
        public string fatherPatientId { get; set; }
        public string[]? arvt { get; set; }
        public string dieDateStart { get; set; }
        public string dieDateEnd { get; set; }
        public string dieAidsDateStart { get; set; }
        public string dieAidsDateEnd { get; set; }
        public string[]? materHome { get; set; }
        public string form309 { get; set; }


        public Boolean selectInpDate { get; set; }
        public Boolean selectPatientId { get; set; }
        public Boolean selectFio { get; set; }
        public Boolean selectBirthDate { get; set; }
        public Boolean selectRegion { get; set; }
        public Boolean selectRegionFact { get; set; }
        public Boolean selectCountry { get; set; }
        public Boolean selectRegOnDate { get; set; }
        public Boolean selectStage { get; set; }
        public Boolean selectCheckCourse { get; set; }
        public Boolean selectInfectCourse { get; set; }
        public Boolean selectShowIllnes { get; set; }
        public Boolean selectTransfArea { get; set; }
        public Boolean selectFr { get; set; }

        public Boolean selectFamilyType { get; set; }
        public Boolean selectFirstCheckDate { get; set; }
        public Boolean selectChildPlace { get; set; }
        public Boolean selectBreastMonthNo { get; set; }
        public Boolean selectChildPhp { get; set; }
        public Boolean selectSex { get; set; }
        public Boolean selectCardNo { get; set; }
        public Boolean selectParentId { get; set; }
        public Boolean selectAddr { get; set; }
        public Boolean selectArvt { get; set; }
        public Boolean selectDieDate { get; set; }
        public Boolean selectMaterHome { get; set; }
        public Boolean selectForm309 { get; set; }

        public int Page { get; set; }
        public Boolean Excel { get; set; }
    }
}
