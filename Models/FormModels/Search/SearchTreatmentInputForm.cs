using HIVBackend.Services;

namespace HIVBackend.Models.FormModels.Search
{
    /// <summary>
    /// данные пришедшие с фронта (фильтры поиска)
    /// </summary>
    public class SearchTreatmentInputForm : BaseSearchInputForm
    {
        #region поля

        public string dateInpStart { get; set; }
        public string dateInpEnd { get; set; }
        public string patientId { get; set; }
        public string familyName { get; set; }
        public string firstName { get; set; }
        public string thirdName { get; set; }
        public string sex { get; set; }
        public string birthDateStart { get; set; }
        public string birthDateEnd { get; set; }
        public string[]? regionReg { get; set; }
        public string regionPreset { get; set; }
        public string[]? regionFact { get; set; }
        public string factRegionPreset { get; set; }
        public string[]? country { get; set; }
        public string city { get; set; }
        public string location { get; set; }
        public string indx { get; set; }
        public string street { get; set; }
        public string home { get; set; }
        public string dateRegOnStart { get; set; }
        public string dateRegOnEnd { get; set; }
        public string dateUnRegStart { get; set; }
        public string dateUnRegEnd { get; set; }
        public string unRegCourse { get; set; }
        public string[]? stage { get; set; }
        public string dateDieStart { get; set; }
        public string dateDieEnd { get; set; }
        public string dateDieAidsStart { get; set; }
        public string dateDieAidsEnd { get; set; }
        public string[]? dieCourse { get; set; }
        public string diePreset { get; set; }
        public string[]? checkCourse { get; set; }
        public string[]? infectCourse { get; set; }
        public string[]? showIllnes { get; set; }
        public string dateShowIllnesStart { get; set; }
        public string dateShowIllnesEnd { get; set; }
        public string transfAreaYNA { get; set; }
        public string dateTransfAreaStart { get; set; }
        public string dateTransfAreaEnd { get; set; }
        public string frYNA { get; set; }
        public string zavApoYNA { get; set; }
        public string ibRes { get; set; }
        public string dateIbResStart { get; set; }
        public string dateIbResEnd { get; set; }
        public string ibNum { get; set; }
        public string dateInpIbStart { get; set; }
        public string dateInpIbEnd { get; set; }
        public string ibSelect { get; set; }
        public string ufsinYNA { get; set; }
        public string dateUfsinStart { get; set; }
        public string dateUfsinEnd { get; set; }
        public string[]? invalid { get; set; }
        public string[]? correspIllnesses { get; set; }
        public string dateCorrespIllnessesStart { get; set; }
        public string dateCorrespIllnessesEnd { get; set; }
        public string[]? schema { get; set; }
        public bool? schemaLast { get; set; }
        public string[]? schemaMedecine { get; set; }
        public string[]? medecine { get; set; }
        public string[]? medecineGive { get; set; }
        public string[]? doctor { get; set; }
        public string? dateGiveStart { get; set; }
        public string? dateGiveEnd { get; set; }
        public string[]? schemaChange { get; set; }
        public string? cardNo { get; set; }
        public string? dateSchemaStart { get; set; }
        public string? dateSchemaEnd { get; set; }
        public string[]? finSource { get; set; }
        public string[]? art { get; set; }
        public string[]? rangeTherapy { get; set; }
        public string? dateVlStart { get; set; }
        public string? dateVlEnd { get; set; }
        public string? resVlStart { get; set; }
        public string? resVlEnd { get; set; }
        public string? dateIMStart { get; set; }
        public string? dateImEnd { get; set; }
        public string? resImStart { get; set; }
        public string? resImEnd { get; set; }
        public string? unrzYNA { get; set; }
        public string? unrz { get; set; }
        public string? snilsYNA { get; set; }
        public string? snils { get; set; }


        public bool selectInpDate { get; set; }
        public bool selectPatientId { get; set; }
        public bool selectFio { get; set; }
        public bool selectSex { get; set; }
        public bool selectBirthDate { get; set; }
        public bool selectRegion { get; set; }
        public bool selectRegionFact { get; set; }
        public bool selectCountry { get; set; }
        public bool selectAddr { get; set; }
        public bool selectRegOnDate { get; set; }
        public bool selectStage { get; set; }
        public bool selectDieDate { get; set; }
        public bool selectDieCourse { get; set; }
        public bool selectCheckCourse { get; set; }
        public bool selectInfectCourse { get; set; }
        public bool selectShowIllnes { get; set; }
        public bool selectTransfArea { get; set; }
        public bool selectFr { get; set; }
        public bool selectIb { get; set; }
        public bool selectUfsin { get; set; }
        public bool selectInvalid { get; set; }
        public bool selectCorrespIllnesses { get; set; }
        public bool selectSchema { get; set; }
        public bool selectSchemaMedecine { get; set; }
        public bool selectMedecine { get; set; }
        public bool selectMedecineGive { get; set; }
        public bool selectDoctor { get; set; }
        public bool selectGiveDate { get; set; }
        public bool selectSchemaChange { get; set; }
        public bool selectCardNo { get; set; }
        public bool selectSchemaDate { get; set; }
        public bool selectFinSource { get; set; }
        public bool selectArt { get; set; }
        public bool selectRangeTherapy { get; set; }
        public bool selectVlDate { get; set; }
        public bool selectVlRes { get; set; }
        public bool selectImDate { get; set; }
        public bool selectImRes { get; set; }
        public bool selectUnrz { get; set; }
        public bool selectSnils { get; set; }

        #endregion

        public override void SetSearchData()
        {
            base.selectGroupSrt.Append("\"tblPatientCard\".patient_id");
            base.joinStr.Append(" FROM \"tblPatientCard\"");
            base.whereStr.Append("WHERE true");

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchTreatmentInputForm).GetProperties().Where(e => e.Name.StartsWith("select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "selectInpDate")
                    {
                        base.columName.Add("Дата ввода");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".input_date");
                    }

                    if (key.Name == "selectFio")
                    {
                        base.columName.Add("Фамилия");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".family_name");
                        base.columName.Add("Имя");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".first_name");
                        base.columName.Add("Отчество");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".third_name");
                    }

                    if (key.Name == "selectSex")
                    {
                        base.columName.Add("Пол");
                        base.selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectBirthDate")
                    {
                        base.columName.Add("Дата рождения");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".birth_date");
                    }

                    if (key.Name == "selectRegion")
                    {
                        base.columName.Add("Регион");
                        base.selectGroupSrt.AppendLine(",\"tblRegion\".region_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectRegionFact")
                    {
                        base.columName.Add("Регион (факт.)");
                        base.selectGroupSrt.AppendLine(",\"tblRegionFact\".region_long");

                        base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                               fieldLeft: "fact_region_id",
                                                               fieldRight: "region_id",
                                                               table: "tblPatientCard",
                                                               alias: "tblRegionFact");
                    }

                    if (key.Name == "selectCountry")
                    {
                        base.columName.Add("Страна");
                        base.selectGroupSrt.AppendLine(",\"tblCountry\".country_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectAddr")
                    {
                        base.columName.Add("Город");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".city_name");
                        base.columName.Add("Населённый пункт");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".location_name");
                        base.columName.Add("Индекс");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_ind");
                        base.columName.Add("Улица");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_street");
                        base.columName.Add("Дом");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_house");
                        base.columName.Add("Корпус");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_ext");
                        base.columName.Add("Квартира");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_flat");
                    }

                    if (key.Name == "selectRegOnDate")
                    {
                        base.columName.Add("Дата постановки на учет");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".reg_on_date");
                        base.columName.Add("Дата снятия с учета");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".reg_off_date");
                        base.columName.Add("Причина снятия с учета");
                        base.selectGroupSrt.AppendLine(",\"regOff\".infect_course_long");
                        base.joinStr.AddLeftJoinIfNotExistDiffField(
                            joinTable: "tblInfectCourse",
                            fieldLeft: "reg_off_reason",
                            fieldRight: "infect_course_id",
                            table: "tblPatientCard",
                            alias: "regOff");
                    }

                    if (key.Name == "selectStage")
                    {
                        base.columName.Add("Стадия");
                        base.selectGroupSrt.AppendLine(",stage.diagnosis_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
                    }

                    if (key.Name == "selectDieDate")
                    {
                        base.columName.Add("Дата смерти");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".die_date");
                        base.columName.Add("Дата смерти от СПИДа");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".die_aids_date");
                    }

                    if (key.Name == "selectDieCourse")
                    {
                        base.columName.Add("Причина смерти");
                        base.selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_long");
                        base.columName.Add("МКБ причина смерти");
                        base.selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_short");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectCheckCourse")
                    {
                        base.columName.Add("Причина обращения");
                        base.selectGroupSrt.AppendLine(",\"tblCheckCourse\".check_course_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectInfectCourse")
                    {
                        base.columName.Add("Причина заражения");
                        base.selectGroupSrt.AppendLine(",\"tblInfectCourse\".infect_course_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectShowIllnes")
                    {
                        base.columName.Add("Индикаторная болезнь");
                        base.selectGroupSrt.AppendLine(",\"tblShowIllness\".show_illness_long");

                        base.columName.Add("Дата вторичного заболивания с");
                        base.selectGroupSrt.AppendLine(",\"tblPatientShowIllness\".start_date");

                        base.columName.Add("Дата вторичного заболивания по");
                        base.selectGroupSrt.AppendLine(",\"tblPatientShowIllness\".end_date");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                    }

                    if (key.Name == "selectTransfArea")
                    {
                        base.columName.Add("Дата передачи в район");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".transf_area_date");
                    }

                    if (key.Name == "selectFr")
                    {
                        base.columName.Add("Внесено в ФР");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_zam_med_part");
                        base.columName.Add("Зав АПО");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_head_physician");
                    }

                    if (key.Name == "selectIb")
                    {
                        base.columName.Add("Результат референс");
                        base.selectGroupSrt.AppendLine(",\"tblIbResult\".ib_result_short");

                        base.columName.Add("Дата референс");
                        base.selectGroupSrt.AppendLine(",\"tblPatientBlot\".blot_date");

                        base.columName.Add("Номер");
                        base.selectGroupSrt.AppendLine(",\"tblPatientBlot\".blot_no");

                        base.columName.Add("Послед");
                        base.selectGroupSrt.AppendLine(",\"tblPatientBlot\".first1");

                        base.columName.Add("Дата ввода");
                        base.selectGroupSrt.AppendLine(",\"tblPatientBlot\".datetime1");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblIbResult", field: "ib_result_id", table: "tblPatientBlot");
                    }

                    if (key.Name == "selectUfsin")
                    {
                        base.columName.Add("Дата постановки на учет УФСИН");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
                    }

                    if (key.Name == "selectInvalid")
                    {
                        base.columName.Add("Группа инвалидности");
                        base.selectGroupSrt.AppendLine(",\"tblInvalid\".invalid_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectCorrespIllnesses")
                    {
                        base.columName.Add("Сопутствующее заболевание");
                        base.selectGroupSrt.AppendLine(",\"tblCorrespIllness\".corresp_illness_long");

                        base.columName.Add("Сопутствующее заболевание дата");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCorrespIllness\".datetime1");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
                    }

                    if (key.Name == "selectSchemaDate")
                    {
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        base.columName.Add("Дата назн.схемы");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCureSchema\".start_date");
                    }

                    if (key.Name == "selectSchema")
                    {
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        base.columName.Add("Схема лечения");
                        base.selectGroupSrt.AppendLine(",\"tblCureSchema\".cure_schema_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                    }

                    if (key.Name == "selectSchemaMedecine")
                    {
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        base.columName.Add("Схема лечения (препарат)");
                        base.selectGroupSrt.AppendLine(",\"tblMedicineForSchema\".medforschema_long");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR", field: "cure_schema_id", table: "tblPatientCureSchema");
                        base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                               fieldLeft: "medicine_id",
                                                               fieldRight: "medforschema_id",
                                                               table: "tblSchemaMedicineR");
                    }

                    if (key.Name == "selectGiveDate")
                    {
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        base.columName.Add("Дата выдачи препарата");
                        base.selectGroupSrt.AppendLine(",\"tblPatientPrescrM\".give_date");
                    }

                    if (key.Name == "selectDoctor")
                    {
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        base.columName.Add("Персонал");
                        base.selectGroupSrt.AppendLine(",\"tblDoctor\".doctor_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
                    }

                    if (key.Name == "selectMedecine")
                    {
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        base.columName.Add("Препарат прописанный");
                        base.selectGroupSrt.AppendLine(",\"tblMedicine\".medicine_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                    }

                    if (key.Name == "selectMedecineGive")
                    {
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        base.columName.Add("Препарат выданный");
                        base.selectGroupSrt.AppendLine(",\"tblGiveMedicine\".medicine_long");
                        base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicine",
                                                               fieldLeft: "give_med_id",
                                                               fieldRight: "medicine_id",
                                                               table: "tblPatientPrescrM",
                                                               alias: "tblGiveMedicine");
                    }

                    if (key.Name == "selectSchemaChange")
                    {
                        base.columName.Add("Причина смены схемы леч.");
                        base.selectGroupSrt.AppendLine(",\"tblCureChange\".cure_change_long");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                    }

                    if (key.Name == "selectCardNo")
                    {
                        base.columName.Add("№ карты");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".card_no");
                    }

                    if (key.Name == "selectArt")
                    {
                        base.columName.Add("АРТ");
                        base.selectGroupSrt.AppendLine(",\"tblArvt\".arvt_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectRangeTherapy")
                    {
                        base.columName.Add("Ряд терапии");
                        base.selectGroupSrt.AppendLine(",\"tblRangeTherapy\".range_therapy_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
                    }

                    if (key.Name == "selectUnrz")
                    {
                        base.columName.Add("УНРЗ");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".unrz_fr");
                    }

                    if (key.Name == "selectSnils")
                    {
                        base.columName.Add("СНИЛС");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".snils");
                    }

                    #region Добавление результаток исследований TODO
                    if (key.Name == "selectVlDate")
                    {
                        base.columName.Add("Дата опред.вир.нагр.");
                        base.selectGroupSrt.AppendLine(",\"vn\".acl_sample_date");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                        if (!base.joinStr.ToString().Contains(str))
                            base.joinStr.AppendLine(str);

                    }

                    if (key.Name == "selectVlRes")
                    {
                        base.columName.Add("Вирусн.нагр.");
                        base.selectGroupSrt.AppendLine(",\"vn\".acl_result");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                        if (!base.joinStr.ToString().Contains(str))
                            base.joinStr.AppendLine(str);
                    }

                    if (key.Name == "selectImDate")
                    {
                        base.columName.Add("Дата опред.иммун.стат.");
                        base.selectGroupSrt.AppendLine(",\"im\".acl_sample_date");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                        if (!base.joinStr.ToString().Contains(str))
                            base.joinStr.AppendLine(str);
                    }

                    if (key.Name == "selectImRes")
                    {
                        base.columName.Add("CD4+(abc)");
                        base.selectGroupSrt.AppendLine(",\"im\".acl_result");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                        if (!base.joinStr.ToString().Contains(str))
                            base.joinStr.AppendLine(str);
                    }
                    #endregion
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (this.patientId.Length != 0)
                base.whereStr.AddWhereSqlEqual("\"tblPatientCard\".patient_id", this.patientId);

            if (this.dateInpStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".input_date", DateOnly.Parse(this.dateInpStart).ToString("dd-MM-yyyy"));

            if (this.dateInpEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".input_date", DateOnly.Parse(this.dateInpEnd).ToString("dd-MM-yyyy"));

            if (this.familyName.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".family_name", this.familyName.ToLower());

            if (this.firstName.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".first_name", this.firstName.ToLower());

            if (this.thirdName.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".third_name", this.thirdName.ToLower());

            if (this.sex.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqualString("\"tblSex\".sex_short", this.sex);
            }

            if (this.birthDateStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".birth_date", DateOnly.Parse(this.birthDateStart).ToString("dd-MM-yyyy"));

            if (this.birthDateEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".birth_date", DateOnly.Parse(this.birthDateEnd).ToString("dd-MM-yyyy"));

            if (this.regionReg[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlIn("\"tblRegion\".region_long", this.regionReg);
            }

            if (this.regionPreset == "Московская обл.")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", "1");
            }

            if (this.regionPreset == "Иногородние")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", "2");
            }

            if (this.regionPreset == "Иностранные")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", "3");
            }

            if (this.regionFact[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                base.whereStr.AddWhereSqlIn("\"tblRegionFact\".region_long", this.regionFact);
            }

            if (this.factRegionPreset == "Московская обл.")
            {
                base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                base.whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", "1");
            }

            if (this.factRegionPreset == "Иногородние")
            {
                base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                base.whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", "2");
            }

            if (this.factRegionPreset == "Иностранные")
            {
                base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                base.whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", "3");
            }

            if (this.country[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlIn("\"tblCountry\".country_long", this.country);
            }

            if (this.city.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".city_name", this.city.ToLower());

            if (this.location.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".location_name", this.location.ToLower());

            if (this.indx.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_ind", this.indx.ToLower());

            if (this.street.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_street", this.street.ToLower());

            if (this.home.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_house", this.home.ToLower());

            if (this.dateRegOnStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_on_date", DateOnly.Parse(this.dateRegOnStart).ToString("dd-MM-yyyy"));

            if (this.dateRegOnEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_on_date", DateOnly.Parse(this.dateRegOnEnd).ToString("dd-MM-yyyy"));

            if (this.dateUnRegStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_off_date", DateOnly.Parse(this.dateUnRegStart).ToString("dd-MM-yyyy"));

            if (this.dateUnRegEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_off_date", DateOnly.Parse(this.dateUnRegEnd).ToString("dd-MM-yyyy"));

            if (this.unRegCourse.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExistDiffField(
                    joinTable: "tblInfectCourse",
                    fieldLeft: "reg_off_reason",
                    fieldRight: "infect_course_id",
                    table: "tblPatientCard",
                    alias: "regOff");
                base.whereStr.AddWhereSqlEqualString("\"regOff\".infect_course_long", this.unRegCourse);
            }

            if (this.stage[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
                base.whereStr.AddWhereSqlIn("stage.diagnosis_long", this.stage);
            }

            if (this.dateDieStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_date", DateOnly.Parse(this.dateDieStart).ToString("dd-MM-yyyy"));

            if (this.dateDieEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_date", DateOnly.Parse(this.dateDieEnd).ToString("dd-MM-yyyy"));

            if (this.dateDieAidsStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_aids_date", DateOnly.Parse(this.dateDieAidsStart).ToString("dd-MM-yyyy"));

            if (this.dateDieAidsEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_aids_date", DateOnly.Parse(this.dateDieAidsEnd).ToString("dd-MM-yyyy"));

            if (this.dieCourse[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".die_course_long", this.dieCourse);
            }

            if (this.diePreset == "ВИЧ")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                base.whereStr.Append($" AND \"tblTempDieCureMKB10List\".\"Dethtype_id\" IN (1,3) ");
            }

            if (this.diePreset == "Не связанные с ВИЧ")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "2");
            }

            if (this.diePreset == "СПИД")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "3");
            }

            if (this.checkCourse[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlIn("\"tblCheckCourse\".check_course_long", this.checkCourse);
            }

            if (this.infectCourse[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlIn("\"tblInfectCourse\".infect_course_long", this.infectCourse);
            }

            if (this.showIllnes[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                base.whereStr.AddWhereSqlIn("\"tblShowIllness\".show_illness_long", this.showIllnes);
            }

            if (this.dateShowIllnesStart.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                base.whereStr.AddWhereSqlDateMore("\"tblPatientShowIllness\".start_date", DateOnly.Parse(this.dateShowIllnesStart).ToString("dd-MM-yyyy"));
            }

            if (this.dateShowIllnesEnd.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                base.whereStr.AddWhereSqlDateLess("\"tblPatientShowIllness\".end_date", DateOnly.Parse(this.dateShowIllnesEnd).ToString("dd-MM-yyyy"));
            }

            if (this.transfAreaYNA == "Да")
                base.whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".transf_area_date");

            if (this.transfAreaYNA == "Нет")
                base.whereStr.AddWhereSqlIsNull("\"tblPatientCard\".transf_area_date");

            if (this.dateTransfAreaStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".transf_area_date", DateOnly.Parse(this.dateTransfAreaStart).ToString("dd-MM-yyyy"));

            if (this.dateTransfAreaEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".transf_area_date", DateOnly.Parse(this.dateTransfAreaEnd).ToString("dd-MM-yyyy"));

            if (this.frYNA == "Да")
                base.whereStr.AddWhereSqlTrue("\"tblPatientCard\".flg_zam_med_part");

            if (this.frYNA == "Нет")
                base.whereStr.AddWhereSqlFalseOrNull("\"tblPatientCard\".flg_zam_med_part");

            if (this.zavApoYNA == "Да")
                base.whereStr.AddWhereSqlTrue("\"tblPatientCard\".flg_head_physician");

            if (this.zavApoYNA == "Нет")
                base.whereStr.AddWhereSqlFalseOrNull("\"tblPatientCard\".flg_head_physician");

            if (this.zavApoYNA == "Нет")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblIbResult", field: "ib_result_id", table: "tblPatientBlot");
                base.whereStr.AddWhereSqlEqualString("\"tblIbResult\".ib_result_short", this.ibRes);
            }

            if (this.dateIbResStart.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".blot_date", DateOnly.Parse(this.dateIbResStart).ToString("dd-MM-yyyy"));
            }

            if (this.dateIbResEnd.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".blot_date", DateOnly.Parse(this.dateIbResEnd).ToString("dd-MM-yyyy"));
            }

            if (this.ibNum.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqual("\"tblPatientBlot\".blot_no", this.ibNum);
            }

            if (this.dateInpIbStart.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".datetime1", DateOnly.Parse(this.dateInpIbStart).ToString("dd-MM-yyyy"));
            }

            if (this.dateInpIbEnd.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".datetime1", DateOnly.Parse(this.dateInpIbEnd).ToString("dd-MM-yyyy"));
            }

            if (this.ibSelect == "Первый")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
            }

            if (this.ibSelect == "Последний")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }

            if (this.ibSelect == "Перв.и посл.")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
                base.whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }

            if (this.ufsinYNA == "Да")
                base.whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".ufsin_date");

            if (this.ufsinYNA == "Нет")
                base.whereStr.AddWhereSqlIsNull("\"tblPatientCard\".ufsin_date");

            if (this.dateUfsinStart.Length != 0)
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".ufsin_date", DateOnly.Parse(this.dateUfsinStart).ToString("dd-MM-yyyy"));

            if (this.dateUfsinEnd.Length != 0)
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".ufsin_date", DateOnly.Parse(this.dateUfsinEnd).ToString("dd-MM-yyyy"));

            if (this.invalid[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlIn("\"tblInvalid\".invalid_long", this.invalid);
            }

            if (this.correspIllnesses[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
                base.whereStr.AddWhereSqlIn("\"tblCorrespIllness\".corresp_illness_long", this.invalid);
            }

            if (this.dateCorrespIllnessesStart.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(this.dateCorrespIllnessesStart).ToString("dd-MM-yyyy"));
            }

            if (this.dateCorrespIllnessesEnd.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(this.dateCorrespIllnessesEnd).ToString("dd-MM-yyyy"));
            }

            if (this.schema[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                base.whereStr.AddWhereSqlIn("\"tblCureSchema\".cure_schema_long", this.schema);
            }

            if (this.schema[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                base.whereStr.AddWhereSqlIn("\"tblCureSchema\".cure_schema_long", this.schema);
            }

            if (this.schemaLast == true)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlTrue("\"tblPatientCureSchema\".\"lastYN\"");
            }

            if (this.schemaMedecine[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR", field: "cure_schema_id", table: "tblPatientCureSchema");
                base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                       fieldLeft: "medicine_id",
                                                       fieldRight: "medforschema_id",
                                                       table: "tblSchemaMedicineR");
                base.whereStr.AddWhereSqlIn("\"tblMedicineForSchema\".medforschema_long", this.schemaMedecine);
            }

            if (this.medecine[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                base.whereStr.AddWhereSqlIn("\"tblMedicine\".medicine_long", this.medecine);
            }

            if (this.medecineGive[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                base.whereStr.AddWhereSqlIn("\"tblGiveMedicine\".medicine_long", this.medecineGive);
            }

            if (this.doctor[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
                base.whereStr.AddWhereSqlIn("\"tblDoctor\".doctor_long", this.doctor);
            }

            if (this.dateGiveStart.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateMore("\"tblPatientPrescrM\".give_date", DateOnly.Parse(this.dateGiveStart).ToString("dd-MM-yyyy"));
            }

            if (this.dateGiveEnd.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateLess("\"tblPatientPrescrM\".give_date", DateOnly.Parse(this.dateGiveEnd).ToString("dd-MM-yyyy"));
            }

            if (this.schemaChange[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                base.whereStr.AddWhereSqlIn("\"tblCureChange\".cure_change_long", this.schemaChange);
            }

            if (this.schemaChange[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                base.whereStr.AddWhereSqlIn("\"tblCureChange\".cure_change_long", this.schemaChange);
            }

            if (this.cardNo.Length != 0)
                base.whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".card_no", this.cardNo);

            if (this.dateSchemaStart.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCureSchema\".start_date", DateOnly.Parse(this.dateSchemaStart).ToString("dd-MM-yyyy"));
            }

            if (this.dateSchemaEnd.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCureSchema\".start_date", DateOnly.Parse(this.dateSchemaEnd).ToString("dd-MM-yyyy"));
            }

            if (this.art[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlIn("\"tblArvt\".arvt_long", this.art);
            }

            if (this.rangeTherapy[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
                base.whereStr.AddWhereSqlIn("\"tblRangeTherapy\".range_therapy_long", this.rangeTherapy);
            }

            if (this.dateVlStart.Length != 0)
            {
                base.whereStr.AddWhereSqlDateMore("\"vn\".acl_sample_date", DateOnly.Parse(this.dateVlStart).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!base.joinStr.ToString().Contains(str))
                    base.joinStr.AppendLine(str);
            }

            if (this.dateVlEnd.Length != 0)
            {
                base.whereStr.AddWhereSqlDateLess("\"vn\".acl_sample_date", DateOnly.Parse(this.dateVlEnd).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!base.joinStr.ToString().Contains(str))
                    base.joinStr.AppendLine(str);
            }

            if (this.resVlStart != null && this.resVlStart.Length != 0)
            {
                base.whereStr.AddWhereIntConvertMore("\"vn\".acl_mcn_code", Int32.Parse(this.resVlStart));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!base.joinStr.ToString().Contains(str))
                    base.joinStr.AppendLine(str);
            }

            if (this.resVlEnd != null && this.resVlEnd.Length != 0)
            {
                base.whereStr.AddWhereIntConvertLess("\"vn\".acl_mcn_code", Int32.Parse(this.resVlEnd));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!base.joinStr.ToString().Contains(str))
                    base.joinStr.AppendLine(str);
            }

            if (this.dateIMStart?.Length != 0)
            {
                base.whereStr.AddWhereSqlDateMore("\"im\".acl_sample_date", DateOnly.Parse(this.dateIMStart).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                if (!base.joinStr.ToString().Contains(str))
                    base.joinStr.AppendLine(str);
            }

            if (this.dateImEnd?.Length != 0)
            {
                base.whereStr.AddWhereSqlDateLess("\"im\".acl_sample_date", DateOnly.Parse(this.dateImEnd).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                if (!base.joinStr.ToString().Contains(str))
                    base.joinStr.AppendLine(str);
            }

            //                //(this.resImStart.Length != 0 && IsImStart ? e.ImResult >= ResImStart : true) &&
            //                //(this.resImEnd.Length != 0 && IsImEnd ? e.ImResult <= ResImEnd : true)

            if (this.unrz?.Length != 0)
            {
                base.whereStr.AddWhereSqlEqualString("\"tblPatientCard\".unrz_fr", this.unrz);
            }

            if (this.unrzYNA == "Да")
            {
                base.whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".unrz_fr");
            }

            if (this.unrzYNA == "Нет")
            {
                base.whereStr.AddWhereSqlIsNull("\"tblPatientCard\".unrz_fr");
            }

            if (this.snils?.Length != 0)
            {
                base.whereStr.AddWhereSqlEqualString("\"tblPatientCard\".snils", this.snils);
            }

            if (this.snilsYNA == "Да")
            {
                base.whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".snils");
            }

            if (this.snilsYNA == "Нет")
            {
                base.whereStr.AddWhereSqlIsNull("\"tblPatientCard\".snils");
            }

            #endregion
        }
    }
}
