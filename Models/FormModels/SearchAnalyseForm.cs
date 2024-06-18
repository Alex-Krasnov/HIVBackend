namespace HIVBackend.Models.FormModels
{
    public class SearchAnalyseForm
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
        public string[]? country { get; set; }
        public string city { get; set; }
        public string location { get; set; }
        public string indx { get; set; }
        public string street { get; set; }
        public string home { get; set; }
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
        public string[]? dieCourse { get; set; }
        public string diePreset { get; set; }
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
        public string ibRes { get; set; }
        public string dateIbResStart { get; set; }
        public string dateIbResEnd { get; set; }
        public string ibNum { get; set; }
        public string dateInpIbStart { get; set; }
        public string dateInpIbEnd { get; set; }
        public string ibSelect { get; set; }
        public string ufsinYNA { get; set; }
        public string dateUfsinStart { get; set; }
        public string dateUfsinEnd { get; set; }

        public string dateVlStart { get; set; }
        public string dateVlEnd { get; set; }
        public string resVlStart { get; set; }
        public string resVlEnd { get; set; }
        public string dateIMStart { get; set; }
        public string dateImEnd { get; set; }
        public string resImCd3Start { get; set; }
        public string resImCd3End { get; set; }
        public string resImCd4Start { get; set; }
        public string resImCd4End { get; set; }
        public string resImCd8Start { get; set; }
        public string resImCd8End { get; set; }
        public string dateHepCIfaStart { get; set; }
        public string dateHepCIfaEnd { get; set; }
        public string dateHepCIfaVal { get; set; }
        public string dateHepBIfaStart { get; set; }
        public string dateHepBIfaEnd { get; set; }
        public string dateHepBIfaVal { get; set; }
        public string dateHepSyphIfaStart { get; set; }
        public string dateHepSyphIfaEnd { get; set; }
        public string dateHepSyphIfaVal { get; set; }
        public string dateHepCStart { get; set; }
        public string dateHepCEnd { get; set; }
        public string dateHepBStart { get; set; }
        public string dateHepBEnd { get; set; }

        public string? cardNo { get; set; }
        public string[]? art { get; set; }


        public Boolean selectInpDate { get; set; }
        public Boolean selectPatientId { get; set; }
        public Boolean selectFio { get; set; }
        public Boolean selectSex { get; set; }
        public Boolean selectBirthDate { get; set; }
        public Boolean selectRegion { get; set; }
        public Boolean selectRegionFact { get; set; }
        public Boolean selectCountry { get; set; }
        public Boolean selectAddr { get; set; }
        public Boolean selectRegOnDate { get; set; }
        public Boolean selectStage { get; set; }
        public Boolean selectDieDate { get; set; }
        public Boolean selectDieCourse { get; set; }
        public Boolean selectCheckCourse { get; set; }
        public Boolean selectInfectCourse { get; set; }
        public Boolean selectShowIllnes { get; set; }
        public Boolean selectTransfArea { get; set; }
        public Boolean selectFr { get; set; }
        public Boolean selectIb { get; set; }
        public Boolean selectUfsin { get; set; }

        public Boolean selectCardNo { get; set; }
        public Boolean selectArt { get; set; }

        public Boolean selectVlDate { get; set; }
        public Boolean selectVlRes { get; set; }
        public Boolean selectImDate { get; set; }
        public Boolean selectImCd3Res { get; set; }
        public Boolean selectImCd4Res { get; set; }
        public Boolean selectImCd8Res { get; set; }
        public Boolean selectHepCIfa { get; set; }
        public Boolean selectHepBIfa { get; set; }
        public Boolean selectHepSyphIfa { get; set; }
        public Boolean selectHepC { get; set; }
        public Boolean selectHepB { get; set; }


        public int Page { get; set; }
        public Boolean Excel { get; set; }
    }
}
