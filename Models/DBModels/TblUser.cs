namespace HIVBackend.Models.DBModuls;
public partial class TblUser
{
    public string Uid { get; set; } = null!;
    public string Pwd { get; set; } = null!;
    public string? UserName { get; set; }
    public string? User1 { get; set; }
    public DateTime? Datetime1 { get; set; }
    public bool Excel1 { get; set; }
    public bool Write1 { get; set; }
    public int? RegionId { get; set; }
    public bool Admin1 { get; set; }
    public bool Delete1 { get; set; }
    public bool Klassif1 { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public virtual TblRegion? Region { get; set; }
}
