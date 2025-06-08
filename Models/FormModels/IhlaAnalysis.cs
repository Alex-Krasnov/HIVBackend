using System.ComponentModel.DataAnnotations;

namespace HIVBackend.Models.FormModels
{
    public class IhlaAnalysis
    {
        public int? Id { get; set; }

        public int PatientId { get; set; }

        [MaxLength(200)]
        public string? Result { get; set; }

        public DateOnly AnalysisDate { get; set; }
    }
}
