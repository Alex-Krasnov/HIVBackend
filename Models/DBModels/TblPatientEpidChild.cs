using HIVBackend.Models.DBModuls;

namespace HIVBackend.Models.DBModels
{
    public class TblPatientEpidChild
    {
        public int PatientId { get; set; }
        public int PatientEpidChildId { get; set; }
        public int? SexId { get; set; }
        public string? ChildFamilyName { get; set; }
        public string? ChildFirstName { get; set; }
        public string? ChildThirdName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public bool Exam { get; set; }

        public virtual TblSex? TblSex { get; set; }
        public virtual TblPatientCard TblPatientCard { get; set; } = null!;
    }
}
