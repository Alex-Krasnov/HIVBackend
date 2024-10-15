using System.Data;

namespace HIVBackend.Models
{
    public class SearchRes
    {
        public List<string> ColumName { get; set; }
        public List<IDictionary<string, object>> resPage { get; set; }
        public int ResCount { get; set; }
    }
}
