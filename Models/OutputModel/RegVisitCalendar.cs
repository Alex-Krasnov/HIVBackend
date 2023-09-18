namespace HIVBackend.Models.OutputModel
{
    public class RegVisitCalendar
    {
        public int PatientId { get; set; }
        public int DocId { get; set; }
        public int CabId { get; set; }
        public List<RegCalendar> Calendars { get; set; }
    }

    public class RegCalendar
    {
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string DayOfWeek { get; set; }
        public int? CuontRecord { get; set; }
    }
}
