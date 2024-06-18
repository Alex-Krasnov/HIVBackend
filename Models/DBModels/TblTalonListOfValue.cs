namespace HIVBackend.Models.DBModuls;

public partial class TblTalonListOfValue
{
    public int TalonField { get; set; }

    public int ValueId { get; set; }

    public int ValueSort { get; set; }

    public string ValueDescr { get; set; } = null!;
}
