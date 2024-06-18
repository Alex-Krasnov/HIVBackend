using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAnalyseController : ControllerBase
    {
        private readonly HivContext _context;
        public SearchAnalyseController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchAnalyse outModel = new();

            outModel.ListSex = _context.TblSexes.Select(e => e.SexShort).ToList();
            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListRegionPreset = new() { "Все", "Московская обл.", "Иногородние", "Иностранные" };
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListRegOff = _context.TblInfectCourses.Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            outModel.ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };
            outModel.ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            outModel.ListDiePreset = new() { "Все", "ВИЧ", "Не связанные с ВИЧ", "СПИД" };
            outModel.ListDieCourse = _context.TblTempDieCureMkb10lists.Select(e => e.DieCourseLong).OrderBy(e => e).ToList();
            outModel.ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();
            outModel.ListPNA = new() { "Все", "Пол", "Отр" };
            outModel.ListSelectBlot = new() { "Все", "Первый", "Последний", "Перв.и посл." };

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchAnalyseForm form)
        {
            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchAnalyseForm).GetProperties())
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

                    if (key.Name == "selectCountry")
                    {
                        columName.Add("Страна");
                        activeColumns.Add("CountryLong");
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

                    if (key.Name == "selectDieDate")
                    {
                        columName.Add("Дата смерти");
                        activeColumns.Add("DieDate");
                        columName.Add("Дата смерти от СПИДа");
                        activeColumns.Add("DieAidsDate");
                    }

                    if (key.Name == "selectDieCourse")
                    {
                        columName.Add("Причина смерти");
                        activeColumns.Add("DieCourseLong");
                        columName.Add("МКБ причина смерти");
                        activeColumns.Add("DieCourseShort");
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

                    if (key.Name == "selectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        activeColumns.Add("UfsinDate");
                    }

                    if (key.Name == "selectCardNo")
                    {
                        columName.Add("№ карты");
                        activeColumns.Add("CardNo");
                    }

                    if (key.Name == "selectArt")
                    {
                        columName.Add("АРТ");
                        activeColumns.Add("ArvtLong");
                    }

                    if (key.Name == "selectVlDate")
                    {
                        columName.Add("Дата опред.вир.нагр.");
                        activeColumns.Add("VlDate");
                    }

                    if (key.Name == "selectVlRes")
                    {
                        columName.Add("Вирусн.нагр.");
                        activeColumns.Add("VlResult");
                    }

                    if (key.Name == "selectImDate")
                    {
                        columName.Add("Дата опред.иммун.стат.");
                        activeColumns.Add("ImDate");
                    }

                    if (key.Name == "selectImCd3Res")
                    {
                        columName.Add("CD3+");
                        activeColumns.Add("I0015");
                    }

                    if (key.Name == "selectImCd4Res")
                    {
                        columName.Add("CD4+(abc)");
                        activeColumns.Add("I0025");
                    }

                    if (key.Name == "selectImCd8Res")
                    {
                        columName.Add("CD8+(abc)");
                        activeColumns.Add("I0035");
                    }

                    if (key.Name == "selectHepCIfa")
                    {
                        columName.Add("Дата гепатит С методом ИФА");
                        activeColumns.Add("HepCIfaDate");
                        columName.Add("Гепатит С методом ИФА");
                        activeColumns.Add("HepCIfaRes");
                    }

                    if (key.Name == "selectHepBIfa")
                    {
                        columName.Add("Дата гепатит В методом ИФА");
                        activeColumns.Add("HepBIfaDate");
                        columName.Add("Гепатит В методом ИФА");
                        activeColumns.Add("HepBIfaRes");
                    }

                    if (key.Name == "selectHepSyphIfa")
                    {
                        columName.Add("Дата сифилис методом ИФА");
                        activeColumns.Add("HepSyphIfaDate");
                        columName.Add("Сифилис методом ИФА");
                        activeColumns.Add("HepSyphIfaRes");
                    }

                    if (key.Name == "selectHepC")
                    {
                        columName.Add("Дата гепатит С методом ПЦР");
                        activeColumns.Add("HepCDate");
                        columName.Add("Гепатит С методом ПЦР");
                        activeColumns.Add("HepCRes");
                    }

                    if (key.Name == "selectHepB")
                    {
                        columName.Add("Дата гепатит В методом ПЦР");
                        activeColumns.Add("HepBDate");
                        columName.Add("Гепатит В методом ПЦР");
                        activeColumns.Add("HepBRes");
                    }
                }
            }

            int ResVlStart, ResVlEnd, ResImCd3Start, ResImCd3End, ResImCd4Start, ResImCd4End, ResImCd8Start, ResImCd8End;
            bool IsVlStart = int.TryParse(form.resVlStart, out ResVlStart),
            IsVlEnd = int.TryParse(form.resVlEnd, out ResVlEnd),
            IsImCd3Start = int.TryParse(form.resImCd3Start, out ResImCd3Start),
            IsImCd3End = int.TryParse(form.resImCd3End, out ResImCd3End),
            IsImCd4Start = int.TryParse(form.resImCd4Start, out ResImCd4Start),
            IsImCd4End = int.TryParse(form.resImCd4End, out ResImCd4End),
            IsImCd8Start = int.TryParse(form.resImCd8Start, out ResImCd8Start),
            IsImCd8End = int.TryParse(form.resImCd8End, out ResImCd8End);

            var qryWhere = _context.QrySearchAnalyses.Where(e =>
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
                        (form.country[0] != "Все" ? form.country.Contains(e.CountryLong) : true) &&
                        (form.city.Length != 0 ? e.CityName.ToLower().StartsWith(form.city.ToLower()) : true) &&
                        (form.location.Length != 0 ? e.LocationName.ToLower().StartsWith(form.location.ToLower()) : true) &&
                        (form.indx.Length != 0 ? e.AddrInd.ToLower().StartsWith(form.indx.ToLower()) : true) &&
                        (form.street.Length != 0 ? e.AddrStreet.ToLower().StartsWith(form.street.ToLower()) : true) &&
                        (form.home.Length != 0 ? e.AddrHouse.ToLower().StartsWith(form.home.ToLower()) : true) &&
                        (form.dateRegOnStart.Length != 0 ? e.RegOnDate >= DateOnly.Parse(form.dateRegOnStart) : true) &&
                        (form.dateRegOnEnd.Length != 0 ? e.RegOnDate <= DateOnly.Parse(form.dateRegOnEnd) : true) &&
                        (form.dateUnRegStart.Length != 0 ? e.RegOffDate >= DateOnly.Parse(form.dateUnRegStart) : true) &&
                        (form.dateUnRegEnd.Length != 0 ? e.RegOffDate <= DateOnly.Parse(form.dateUnRegEnd) : true) &&
                        (form.unRegCourse.Length != 0 ? e.InfectCourseLong == form.unRegCourse : true) &&
                        (form.stage[0] != "Все" ? form.stage.Contains(e.DiagnosisLong) : true) &&
                        (form.dateDieStart.Length != 0 ? e.DieDate >= DateOnly.Parse(form.dateDieStart) : true) &&
                        (form.dateDieEnd.Length != 0 ? e.DieDate <= DateOnly.Parse(form.dateDieEnd) : true) &&
                        (form.dateDieAidsStart.Length != 0 ? e.DieAidsDate >= DateOnly.Parse(form.dateDieAidsStart) : true) &&
                        (form.dateDieAidsEnd.Length != 0 ? e.DieAidsDate <= DateOnly.Parse(form.dateDieAidsEnd) : true) &&
                        (form.dieCourse[0] != "Все" ? form.dieCourse.Contains(e.DieCourseLong) : true) &&
                        (form.diePreset == "ВИЧ" ? e.DethtypeId == 1 || e.DethtypeId == 3 : true) &&
                        (form.diePreset == "Не связанные с ВИЧ" ? e.DethtypeId == 2 : true) &&
                        (form.diePreset == "СПИД" ? e.DethtypeId == 3 : true) &&
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
                        (form.ibRes.Length != 0 ? e.IbResultShort == form.ibRes : true) &&
                        (form.dateIbResStart.Length != 0 ? e.BlotDate >= DateOnly.Parse(form.dateIbResStart) : true) &&
                        (form.dateIbResEnd.Length != 0 ? e.BlotDate <= DateOnly.Parse(form.dateIbResEnd) : true) &&
                        (form.ibNum.Length != 0 ? e.BlotNo == int.Parse(form.ibNum) : true) &&
                        (form.dateInpIbStart.Length != 0 ? e.Datetime1 >= DateOnly.Parse(form.dateInpIbStart) : true) &&
                        (form.dateInpIbEnd.Length != 0 ? e.Datetime1 <= DateOnly.Parse(form.dateInpIbEnd) : true) &&
                        (form.ibSelect == "Первый" ? e.First1 == true : true) &&
                        (form.ibSelect == "Последний" ? e.Last1 == true : true) &&
                        (form.ibSelect == "Перв.и посл." ? e.Last1 == true || e.First1 == true : true) &&
                        (form.ufsinYNA == "Да" ? e.UfsinDate != null : true) &&
                        (form.ufsinYNA == "Нет" ? e.UfsinDate == null : true) &&
                        (form.dateUfsinStart.Length != 0 ? e.UfsinDate >= DateOnly.Parse(form.dateUfsinStart) : true) &&
                        (form.dateUfsinEnd.Length != 0 ? e.UfsinDate <= DateOnly.Parse(form.dateUfsinEnd) : true) &&
                        (form.cardNo.Length != 0 ? e.CardNo.ToLower().StartsWith(form.cardNo.ToLower()) : true) &&
                        (form.art[0] != "Все" ? form.art.Contains(e.ArvtLong) : true) &&

                        (form.dateVlStart.Length != 0 ? e.VlDate >= DateOnly.Parse(form.dateVlStart) : true) &&
                        (form.dateVlEnd.Length != 0 ? e.VlDate <= DateOnly.Parse(form.dateVlEnd) : true) &&
                        (form.resVlStart.Length != 0 && IsVlStart ? e.VlResult >= ResVlStart : true) &&
                        (form.resVlEnd.Length != 0 && IsVlEnd ? e.VlResult <= ResVlEnd : true) &&
                        (form.dateIMStart.Length != 0 ? e.ImDate >= DateOnly.Parse(form.dateIMStart) : true) &&
                        (form.dateImEnd.Length != 0 ? e.ImDate <= DateOnly.Parse(form.dateImEnd) : true) &&
                        (form.resImCd3Start.Length != 0 && IsImCd3Start ? e.I0015 >= ResImCd3Start : true) &&
                        (form.resImCd3End.Length != 0 && IsImCd3End ? e.I0015 <= ResImCd3End : true) &&
                        (form.resImCd4Start.Length != 0 && IsImCd4Start ? e.I0025 >= ResImCd4Start : true) &&
                        (form.resImCd4End.Length != 0 && IsImCd4End ? e.I0025 <= ResImCd4End : true) &&
                        (form.resImCd8Start.Length != 0 && IsImCd8Start ? e.I0025 >= ResImCd8Start : true) &&
                        (form.resImCd8End.Length != 0 && IsImCd8End ? e.I0025 <= ResImCd8End : true) &&
                        (form.dateHepCIfaStart.Length != 0 ? e.HepCIfaDate >= DateOnly.Parse(form.dateHepCIfaStart) : true) &&
                        (form.dateHepCIfaEnd.Length != 0 ? e.HepCIfaDate <= DateOnly.Parse(form.dateHepCIfaEnd) : true) &&
                        (form.dateHepCIfaVal == "Пол" ? e.HepCIfaRes.Contains("Пол") : true) &&
                        (form.dateHepCIfaVal == "Отр" ? e.HepCIfaRes.Contains("Отр") : true) &&
                        (form.dateHepBIfaStart.Length != 0 ? e.HepBIfaDate >= DateOnly.Parse(form.dateHepBIfaStart) : true) &&
                        (form.dateHepBIfaEnd.Length != 0 ? e.HepBIfaDate <= DateOnly.Parse(form.dateHepBIfaEnd) : true) &&
                        (form.dateHepBIfaVal == "Пол" ? e.HepBIfaRes.Contains("Пол") : true) &&
                        (form.dateHepBIfaVal == "Отр" ? e.HepBIfaRes.Contains("Отр") : true) &&
                        (form.dateHepSyphIfaStart.Length != 0 ? e.HepSyphIfaDate >= DateOnly.Parse(form.dateHepBIfaStart) : true) &&
                        (form.dateHepSyphIfaEnd.Length != 0 ? e.HepSyphIfaDate <= DateOnly.Parse(form.dateHepBIfaEnd) : true) &&
                        (form.dateHepSyphIfaVal == "Пол" ? e.HepSyphIfaRes.Contains("Пол") : true) &&
                        (form.dateHepSyphIfaVal == "Отр" ? e.HepSyphIfaRes.Contains("Отр") : true) &&
                        (form.dateHepCStart.Length != 0 ? e.HepCDate >= DateOnly.Parse(form.dateHepCStart) : true) &&
                        (form.dateHepCEnd.Length != 0 ? e.HepCDate <= DateOnly.Parse(form.dateHepCEnd) : true)
                            ).OrderBy(e => e.FamilyName).ThenBy(e => e.FirstName).ThenBy(e => e.ThirdName);

            var lambda = new CreateLambda<QrySearchAnalyse>().CreateLambdaSelect(activeColumns);
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
