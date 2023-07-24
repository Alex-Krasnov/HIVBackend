using System;

namespace HIVBackend.Models.FormModels
{
    public class SearchNonresidentForm
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
        public string dateRegOnStart { get; set; }
        public string dateRegOnEnd { get; set; }
        public string dateUnRegStart { get; set; }
        public string dateUnRegEnd { get; set; }
        public string[]? stage { get; set; }
        public string stageDateStart { get; set; }
        public string stageDateEnd { get; set; }
        public string[]? checkCourse { get; set; }
        public string[]? infectCourse { get; set; }
        public string[]? showIllnes { get; set; }
        public string dateShowIllnesStart { get; set; }
        public string dateShowIllnesEnd { get; set; }
        public string transfAreaYNA { get; set; }
        public string dateTransfAreaStart { get; set; }
        public string dateTransfAreaEnd { get; set; }
        public string ufsinYNA { get; set; }
        public string dateUfsinStart { get; set; }
        public string dateUfsinEnd { get; set; }
        public string frYNA { get; set; }
        public string zavApoYNA { get; set; }

        public string dateDiagnosisStart { get; set; }
        public string dateDiagnosisEnd { get; set; }
        public string[]? placeDiagnosis { get; set; }
        public string dateRegistrationYNA { get; set; }
        public string dateRegistrationStart { get; set; }
        public string dateRegistrationEnd { get; set; }
        public string dateDepartureYNA { get; set; }
        public string dateDepartureStart { get; set; }
        public string dateDepartureEnd { get; set; }


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
        public Boolean selectCheckCourse { get; set; }
        public Boolean selectInfectCourse { get; set; }
        public Boolean selectShowIllnes { get; set; }
        public Boolean selectTransfArea { get; set; }
        public Boolean selectFr { get; set; }
        public Boolean selectUfsin { get; set; }

        public Boolean selectDateDiagnosis { get; set; }
        public Boolean selectPlaceDiagnosis { get; set; }
        public Boolean selectDateRegistration { get; set; }
        public Boolean selectDateDeparture { get; set; }
        public Boolean selectAddr { get; set; }

        public int Page { get; set; }
        public Boolean Excel { get; set; }
    }
}
