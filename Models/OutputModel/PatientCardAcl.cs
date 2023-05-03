namespace HIVBackend.Models.OutputModel
{
    public class PatientCardAcl
    {

        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public List<FrmBHGE>? Bhs { get; set; }
        public List<FrmBHGE>? Ges { get; set; }
    }

    public class FrmBHGE
    {
        public DateOnly Date { get; set; }
        public string? B001 { get; set; }
        public string? B005 { get; set; }
        public string? B010 { get; set; }
        public string? B015 { get; set; }
        public string? B020 { get; set; }
        public string? B025 { get; set; }
        public string? B030 { get; set; }
        public string? B035 { get; set; }
        public string? B040 { get; set; }
        public string? B045 { get; set; }
        public string? B050 { get; set; }
        public string? B055 { get; set; }
        public string? B060 { get; set; }
        public string? B065 { get; set; }
        public string? B070 { get; set; }
        public string? B075 { get; set; }
        public string? B080 { get; set; }
        public string? B085 { get; set; }
        public string? B090 { get; set; }
        public string? B095 { get; set; }
        public string? B100 { get; set; }
        public string? B105 { get; set; }
        public string? B110 { get; set; }
        public string? B115 { get; set; }
    }
}
