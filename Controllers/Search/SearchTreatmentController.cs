using DocumentFormat.OpenXml.Presentation;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using HIVBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace HIVBackend.Controllers.Search
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

            #region базовые переменые 

            int pageSize = 100;
            List<string> columName = new() { "Ид пациента" };
            StringBuilder selectGroupSrt = new();
            StringBuilder joinStr = new();
            StringBuilder whereStr = new();
            selectGroupSrt.Append("\"tblPatientCard\".patient_id");
            joinStr.Append(" FROM \"tblPatientCard\"");
            whereStr.Append("WHERE true");

            #endregion

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchTreatmentForm).GetProperties().Where(e => e.Name.StartsWith("select")))
            {
                if ((bool)key.GetValue(form) == true)
                {
                    if (key.Name == "selectInpDate")
                    {
                        columName.Add("Дата ввода");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".input_date");
                    }

                    if (key.Name == "selectFio")
                    {
                        columName.Add("Фамилия");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".family_name");
                        columName.Add("Имя");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".first_name");
                        columName.Add("Отчество");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".third_name");
                    }

                    if (key.Name == "selectSex")
                    {
                        columName.Add("Пол");
                        selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectBirthDate")
                    {
                        columName.Add("Дата рождения");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".birth_date");
                    }

                    if (key.Name == "selectRegion")
                    {
                        columName.Add("Регион");
                        selectGroupSrt.AppendLine(",\"tblRegion\".region_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectRegionFact")
                    {
                        columName.Add("Регион (факт.)");
                        selectGroupSrt.AppendLine(",\"tblRegionFact\".region_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard", alias: "tblRegionFact");
                    }

                    if (key.Name == "selectCountry")
                    {
                        columName.Add("Страна");
                        selectGroupSrt.AppendLine(",\"tblCountry\".country_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectAddr")
                    {
                        columName.Add("Город");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".city_name");
                        columName.Add("Населённый пункт");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".location_name");
                        columName.Add("Индекс");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_ind");
                        columName.Add("Улица");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_street");
                        columName.Add("Дом");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_house");
                        columName.Add("Корпус");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_ext");
                        columName.Add("Квартира");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_flat");
                    }

                    if (key.Name == "selectRegOnDate")
                    {
                        columName.Add("Дата постановки на учет");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".reg_on_date");
                        columName.Add("Дата снятия с учета");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".reg_off_date");
                        columName.Add("Причина снятия с учета");
                        selectGroupSrt.AppendLine(",\"regOff\".infect_course_long");
                        joinStr.AddLeftJoinIfNotExistDiffField(
                            joinTable: "tblInfectCourse", 
                            fieldLeft: "reg_off_reason",
                            fieldRight: "infect_course_id", 
                            table: "tblPatientCard", 
                            alias: "regOff");
                    }

                    if (key.Name == "selectStage")
                    {
                        columName.Add("Стадия");
                        selectGroupSrt.AppendLine(",stage.diagnosis_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
                    }

                    if (key.Name == "selectDieDate")
                    {
                        columName.Add("Дата смерти");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".die_date");
                        columName.Add("Дата смерти от СПИДа");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".die_aids_date");
                    }

                    if (key.Name == "selectDieCourse")
                    {
                        columName.Add("Причина смерти");
                        selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_long");
                        columName.Add("МКБ причина смерти");
                        selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_short");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectCheckCourse")
                    {
                        columName.Add("Причина обращения");
                        selectGroupSrt.AppendLine(",\"tblCheckCourse\".check_course_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectInfectCourse")
                    {
                        columName.Add("Причина заражения");
                        selectGroupSrt.AppendLine(",\"tblInfectCourse\".infect_course_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectShowIllnes")
                    {
                        columName.Add("Индикаторная болезнь");
                        selectGroupSrt.AppendLine(",\"tblShowIllness\".show_illness_long");

                        columName.Add("Дата вторичного заболивания с");
                        selectGroupSrt.AppendLine(",\"tblPatientShowIllness\".start_date");

                        columName.Add("Дата вторичного заболивания по");
                        selectGroupSrt.AppendLine(",\"tblPatientShowIllness\".end_date");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                    }

                    if (key.Name == "selectTransfArea")
                    {
                        columName.Add("Дата передачи в район");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".transf_area_date");
                    }

                    if (key.Name == "selectFr")
                    {
                        columName.Add("Внесено в ФР");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_zam_med_part");
                        columName.Add("Зав АПО");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_head_physician");
                    }

                    if (key.Name == "selectIb")
                    {
                        columName.Add("Результат референс");
                        selectGroupSrt.AppendLine(",\"tblIbResult\".ib_result_short");

                        columName.Add("Дата референс");
                        selectGroupSrt.AppendLine(",\"tblPatientBlot\".blot_date");

                        columName.Add("Номер");
                        selectGroupSrt.AppendLine(",\"tblPatientBlot\".blot_no");

                        columName.Add("Послед");
                        selectGroupSrt.AppendLine(",\"tblPatientBlot\".first1");

                        columName.Add("Дата ввода");
                        selectGroupSrt.AppendLine(",\"tblPatientBlot\".datetime1");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblIbResult", field: "ib_result_id", table: "tblPatientBlot");
                    }

                    if (key.Name == "selectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
                    }

                    if (key.Name == "selectInvalid")
                    {
                        columName.Add("Группа инвалидности");
                        selectGroupSrt.AppendLine(",\"tblInvalid\".invalid_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectCorrespIllnesses")
                    {
                        columName.Add("Сопутствующее заболевание");
                        selectGroupSrt.AppendLine(",\"tblCorrespIllness\".corresp_illness_long");

                        columName.Add("Сопутствующее заболевание дата");
                        selectGroupSrt.AppendLine(",\"tblPatientCorrespIllness\".datetime1");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
                    }

                    if (key.Name == "selectSchemaDate")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Дата назн.схемы");
                        selectGroupSrt.AppendLine(",\"tblPatientCureSchema\".start_date");
                    }

                    if (key.Name == "selectSchema")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Схема лечения");
                        selectGroupSrt.AppendLine(",\"tblCureSchema\".cure_schema_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                    }

                    if (key.Name == "selectSchemaMedecine")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Схема лечения (препарат)");
                        selectGroupSrt.AppendLine(",\"tblMedicineForSchema\".medforschema_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR", field: "cure_schema_id", table: "tblPatientCureSchema");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                               fieldLeft: "medicine_id",
                                                               fieldRight: "medforschema_id",
                                                               table: "tblSchemaMedicineR");
                    }

                    if (key.Name == "selectGiveDate")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Дата выдачи препарата");
                        selectGroupSrt.AppendLine(",\"tblPatientPrescrM\".give_date");
                    }

                    if (key.Name == "selectDoctor")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Персонал");
                        selectGroupSrt.AppendLine(",\"tblDoctor\".doctor_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
                    }

                    if (key.Name == "selectMedecine")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Препарат прописанный");
                        selectGroupSrt.AppendLine(",\"tblMedicine\".medicine_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                    }

                    if (key.Name == "selectMedecineGive")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Препарат выданный");
                        selectGroupSrt.AppendLine(",\"tblGiveMedicine\".medicine_long");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicine", 
                                                               fieldLeft: "give_med_id",
                                                               fieldRight: "medicine_id", 
                                                               table: "tblPatientPrescrM",
                                                               alias: "tblGiveMedicine");
                    }

                    if (key.Name == "selectSchemaChange")
                    {
                        columName.Add("Причина смены схемы леч.");
                        selectGroupSrt.AppendLine(",\"tblCureChange\".cure_change_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                    }

                    if (key.Name == "selectCardNo")
                    {
                        columName.Add("№ карты");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".card_no");
                    }

                    if (key.Name == "selectArt")
                    {
                        columName.Add("АРТ");
                        selectGroupSrt.AppendLine(",\"tblArvt\".arvt_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectRangeTherapy")
                    {
                        columName.Add("Ряд терапии");
                        selectGroupSrt.AppendLine(",\"tblRangeTherapy\".range_therapy_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
                    }

                    #region Добавление результаток исследований TODO
                    if (key.Name == "selectVlDate")
                    {
                        columName.Add("Дата опред.вир.нагр.");
                        selectGroupSrt.AppendLine(",\"vn\".acl_sample_date");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);

                    }

                    if (key.Name == "selectVlRes")
                    {
                        columName.Add("Вирусн.нагр.");
                        selectGroupSrt.AppendLine(",\"vn\".acl_result");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);
                    }

                    if (key.Name == "selectImDate")
                    {
                        columName.Add("Дата опред.иммун.стат.");
                        selectGroupSrt.AppendLine(",\"im\".acl_sample_date");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);
                    }

                    if (key.Name == "selectImRes")
                    {
                        columName.Add("CD4+(abc)");
                        selectGroupSrt.AppendLine(",\"im\".acl_result");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);
                    }
                    #endregion
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (form.patientId.Length != 0)
                whereStr.AddWhereSqlEqual("\"tblPatientCard\".patient_id", form.patientId);

            if (form.dateInpStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".input_date", DateOnly.Parse(form.dateInpStart).ToString("dd-MM-yyyy"));

            if (form.dateInpEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".input_date", DateOnly.Parse(form.dateInpEnd).ToString("dd-MM-yyyy"));

            if (form.familyName.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".family_name", form.familyName.ToLower());

            if (form.firstName.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".first_name", form.firstName.ToLower());

            if (form.thirdName.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".third_name", form.thirdName.ToLower());

            if (form.sex.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqualString("\"tblSex\".sex_short", form.sex);
            }

            if (form.birthDateStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".birth_date", DateOnly.Parse(form.birthDateStart).ToString("dd-MM-yyyy"));

            if (form.birthDateEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".birth_date", DateOnly.Parse(form.birthDateEnd).ToString("dd-MM-yyyy"));

            if (form.regionReg[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblRegion\".region_long", form.regionReg);
            }

            if (form.regionPreset == "Московская обл.")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", "1");
            }

            if (form.regionPreset == "Иногородние")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", "2");
            }

            if (form.regionPreset == "Иностранные")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", "3");
            }

            if (form.regionFact[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard", alias: "tblRegionFact");
                whereStr.AddWhereSqlIn("\"tblRegionFact\".region_long", form.regionFact);
            }

            if (form.factRegionPreset == "Московская обл.")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard", alias: "tblRegionFact");
                whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", "1");
            }

            if (form.factRegionPreset == "Иногородние")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard", alias: "tblRegionFact");
                whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", "2");
            }

            if (form.factRegionPreset == "Иностранные")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard", alias: "tblRegionFact");
                whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", "3");
            }

            if (form.country[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblCountry\".country_long", form.country);
            }

            if (form.city.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".city_name", form.city.ToLower());

            if (form.location.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".location_name", form.location.ToLower());

            if (form.indx.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_ind", form.indx.ToLower());

            if (form.street.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_street", form.street.ToLower());

            if (form.home.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_house", form.home.ToLower());

            if (form.dateRegOnStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_on_date", DateOnly.Parse(form.dateRegOnStart).ToString("dd-MM-yyyy"));

            if (form.dateRegOnEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_on_date", DateOnly.Parse(form.dateRegOnEnd).ToString("dd-MM-yyyy"));

            if (form.dateUnRegStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_off_date", DateOnly.Parse(form.dateUnRegStart).ToString("dd-MM-yyyy"));

            if (form.dateUnRegEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_off_date", DateOnly.Parse(form.dateUnRegEnd).ToString("dd-MM-yyyy"));

            if (form.unRegCourse.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExistDiffField(
                    joinTable: "tblInfectCourse",
                    fieldLeft: "reg_off_reason",
                    fieldRight: "infect_course_id",
                    table: "tblPatientCard",
                    alias: "regOff");
                whereStr.AddWhereSqlEqualString("\"regOff\".infect_course_long", form.unRegCourse);
            }

            if (form.stage[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
                whereStr.AddWhereSqlIn("stage.diagnosis_long", form.stage);
            }

            if (form.dateDieStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_date", DateOnly.Parse(form.dateDieStart).ToString("dd-MM-yyyy"));

            if (form.dateDieEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_date", DateOnly.Parse(form.dateDieEnd).ToString("dd-MM-yyyy"));

            if (form.dateDieAidsStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_aids_date", DateOnly.Parse(form.dateDieAidsStart).ToString("dd-MM-yyyy"));

            if (form.dateDieAidsEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_aids_date", DateOnly.Parse(form.dateDieAidsEnd).ToString("dd-MM-yyyy"));

            if (form.dieCourse[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".die_course_long", form.dieCourse);
            }

            if (form.diePreset == "ВИЧ")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.Append($" AND \"tblTempDieCureMKB10List\".\"Dethtype_id\" IN (1,3) ");
            }

            if (form.diePreset == "Не связанные с ВИЧ")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "2");
            }

            if (form.diePreset == "СПИД")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "3");
            }

            if (form.checkCourse[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblCheckCourse\".check_course_long", form.checkCourse);
            }

            if (form.infectCourse[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblInfectCourse\".infect_course_long", form.infectCourse);
            }

            if (form.showIllnes[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                whereStr.AddWhereSqlIn("\"tblShowIllness\".show_illness_long", form.showIllnes);
            }

            if (form.dateShowIllnesStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                whereStr.AddWhereSqlDateMore("\"tblPatientShowIllness\".start_date", DateOnly.Parse(form.dateShowIllnesStart).ToString("dd-MM-yyyy"));
            }

            if (form.dateShowIllnesEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                whereStr.AddWhereSqlDateLess("\"tblPatientShowIllness\".end_date", DateOnly.Parse(form.dateShowIllnesEnd).ToString("dd-MM-yyyy"));
            }

            if (form.transfAreaYNA == "Да")
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".transf_area_date");

            if (form.transfAreaYNA == "Нет")
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".transf_area_date");

            if (form.dateTransfAreaStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".transf_area_date", DateOnly.Parse(form.dateTransfAreaStart).ToString("dd-MM-yyyy"));

            if (form.dateTransfAreaEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".transf_area_date", DateOnly.Parse(form.dateTransfAreaEnd).ToString("dd-MM-yyyy"));

            if (form.frYNA == "Да")
                whereStr.AddWhereSqlTrue("\"tblPatientCard\".flg_zam_med_part");

            if (form.frYNA == "Нет")
                whereStr.AddWhereSqlFalseOrNull("\"tblPatientCard\".flg_zam_med_part");

            if (form.zavApoYNA == "Да")
                whereStr.AddWhereSqlTrue("\"tblPatientCard\".flg_head_physician");

            if (form.zavApoYNA == "Нет")
                whereStr.AddWhereSqlFalseOrNull("\"tblPatientCard\".flg_head_physician");

            if (form.zavApoYNA == "Нет")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblIbResult", field: "ib_result_id", table: "tblPatientBlot");
                whereStr.AddWhereSqlEqualString("\"tblIbResult\".ib_result_short", form.ibRes);
            }

            if (form.dateIbResStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".blot_date", DateOnly.Parse(form.dateIbResStart).ToString("dd-MM-yyyy"));
            }

            if (form.dateIbResEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".blot_date", DateOnly.Parse(form.dateIbResEnd).ToString("dd-MM-yyyy"));
            }

            if (form.ibNum.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblPatientBlot\".blot_no", form.ibNum);
            }

            if (form.dateInpIbStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".datetime1", DateOnly.Parse(form.dateInpIbStart).ToString("dd-MM-yyyy"));
            }

            if (form.dateInpIbEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".datetime1", DateOnly.Parse(form.dateInpIbEnd).ToString("dd-MM-yyyy"));
            }

            if (form.ibSelect == "Первый")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
            }

            if (form.ibSelect == "Последний")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }

            if (form.ibSelect == "Перв.и посл.")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }

            if (form.ufsinYNA == "Да")
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".ufsin_date");

            if (form.ufsinYNA == "Нет")
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".ufsin_date");

            if (form.dateUfsinStart.Length != 0)
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".ufsin_date", DateOnly.Parse(form.dateUfsinStart).ToString("dd-MM-yyyy"));

            if (form.dateUfsinEnd.Length != 0)
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".ufsin_date", DateOnly.Parse(form.dateUfsinEnd).ToString("dd-MM-yyyy"));

            if (form.invalid[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblInvalid\".invalid_long", form.invalid);
            }

            if (form.correspIllnesses[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
                whereStr.AddWhereSqlIn("\"tblCorrespIllness\".corresp_illness_long", form.invalid);
            }

            if (form.dateCorrespIllnessesStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(form.dateCorrespIllnessesStart).ToString("dd-MM-yyyy"));
            }

            if (form.dateCorrespIllnessesEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(form.dateCorrespIllnessesEnd).ToString("dd-MM-yyyy"));
            }

            if (form.schema[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblCureSchema\".cure_schema_long", form.schema);
            }

            if (form.schema[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblCureSchema\".cure_schema_long", form.schema);
            }

            if (form.schemaLast == true)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientCureSchema\".\"lastYN\"");
            }

            if (form.schemaMedecine[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR", field: "cure_schema_id", table: "tblPatientCureSchema");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                       fieldLeft: "medicine_id",
                                                       fieldRight: "medforschema_id",
                                                       table: "tblSchemaMedicineR");
                whereStr.AddWhereSqlIn("\"tblMedicineForSchema\".medforschema_long", form.schemaMedecine);
            }

            if (form.medecine[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                whereStr.AddWhereSqlIn("\"tblMedicine\".medicine_long", form.medecine);
            }

            if (form.medecineGive[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                whereStr.AddWhereSqlIn("\"tblGiveMedicine\".medicine_long", form.medecineGive);
            }

            if (form.doctor[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
                whereStr.AddWhereSqlIn("\"tblDoctor\".doctor_long", form.doctor);
            }

            if (form.dateGiveStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientPrescrM\".give_date", DateOnly.Parse(form.dateGiveStart).ToString("dd-MM-yyyy"));
            }

            if (form.dateGiveEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientPrescrM\".give_date", DateOnly.Parse(form.dateGiveEnd).ToString("dd-MM-yyyy"));
            }

            if (form.schemaChange[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblCureChange\".cure_change_long", form.schemaChange);
            }

            if (form.schemaChange[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblCureChange\".cure_change_long", form.schemaChange);
            }

            if (form.cardNo.Length != 0)
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".card_no", form.cardNo);

            if (form.dateSchemaStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientCureSchema\".start_date", DateOnly.Parse(form.dateSchemaStart).ToString("dd-MM-yyyy"));
            }

            if (form.dateSchemaEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientCureSchema\".start_date", DateOnly.Parse(form.dateSchemaEnd).ToString("dd-MM-yyyy"));
            }

            if (form.art[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblArvt\".arvt_long", form.art);
            }

            if (form.rangeTherapy[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblRangeTherapy\".range_therapy_long", form.rangeTherapy);
            }

            if (form.dateVlStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"vn\".acl_sample_date", DateOnly.Parse(form.dateVlStart).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (form.dateVlEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"vn\".acl_sample_date", DateOnly.Parse(form.dateVlEnd).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            //                //(form.resVlStart.Length != 0 && IsVlStart ? e.VlResult >= ResVlStart : true) &&
            //                //(form.resVlEnd.Length != 0 && IsVlEnd ? e.VlResult <= ResVlEnd : true) &&

            if (form.dateIMStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"im\".acl_sample_date", DateOnly.Parse(form.dateIMStart).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (form.dateImEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"im\".acl_sample_date", DateOnly.Parse(form.dateImEnd).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            //                //(form.resImStart.Length != 0 && IsImStart ? e.ImResult >= ResImStart : true) &&
            //                //(form.resImEnd.Length != 0 && IsImEnd ? e.ImResult <= ResImEnd : true)

            #endregion

            var searchRes = SerarchResService.GetSearchRes(selectGroupSrt, joinStr, whereStr, pageSize, form.Page);


            if (form.Excel)
            {
                string authHeader = Request.Headers["Authorization"].First();
                string jwt = authHeader.Substring("Bearer ".Length);
                var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var token = jwtHandler.ReadJwtToken(jwt);


                var createExcel = new CreateExcel();
                string fileName = $"res_search_{token.Claims.First().Value}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);
                //string path = Path.Combine(Environment.CurrentDirectory, @"wwwroot", fileName);

                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                createExcel.CreateSearchExcel(searchRes?.resPage, path, columName);

                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);

                return File(fileBytes, contentType, "res_search.xlsx");
            }

            searchRes.ColumName = columName;
            return Ok(searchRes);
        }
    }
}
