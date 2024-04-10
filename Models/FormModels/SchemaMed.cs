namespace HIVBackend.Models.FormModels
{
    public class SchemaMed
    {
        public int Id { get; set; }
        public string LongName { get; set; } = null!;
        public string? ShortName { get; set; }
        public List<int> Meds { get; set; } = null!;
    }
}
