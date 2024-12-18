namespace HIVBackend.Models.FormModels.Search
{
    public class SearchChildInputForm
    {
        #region поля

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

        #endregion

        #region select поля

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

        public bool selectFamilyType { get; set; }
        public bool selectFirstCheckDate { get; set; }
        public bool selectChildPlace { get; set; }
        public bool selectBreastMonthNo { get; set; }
        public bool selectChildPhp { get; set; }
        public bool selectSex { get; set; }
        public bool selectCardNo { get; set; }
        public bool selectParentId { get; set; }
        public bool selectAddr { get; set; }
        public bool selectArvt { get; set; }
        public bool selectDieDate { get; set; }
        public bool selectMaterHome { get; set; }
        public bool selectForm309 { get; set; }

        #endregion

        public int Page { get; set; }
        public bool Excel { get; set; }
    }
}
