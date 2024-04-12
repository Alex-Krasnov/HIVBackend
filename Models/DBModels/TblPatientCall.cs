using HIVBackend.Models.DBModuls;

namespace HIVBackend.Models.DBModels
{
    public class TblPatientCall
    {
        public int PatientCallId { get; set; }
        public int? CallStatusId { get; set; }
        public int PatientId { get; set; }
        public DateOnly? CallDate { get; set; }

        public virtual TblListCallStatus? TblListCallStatus { get; set; }

        public virtual TblPatientCard TblPatientCard { get; set; } = null!;
    }
}
