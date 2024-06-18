namespace HIVBackend.Interfaces
{
    public interface IPatientCard
    {
        int PatientId { get; set; }
        string? CardNo { get; set; }
        string? FamilyName { get; set; }
        string? FirstName { get; set; }
        string? ThirdName { get; set; }
        string? Sex { get; set; }
        DateOnly? BirthDate { get; set; }
        string? Region { get; set; }
        string? CityName { get; set; }
        string? AddrName { get; set; }
        string? AddrInd { get; set; }
        string? AddrStreet { get; set; }
        string? AddrHouse { get; set; }
        string? AddrFlat { get; set; }
        string? Country { get; set; }
    }
}
