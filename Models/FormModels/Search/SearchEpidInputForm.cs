﻿namespace HIVBackend.Models.FormModels.Search
{
    public class SearchEpidInputForm
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
        public string[]? blotCheckPlace { get; set; }
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
        public string[]? age { get; set; }
        public string cardNo { get; set; }
        public string[]? art { get; set; }
        public string[]? mkb10 { get; set; }
        public string transfAreaYNA { get; set; }
        public string dateTransfAreaStart { get; set; }
        public string dateTransfAreaEnd { get; set; }
        public string frYNA { get; set; }
        public string zavApoYNA { get; set; }
        public string transfFederYNA { get; set; }
        public string dateTransfFederStart { get; set; }
        public string dateTransfFederEnd { get; set; }
        public string ufsinYNA { get; set; }
        public string dateUfsinStart { get; set; }
        public string dateUfsinEnd { get; set; }
        public string aids12 { get; set; }

        public string dtMailRegStart { get; set; }
        public string dtMailRegEnd { get; set; }
        public string[]? education { get; set; }
        public string[]? familyStatus { get; set; }
        public string[]? employment { get; set; }
        public string[]? trans { get; set; }
        public string[]? placeCheck { get; set; }
        public string[]? situationDetect { get; set; }
        public string[]? transmisionMech { get; set; }
        public string[]? vulnerableGroup { get; set; }
        public string vacName { get; set; }
        public string vacDateStart { get; set; }
        public string vacDateEnd { get; set; }
        public string covidMkb10 { get; set; }
        public string covidDateStart { get; set; }
        public string covidDateEnd { get; set; }
        public string chemsexYNA { get; set; }
        public string chemsexContactType { get; set; }
        public string pavInjYNA { get; set; }
        public string pavInjDateStart { get; set; }
        public string pavInjDateEnd { get; set; }
        public string pavNotInjYNA { get; set; }
        public string pavNotInjDateStart { get; set; }
        public string pavNotInjDateEnd { get; set; }
        public string timeInfectDateStart { get; set; }
        public string timeInfectDateEnd { get; set; }

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
        public bool selectBlotCheckPlace { get; set; }
        public bool selectStage { get; set; }
        public bool selectDieDate { get; set; }
        public bool selectCheckCourse { get; set; }
        public bool selectDieCourse { get; set; }
        public bool selectInfectCourse { get; set; }
        public bool selectShowIllnes { get; set; }
        public bool selectIb { get; set; }
        public bool selectHospCourse { get; set; }
        public bool selectAge { get; set; }
        public bool selectCardNo { get; set; }
        public bool selectArt { get; set; }
        public bool selectMkb10 { get; set; }
        public bool selectTransfArea { get; set; }
        public bool selectFr { get; set; }
        public bool selectTransfFeder { get; set; }
        public bool selectUfsin { get; set; }
        public bool selectAids12 { get; set; }

        public bool selectDtMailReg { get; set; }
        public bool selectEdu { get; set; }
        public bool selectFamilyStatus { get; set; }
        public bool selectEmployment { get; set; }
        public bool selectTrans { get; set; }
        public bool selectPlaceCheck { get; set; }
        public bool selectSituationDetect { get; set; }
        public bool selectTransmisionMech { get; set; }
        public bool selectVulnerableGroup { get; set; }
        public bool selectCovidVac { get; set; }
        public bool selectCovid { get; set; }
        public bool selectChemsex { get; set; }
        public bool selectPavInj { get; set; }
        public bool selectPavNotInj { get; set; }
        public bool selectTimeInfect { get; set; }

        #endregion


        public int Page { get; set; }
        public bool Excel { get; set; }
    }
}