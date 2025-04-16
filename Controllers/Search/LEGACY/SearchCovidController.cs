using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels.Search.LEGACY;
using HIVBackend.Models.OutputModel;
using HIVBackend.Models.OutputModel.Search;
using HIVBackend.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.Search.LEGACY
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchCovidController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchCovidController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchCovid outModel = new();

            outModel.ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListRegionPreset = new() { "Все", "Московская обл.", "Иногородние", "Иностранные" };
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListRegOff = _context.TblInfectCourses.Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210).Select(e => e.InfectCourseLong).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            outModel.ListDieCourse = _context.TblTempDieCureMkb10lists.Select(e => e.DieCourseLong).OrderBy(e => e).ToList();
            outModel.ListDiePreset = new() { "Все", "ВИЧ", "Не связанные с ВИЧ", "СПИД" };
            outModel.ListInfectCourse = _context.TblInfectCourses.Where(e => e.InfectCourseId != 210).Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            outModel.ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();
            outModel.ListSelectBlot = new() { "Все", "Первый", "Последний", "Перв.и посл." };
            outModel.ListHospCourse = _context.TblHospCourses.Select(e => e.HospCourseLong).OrderBy(e => e).ToList();
            outModel.ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            outModel.ListCodeMKB10 = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long).OrderBy(e => e).ToList();
            outModel.ListMkb10Covid = _context.TblListMkb10Covids.Select(e => e.Mkb10LongName).OrderBy(e => e).ToList();
            outModel.ListMkb10Tuber = _context.TblListMkbTuders.Select(e => e.TuberNameShort).OrderBy(e => e).ToList();
            outModel.ListMkb10Pneumonia = _context.TblListMkbPneumonia.Select(e => e.PneumoniaNameShort).OrderBy(e => e).ToList();
            outModel.ListOutHosp = _context.TblListOutHosps.Select(e => e.HospName).OrderBy(e => e).ToList();
            outModel.ListClinVarCovid = _context.TblListClinVarCovids.Select(e => e.ClinVarCovidName).OrderBy(e => e).ToList();
            outModel.ListCourseCovid = _context.TblListCourseCovids.Select(e => e.CourseCovidName).OrderBy(e => e).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchCovidForm form)
        {
            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchCovidForm).GetProperties())
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
                        columName.Add("Смена ФИО");
                        activeColumns.Add("FioChange");
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

                    if (key.Name == "selectCheckCourse")
                    {
                        columName.Add("Причина обращения");
                        activeColumns.Add("CheckCourseLong");
                    }

                    if (key.Name == "selectDieCourse")
                    {
                        columName.Add("Причина смерти");
                        activeColumns.Add("DieCourseLong");
                        columName.Add("МКБ причина смерти");
                        activeColumns.Add("DieCourseShort");
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

                    if (key.Name == "selectHospCourse")
                    {
                        columName.Add("Причина госпитализации");
                        activeColumns.Add("HospCourseLong");
                    }

                    if (key.Name == "selectArt")
                    {
                        columName.Add("АРТ");
                        activeColumns.Add("ArvtLong");
                    }

                    if (key.Name == "selectMkb10")
                    {
                        columName.Add("Код МКБ10");
                        activeColumns.Add("CodeMkb10Long");
                    }

                    if (key.Name == "selectMkb10Covid")
                    {
                        columName.Add("Код МКБ10 COVID");
                        activeColumns.Add("Mkb10LongName");
                    }

                    if (key.Name == "selectMkb10Tuber")
                    {
                        columName.Add("Код МКБ10 Туберкулез");
                        activeColumns.Add("TuberNameShort");
                    }

                    if (key.Name == "selectMkb10Pneumonia")
                    {
                        columName.Add("Код МКБ10 Пневмания");
                        activeColumns.Add("PneumoniaNameShort");
                    }

                    if (key.Name == "selectHospCovid")
                    {
                        columName.Add("Исход госпитализации COVID");
                        activeColumns.Add("HospName");
                    }

                    if (key.Name == "selectClinVarCovid")
                    {
                        columName.Add("Клинические варианты и проявления");
                        activeColumns.Add("ClinVarCovidName");
                    }

                    if (key.Name == "selectCourseCovid")
                    {
                        columName.Add("Тяжесть Течения COVID");
                        activeColumns.Add("CourseVarCovidName");
                    }

                    if (key.Name == "selectArterHyper")
                    {
                        columName.Add("Артериальная гипертензия");
                        activeColumns.Add("ArterHyperYn");
                    }

                    if (key.Name == "selectDiabetes")
                    {
                        columName.Add("Сахарный диабет");
                        activeColumns.Add("DiabetesYn");
                    }

                    if (key.Name == "selectCoronarySynd")
                    {
                        columName.Add("Острый коронарный синдром");
                        activeColumns.Add("CoronarySyndYn");
                    }

                    if (key.Name == "selectHobl")
                    {
                        columName.Add("ХОБЛ");
                        activeColumns.Add("HoblYn");
                    }

                    if (key.Name == "selectBronhAstma")
                    {
                        columName.Add("Бронхиальная асмтма");
                        activeColumns.Add("BronhAstmaYn");
                    }

                    if (key.Name == "selectCancer")
                    {
                        columName.Add("Онкология");
                        activeColumns.Add("CancerYn");
                    }

                    if (key.Name == "selectKidneyDes")
                    {
                        columName.Add("Болезнь почек");
                        activeColumns.Add("KidneyDesYn");
                    }

                    if (key.Name == "selectOutpatTreat")
                    {
                        columName.Add("Амбулаторное лечение");
                        activeColumns.Add("OutpatTreatYn");
                    }

                    if (key.Name == "selectDeathCovid")
                    {
                        columName.Add("Смерть от COVID");
                        activeColumns.Add("DeathCovidYn");
                    }

                    if (key.Name == "selectOrit")
                    {
                        columName.Add("Нахождение в ОРИТ");
                        activeColumns.Add("OritYn");
                    }

                    if (key.Name == "selectOxygen")
                    {
                        columName.Add("Кислород");
                        activeColumns.Add("OxygenYn");
                    }

                    if (key.Name == "selectTypeAlv")
                    {
                        columName.Add("ИВЛ");
                        activeColumns.Add("TypeAlvYn");
                    }

                    if (key.Name == "selectPeriodDes")
                    {
                        columName.Add("Период заболевания");
                        activeColumns.Add("DPeriodDes");
                    }

                    if (key.Name == "selectPositivResCovid")
                    {
                        columName.Add("Дата + рез COVID");
                        activeColumns.Add("DPositivResCovid");
                    }

                    if (key.Name == "selectNegativeResCovid")
                    {
                        columName.Add("Дата - рез COVID");
                        activeColumns.Add("DNegativeResCovid");
                    }

                    if (key.Name == "selectHospitalization")
                    {
                        columName.Add("Госпитализация");
                        activeColumns.Add("Hospitalization");
                    }

                    if (key.Name == "selectDischarge")
                    {
                        columName.Add("Дата выписки/смерти");
                        activeColumns.Add("DDischarge");
                    }
                }
            }
            var qryWhere = _context.QrySearchCovids.Where(e =>
                        (form.dateInpStart.Length != 0 ? e.InputDate >= DateOnly.Parse(form.dateInpStart) : true) &&
                        (form.dateInpEnd.Length != 0 ? e.InputDate <= DateOnly.Parse(form.dateInpEnd) : true) &&
                        (form.patientId.Length != 0 ? e.PatientId == int.Parse(form.patientId) : true) &&
                        (form.familyName.Length != 0 ? e.FamilyName.ToLower().StartsWith(form.familyName.ToLower()) : true) &&
                        (form.firstName.Length != 0 ? e.FirstName.ToLower().StartsWith(form.firstName.ToLower()) : true) &&
                        (form.thirdName.Length != 0 ? e.ThirdName.ToLower().StartsWith(form.thirdName.ToLower()) : true) &&
                        (form.fioChange.Length != 0 ? e.FioChange.ToLower().StartsWith(form.fioChange.ToLower()) : true) &&
                        (form.sex.Length != 0 ? e.SexShort == form.sex : true) &&
                        (form.birthDateStart.Length != 0 ? e.BirthDate >= DateOnly.Parse(form.birthDateStart) : true) &&
                        (form.birthDateEnd.Length != 0 ? e.BirthDate <= DateOnly.Parse(form.birthDateEnd) : true) &&
                        (form.regionFact[0] != "Все" ? form.regionFact.Contains(e.RegionLongFact) : true) &&
                        (form.regionPreset == "Московская обл." ? e.RegtypeId == 1 : true) &&
                        (form.regionPreset == "Иногородние" ? e.RegtypeId == 2 : true) &&
                        (form.regionPreset == "Иностранные" ? e.RegtypeId == 3 : true) &&
                        (form.regionReg[0] != "Все" ? form.regionReg.Contains(e.RegionLong) : true) &&
                        (form.factRegionPreset == "Московская обл." ? e.FactRegtypeId == 1 : true) &&
                        (form.factRegionPreset == "Иногородние" ? e.FactRegtypeId == 2 : true) &&
                        (form.factRegionPreset == "Иностранные" ? e.FactRegtypeId == 3 : true) &&
                        (form.country[0] != "Все" ? form.country.Contains(e.CountryLong) : true) &&
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
                        (form.checkCourse[0] != "Все" ? form.checkCourse.Contains(e.CheckCourseLong) : true) &&
                        (form.dieCourse[0] != "Все" ? form.dieCourse.Contains(e.DieCourseLong) : true) &&
                        (form.diePreset == "ВИЧ" ? e.DethtypeId == 1 || e.DethtypeId == 3 : true) &&
                        (form.diePreset == "Не связанные с ВИЧ" ? e.DethtypeId == 2 : true) &&
                        (form.diePreset == "СПИД" ? e.DethtypeId == 3 : true) &&
                        (form.infectCourse[0] != "Все" ? form.infectCourse.Contains(e.InfectCourseLong) : true) &&
                        (form.showIllnes[0] != "Все" ? form.showIllnes.Contains(e.ShowIllnessLong) : true) &&
                        (form.dateShowIllnesStart.Length != 0 ? e.StartDate >= DateOnly.Parse(form.dateShowIllnesStart) : true) &&
                        (form.dateShowIllnesEnd.Length != 0 ? e.StartDate <= DateOnly.Parse(form.dateShowIllnesEnd) : true) &&
                        (form.ibRes.Length != 0 ? e.IbResultShort == form.ibRes : true) &&
                        (form.dateIbResStart.Length != 0 ? e.BlotDate >= DateOnly.Parse(form.dateIbResStart) : true) &&
                        (form.dateIbResEnd.Length != 0 ? e.BlotDate <= DateOnly.Parse(form.dateIbResEnd) : true) &&
                        (form.ibNum.Length != 0 ? e.BlotNo == int.Parse(form.ibNum) : true) &&
                        (form.dateInpIbStart.Length != 0 ? e.Datetime1 >= DateOnly.Parse(form.dateInpIbStart) : true) &&
                        (form.dateInpIbEnd.Length != 0 ? e.Datetime1 <= DateOnly.Parse(form.dateInpIbEnd) : true) &&
                        (form.ibSelect == "Первый" ? e.First1 == true : true) &&
                        (form.ibSelect == "Последний" ? e.Last1 == true : true) &&
                        (form.ibSelect == "Перв.и посл." ? e.Last1 == true || e.First1 == true : true) &&
                        (form.hospCourse[0] != "Все" ? form.hospCourse.Contains(e.ShowIllnessLong) : true) &&
                        (form.art[0] != "Все" ? form.art.Contains(e.ArvtLong) : true) &&
                        (form.mkb10[0] != "Все" ? form.mkb10.Contains(e.CodeMkb10Long) : true) &&
                        (form.mkb10Covid[0] != "Все" ? form.mkb10Covid.Contains(e.Mkb10LongName) : true) &&
                        (form.mkb10Tuber[0] != "Все" ? form.mkb10Tuber.Contains(e.TuberNameShort) : true) &&
                        (form.mkb10Pneumonia[0] != "Все" ? form.mkb10Pneumonia.Contains(e.PneumoniaNameShort) : true) &&
                        (form.hospCovid[0] != "Все" ? form.hospCovid.Contains(e.HospName) : true) &&
                        (form.clinVarCovid[0] != "Все" ? form.clinVarCovid.Contains(e.ClinVarCovidName) : true) &&
                        (form.courseCovid[0] != "Все" ? form.courseCovid.Contains(e.CourseVarCovidName) : true) &&
                        (form.arterHyperYn == "Да" ? e.ArterHyperYn == "Да" : true) &&
                        (form.arterHyperYn == "Нет" ? e.ArterHyperYn == "Нет" : true) &&
                        (form.diabetesYn == "Да" ? e.DiabetesYn == "Да" : true) &&
                        (form.diabetesYn == "Нет" ? e.DiabetesYn == "Нет" : true) &&
                        (form.coronarySyndYn == "Да" ? e.CoronarySyndYn == "Да" : true) &&
                        (form.coronarySyndYn == "Нет" ? e.CoronarySyndYn == "Нет" : true) &&
                        (form.hoblYn == "Да" ? e.HoblYn == "Да" : true) &&
                        (form.hoblYn == "Нет" ? e.HoblYn == "Нет" : true) &&
                        (form.bronhAstmaYn == "Да" ? e.BronhAstmaYn == "Да" : true) &&
                        (form.bronhAstmaYn == "Нет" ? e.BronhAstmaYn == "Нет" : true) &&
                        (form.cancerYn == "Да" ? e.CancerYn == "Да" : true) &&
                        (form.cancerYn == "Нет" ? e.CancerYn == "Нет" : true) &&
                        (form.kidneyDesYn == "Да" ? e.KidneyDesYn == "Да" : true) &&
                        (form.kidneyDesYn == "Нет" ? e.KidneyDesYn == "Нет" : true) &&
                        (form.outpatTreatYn == "Да" ? e.OutpatTreatYn == "Да" : true) &&
                        (form.outpatTreatYn == "Нет" ? e.OutpatTreatYn == "Нет" : true) &&
                        (form.deathCovidYn == "Да" ? e.DeathCovidYn == "Да" : true) &&
                        (form.deathCovidYn == "Нет" ? e.DeathCovidYn == "Нет" : true) &&
                        (form.oritYn == "Да" ? e.OritYn == "Да" : true) &&
                        (form.oritYn == "Нет" ? e.OritYn == "Нет" : true) &&
                        (form.oxygenYn == "Да" ? e.OxygenYn == "Да" : true) &&
                        (form.oxygenYn == "Нет" ? e.OxygenYn == "Нет" : true) &&
                        (form.typeAlvYn == "Да" ? e.TypeAlvYn == "Да" : true) &&
                        (form.typeAlvYn == "Нет" ? e.TypeAlvYn == "Нет" : true) &&
                        (form.periodDesStart.Length != 0 ? e.DPeriodDes >= DateOnly.Parse(form.periodDesStart) : true) &&
                        (form.periodDesEnd.Length != 0 ? e.DPeriodDes <= DateOnly.Parse(form.periodDesEnd) : true) &&
                        (form.positivResCovidStart.Length != 0 ? e.DPositivResCovid >= DateOnly.Parse(form.positivResCovidStart) : true) &&
                        (form.positivResCovidEnd.Length != 0 ? e.DPositivResCovid <= DateOnly.Parse(form.positivResCovidEnd) : true) &&
                        (form.negativeResCovidStart.Length != 0 ? e.DNegativeResCovid >= DateOnly.Parse(form.negativeResCovidStart) : true) &&
                        (form.negativeResCovidEnd.Length != 0 ? e.DNegativeResCovid <= DateOnly.Parse(form.negativeResCovidEnd) : true) &&
                        (form.hospitalizationStart.Length != 0 ? e.Hospitalization >= DateOnly.Parse(form.hospitalizationStart) : true) &&
                        (form.hospitalizationEnd.Length != 0 ? e.Hospitalization <= DateOnly.Parse(form.hospitalizationEnd) : true) &&
                        (form.dischargeStart.Length != 0 ? e.DDischarge >= DateOnly.Parse(form.dischargeStart) : true) &&
                        (form.dischargeEnd.Length != 0 ? e.DDischarge <= DateOnly.Parse(form.dischargeEnd) : true)
                            ).OrderBy(e => e.FamilyName).ThenBy(e => e.FirstName).ThenBy(e => e.ThirdName);

            var lambda = new CreateLambda<QrySearchCovid>().CreateLambdaSelect(activeColumns);
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
                return Ok(new { columName, resCount });

            var resPage = resQry.Skip(pageSize * (form.Page - 1)).Take(pageSize).ToList();

            return Ok(new { columName, resPage, resCount });

        }
    }
}
