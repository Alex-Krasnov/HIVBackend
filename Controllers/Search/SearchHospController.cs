﻿using HIVBackend.Models.FormModels.Search;
using HIVBackend.Models.OutputModel.Search;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHospController : BaseSearchController<SearchHospForm, SearchHospInputForm>
    {
        
    }
}
