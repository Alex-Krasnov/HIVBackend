﻿using System;

namespace HIVBackend.Models.FormModels
{
    public class SearchTreatmentForm
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
        public string[]? invalid { get; set; }
        public string[]? correspIllnesses { get; set; }
        public string dateCorrespIllnessesStart { get; set; }
        public string dateCorrespIllnessesEnd { get; set; }
        public string[]? schema { get; set; }
        public bool? schemaLast { get; set; }
        public string[]? schemaMedecine { get; set; }
        public string[]? medecine { get; set; }
        public string[]? medecineGive { get; set; }
        public string[]? doctor { get; set; }
        public string? dateGiveStart { get; set; }
        public string? dateGiveEnd { get; set; }
        public string[]? schemaChange { get; set; }
        public string? cardNo { get; set; }
        public string? dateSchemaStart { get; set; }
        public string? dateSchemaEnd { get; set; }
        public string[]? finSource { get; set; }
        public string[]? art { get; set; }
        public string[]? rangeTherapy { get; set; }


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
        public Boolean selectInvalid { get; set; }
        public Boolean selectCorrespIllnesses { get; set; }
        public Boolean selectSchema { get; set; }
        public Boolean selectSchemaMedecine { get; set; }
        public Boolean selectMedecine { get; set; }
        public Boolean selectMedecineGive { get; set; }
        public Boolean selectDoctor { get; set; }
        public Boolean selectGiveDate { get; set; }
        public Boolean selectSchemaChange { get; set; }
        public Boolean selectCardNo { get; set; }
        public Boolean selectSchemaDate { get; set; }
        public Boolean selectFinSource { get; set; }
        public Boolean selectArt { get; set; }
        public Boolean selectRangeTherapy { get; set; }

        public int Page { get; set; }
    }
}
