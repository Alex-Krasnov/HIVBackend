using System.ComponentModel.DataAnnotations;

namespace HIVBackend.Models.DTOs.Requests
{
    public class DeleteAnalysisRequest
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public DateTime AnalysisDate { get; set; }

        [Required]
        [MinLength(3)]
        public string AnalysisCode { get; set; }
    }
}
