using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIVBackend.Models.DBModels
{
    public class TblIhlaAnalysis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PatientId { get; set; }

        [MaxLength(200)]
        public string? Result { get; set; }

        public DateOnly AnalysisDate { get; set; }

        public string? AnalysisNumber { get; set; }

        public string? User { get; set; }

        public DateOnly DateCreate { get; set; }

        public DateOnly DateChange { get; set; }
    }
}
