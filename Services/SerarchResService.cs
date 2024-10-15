using HIVBackend.Models;
using System.Text;

namespace HIVBackend.Services
{
    public class SerarchResService
    {
        /// <summary>
        /// Получить объект для отправки на фронт
        /// </summary>
        public static SearchRes GetSearchRes(StringBuilder selectGroupSrt, StringBuilder joinStr, StringBuilder whereStr, int pageSize, int page)
        {
            //получаем количество строк с ограничинием в 1 млн, иначи все ломается
            var count = NpgsqlService.GetCountRow(selectGroupSrt, joinStr, whereStr, pageSize, page);

            //получаем сами данные из бд тут, вроде пофиг на кол-во из-за пагинации, но хз
            var res = NpgsqlService.GetDBData(selectGroupSrt, joinStr, whereStr, pageSize, page);

            return new SearchRes() { ResCount = count, resPage = NpgsqlService.DataSetToList(res)};
        }
    }
}
