using System.Text;

namespace HIVBackend.Models.FormModels.Search
{
    public abstract class BaseSearchInputForm
    {
        public int Page { get; set; }
        public bool Excel { get; set; }

        public List<string> columName = new() { "Ид пациента" };
        public StringBuilder selectGroupSrt = new();
        public StringBuilder joinStr = new();
        public StringBuilder whereStr = new();

        /// <summary>
        /// наполняем columName selectGroupSrt joinStr whereStr для дальнейшего поиска
        /// </summary>
        public abstract void SetSearchData();
    }
}
