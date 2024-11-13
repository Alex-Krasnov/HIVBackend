using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using HIVBackend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        /// <summary>
        /// Для отправки Excel
        /// </summary>
        public static byte[] GetExcelRes(string authHeader, 
                                         StringBuilder selectGroupSrt, 
                                         StringBuilder joinStr, 
                                         StringBuilder whereStr, 
                                         int pageSize, 
                                         int page, 
                                         List<string> columName)
        {
            string jwt = authHeader.Substring("Bearer ".Length);
            var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = jwtHandler.ReadJwtToken(jwt);
            
            var excelRes = NpgsqlService.GetDBData(selectGroupSrt, joinStr, whereStr, pageSize, page, true);

            var createExcel = new CreateExcel();
            string fileName = $"res_search_{token.Claims.First().Value}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            if (File.Exists(path))
                File.Delete(path);

            createExcel.CreateSearchExcel(NpgsqlService.DataSetToList(excelRes), path, columName);

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            byte[] fileBytes = File.ReadAllBytes(path);

            return fileBytes; 
        }
    }
}
