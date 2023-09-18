namespace HIVBackend.Models.OutputModel
{
    public class RegVisitTime
    {
        public int PatientId { get; set; }
        public int DocId { get; set; }
        public int CabId { get; set; }
        public DateTime Date { get; set; }
        public List<RegTime> RegTimes { get; set; }
    }

    public class RegTime
    {
        public string TimeName { get; set; }
        public bool IsActive { get; set; }
        public int CuontRecord { get; set; }
    }
}
