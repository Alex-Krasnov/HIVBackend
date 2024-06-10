using HIVBackend.Models.DBModuls;

namespace HIVBackend.Models.DBModels
{
    public class TblHepC
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public string? Descr { get; set; }
        public string? User { get; set; }
        public DateOnly? DateCreate { get; set; }

        public virtual TblPatientCard Patient { get; set; } = null!;
    }
}
