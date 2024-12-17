namespace HIVBackend.Models.OutputModel.Search
{
    public class SearchVisit
    {
        public List<string>? ListSex { get; set; }
        public List<string>? ListRegion { get; set; }
        public List<string>? ListCountry { get; set; }
        public List<string>? ListStage { get; set; }
        public List<Selector2Col>? ListCheckCourse { get; set; }
        public List<string>? ListInfectCourse { get; set; }
        public List<string>? ListShowIllness { get; set; }
        public List<string>? ListYNA { get; set; }
        public List<string>? ListDoctor { get; set; }
        public List<string>? ListArvt { get; set; }
        public List<string>? ListRegionPreset { get; set; }
    }
}
