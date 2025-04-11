using HIVBackend.Data;
using HIVBackend.Helpers;
using HIVBackend.Models.FormModels.Search;
using HIVBackend.Models.OutputModel.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.Search
{
    /// <summary>
    /// базовый контролер форм поиска
    /// </summary>
    /// <typeparam name="TForm">класс наследованый от BaseSearchForm</typeparam>
    /// <typeparam name="TInputForm"></typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseSearchController<TForm, TInputForm> : ControllerBase
        where TForm : BaseSearchForm
        where TInputForm : BaseSearchInputForm
    {
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            using (HivContext context = new HivContext())
            {
                var form = Activator.CreateInstance(typeof(TForm), new object[] { context }) as TForm;
                return Ok(form);
            }
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(TInputForm form)
        {
            int pageSize = 100;

            // наполняем columName selectGroupSrt joinStr whereStr для дальнейшего поиска
            form.SetSearchData();

            if (form.Excel)
            {
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                byte[] fileBytes = SerarchResService.GetExcelRes(authHeader: Request.Headers["Authorization"].First(),
                                                                 selectGroupSrt: form._queryBuilder.selectGroupSrt,
                                                                 joinStr: form._queryBuilder.joinStr,
                                                                 whereStr: form._queryBuilder.whereStr,
                                                                 pageSize: pageSize,
                                                                 page: form.Page,
                                                                 columName: form._queryBuilder.columName);

                return File(fileBytes, contentType, "res_search.xlsx");
            }

            var searchRes = SerarchResService.GetSearchRes(
                    form._queryBuilder.selectGroupSrt, 
                    form._queryBuilder.joinStr, 
                    form._queryBuilder.whereStr, 
                    pageSize, 
                    form.Page);

            searchRes.ColumName = form._queryBuilder.columName;
            return Ok(searchRes);
        }
    }
}
