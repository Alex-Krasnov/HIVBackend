﻿using HIVBackend.Models.FormModels.Search;
using HIVBackend.Models.OutputModel.Search;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchPregnantController : BaseSearchController<SearchPregnantForm, SearchPregnantInputForm>
    {
    }
}
