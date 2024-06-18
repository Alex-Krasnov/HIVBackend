namespace HIVBackend.Models.DBModuls;

public partial class TblSecDi
{
    public int IdSecDis { get; set; }

    public int? PatientId { get; set; }

    public int? IdMkbSecDis { get; set; }

    public string? Comment { get; set; }

    public DateOnly? DStart { get; set; }

    public DateOnly? DEnd { get; set; }
}
