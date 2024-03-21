namespace HIVBackend.Models.FormModels
{
    public class Doctor
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string LongName { get; set; } = null!;
        public string? DoctorCode { get; set; }
        public string? DoctorSnils { get; set; }
    }
}
