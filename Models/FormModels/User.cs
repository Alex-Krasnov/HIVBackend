namespace HIVBackend.Models.FormModels
{
    public class User
    {
        public string Uid { get; set; } = null!;
        public string Pwd { get; set; } = null!;
        public string? UserName { get; set; }
        public bool Excel { get; set; }
        public bool Write { get; set; }
        public bool Admin { get; set; }
        public bool Deleter { get; set; }
        public bool Klassif { get; set; }
        public bool Lab { get; set; }
    }
}
