using HIVBackend.Data;
using HIVBackend.Enums;

namespace HIVBackend.Models.OutputModel.Search
{
    /// <summary>
    /// базовый класс для всех форм поиска 
    /// данные необходимые фронту для отрисовки формы поиска (всевозможные списки)
    /// </summary>
    public abstract class BaseSearchForm
    {
        public List<string>? ListYNA { get; set; }

        protected BaseSearchForm(HivContext _context)
        {
            ListYNA = EnumExtension.EnumToListOfDescription(typeof(YNAEnum));
        }
    }
}
