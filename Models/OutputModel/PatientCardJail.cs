namespace HIVBackend.Models.OutputModel
{
    public class PatientCardJail
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public string? JailName { get; set; }
        public string? JailOffRegion { get; set; }
        public DateOnly? JailOffDate { get; set; }

        public List<string>? ListJail { get; set; }
        public List<string>? ListRegion { get; set; }

        public List<Jail>? Jails { get; set; }
    }

    public class Jail
    {
        public string JailName { get; set; }
        public string? JailLeavName { get; set;}
        public DateOnly JailStart { get; set; }
        public DateOnly JailEnd { get; set; }
    }
}
