namespace HIVBackend.Models.FormModels
{
    public class PassportForm
    {
        public int PatientId { get; set; }
        public string? Region { get; set; }
        public string? CityName { get; set; }
        public string? LocationName { get; set; }
        public string? Index { get; set; }
        public string? AddrStreat { get; set; }
        public string? AddrHouse { get; set; }
        public string? AddrExt { get; set; }
        public string? AddrFlat { get; set; }
        public string? RegionFact { get; set; }
        public string? CityNameFact { get; set; }
        public string? LocationNameFact { get; set; }
        public string? IndexFact { get; set; }
        public string? AddrStreatFact { get; set; }
        public string? AddrExtFact { get; set; }
        public string? AddrHouseFact { get; set; }
        public string? AddrFlatFact { get; set; }
        public string? DtRegBeg { get; set; }
        public string? DtRegEnd { get; set; }
        public string? PasSer { get; set; }
        public string? PasNum { get; set; }
        public string? PasWhen { get; set; }
        public string? PasWhom { get; set; }
        public string? OmsSer { get; set; }
        public string? OmsNum { get; set; }
        public string? OmsWhen { get; set; }
    }
}
