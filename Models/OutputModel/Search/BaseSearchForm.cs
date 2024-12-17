using HIVBackend.Data;

namespace HIVBackend.Models.OutputModel.Search
{
    /// <summary>
    /// базовый класс для всех форм поиска 
    /// данные необходимые фронту для отрисовки формы поиска (всевозможные списки)
    /// </summary>
    public abstract class BaseSearchForm
    {
        protected BaseSearchForm(HivContext _context)
        {

        }
    }
}
