namespace HIVBackend.Models.FormModels.Search
{
    public class SearchCovidForm
    {
        public string dateInpStart { get; set; }
        public string dateInpEnd { get; set; }
        public string patientId { get; set; }
        public string familyName { get; set; }
        public string firstName { get; set; }
        public string thirdName { get; set; }
        public string fioChange { get; set; }
        public string sex { get; set; }
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
        public string unRegCourse { get; set; }
        public string[]? stage { get; set; }
        public string dateDieStart { get; set; }
        public string dateDieEnd { get; set; }
        public string dateDieAidsStart { get; set; }
        public string dateDieAidsEnd { get; set; }
        public string[]? checkCourse { get; set; }
        public string[]? dieCourse { get; set; }
        public string diePreset { get; set; }
        public string[]? infectCourse { get; set; }
        public string[]? showIllnes { get; set; }
        public string dateShowIllnesStart { get; set; }
        public string dateShowIllnesEnd { get; set; }
        public string ibRes { get; set; }
        public string dateIbResStart { get; set; }
        public string dateIbResEnd { get; set; }
        public string ibNum { get; set; }
        public string dateInpIbStart { get; set; }
        public string dateInpIbEnd { get; set; }
        public string ibSelect { get; set; }
        public string[]? hospCourse { get; set; }
        public string[]? art { get; set; }
        public string[]? mkb10 { get; set; }


        public string[]? mkb10Covid { get; set; }
        public string[]? mkb10Tuber { get; set; }
        public string[]? mkb10Pneumonia { get; set; }
        public string[]? hospCovid { get; set; }
        public string[]? clinVarCovid { get; set; }
        public string[]? courseCovid { get; set; }
        public string arterHyperYn { get; set; }
        public string diabetesYn { get; set; }
        public string coronarySyndYn { get; set; }
        public string hoblYn { get; set; }
        public string bronhAstmaYn { get; set; }
        public string cancerYn { get; set; }
        public string kidneyDesYn { get; set; }
        public string outpatTreatYn { get; set; }
        public string deathCovidYn { get; set; }
        public string oritYn { get; set; }
        public string oxygenYn { get; set; }
        public string typeAlvYn { get; set; }
        public string periodDesStart { get; set; }
        public string periodDesEnd { get; set; }
        public string positivResCovidStart { get; set; }
        public string positivResCovidEnd { get; set; }
        public string negativeResCovidStart { get; set; }
        public string negativeResCovidEnd { get; set; }
        public string hospitalizationStart { get; set; }
        public string hospitalizationEnd { get; set; }
        public string dischargeStart { get; set; }
        public string dischargeEnd { get; set; }


        public bool selectInpDate { get; set; }
        public bool selectPatientId { get; set; }
        public bool selectFio { get; set; }
        public bool selectSex { get; set; }
        public bool selectBirthDate { get; set; }
        public bool selectRegion { get; set; }
        public bool selectRegionFact { get; set; }
        public bool selectCountry { get; set; }
        public bool selectRegOnDate { get; set; }
        public bool selectStage { get; set; }
        public bool selectDieDate { get; set; }
        public bool selectCheckCourse { get; set; }
        public bool selectDieCourse { get; set; }
        public bool selectInfectCourse { get; set; }
        public bool selectShowIllnes { get; set; }
        public bool selectIb { get; set; }
        public bool selectHospCourse { get; set; }
        public bool selectArt { get; set; }
        public bool selectMkb10 { get; set; }

        public bool selectMkb10Covid { get; set; }
        public bool selectMkb10Tuber { get; set; }
        public bool selectMkb10Pneumonia { get; set; }
        public bool selectHospCovid { get; set; }
        public bool selectClinVarCovid { get; set; }
        public bool selectCourseCovid { get; set; }
        public bool selectArterHyper { get; set; }
        public bool selectDiabetes { get; set; }
        public bool selectCoronarySynd { get; set; }
        public bool selectHobl { get; set; }
        public bool selectBronhAstma { get; set; }
        public bool selectCancer { get; set; }
        public bool selectKidneyDes { get; set; }
        public bool selectOutpatTreat { get; set; }
        public bool selectDeathCovid { get; set; }
        public bool selectOrit { get; set; }
        public bool selectOxygen { get; set; }
        public bool selectTypeAlv { get; set; }
        public bool selectPeriodDes { get; set; }
        public bool selectPositivResCovid { get; set; }
        public bool selectNegativeResCovid { get; set; }
        public bool selectHospitalization { get; set; }
        public bool selectDischarge { get; set; }

        public int Page { get; set; }
        public bool Excel { get; set; }
    }
}
