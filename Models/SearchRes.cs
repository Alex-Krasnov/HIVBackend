using System.Data;

namespace HIVBackend.Models
{
    public class SearchRes
    {
        public List<string> ColumName { get; set; }
        public List<IDictionary<string, object>> ResPage { get; set; }
        public int ResCount { get; set; }
    }
}
