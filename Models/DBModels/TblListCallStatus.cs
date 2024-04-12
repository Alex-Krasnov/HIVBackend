using HIVBackend.Models.DBModuls;

namespace HIVBackend.Models.DBModels
{
    public class TblListCallStatus
    {
        public int CallStatusId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; } = null!;

        public virtual ICollection<TblPatientCall> TblPatientCalls { get; } = new List<TblPatientCall>();
    }
}
