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
    public class SearchPregnantController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchPregnantController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchPregnant outModel = new();

            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            outModel.ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };
            outModel.ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            outModel.ListPregCheck = _context.TblPregChecks.Select(e => e.PregCheckLong).OrderBy(e => e).ToList();
            outModel.ListBirthType = _context.TblBirthTypes.Select(e => e.BirthTypeLong).OrderBy(e => e).ToList();
            outModel.ListSchema = _context.TblCureSchemas.Select(e => e.CureSchemaLong).OrderBy(e => e).ToList();
            outModel.ListMedecineForSchema = _context.TblMedicineForSchemas.Select(e => e.MedforschemaLong).OrderBy(e => e).ToList();
            outModel.ListMaterHome = _context.TblMaterHomes.Select(e => e.MaterhomeLong).OrderBy(e => e).ToList();
            outModel.ListDiePreset = new() { "Все", "ВИЧ", "Не связанные с ВИЧ", "СПИД" };
            outModel.ListRegionPreset = new() { "Все", "Московская обл.", "Иногородние", "Иностранные" };

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchPregnantInputForm form)
        {
            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchPregnantInputForm).GetProperties())
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

                    if (key.Name == "selectCountry")
                    {
                        columName.Add("Страна");
                        activeColumns.Add("CountryLong");
                    }

                    if (key.Name == "selectRegOnDate")
                    {
                        columName.Add("Дата постановки на учет");
                        activeColumns.Add("RegOnDate");
                        columName.Add("Дата снятия с учета");
                        activeColumns.Add("RegOffDate");
                    }

                    if (key.Name == "selectStage")
                    {
                        columName.Add("Стадия");
                        activeColumns.Add("DiagnosisLong");
                        columName.Add("Дата постановки стадии");
                        activeColumns.Add("DiagnosisDefDate");
                    }

                    if (key.Name == "selectCheckCourse")
                    {
                        columName.Add("Причина обращения");
                        activeColumns.Add("CheckCourseLong");
                    }

                    if (key.Name == "selectInfectCourse")
                    {
                        columName.Add("Причина заражения");
                        activeColumns.Add("InfectCourseLong");
                    }

                    if (key.Name == "selectShowIllnes")
                    {
                        columName.Add("Индикаторная болезнь");
                        activeColumns.Add("ShowIllnessLong");
                        columName.Add("Дата вторичного заболивания с");
                        activeColumns.Add("StartDate");
                        columName.Add("Дата вторичного заболивания по");
                        activeColumns.Add("EndDate");
                    }

                    if (key.Name == "selectTransfArea")
                    {
                        columName.Add("Дата передачи в район");
                        activeColumns.Add("TransfAreaDate");
                    }

                    if (key.Name == "selectFr")
                    {
                        columName.Add("Внесено в ФР");
                        activeColumns.Add("FlgZamMedPart");
                        columName.Add("Зав АПО");
                        activeColumns.Add("FlgHeadPhysician");
                    }

                    if (key.Name == "selectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        activeColumns.Add("UfsinDate");
                    }

                    if (key.Name == "selectPregCheck")
                    {
                        columName.Add("Выявление");
                        activeColumns.Add("PregCheckLong");
                    }

                    if (key.Name == "selectPregMonthNo")
                    {
                        columName.Add("Срок беременности");
                        activeColumns.Add("PregMonthNo");
                    }

                    if (key.Name == "selectBirthType")
                    {
                        columName.Add("Вид родов");
                        activeColumns.Add("BirthTypeLong");
                    }

                    if (key.Name == "selectMedecineStartMonthNo")
                    {
                        columName.Add("Срок начала приёма медик.");
                        activeColumns.Add("MedecineStartMonthNo");
                    }

                    if (key.Name == "selectChildBirthDate")
                    {
                        columName.Add("Дата родов");
                        activeColumns.Add("ChildBirthDate");
                        columName.Add("Дата начала берем");
                        activeColumns.Add("PregDate");
                    }

                    if (key.Name == "selectChildFio")
                    {
                        columName.Add("Фамилия ребёнка");
                        activeColumns.Add("ChildFamilyName");
                        columName.Add("Имя ребёнка");
                        activeColumns.Add("ChildFirstName");
                        columName.Add("Отчество ребёнка");
                        activeColumns.Add("ChildThirdName");
                    }

                    if (key.Name == "selectCardNo")
                    {
                        columName.Add("№ карты");
                        activeColumns.Add("CardNo");
                    }

                    if (key.Name == "selectPhpSchema1")
                    {
                        columName.Add("ПХП1 схема");
                        activeColumns.Add("Php1Name");
                    }

                    if (key.Name == "selectPhpSchema2")
                    {
                        columName.Add("ПХП2 схема");
                        activeColumns.Add("Php2Name");
                    }

                    if (key.Name == "selectPhpSchema3")
                    {
                        columName.Add("ПХП3 схема");
                        activeColumns.Add("Php3Name");
                    }

                    if (key.Name == "selectMedecineForSchema1")
                    {
                        columName.Add("ПХП1 препарат");
                        activeColumns.Add("MedecineForSchemaLong1");
                    }

                    if (key.Name == "selectMedecineForSchema2")
                    {
                        columName.Add("ПХП2 препарат");
                        activeColumns.Add("MedecineForSchemaLong2");
                    }

                    if (key.Name == "selectMedecineForSchema3")
                    {
                        columName.Add("ПХП3 препарат");
                        activeColumns.Add("MedecineForSchemaLong3");
                    }

                    if (key.Name == "selectArt")
                    {
                        columName.Add("АРТ");
                        activeColumns.Add("ArvtLong");
                    }

                    if (key.Name == "selectAddr")
                    {
                        columName.Add("Город");
                        activeColumns.Add("CityName");
                        columName.Add("Населённый пункт");
                        activeColumns.Add("LocationName");
                        columName.Add("Индекс");
                        activeColumns.Add("AddrInd");
                        columName.Add("Улица");
                        activeColumns.Add("AddrStreet");
                        columName.Add("Дом");
                        activeColumns.Add("AddrHouse");
                        columName.Add("Корпус");
                        activeColumns.Add("AddrExt");
                        columName.Add("Квартира");
                        activeColumns.Add("AddrFlat");
                    }

                    if (key.Name == "selectMaterhome")
                    {
                        columName.Add("Роддом");
                        activeColumns.Add("MaterhomeLong");
                        columName.Add("Ид ребёнка");
                        activeColumns.Add("ChildId");
                    }

                    if (key.Name == "selectAclDate")
                    {
                        columName.Add("Дата опред.иммун.стат.");
                        activeColumns.Add("AclSampleDate");
                    }

                    if (key.Name == "selectAclMcnCode")
                    {
                        columName.Add("CD4+(abc)");
                        activeColumns.Add("AclMcnCode");
                    }
                }
            }

            int Num, Num1, McnCodeStart, McnCodeEnd;
            bool IsMcnCodeStart = int.TryParse(form.aclMcnCodeStart, out McnCodeStart),
            ISMcnCodeEnd = int.TryParse(form.aclMcnCodeEnd, out McnCodeEnd);

            var qryWhere = _context.QrySearchPregnants.Where(e =>
                        (form.dateInpStart.Length != 0 ? e.InputDate >= DateOnly.Parse(form.dateInpStart) : true) &&
                        (form.dateInpEnd.Length != 0 ? e.InputDate <= DateOnly.Parse(form.dateInpEnd) : true) &&
                        (form.patientId.Length != 0 ? e.PatientId == int.Parse(form.patientId) : true) &&
                        (form.familyName.Length != 0 ? e.FamilyName.ToLower().StartsWith(form.familyName.ToLower()) : true) &&
                        (form.firstName.Length != 0 ? e.FirstName.ToLower().StartsWith(form.firstName.ToLower()) : true) &&
                        (form.thirdName.Length != 0 ? e.ThirdName.ToLower().StartsWith(form.thirdName.ToLower()) : true) &&
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
                        (form.country[0] != "Все" ? form.country.Contains(e.CountryLong) : true) &&
                        (form.dateRegOnStart.Length != 0 ? e.RegOnDate >= DateOnly.Parse(form.dateRegOnStart) : true) &&
                        (form.dateRegOnEnd.Length != 0 ? e.RegOnDate <= DateOnly.Parse(form.dateRegOnEnd) : true) &&
                        (form.dateUnRegStart.Length != 0 ? e.RegOffDate >= DateOnly.Parse(form.dateUnRegStart) : true) &&
                        (form.dateUnRegEnd.Length != 0 ? e.RegOffDate <= DateOnly.Parse(form.dateUnRegEnd) : true) &&
                        (form.stage[0] != "Все" ? form.stage.Contains(e.DiagnosisLong) : true) &&
                        (form.checkCourse[0] != "Все" ? form.checkCourse.Contains(e.CheckCourseLong) : true) &&
                        (form.infectCourse[0] != "Все" ? form.infectCourse.Contains(e.InfectCourseLong) : true) &&
                        (form.showIllnes[0] != "Все" ? form.showIllnes.Contains(e.ShowIllnessLong) : true) &&
                        (form.dateShowIllnesStart.Length != 0 ? e.StartDate >= DateOnly.Parse(form.dateShowIllnesStart) : true) &&
                        (form.dateShowIllnesEnd.Length != 0 ? e.StartDate <= DateOnly.Parse(form.dateShowIllnesEnd) : true) &&
                        (form.transfAreaYNA == "Да" ? e.TransfAreaDate != null : true) &&
                        (form.transfAreaYNA == "Нет" ? e.TransfAreaDate == null : true) &&
                        (form.dateTransfAreaStart.Length != 0 ? e.TransfAreaDate >= DateOnly.Parse(form.dateTransfAreaStart) : true) &&
                        (form.dateTransfAreaEnd.Length != 0 ? e.TransfAreaDate <= DateOnly.Parse(form.dateTransfAreaEnd) : true) &&
                        (form.frYNA == "Да" ? e.FlgZamMedPart == true : true) &&
                        (form.frYNA == "Нет" ? e.FlgZamMedPart == false || e.FlgZamMedPart == null : true) &&
                        (form.zavApoYNA == "Да" ? e.FlgHeadPhysician == true : true) &&
                        (form.zavApoYNA == "Нет" ? e.FlgHeadPhysician == false || e.FlgHeadPhysician == null : true) &&
                        (form.ufsinYNA == "Да" ? e.UfsinDate != null : true) &&
                        (form.ufsinYNA == "Нет" ? e.UfsinDate == null : true) &&
                        (form.dateUfsinStart.Length != 0 ? e.UfsinDate >= DateOnly.Parse(form.dateUfsinStart) : true) &&
                        (form.dateUfsinEnd.Length != 0 ? e.UfsinDate <= DateOnly.Parse(form.dateUfsinEnd) : true) &&
                        (form.pregCheck[0] != "Все" ? form.pregCheck.Contains(e.PregCheckLong) : true) &&
                        (form.pregMonthNo.Length != 0 && int.TryParse(form.pregMonthNo, out Num) ? e.PregMonthNo == Num : true) &&
                        (form.birthType[0] != "Все" ? form.birthType.Contains(e.BirthTypeLong) : true) &&
                        (form.medecineStartMonthNo.Length != 0 && int.TryParse(form.medecineStartMonthNo, out Num) ? e.MedecineStartMonthNo == Num : true) &&
                        (form.childBirthDateStart.Length != 0 ? e.ChildBirthDate >= DateOnly.Parse(form.childBirthDateStart) : true) &&
                        (form.childBirthDateEnd.Length != 0 ? e.ChildBirthDate <= DateOnly.Parse(form.childBirthDateEnd) : true) &&
                        (form.childFamilyName.Length != 0 ? e.ChildFamilyName.ToLower().StartsWith(form.childFamilyName.ToLower()) : true) &&
                        (form.childFirstName.Length != 0 ? e.ChildFirstName.ToLower().StartsWith(form.childFirstName.ToLower()) : true) &&
                        (form.childThirdName.Length != 0 ? e.ChildThirdName.ToLower().StartsWith(form.childThirdName.ToLower()) : true) &&
                        (form.cardNo.Length != 0 ? e.CardNo.ToLower().StartsWith(form.cardNo.ToLower()) : true) &&
                        (form.phpSchema1[0] != "Все" ? form.phpSchema1.Contains(e.Php1Name) : true) &&
                        (form.phpSchema2[0] != "Все" ? form.phpSchema2.Contains(e.Php2Name) : true) &&
                        (form.phpSchema3[0] != "Все" ? form.phpSchema3.Contains(e.Php3Name) : true) &&
                        (form.medecineForSchema1[0] != "Все" ? form.medecineForSchema1.Contains(e.MedecineForSchemaLong1) : true) &&
                        (form.medecineForSchema2[0] != "Все" ? form.medecineForSchema2.Contains(e.MedecineForSchemaLong2) : true) &&
                        (form.medecineForSchema3[0] != "Все" ? form.medecineForSchema3.Contains(e.MedecineForSchemaLong3) : true) &&
                        (form.art[0] != "Все" ? form.art.Contains(e.ArvtLong) : true) &&
                        (form.materhome[0] != "Все" ? form.materhome.Contains(e.MaterhomeLong) : true) &&
                        (form.aclDateStart.Length != 0 ? e.AclSampleDate >= DateOnly.Parse(form.aclDateStart) : true) &&
                        (form.aclDateEnd.Length != 0 ? e.AclSampleDate <= DateOnly.Parse(form.aclDateEnd) : true) &&
                        (form.aclMcnCodeStart.Length != 0 && IsMcnCodeStart ? e.AclMcnCode >= McnCodeStart : true) &&
                        (form.aclMcnCodeEnd.Length != 0 && ISMcnCodeEnd ? e.AclMcnCode <= McnCodeEnd : true)
                            );

            var lambda = new CreateLambda<QrySearchPregnant>().CreateLambdaSelect(activeColumns);
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
                string path = Path.Combine(Environment.CurrentDirectory, @"wwwroot", fileName);

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

            var resPage = resQry.Select((x, i) => new { Index = i, Value = x })
                        .GroupBy(x => x.Index / pageSize)
                        .Select(x => x.Select(v => v.Value).ToList())
                        .ToList().ElementAt(form.Page - 1);

            return Ok(new { columName, resPage, resCount });

        }
    }
}
