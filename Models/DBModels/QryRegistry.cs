namespace HIVBackend.Models.DBModuls;
public partial class QryRegistry
{
    public int PatientId { get; set; }
    public string? CardNo { get; set; }
    public string? FamilyName { get; set; }
    public string? FirstName { get; set; }
    public string? ThirdName { get; set; }
    public string? RegionLong { get; set; }
    public string? RegionLongFact { get; set; }
    public string? CountryLong { get; set; }
    public string? CityName { get; set; }
    public string? LocationName { get; set; }
    public string? AddrStreet { get; set; }
    public string? AddrHouse { get; set; }
    public string? Archive { get; set; }
    public string? FioChange { get; set; }
    public DateOnly RegDate { get; set; }
    public int? DocId { get; set; }
}

