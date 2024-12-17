namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchAcl
    {
        public List<string>? ListRegion { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListYNA { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListResIb { get; set; }
        public List<string>? ListSelectBlot { get; set; }
        public List<string>? ListRegionPreset { get; set; }
        public List<string>? ListSex { get; set; }
    }
}
