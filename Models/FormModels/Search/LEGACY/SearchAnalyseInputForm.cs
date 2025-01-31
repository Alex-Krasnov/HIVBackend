namespace HIVBackend.Models.FormModels.Search.LEGACY
{
    public class SearchAnalyseInputForm
    {
        #region поля

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

        #endregion

        #region select поля

        public bool selectInpDate { get; set; }
        public bool selectPatientId { get; set; }
        public bool selectFio { get; set; }
        public bool selectSex { get; set; }
        public bool selectBirthDate { get; set; }
        public bool selectRegion { get; set; }
        public bool selectRegionFact { get; set; }
        public bool selectCountry { get; set; }
        public bool selectAddr { get; set; }
        public bool selectRegOnDate { get; set; }
        public bool selectStage { get; set; }
        public bool selectDieDate { get; set; }
        public bool selectDieCourse { get; set; }
        public bool selectCheckCourse { get; set; }
        public bool selectInfectCourse { get; set; }
        public bool selectShowIllnes { get; set; }
        public bool selectTransfArea { get; set; }
        public bool selectFr { get; set; }
        public bool selectIb { get; set; }
        public bool selectUfsin { get; set; }

        public bool selectCardNo { get; set; }
        public bool selectArt { get; set; }

        public bool selectVlDate { get; set; }
        public bool selectVlRes { get; set; }
        public bool selectImDate { get; set; }
        public bool selectImCd3Res { get; set; }
        public bool selectImCd4Res { get; set; }
        public bool selectImCd8Res { get; set; }
        public bool selectHepCIfa { get; set; }
        public bool selectHepBIfa { get; set; }
        public bool selectHepSyphIfa { get; set; }
        public bool selectHepC { get; set; }
        public bool selectHepB { get; set; }

        #endregion

        public int Page { get; set; }
        public bool Excel { get; set; }
    }
}
