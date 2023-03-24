namespace HIVBackend.Models.FormModels
{
    public class PatientCardMainForm
    {
        public int PatientId { get; set; }
        public string? FamilyName { get; set; }
        public string? FirstName { get; set; }
        public string? ThirdName { get; set; }
        public string? SexId { get; set; }
        public string? BirthDate { get; set; }
        public string? RegOnDate { get; set; }
        public string? RegOffDate { get; set; }
        public string? RegOffReason { get; set; }
        public string? UnrzFr1 { get; set; }

        public string? RegionId { get; set; }
        public string? CityName { get; set; }
        public string? LocationName { get; set; }
        public string? AddrIndPhone { get; set; }
        public string? AddrStreet { get; set; }
        public string? AddrHouse { get; set; }
        public string? AddrExt { get; set; }
        public string? AddrFlat { get; set; }

        public string? FactRegionId { get; set; }
        public string? FactCityName { get; set; }
        public string? FactLocationName { get; set; }
        public string? FactAddrInd { get; set; }
        public string? FactAddrStreet { get; set; }
        public string? FactAddrHouse { get; set; }
        public string? FactAddrExt { get; set; }
        public string? FactAddrFlat { get; set; }
        public string? DtRegBeg { get; set; }
        public string? DtRegEnd { get; set; }

        public string? AddrNameComm { get; set; }
        public string? CountryId { get; set; }

        public string? PlaceCheckId { get; set; }
        public string? CodeMkb10Id { get; set; }
        public string? CardNo { get; set; }
        public string? VulnerableGroupId { get; set; }
        public decimal? HeightOld { get; set; }//
        public decimal? WeightOld { get; set; }//
        public bool? FlgZamMedPart { get; set; }
        public bool? FlgHeadPhysician { get; set; }

        public string? CheckCourseId { get; set; }
        public string? InfectCourseId { get; set; }
        public string? DieCourseId { get; set; }

        public string? TransfAreaDate { get; set; }
        public string? TransfFederDate { get; set; }
        public string? UfsinDate { get; set; }
        public string? DieDate { get; set; }
        public string? DieAidsDate { get; set; }
        public string? ArvtId { get; set; }
        public string? InvalidId { get; set; }
        public string? SnilsFedArchive { get; set; }
        public string? Codeword { get; set; }
        public string? Snils { get; set; }
        public string? FioChange { get; set; }
    }
}
