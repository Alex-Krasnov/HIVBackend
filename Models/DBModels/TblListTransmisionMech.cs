namespace HIVBackend.Models.DBModuls;

public partial class TblListTransmisionMech
{
    public int TransmissionMechId { get; set; }

    public string? TransmisiomMechName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
