using HIVBackend.Models.FormModels.Search;
using HIVBackend.Models.OutputModel.Search;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchTreatmentController : SearchBaseController<SearchTreatmentForm, SearchTreatmentInputForm>
    {
        //[HttpPost, Route("GetRes")]
        //[Authorize(Roles = "User")]
        //public IActionResult GetRes(SearchTreatmentInputForm form)
        //{
        //    int pageSize = 100;

        //    // наполняем columName selectGroupSrt joinStr whereStr для дальнейшего поиска
        //    form.SetSearchData();

        //    if (form.Excel)
        //    {
        //        string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        byte[] fileBytes = SerarchResService.GetExcelRes(authHeader: Request.Headers["Authorization"].First(),
        //                                                         selectGroupSrt: form.selectGroupSrt,
        //                                                         joinStr: form.joinStr,
        //                                                         whereStr: form.whereStr,
        //                                                         pageSize: pageSize,
        //                                                         page: form.Page,
        //                                                         columName: form.columName);

        //        return File(fileBytes, contentType, "res_search.xlsx");
        //    }

        //    var searchRes = SerarchResService.GetSearchRes(form.selectGroupSrt, form.joinStr, form.whereStr, pageSize, form.Page);

        //    searchRes.ColumName = form.columName;
        //    return Ok(searchRes);
        //}
    }
}
