using HIVBackend.Data;
using HIVBackend.Models.FormModels.Search;
using HIVBackend.Models.OutputModel.Search;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.Search
{
    /// <summary>
    /// базовый контролер форм поиска
    /// </summary>
    /// <typeparam name="TForm">класс наследованый от BaseSearchForm</typeparam>
    /// <typeparam name="TFormModel"></typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseSearchController<TForm, TFormModel> : ControllerBase
        where TForm : BaseSearchForm
        where TFormModel : BaseSearchInputForm
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
        public IActionResult GetRes(TFormModel form)
        {
            int pageSize = 100;

            // наполняем columName selectGroupSrt joinStr whereStr для дальнейшего поиска
            form.SetSearchData();

            if (form.Excel)
            {
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                byte[] fileBytes = SerarchResService.GetExcelRes(authHeader: Request.Headers["Authorization"].First(),
                                                                 selectGroupSrt: form.selectGroupSrt,
                                                                 joinStr: form.joinStr,
                                                                 whereStr: form.whereStr,
                                                                 pageSize: pageSize,
                                                                 page: form.Page,
                                                                 columName: form.columName);

                return File(fileBytes, contentType, "res_search.xlsx");
            }

            var searchRes = SerarchResService.GetSearchRes(form.selectGroupSrt, form.joinStr, form.whereStr, pageSize, form.Page);

            searchRes.ColumName = form.columName;
            return Ok(searchRes);
        }
    }
}
