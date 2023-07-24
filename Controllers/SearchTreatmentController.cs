using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchTreatmentController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchTreatmentController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchTreatment outModel = new();

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
            outModel.ListSchema = _context.TblCureSchemas.Select(e => e.CureSchemaLong).OrderBy(e => e).ToList();
            outModel.ListDiePreset = new() { "Все", "ВИЧ", "Не связанные с ВИЧ", "СПИД" };
            outModel.ListInvalid = _context.TblInvalids.Select(e => e.InvalidLong).OrderBy(e => e).ToList();
            outModel.ListCorrespIllness = _context.TblCorrespIllnesses.Select(e => e.CorrespIllnessLong).OrderBy(e => e).ToList();
            outModel.ListSchemaMedecine = _context.TblMedicineForSchemas.Select(e => e.MedforschemaLong).OrderBy(e => e).ToList();
            outModel.ListMedecine = _context.TblMedicines.Select(e => e.MedicineLong).OrderBy(e => e).ToList();
            outModel.ListDoctor = _context.TblDoctors.Select(e => e.DoctorLong).OrderBy(e => e).ToList();
            outModel.ListSchemaChange = _context.TblCureChanges.Select(e => e.CureChangeLong).OrderBy(e => e).ToList();
            outModel.ListFinSourse = _context.TblFinSources.Select(e => e.FinSourceLong).OrderBy(e => e).ToList();
            outModel.ListRangeTherapy = _context.TblRangeTherapies.Select(e => e.RangeTherapyLong).OrderBy(e => e).ToList();
            outModel.ListDieCourse = _context.TblTempDieCureMkb10lists.Select(e => e.DieCourseLong).OrderBy(e => e).ToList();
            outModel.ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();
            outModel.ListSelectBlot = new() { "Все", "Первый", "Последний", "Перв.и посл." };

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchTreatmentForm form)
        {
            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchTreatmentForm).GetProperties())
            {
                if (key.Name.StartsWith("select") && (Boolean)key.GetValue(form) == true)
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

                    if (key.Name == "selectInvalid")
                    {
                        columName.Add("Группа инвалидности");
                        activeColumns.Add("InvalidLong");
                    }

                    if (key.Name == "selectCorrespIllnesses")
                    {
                        columName.Add("Сопутствующее заболевание");
                        activeColumns.Add("CorrespIllnessLong");
                        columName.Add("Сопутствующее заболевание дата");
                        activeColumns.Add("CorrespIllnessDate");
                    }

                    if (key.Name == "selectSchema")
                    {
                        columName.Add("Схема лечения");
                        activeColumns.Add("CureSchemaLong");
                    }

                    if (key.Name == "selectSchemaMedecine")
                    {
                        columName.Add("Схема лечения (препарат)");
                        activeColumns.Add("MedforschemaLong");
                    }

                    if (key.Name == "selectMedecine")
                    {
                        columName.Add("Препарат прописанный");
                        activeColumns.Add("MedicineLong");
                    }

                    if (key.Name == "selectMedecineGive")
                    {
                        columName.Add("Препарат выданный");
                        activeColumns.Add("GiveMedicineLong");
                    }

                    if (key.Name == "selectDoctor")
                    {
                        columName.Add("Персонал");
                        activeColumns.Add("DoctorLong");
                    }

                    if (key.Name == "selectGiveDate")
                    {
                        columName.Add("Дата выдачи препарата");
                        activeColumns.Add("GiveDate");
                    }

                    if (key.Name == "selectSchemaChange")
                    {
                        columName.Add("Причина смены схемы леч.");
                        activeColumns.Add("CureChangeLong");
                    }

                    if (key.Name == "selectCardNo")
                    {
                        columName.Add("№ карты");
                        activeColumns.Add("CardNo");
                    }

                    if (key.Name == "selectSchemaDate")
                    {
                        columName.Add("Дата назн.схемы");
                        activeColumns.Add("SchemaStartDate");
                    }

                    if (key.Name == "selectFinSource")
                    {
                        columName.Add("Источник финансирования");
                        activeColumns.Add("FinSourceLong");
                    }

                    if (key.Name == "selectArt")
                    {
                        columName.Add("АРТ");
                        activeColumns.Add("ArvtLong");
                    }

                    if (key.Name == "selectRangeTherapy")
                    {
                        columName.Add("Ряд терапии");
                        activeColumns.Add("RangeTherapyLong");
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

                    if (key.Name == "selectImRes")
                    {
                        columName.Add("CD4+(abc)");
                        activeColumns.Add("ImResult");
                    }
                }
            }

            int ResVlStart, ResVlEnd, ResImStart, ResImEnd;
            bool IsVlStart = int.TryParse(form.resVlStart, out ResVlStart),
            IsVlEnd = int.TryParse(form.resVlEnd, out ResVlEnd),
            IsImStart = int.TryParse(form.resImStart, out ResImStart),
            IsImEnd = int.TryParse(form.resImEnd, out ResImEnd);

            var qryWhere = _context.QrySearchTreatments.Where(e =>
                        (form.dateInpStart.Length != 0 ? e.InputDate >= DateOnly.Parse(form.dateInpStart) : true) &&
                        (form.dateInpEnd.Length != 0 ? e.InputDate <= DateOnly.Parse(form.dateInpEnd) : true) &&
                        (form.patientId.Length != 0 ? e.PatientId == int.Parse(form.patientId) : true) &&
                        (form.familyName.Length != 0 ? e.FamilyName.ToLower().StartsWith(form.familyName.ToLower()) : true) &&
                        (form.firstName.Length != 0 ? e.FirstName.ToLower().StartsWith(form.firstName.ToLower()) : true) &&
                        (form.thirdName.Length != 0 ? e.ThirdName.ToLower().StartsWith(form.thirdName.ToLower()) : true) &&
                        (form.sex.Length != 0 ? e.SexShort == form.sex : true) &&
                        (form.birthDateStart.Length != 0 ? e.BirthDate >= DateOnly.Parse(form.birthDateStart) : true) &&
                        (form.birthDateEnd.Length != 0 ? e.BirthDate <= DateOnly.Parse(form.birthDateEnd) : true) &&
                        (form.regionFact[0] != "Все" ? form.regionFact.Contains(e.RegionLong) : true) &&
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
                        (form.diePreset == "ВИЧ" ? (e.DethtypeId == 1 || e.DethtypeId == 3) : true) &&
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
                        (form.frYNA == "Нет" ? (e.FlgZamMedPart == false || e.FlgZamMedPart == null) : true) &&
                        (form.zavApoYNA == "Да" ? e.FlgHeadPhysician == true : true) &&
                        (form.zavApoYNA == "Нет" ? (e.FlgHeadPhysician == false || e.FlgHeadPhysician == null) : true) &&
                        (form.ibRes.Length != 0 ? e.IbResultShort == form.ibRes : true) &&
                        (form.dateIbResStart.Length != 0 ? e.BlotDate >= DateOnly.Parse(form.dateIbResStart) : true) &&
                        (form.dateIbResEnd.Length != 0 ? e.BlotDate <= DateOnly.Parse(form.dateIbResEnd) : true) &&
                        (form.ibNum.Length != 0 ? e.BlotNo == int.Parse(form.ibNum) : true) &&
                        (form.dateInpIbStart.Length != 0 ? e.Datetime1 >= DateOnly.Parse(form.dateInpIbStart) : true) &&
                        (form.dateInpIbEnd.Length != 0 ? e.Datetime1 <= DateOnly.Parse(form.dateInpIbEnd) : true) &&
                        (form.ibSelect == "Первый" ? e.First1 == true : true) &&
                        (form.ibSelect == "Последний" ? e.Last1 == true : true) &&
                        (form.ibSelect == "Перв.и посл." ? (e.Last1 == true || e.First1 == true) : true) &&
                        (form.ufsinYNA == "Да" ? e.UfsinDate != null : true) &&
                        (form.ufsinYNA == "Нет" ? e.UfsinDate == null : true) &&
                        (form.dateUfsinStart.Length != 0 ? e.UfsinDate >= DateOnly.Parse(form.dateUfsinStart) : true) &&
                        (form.dateUfsinEnd.Length != 0 ? e.UfsinDate <= DateOnly.Parse(form.dateUfsinEnd) : true) &&
                        (form.invalid[0] != "Все" ? form.invalid.Contains(e.InvalidLong) : true) &&
                        (form.correspIllnesses[0] != "Все" ? form.correspIllnesses.Contains(e.CorrespIllnessLong) : true) &&
                        (form.dateCorrespIllnessesStart.Length != 0 ? e.CorrespIllnessDate >= DateOnly.Parse(form.dateCorrespIllnessesStart) : true) &&
                        (form.dateCorrespIllnessesEnd.Length != 0 ? e.CorrespIllnessDate <= DateOnly.Parse(form.dateCorrespIllnessesEnd) : true) &&
                        (form.schema[0] != "Все" ? form.schema.Contains(e.CureSchemaLong) : true) &&
                        (form.schemaLast == true ? e.SchemaLast == true : true) &&
                        (form.schemaMedecine[0] != "Все" ? form.schemaMedecine.Contains(e.MedforschemaLong) : true) &&
                        (form.medecine[0] != "Все" ? form.medecine.Contains(e.MedicineLong) : true) &&
                        (form.medecineGive[0] != "Все" ? form.medecineGive.Contains(e.GiveMedicineLong) : true) &&
                        (form.doctor[0] != "Все" ? form.doctor.Contains(e.DoctorLong) : true) &&
                        (form.dateDieStart.Length != 0 ? e.GiveDate >= DateOnly.Parse(form.dateDieStart) : true) &&
                        (form.dateGiveEnd.Length != 0 ? e.GiveDate <= DateOnly.Parse(form.dateGiveEnd) : true) &&
                        (form.schemaChange[0] != "Все" ? form.schemaChange.Contains(e.CureChangeLong) : true) &&
                        (form.cardNo.Length != 0 ? e.CardNo.ToLower().StartsWith(form.cardNo.ToLower()) : true) &&
                        (form.dateSchemaStart.Length != 0 ? e.SchemaStartDate >= DateOnly.Parse(form.dateSchemaStart) : true) &&
                        (form.dateSchemaEnd.Length != 0 ? e.SchemaStartDate <= DateOnly.Parse(form.dateSchemaEnd) : true) &&
                        (form.finSource[0] != "Все" ? form.finSource.Contains(e.FinSourceLong) : true) &&
                        (form.art[0] != "Все" ? form.art.Contains(e.ArvtLong) : true) &&
                        (form.rangeTherapy[0] != "Все" ? form.rangeTherapy.Contains(e.RangeTherapyLong) : true) &&
                        (form.dateVlStart.Length != 0 ? e.VlDate >= DateOnly.Parse(form.dateVlStart) : true) &&
                        (form.dateVlEnd.Length != 0 ? e.VlDate <= DateOnly.Parse(form.dateVlEnd) : true) &&
                        (form.resVlStart.Length != 0 && IsVlStart ? e.VlResult >= ResVlStart : true) &&
                        (form.resVlEnd.Length != 0 && IsVlEnd ? e.VlResult <= ResVlEnd : true) &&
                        (form.dateIMStart.Length != 0 ? e.ImDate >= DateOnly.Parse(form.dateIMStart) : true) &&
                        (form.dateImEnd.Length != 0 ? e.ImDate <= DateOnly.Parse(form.dateImEnd) : true) &&
                        (form.resImStart.Length != 0 && IsImStart ? e.ImResult >= ResImStart : true) &&
                        (form.resImEnd.Length != 0 && IsImEnd ? e.ImResult <= ResImEnd : true)
                            );

            var lambda = new CreateLambda<QrySearchTreatment>().CreateLambdaSelect(activeColumns);
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
