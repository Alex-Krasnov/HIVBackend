namespace HIVBackend.Models.FormModels
{
    public class List3Col
    {
        public int Id { get; set; }
        public required string LongName { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
