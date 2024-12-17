using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels.Search;
using HIVBackend.Models.OutputModel;
using HIVBackend.Models.OutputModel.Search;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAclController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchAclController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchAcl outModel = new();

            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };
            outModel.ListRegionPreset = new() { "Все", "Московская обл.", "Иногородние", "Иностранные" };
            outModel.ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();
            outModel.ListSelectBlot = new() { "Все", "Первый", "Последний", "Перв.и посл." };
            outModel.ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchAclForm form)
        {
            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchAclForm).GetProperties())
            {
                if (key.Name.StartsWith("select") && (bool)key.GetValue(form) == true)
                {
                    if (key.Name == "selectInpDate")
                    {
                        columName.Add("Дата ввода");
                        activeColumns.Add("InputDate");
                    }

                    if (key.Name == "selectFio")
                    {
                        columName.Add("Фамилия");
                        activeColumns.Add("FamilyName");
                        columName.Add("Имя");
                        activeColumns.Add("FirstName");
                        columName.Add("Отчество");
                        activeColumns.Add("ThirdName");
                    }

                    if (key.Name == "selectSex")
                    {
                        columName.Add("Пол");
                        activeColumns.Add("SexShort");
                    }

                    if (key.Name == "selectBirthDate")
                    {
                        columName.Add("Дата рождения");
                        activeColumns.Add("BirthDate");
                    }

                    if (key.Name == "selectRegion")
                    {
                        columName.Add("Регион");
                        activeColumns.Add("RegionLong");
                    }

                    if (key.Name == "selectRegionFact")
                    {
                        columName.Add("Регион (факт.)");
                        activeColumns.Add("RegionLongFact");
                    }

                    if (key.Name == "selectRegOnDate")
                    {
                        columName.Add("Дата постановки на учет");
                        activeColumns.Add("RegOnDate");
                        columName.Add("Дата снятия с учета");
                        activeColumns.Add("RegOffDate");
                        columName.Add("Причина снятия с учета");
                        activeColumns.Add("RegOff");
                    }

                    if (key.Name == "selectStage")
                    {
                        columName.Add("Стадия");
                        activeColumns.Add("DiagnosisLong");
                    }

                    if (key.Name == "selectCheckCourse")
                    {
                        columName.Add("Причина обращения");
                        activeColumns.Add("CheckCourseLong");
                    }

                    if (key.Name == "selectIb")
                    {
                        columName.Add("Результат референс");
                        activeColumns.Add("IbResultShort");
                        columName.Add("Дата референс");
                        activeColumns.Add("BlotDate");
                        columName.Add("Номер");
                        activeColumns.Add("BlotNo");
                        columName.Add("Послед");
                        activeColumns.Add("First1");
                        columName.Add("Дата ввода");
                        activeColumns.Add("Datetime1");
                    }

                    if (key.Name == "selectTestCode")
                    {
                        columName.Add("Код теста");
                        activeColumns.Add("AclTestCode");
                    }

                    if (key.Name == "selectSampleDate")
                    {
                        columName.Add("Дата теста");
                        activeColumns.Add("AclSampleDate");
                    }
                }
            }

            string[] BioHemCode = {"Б0001","Б0005","Б0010","Б0015","Б0020","Б0025","Б0030","Б0035","Б0040","Б0045","Б0050","Б0055",
                "Б0060","Б0065","Б0070","Б0075","Б0080","Б0085","Б0090","Б0095","Б0100","Б0105","Б0110","Б0115"
            },
            HematCode = {"Г0001","Г0005","Г0010","Г0015","Г0020","Г0025","Г0030","Г0035","Г0040","Г0045","Г0050","Г0055","Г0060",
                "Г0065","Г0070","Г0075","Г0080","Г0085","Г0090","Г0095","Г0100","Г0105","Г0110","Г0115"
            };
            List<string> TestCode = new();

            if (form.aclTestCode1.Length != 0)
                TestCode.Add(form.aclTestCode1);
            if (form.aclTestCode2.Length != 0)
                TestCode.Add(form.aclTestCode2);
            if (form.aclTestCode3.Length != 0)
                TestCode.Add(form.aclTestCode3);
            if (form.aclTestCode4.Length != 0)
                TestCode.Add(form.aclTestCode4);
            if (form.aclTestCode5.Length != 0)
                TestCode.Add(form.aclTestCode5);
            if (form.aclTestCode6.Length != 0)
                TestCode.Add(form.aclTestCode6);
            if (form.aclTestCode7.Length != 0)
                TestCode.Add(form.aclTestCode7);

            var qryWhere = _context.QrySearchAcls.Where(e =>
                        (form.dateInpStart.Length != 0 ? e.InputDate >= DateOnly.Parse(form.dateInpStart) : true) &&
                        (form.dateInpEnd.Length != 0 ? e.InputDate <= DateOnly.Parse(form.dateInpEnd) : true) &&
                        (form.patientId.Length != 0 ? e.PatientId == int.Parse(form.patientId) : true) &&
                        (form.familyName.Length != 0 ? e.FamilyName.ToLower().StartsWith(form.familyName.ToLower()) : true) &&
                        (form.firstName.Length != 0 ? e.FirstName.ToLower().StartsWith(form.firstName.ToLower()) : true) &&
                        (form.thirdName.Length != 0 ? e.ThirdName.ToLower().StartsWith(form.thirdName.ToLower()) : true) &&
                        (form.sex.Length != 0 ? e.SexShort == form.sex : true) &&
                        (form.birthDateStart.Length != 0 ? e.BirthDate >= DateOnly.Parse(form.birthDateStart) : true) &&
                        (form.birthDateEnd.Length != 0 ? e.BirthDate <= DateOnly.Parse(form.birthDateEnd) : true) &&
                        (form.regionFact[0] != "Все" ? form.regionFact.Contains(e.RegionLongFact) : true) &&
                        (form.factRegionPreset == "Московская обл." ? e.FactRegtypeId == 1 : true) &&
                        (form.factRegionPreset == "Иногородние" ? e.FactRegtypeId == 2 : true) &&
                        (form.factRegionPreset == "Иностранные" ? e.FactRegtypeId == 3 : true) &&
                        (form.regionReg[0] != "Все" ? form.regionReg.Contains(e.RegionLong) : true) &&
                        (form.regionPreset == "Московская обл." ? e.RegtypeId == 1 : true) &&
                        (form.regionPreset == "Иногородние" ? e.RegtypeId == 2 : true) &&
                        (form.regionPreset == "Иностранные" ? e.RegtypeId == 3 : true) &&
                        (form.dateRegOnStart.Length != 0 ? e.RegOnDate >= DateOnly.Parse(form.dateRegOnStart) : true) &&
                        (form.dateRegOnEnd.Length != 0 ? e.RegOnDate <= DateOnly.Parse(form.dateRegOnEnd) : true) &&
                        (form.dateUnRegStart.Length != 0 ? e.RegOffDate >= DateOnly.Parse(form.dateUnRegStart) : true) &&
                        (form.dateUnRegEnd.Length != 0 ? e.RegOffDate <= DateOnly.Parse(form.dateUnRegEnd) : true) &&
                        (form.stage[0] != "Все" ? form.stage.Contains(e.DiagnosisLong) : true) &&
                        (form.checkCourse[0] != "Все" ? form.checkCourse.Contains(e.CheckCourseLong) : true) &&
                        (form.ibRes.Length != 0 ? e.IbResultShort == form.ibRes : true) &&
                        (form.dateIbResStart.Length != 0 ? e.BlotDate >= DateOnly.Parse(form.dateIbResStart) : true) &&
                        (form.dateIbResEnd.Length != 0 ? e.BlotDate <= DateOnly.Parse(form.dateIbResEnd) : true) &&
                        (form.ibNum.Length != 0 ? e.BlotNo == int.Parse(form.ibNum) : true) &&
                        (form.dateInpIbStart.Length != 0 ? e.Datetime1 >= DateOnly.Parse(form.dateInpIbStart) : true) &&
                        (form.dateInpIbEnd.Length != 0 ? e.Datetime1 <= DateOnly.Parse(form.dateInpIbEnd) : true) &&
                        (form.ibSelect == "Первый" ? e.First1 == true : true) &&
                        (form.ibSelect == "Последний" ? e.Last1 == true : true) &&
                        (form.ibSelect == "Перв.и посл." ? e.Last1 == true || e.First1 == true : true) &&
                        (form.biochemistry ? BioHemCode.Contains(e.AclTestCode) : true) &&
                        (form.hematology ? HematCode.Contains(e.AclTestCode) : true) &&
                        (form.aclTestCode1.Length != 0 || form.aclTestCode2.Length != 0 || form.aclTestCode3.Length != 0 || form.aclTestCode4.Length != 0 ||
                          form.aclTestCode5.Length != 0 || form.aclTestCode6.Length != 0 || form.aclTestCode7.Length != 0 ? TestCode.Contains(e.AclTestCode) : true) &&
                        (form.aclSampleDateStart.Length != 0 ? e.AclSampleDate >= DateOnly.Parse(form.aclSampleDateStart) : true) &&
                        (form.aclSampleDateEnd.Length != 0 ? e.AclSampleDate <= DateOnly.Parse(form.aclSampleDateEnd) : true)
                            ).OrderBy(e => e.FamilyName).ThenBy(e => e.FirstName).ThenBy(e => e.ThirdName);

            var lambda = new CreateLambda<QrySearchAcl>().CreateLambdaSelect(activeColumns);
            var selected = qryWhere.Select(lambda);
            var resQry = selected.GroupBy(item => item, new DictionaryEqualityComparer()).Select(e => e.First()).ToList();
            int resCount = resQry.Count();

            if (form.Excel)
            {
                string authHeader = Request.Headers["Authorization"].First();
                string jwt = authHeader.Substring("Bearer ".Length);
                var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var token = jwtHandler.ReadJwtToken(jwt);


                var createExcel = new CreateExcel();
                string fileName = $"res_search_{token.Claims.First().Value}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);

                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                createExcel.CreateSearchExcel(resQry, path, columName);

                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);

                return File(fileBytes, contentType, "res_search.xlsx");
            }

            if (resCount == 0)
            {
                return Ok(new { columName, resCount });
            }

            var resPage = resQry.Skip(pageSize * (form.Page - 1)).Take(pageSize).ToList();

            return Ok(new { columName, resPage, resCount });
        }
    }
}
