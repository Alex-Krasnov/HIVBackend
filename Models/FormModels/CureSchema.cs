namespace HIVBackend.Models.FormModels
{
    public class CureSchema
    {
        public int PatientId { get; set; }
        public string CureSchemaName { get; set; }
        public string StartDate { get; set;}
        public string CureSchemaNameOld { get; set; }
        public string StartDateOld { get; set; }
        public string? EndDate { get; set;}
        public string? SchemaCom { get; set; }
        public string? CureChangeName { get; set; }
        public string? ProtNum { get; set; }
        public string? RangeTherapyName { get; set; }
        public bool? Last { get; set; }
    }
}
