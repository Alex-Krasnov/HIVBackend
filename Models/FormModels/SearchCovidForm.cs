using System;

namespace HIVBackend.Models.FormModels
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


        public Boolean selectInpDate { get; set; }
        public Boolean selectPatientId { get; set; }
        public Boolean selectFio { get; set; }
        public Boolean selectSex { get; set; }
        public Boolean selectBirthDate { get; set; }
        public Boolean selectRegion { get; set; }
        public Boolean selectRegionFact { get; set; }
        public Boolean selectCountry { get; set; }
        public Boolean selectRegOnDate { get; set; }
        public Boolean selectStage { get; set; }
        public Boolean selectDieDate { get; set; }
        public Boolean selectCheckCourse { get; set; }
        public Boolean selectDieCourse { get; set; }
        public Boolean selectInfectCourse { get; set; }
        public Boolean selectShowIllnes { get; set; }
        public Boolean selectIb { get; set; }
        public Boolean selectHospCourse { get; set; }
        public Boolean selectArt { get; set; }
        public Boolean selectMkb10 { get; set; }

        public Boolean selectMkb10Covid { get; set; }
        public Boolean selectMkb10Tuber { get; set; }
        public Boolean selectMkb10Pneumonia { get; set; }
        public Boolean selectHospCovid { get; set; }
        public Boolean selectClinVarCovid { get; set; }
        public Boolean selectCourseCovid { get; set; }
        public Boolean selectArterHyper { get; set; }
        public Boolean selectDiabetes { get; set; }
        public Boolean selectCoronarySynd { get; set; }
        public Boolean selectHobl { get; set; }
        public Boolean selectBronhAstma { get; set; }
        public Boolean selectCancer { get; set; }
        public Boolean selectKidneyDes { get; set; }
        public Boolean selectOutpatTreat { get; set; }
        public Boolean selectDeathCovid { get; set; }
        public Boolean selectOrit { get; set; }
        public Boolean selectOxygen { get; set; }
        public Boolean selectTypeAlv { get; set; }
        public Boolean selectPeriodDes { get; set; }
        public Boolean selectPositivResCovid { get; set; }
        public Boolean selectNegativeResCovid { get; set; }
        public Boolean selectHospitalization { get; set; }
        public Boolean selectDischarge { get; set; }

        public int Page { get; set; }
    }
}
