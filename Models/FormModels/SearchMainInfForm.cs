﻿using System;

namespace HIVBackend.Models.FormModels
{
    public class SearchMainInfForm
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
        public string[]? regionFact { get; set; }
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
        public string archiveYNA { get; set; }
        public string archive { get; set; }
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
        public string unrzYNA { get; set; }
        public string unrz { get; set; }
        public string dieDiagYNA { get; set; }
        public string chemprof { get; set; }
        public string dateChemprofStartStart { get; set; }
        public string dateChemprofStartEnd { get; set; }
        public string dateChemprofEndStart { get; set; }
        public string dateChemprofEndEnd { get; set; }
        public string dateRegStart { get; set; }
        public string dateRegEnd { get; set; }
        public string regionPreset { get; set; }
        public string factRegionPreset { get; set; }

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
        public Boolean selectBlotCheckPlace { get; set; }
        public Boolean selectStage { get; set; }
        public Boolean selectDieDate { get; set; }
        public Boolean selectCheckCourse { get; set; }
        public Boolean selectDieCourse { get; set; }
        public Boolean selectInfectCourse { get; set; }
        public Boolean selectShowIllnes { get; set; }
        public Boolean selectIb { get; set; }
        public Boolean selectHospCourse { get; set; }
        public Boolean selectAge { get; set; }
        public Boolean selectCardNo { get; set; }
        public Boolean selectArt { get; set; }
        public Boolean selectMkb10 { get; set; }
        public Boolean selectArchive { get; set; }
        public Boolean selectTransfArea { get; set; }
        public Boolean selectFr { get; set; }
        public Boolean selectTransfFeder { get; set; }
        public Boolean selectUfsin { get; set; }
        public Boolean selectAids12 { get; set; }
        public Boolean selectUnrz { get; set; }
        public Boolean selectChemprof { get; set; }
        public Boolean selectDieDiag { get; set; }
        public Boolean selectDateReg { get; set; }
        public Boolean selectPasSer { get; set; }
        public Boolean selectPasNum { get; set; }
        public Boolean selectPasWhom { get; set; }
        public Boolean selectPasWhen { get; set; }

        public int Page { get; set; }
    }
}
