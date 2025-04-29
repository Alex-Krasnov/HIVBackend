using System.ComponentModel.DataAnnotations;

namespace HIVBackend.Models.DTOs.Requests
{
    public class AnalysisFilter
    {
        public int? PatientId { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? EndDate { get; set; }

        [MinLength(3)]
        public string? AnalysisCode { get; set; }

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;
    }
}
