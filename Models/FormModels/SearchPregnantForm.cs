﻿using System;

namespace HIVBackend.Models.FormModels
{
    public class SearchPregnantForm
    {
        public string dateInpStart { get; set; }
        public string dateInpEnd { get; set; }
        public string patientId { get; set; }
        public string familyName { get; set; }
        public string firstName { get; set; }
        public string thirdName { get; set; }
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
        public string ufsinYNA { get; set; }
        public string dateUfsinStart { get; set; }
        public string dateUfsinEnd { get; set; }

        public string[]? pregCheck { get; set; }
        public string pregMonthNo { get; set; }
        public string[]? birthType { get; set; }
        public string medecineStartMonthNo { get; set; }
        public string childBirthDateStart { get; set; }
        public string childBirthDateEnd { get; set; }
        public string childFamilyName { get; set; }
        public string childFirstName { get; set; }
        public string childThirdName { get; set; }
        public string cardNo { get; set; }
        public string[]? phpSchema1 { get; set; }
        public string[]? phpSchema2 { get; set; }
        public string[]? phpSchema3 { get; set; }
        public string[]? medecineForSchema1 { get; set; }
        public string[]? medecineForSchema2 { get; set; }
        public string[]? medecineForSchema3 { get; set; }
        public string[]? art { get; set; }
        public string[]? materhome { get; set; }
        public string aclDateStart { get; set; }
        public string aclDateEnd { get; set; }
        public string aclMcnCodeStart { get; set; }
        public string aclMcnCodeEnd { get; set; }

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
        public Boolean selectUfsin { get; set; }

        public Boolean selectPregCheck { get; set; }
        public Boolean selectPregMonthNo { get; set; }
        public Boolean selectBirthType { get; set; }
        public Boolean selectMedecineStartMonthNo { get; set; }
        public Boolean selectChildBirthDate { get; set; }
        public Boolean selectChildFio { get; set; }
        public Boolean selectCardNo { get; set; }
        public Boolean selectPhpSchema1 { get; set; }
        public Boolean selectPhpSchema2 { get; set; }
        public Boolean selectPhpSchema3 { get; set; }
        public Boolean selectMedecineForSchema1 { get; set; }
        public Boolean selectMedecineForSchema2 { get; set; }
        public Boolean selectMedecineForSchema3 { get; set; }
        public Boolean selectArt { get; set; }
        public Boolean selectAddr { get; set; }
        public Boolean selectMaterhome { get; set; }
        public Boolean selectAclDate { get; set; }
        public Boolean selectAclMcnCode { get; set; }

        public int Page { get; set; }
    }
}