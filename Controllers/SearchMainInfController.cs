using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using HIVBackend.Services;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchMainInfController : ControllerBase
    {

        private readonly HivContext _context;
        public SearchMainInfController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            SearchMainInf outModel = new ();

            outModel.ListSex = _context.TblSexes.Select(e => e.SexShort).OrderBy(e => e).ToList();
            outModel.ListRegion = _context.TblRegions.Select(e => e.RegionLong).OrderBy(e => e).ToList();
            outModel.ListCountry = _context.TblCountries.Select(e => e.CountryLong).OrderBy(e => e).ToList();
            outModel.ListInfectCourse = _context.TblInfectCourses
                .Where(e => e.InfectCourseId == 201 || e.InfectCourseId == 203 || e.InfectCourseId == 210)
                .Select(e => e.InfectCourseLong).OrderBy(e => e).ToList();
            outModel.ListCheckPlace = _context.TblCheckPlaces.Select(e => e.CheckPlaceLong).OrderBy(e => e).ToList();
            outModel.ListStage = _context.TblDiagnoses.Select(e => e.DiagnosisLong).OrderBy(e => e).ToList();
            outModel.ListCheckCourse = _context.TblCheckCourses.Select(e => new Selector2Col {Short = e.CheckCourseShort, Long = e.CheckCourseLong }).OrderBy(e => e.Short).ToList();
            outModel.ListDieCourse = _context.TblTempDieCureMkb10lists.Select(e => e.DieCourseLong).OrderBy(e => e).ToList();
            outModel.ListShowIllness = _context.TblShowIllnesses.Select(e => e.ShowIllnessLong).OrderBy(e => e).ToList();
            outModel.ListResIb = _context.TblIbResults.Select(e => e.IbResultShort).OrderBy(e => e).ToList();
            outModel.ListSelectBlot = new() { "Все", "Первый", "Последний", "Перв.и посл." };
            outModel.ListHospCourse = _context.TblHospCourses.Select(e => e.HospCourseLong).OrderBy(e => e).ToList();
            outModel.ListAge = _context.TblAgegrs.Select(e => e.AgegrLong).ToList();
            outModel.ListArvt = _context.TblArvts.Select(e => e.ArvtLong).OrderBy(e => e).ToList();
            outModel.ListCodeMKB10 = _context.TblCodeMkb10s.Select(e => e.CodeMkb10Long).OrderBy(e => e).ToList();
            outModel.ListYN = _context.TblListYns.Select(e => e.YNName).OrderBy(e => e).ToList();
            outModel.ListYNA = new() { "Да", "Нет", "Все" };
            outModel.ListAids12 = _context.TblAids12s.Select(e => e.Aids12Long).OrderBy(e => e).ToList();
            outModel.ListChemop = _context.TblChemops.Select(e => e.ChemopLong).OrderBy(e => e).ToList();
            outModel.ListDiePreset = new() { "Все", "ВИЧ", "Не связанные с ВИЧ", "СПИД" };
            outModel.ListRegionPreset = new() { "Все", "Московская обл.", "Иногородние", "Иностранные" };

            return Ok(outModel);
        }

        [HttpPost, Route("GetRes")]
        [Authorize(Roles = "User")]
        public IActionResult GetRes(SearchMainInfForm form)
        {
            int pageSize = 100;
            List<string> columName = new() {"Ид пациента"};

            List<string> activeColumns = new() { "PatientId" };

            foreach (var key in typeof(SearchMainInfForm).GetProperties())
            {
                if (key.Name.StartsWith("select") && (Boolean)key.GetValue(form) == true)
                {
                    if(key.Name == "selectInpDate")
                    {
                        columName.Add("Дата ввода");
                        activeColumns.Add("InputDate");
                    }

                    if (key.Name == "selectPatientId")
                    {
                        columName.Add("СНИЛС");
                        activeColumns.Add("Snils");
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

                    if (key.Name == "selectBlotCheckPlace")
                    {
                        columName.Add("Место лаб. исследования");
                        activeColumns.Add("CheckPlaceLong");
                    }

                    if (key.Name == "selectStage")
                    {
                        columName.Add("Стадия");
                        activeColumns.Add("DiagnosisLong");
                        columName.Add("Дата постановки стадии");
                        activeColumns.Add("DiagnosisDefDate");
                    }

                    if (key.Name == "selectDieDate")
                    {
                        columName.Add("Дата смерти");
                        activeColumns.Add("DieDate");
                        columName.Add("Дата смерти от СПИДа");
                        activeColumns.Add("DieAidsDate");
                        columName.Add("Дата ввода смерти");
                        activeColumns.Add("DieDateInput");
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
                        //columName.Add("Непосредственная причина смерти");
                        //columName.Add("МКБ непосредственная причина смерти");
                        //columName.Add("Состояния приведшие к смерти");
                        //columName.Add("МКБ состояния приведшие к смерти");
                        //columName.Add("Первоночальная причина смерти");
                        //columName.Add("МКБ первоночальная причина смерти");
                        //columName.Add("Внешняя причина смерти");
                        //columName.Add("МКБ внешняя причина смерти");
                        //columName.Add("Прочие состояния способствовавшие смерти");
                        //columName.Add("МКБ пр состояния");
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

                    if (key.Name == "selectAge")
                    {
                        columName.Add("Возраст");

                        activeColumns.Add("Age");
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

                    if (key.Name == "selectMkb10")
                    {
                        columName.Add("Код МКБ10");
                        activeColumns.Add("CodeMkb10Long");
                    }

                    if (key.Name == "selectArchive")
                    {
                        columName.Add("Архив");
                        activeColumns.Add("Archive");
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

                    if (key.Name == "selectTransfFeder")
                    {
                        columName.Add("Дата передачи в субъект федерации");
                        activeColumns.Add("TransfFederDate");
                    }

                    if (key.Name == "selectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        activeColumns.Add("UfsinDate");
                    }

                    if (key.Name == "selectAids12")
                    {
                        columName.Add("Вич 1 2");
                        activeColumns.Add("Aids12Long");
                    }

                    if (key.Name == "selectUnrz")
                    {
                        columName.Add("УНРЗ");
                        activeColumns.Add("UnrzFr");
                    }

                    if (key.Name == "selectChemprof")
                    {
                        columName.Add("Химиопрофилактика");
                        activeColumns.Add("ChemopLong");
                        columName.Add("Химиопрофилактика с");
                        activeColumns.Add("ChemopDateFrom");
                        columName.Add("Химиопрофилактика по");
                        activeColumns.Add("ChemopDateTo");
                    }

                    if (key.Name == "selectDateReg")
                    {
                        columName.Add("Дата регистрации нач");
                        activeColumns.Add("DtRegBeg");
                        columName.Add("Дата регистрации кон");
                        activeColumns.Add("DtRegEnd");
                    }

                    if (key.Name == "selectPasSer")
                    {
                        columName.Add("Паспорт серия");
                        activeColumns.Add("PasSer");
                    }

                    if (key.Name == "selectPasNum")
                    {
                        columName.Add("Паспорт номер");
                        activeColumns.Add("PasNum");
                    }

                    if (key.Name == "selectPasWhom")
                    {
                        columName.Add("Паспорт выдан");
                        activeColumns.Add("PasWhen");
                    }

                    if (key.Name == "selectPasWhen")
                    {
                        columName.Add("Паспорт Дата выдачи");
                        activeColumns.Add("PasWhom");
                    }
                }
            }

            List<string> ages = new();

            if (form.age.Contains("0 - 1"))
            {
                ages.Add("0");
                ages.Add("1");
            }
            if (form.age.Contains("1 - 2"))
            {
                ages.Add("1");
                ages.Add("2");
            }
            if (form.age.Contains("3 - 4"))
            {
                ages.Add("3");
                ages.Add("4");
            }

            if (form.age.Contains("5 - 9"))
                for(int i = 5;i <= 9; i++)
                    ages.Add($"{i}");

            if (form.age.Contains("10 - 14"))
                for (int i = 10; i <= 14; i++)
                    ages.Add($"{i}");

            if (form.age.Contains("15 - 17"))
                for (int i = 15; i <= 17; i++)
                    ages.Add($"{i}");

            if (form.age.Contains("18 - 24"))
                for (int i = 18; i <= 24; i++)
                    ages.Add($"{i}");

            if (form.age.Contains("25 - 34"))
                for (int i = 25; i <= 34; i++)
                    ages.Add($"{i}");

            if (form.age.Contains("35 - 44"))
                for (int i = 35; i <= 44; i++)
                    ages.Add($"{i}");

            if (form.age.Contains("45 - 49"))
                for (int i = 45; i <= 49; i++)
                    ages.Add($"{i}");

            if (form.age.Contains("50 - 59"))
                for (int i = 50; i <= 59; i++)
                    ages.Add($"{i}");

            var qryWhere = _context.QrySearchMainInfs.Where(e =>
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
                        (form.regionFact[0] != "Все" ? form.regionFact.Contains(e.RegionLong) : true) &&
                        (form.regionReg[0] != "Все" ? form.regionReg.Contains(e.RegionLong) : true) &&
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
                        (form.blotCheckPlace[0] != "Все" ? form.blotCheckPlace.Contains(e.CheckPlaceLong) : true) &&
                        (form.stage[0] != "Все" ? form.stage.Contains(e.DiagnosisLong) : true) &&
                        (form.dateDieStart.Length != 0 ? e.DieDate >= DateOnly.Parse(form.dateDieStart) : true) &&
                        (form.dateDieEnd.Length != 0 ? e.DieDate <= DateOnly.Parse(form.dateDieEnd) : true) &&
                        (form.dateDieAidsStart.Length != 0 ? e.DieAidsDate >= DateOnly.Parse(form.dateDieAidsStart) : true) &&
                        (form.dateDieAidsEnd.Length != 0 ? e.DieAidsDate <= DateOnly.Parse(form.dateDieAidsEnd) : true) &&
                        (form.checkCourse[0] != "Все" ? form.checkCourse.Contains(e.CheckCourseLong) : true) &&
                        (form.dieCourse[0] != "Все" ? form.dieCourse.Contains(e.DieCourseLong) : true) &&
                        (form.diePreset == "ВИЧ" ? (e.DethtypeId == 1 || e.DethtypeId == 3) : true) &&
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
                        (form.ibSelect == "Перв.и посл." ? (e.Last1 == true || e.First1 == true) : true) &&
                        (form.hospCourse[0] != "Все" ? form.hospCourse.Contains(e.ShowIllnessLong) : true) &&
                        (form.age[0] != "Все" && form.age.Contains("> 60") != true ? (ages.Contains(e.Age.ToString())) : true) &&
                        (form.age[0] != "Все" && form.age.Contains("> 60") ? ( ages.Contains(e.Age.ToString()) || e.Age >= 60) : true) &&
                        (form.cardNo.Length != 0 ? e.CardNo.ToLower().StartsWith(form.cardNo.ToLower()) : true) &&
                        (form.art[0] != "Все" ? form.art.Contains(e.ArvtLong) : true) &&
                        (form.mkb10[0] != "Все" ? form.mkb10.Contains(e.CodeMkb10Long) : true) &&
                        (form.archiveYNA == "Да" ? (e.Archive != null || e.Archive.Length != 0) : true) &&
                        (form.archiveYNA == "Нет" ? (e.Archive == null || e.Archive.Length == 0) : true) &&
                        (form.transfAreaYNA == "Да" ? e.TransfAreaDate != null : true) &&
                        (form.transfAreaYNA == "Нет" ? e.TransfAreaDate == null : true) &&
                        (form.dateTransfAreaStart.Length != 0 ? e.TransfAreaDate >= DateOnly.Parse(form.dateTransfAreaStart) : true) &&
                        (form.dateTransfAreaEnd.Length != 0 ? e.TransfAreaDate <= DateOnly.Parse(form.dateTransfAreaEnd) : true) &&
                        (form.frYNA == "Да" ? e.FlgZamMedPart == true : true) &&
                        (form.frYNA == "Нет" ? (e.FlgZamMedPart == false || e.FlgZamMedPart == null) : true) &&
                        (form.zavApoYNA == "Да" ? e.FlgHeadPhysician == true : true) &&
                        (form.zavApoYNA == "Нет" ? (e.FlgHeadPhysician == false || e.FlgHeadPhysician == null) : true) &&
                        (form.transfFederYNA == "Да" ? e.TransfFederDate != null : true) &&
                        (form.transfFederYNA == "Нет" ? e.TransfFederDate == null : true) &&
                        (form.dateTransfFederStart.Length != 0 ? e.TransfFederDate >= DateOnly.Parse(form.dateTransfFederStart) : true) &&
                        (form.dateTransfFederEnd.Length != 0 ? e.TransfFederDate <= DateOnly.Parse(form.dateTransfFederEnd) : true) &&
                        (form.ufsinYNA == "Да" ? e.UfsinDate != null : true) &&
                        (form.ufsinYNA == "Нет" ? e.UfsinDate == null : true) &&
                        (form.dateUfsinStart.Length != 0 ? e.UfsinDate >= DateOnly.Parse(form.dateUfsinStart) : true) &&
                        (form.dateUfsinEnd.Length != 0 ? e.UfsinDate <= DateOnly.Parse(form.dateUfsinEnd) : true) &&
                        (form.aids12.Length != 0 ? e.Aids12Long == form.aids12 : true) &&
                        (form.unrzYNA == "Да" ? (e.UnrzFr != null || e.UnrzFr.Length != 0) : true) &&
                        (form.unrzYNA == "Нет" ? e.UnrzFr == null : true) &&
                        (form.unrz.Length != 0 ? e.UnrzFr.ToLower().StartsWith(form.unrz.ToLower()) : true) &&
                        (form.chemprof.Length != 0 ? e.ChemopLong == form.chemprof : true) &&
                        (form.dateChemprofStartStart.Length != 0 ? e.ChemopDateFrom >= DateOnly.Parse(form.dateChemprofStartStart) : true) &&
                        (form.dateChemprofStartEnd.Length != 0 ? e.ChemopDateFrom <= DateOnly.Parse(form.dateChemprofStartEnd) : true) &&
                        (form.dateChemprofEndStart.Length != 0 ? e.ChemopDateTo >= DateOnly.Parse(form.dateChemprofEndStart) : true) &&
                        (form.dateChemprofEndEnd.Length != 0 ? e.ChemopDateTo <= DateOnly.Parse(form.dateChemprofEndEnd) : true) &&
                        (form.dateRegStart.Length != 0 ? e.DtRegEnd >= DateOnly.Parse(form.dateRegStart) : true) &&
                        (form.dateRegEnd.Length != 0 ? e.DtRegEnd <= DateOnly.Parse(form.dateRegEnd) : true) &&
                        (form.regionPreset == "Московская обл." ? e.RegtypeId == 1 : true) &&
                        (form.regionPreset == "Иногородние" ? e.RegtypeId == 2 : true) &&
                        (form.regionPreset == "Иностранные" ? e.RegtypeId == 3 : true) &&
                        (form.factRegionPreset == "Московская обл." ? e.FactRegtypeId == 1 : true) &&
                        (form.factRegionPreset == "Иногородние" ? e.FactRegtypeId == 2 : true) &&
                        (form.factRegionPreset == "Иностранные" ? e.FactRegtypeId == 3 : true)
                            );

            var lambda = new CreateLambda<QrySearchMainInf>().CreateLambdaSelect(activeColumns);
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