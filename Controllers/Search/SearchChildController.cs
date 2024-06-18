using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchChildController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchChildController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchChild outModel = new();

            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListRegionPreset = new() { "Все", "Московская обл.", "Иногородние", "Иностранные" };
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListRegOff = _context.TblInfectCourses
                .Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210)
                .Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong })
                .OrderBy(e => e.Short).ToList();
            outModel.ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            outModel.ListCodeMKB10 = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long).OrderBy(e => e).ToList();
            outModel.ListFamilyType = _context.TblFamilyTypes.Select(e => e.FamilyTypeLong).OrderBy(e => e).ToList();
            outModel.ListChildPlace = _context.TblChildPlaces.Select(e => e.ChildPlaceLong).OrderBy(e => e).ToList();
            outModel.ListPhp = _context.TblChildPhps.Select(e => e.ChildPhpLong).OrderBy(e => e).ToList();
            outModel.ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            outModel.ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            outModel.ListMaterhome = _context.TblMaterHomes.Select(e => e.MaterhomeLong).OrderBy(e => e).ToList();
            outModel.ListYN = _context.TblListYns.Select(e => e.YNName).OrderBy(e => e).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchChildForm form)
        {
            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchChildForm).GetProperties())
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
                        columName.Add("Возраст в днях");
                        activeColumns.Add("AgeDay");
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
                        columName.Add("Причина снятия с учета");
                        activeColumns.Add("RegOff");
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

                    if (key.Name == "selectFamilyType")
                    {
                        columName.Add("Состав семьи");
                        activeColumns.Add("FamilyTypeLong");
                    }

                    if (key.Name == "selectFirstCheckDate")
                    {
                        columName.Add("Дата 1-го визита");
                        activeColumns.Add("CheckFirstDate");
                    }

                    if (key.Name == "selectChildPlace")
                    {
                        columName.Add("Распол отказ реб");
                        activeColumns.Add("ChildPlaceLong");
                    }

                    if (key.Name == "selectBreastMonthNo")
                    {
                        columName.Add("Месяц грудного вскармливания");
                        activeColumns.Add("BreastMonthNo");
                    }

                    if (key.Name == "selectChildPhp")
                    {
                        columName.Add("Профилактика ПХП");
                        activeColumns.Add("ChildPhpLong");
                    }

                    if (key.Name == "selectSex")
                    {
                        columName.Add("Профилактика ПХП");
                        activeColumns.Add("SexShort");
                    }

                    if (key.Name == "selectCardNo")
                    {
                        columName.Add("№ карты");
                        activeColumns.Add("CardNo");
                    }

                    if (key.Name == "selectParentId")
                    {
                        columName.Add("Зарег. мать");
                        activeColumns.Add("MotherPatientId");
                        columName.Add("Зарег. мать фамилия");
                        activeColumns.Add("MotherFamilyName");
                        columName.Add("Зарег. мать имя");
                        activeColumns.Add("MotherFirstName");
                        columName.Add("Зарег. мать отчество");
                        activeColumns.Add("MotherThirdName");

                        columName.Add("Зарег. отец");
                        activeColumns.Add("FatherPatientId");
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

                    if (key.Name == "selectArvt")
                    {
                        columName.Add("АРТ");
                        activeColumns.Add("ArvtLong");
                    }

                    if (key.Name == "selectDieDate")
                    {

                        columName.Add("Дата смерти");
                        activeColumns.Add("DieDate");
                        columName.Add("Дата смерти от СПИДа");
                        activeColumns.Add("DieAidsDate");
                    }

                    if (key.Name == "selectMaterHome")
                    {
                        columName.Add("Роддом");
                        activeColumns.Add("MaterHomeLong");
                    }

                    if (key.Name == "selectForm309")
                    {
                        columName.Add("Форма 309");
                        activeColumns.Add("Form309");
                    }
                }
            }


            var qryWhere = _context.QrySearchChilds.Where(e =>
                        (form.dateInpStart.Length != 0 ? e.InputDate >= DateOnly.Parse(form.dateInpStart) : true) &&
                        (form.dateInpEnd.Length != 0 ? e.InputDate <= DateOnly.Parse(form.dateInpEnd) : true) &&
                        (form.patientId.Length != 0 ? e.PatientId == int.Parse(form.patientId) : true) &&
                        (form.familyName.Length != 0 ? e.FamilyName.ToLower().StartsWith(form.familyName.ToLower()) : true) &&
                        (form.firstName.Length != 0 ? e.FirstName.ToLower().StartsWith(form.firstName.ToLower()) : true) &&
                        (form.thirdName.Length != 0 ? e.ThirdName.ToLower().StartsWith(form.thirdName.ToLower()) : true) &&
                        (form.birthDateStart.Length != 0 ? e.BirthDate >= DateOnly.Parse(form.birthDateStart) : true) &&
                        (form.birthDateEnd.Length != 0 ? e.BirthDate <= DateOnly.Parse(form.birthDateEnd) : true) &&
                        (form.ageDayStart.Length != 0 ? e.AgeDay >= int.Parse(form.birthDateEnd) : true) &&
                        (form.ageDayEnd.Length != 0 ? e.AgeDay <= int.Parse(form.ageDayEnd) : true) &&
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
                        (form.unRegCourse.Length != 0 ? e.InfectCourseLong == form.unRegCourse : true) &&
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
                        (form.familyType[0] != "Все" ? form.familyType.Contains(e.FamilyTypeLong) : true) &&
                        (form.firstCheckDateStart.Length != 0 ? e.CheckFirstDate >= DateOnly.Parse(form.firstCheckDateStart) : true) &&
                        (form.firstCheckDateEnd.Length != 0 ? e.CheckFirstDate <= DateOnly.Parse(form.firstCheckDateEnd) : true) &&
                        (form.childPlace[0] != "Все" ? form.childPlace.Contains(e.ChildPlaceLong) : true) &&
                        (form.breastMonthNoStart.Length != 0 ? e.BreastMonthNo >= double.Parse(form.breastMonthNoStart) : true) &&
                        (form.breastMonthNoEnd.Length != 0 ? e.BreastMonthNo <= double.Parse(form.breastMonthNoEnd) : true) &&
                        (form.childPhp[0] != "Все" ? form.childPhp.Contains(e.ChildPhpLong) : true) &&
                        (form.sex.Length != 0 ? e.SexShort == form.sex : true) &&
                        (form.cardNo.Length != 0 ? e.CardNo.ToLower().StartsWith(form.cardNo.ToLower()) : true) &&
                        (form.motherPatientId.Length != 0 ? e.MotherPatientId == int.Parse(form.motherPatientId) : true) &&
                        (form.fatherPatientId.Length != 0 ? e.FatherPatientId == int.Parse(form.fatherPatientId) : true) &&
                        (form.arvt[0] != "Все" ? form.arvt.Contains(e.ArvtLong) : true) &&
                        (form.dieDateStart.Length != 0 ? e.DieDate >= DateOnly.Parse(form.dieDateStart) : true) &&
                        (form.dieDateEnd.Length != 0 ? e.DieDate <= DateOnly.Parse(form.dieDateEnd) : true) &&
                        (form.dieAidsDateStart.Length != 0 ? e.DieAidsDate >= DateOnly.Parse(form.dieAidsDateStart) : true) &&
                        (form.dieAidsDateEnd.Length != 0 ? e.DieAidsDate <= DateOnly.Parse(form.dieAidsDateEnd) : true) &&
                        (form.materHome[0] != "Все" ? form.materHome.Contains(e.MaterHomeLong) : true) &&
                        (form.form309 == "Да" ? e.Form309 == 1 : true) &&
                        (form.form309 == "Нет" ? e.Form309 == 2 : true)
                            ).OrderBy(e => e.FamilyName).ThenBy(e => e.FirstName).ThenBy(e => e.ThirdName);
            var lambda = new CreateLambda<QrySearchChild>().CreateLambdaSelect(activeColumns);
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
