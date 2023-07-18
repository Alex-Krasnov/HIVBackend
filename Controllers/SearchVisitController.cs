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
    public class SearchVisitController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchVisitController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchVisit outModel = new();

            outModel.ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListInfectCourse = _context.TblInfectCourses
                .Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210)
                .Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col { Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            outModel.ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            outModel.ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };
            outModel.ListRegionPreset = new() { "Все", "Московская обл.", "Иногородние", "Иностранные" };

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchVisitForm form)
        {
            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchVisitForm).GetProperties())
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

                    if (key.Name == "selectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        activeColumns.Add("UfsinDate");
                    }

                    if (key.Name == "selectFr")
                    {
                        columName.Add("Внесено в ФР");
                        activeColumns.Add("FlgZamMedPart");
                        columName.Add("Зав АПО");
                        activeColumns.Add("FlgHeadPhysician");
                    }

                    if (key.Name == "selectRegDate")
                    {
                        columName.Add("Дата записи");
                        activeColumns.Add("RegDate");
                    }

                    if (key.Name == "selectCheckDate")
                    {
                        columName.Add("Дата приема на выезде");
                        activeColumns.Add("CheckDate");
                    }

                    if (key.Name == "selectDoctor")
                    {
                        columName.Add("Специалист");
                        activeColumns.Add("DoctorLong");
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

                    if (key.Name == "selectRegCheck")
                    {
                        columName.Add("Явка");
                        activeColumns.Add("RegCheck");
                    }
                }
            }


            var qryWhere = _context.QrySearchVisits.Where(e =>
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
                        (form.ufsinYNA == "Да" ? e.UfsinDate != null : true) &&
                        (form.ufsinYNA == "Нет" ? e.UfsinDate == null : true) &&
                        (form.dateUfsinStart.Length != 0 ? e.UfsinDate >= DateOnly.Parse(form.dateUfsinStart) : true) &&
                        (form.dateUfsinEnd.Length != 0 ? e.UfsinDate <= DateOnly.Parse(form.dateUfsinEnd) : true) &&
                        (form.frYNA == "Да" ? e.FlgZamMedPart == true : true) &&
                        (form.frYNA == "Нет" ? (e.FlgZamMedPart == false || e.FlgZamMedPart == null) : true) &&
                        (form.zavApoYNA == "Да" ? e.FlgHeadPhysician == true : true) &&
                        (form.zavApoYNA == "Нет" ? (e.FlgHeadPhysician == false || e.FlgHeadPhysician == null) : true) &&
                        (form.regDateStart.Length != 0 ? e.RegDate >= DateOnly.Parse(form.regDateStart) : true) &&
                        (form.regDateEnd.Length != 0 ? e.RegDate <= DateOnly.Parse(form.regDateEnd) : true) &&
                        (form.checkDateStart.Length != 0 ? e.CheckDate >= DateOnly.Parse(form.checkDateStart) : true) &&
                        (form.checkDateEnd.Length != 0 ? e.CheckDate <= DateOnly.Parse(form.checkDateEnd) : true) &&
                        (form.doctor[0] != "Все" ? form.doctor.Contains(e.DoctorLong) : true) &&
                        (form.cardNo.Length != 0 ? e.CardNo.ToLower().StartsWith(form.cardNo.ToLower()) : true) &&
                        (form.art[0] != "Все" ? form.art.Contains(e.ArvtLong) : true) &&
                        (form.regCheck == "Да" ? e.RegCheck == true : true) &&
                        (form.regCheck == "Нет" ? e.RegCheck == false : true)
                            );

            var lambda = new CreateLambda<QrySearchVisit>().CreateLambdaSelect(activeColumns);
            var selected = qryWhere.Select(lambda);
            var resQry = selected.GroupBy(item => item, new DictionaryEqualityComparer()).Select(e => e.First()).ToList();
            int resCount = resQry.Count();

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
