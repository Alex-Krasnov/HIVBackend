namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchHosp
    {
        public List<string>? ListSex { get; set; }
        public List<string>? ListRegion { get; set; }
        public List<string>? ListRegionPreset { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListLpu { get; set; }
        public List<string>? ListHospCourse { get; set; }
        public List<string>? ListHospResult { get; set; }
        public List<string>? ListYNA { get; set; }
    }
}
