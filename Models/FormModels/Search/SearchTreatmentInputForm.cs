using HIVBackend.Enums;
using HIVBackend.Helpers;

namespace HIVBackend.Models.FormModels.Search
{
    /// <summary>
    /// данные пришедшие с фронта (фильтры поиска)
    /// </summary>
    public class SearchTreatmentInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string DateDieStart { get; set; } = string.Empty;
        public string DateDieEnd { get; set; } = string.Empty;
        public string DateDieAidsStart { get; set; } = string.Empty;
        public string DateDieAidsEnd { get; set; } = string.Empty;
        public string[] DieCourse { get; set; } = new string[] { "Все" };
        public string DiePreset { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string IbRes { get; set; } = string.Empty;
        public string DateIbResStart { get; set; } = string.Empty;
        public string DateIbResEnd { get; set; } = string.Empty;
        public string IbNum { get; set; } = string.Empty;
        public string DateInpIbStart { get; set; } = string.Empty;
        public string DateInpIbEnd { get; set; } = string.Empty;
        public string IbSelect { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string[] Invalid { get; set; } = new string[] { "Все" };
        public string[] CorrespIllnesses { get; set; } = new string[] { "Все" };
        public string DateCorrespIllnessesStart { get; set; } = string.Empty;
        public string DateCorrespIllnessesEnd { get; set; } = string.Empty;
        public string[] Schema { get; set; } = new string[] { "Все" };
        public bool SchemaLast { get; set; } = false;
        public string[] SchemaMedecine { get; set; } = new string[] { "Все" };
        public string[] Medecine { get; set; } = new string[] { "Все" };
        public string[] MedecineGive { get; set; } = new string[] { "Все" };
        public string[] Doctor { get; set; } = new string[] { "Все" };
        public string DateGiveStart { get; set; } = string.Empty;
        public string DateGiveEnd { get; set; } = string.Empty;
        public string[] SchemaChange { get; set; } = new string[] { "Все" };
        public string CardNo { get; set; } = string.Empty;
        public string DateSchemaStart { get; set; } = string.Empty;
        public string DateSchemaEnd { get; set; } = string.Empty;
        public string[] FinSource { get; set; } = new string[] { "Все" };
        public string[] Art { get; set; } = new string[] { "Все" };
        public string[] RangeTherapy { get; set; } = new string[] { "Все" };
        public string DateVlStart { get; set; } = string.Empty;
        public string DateVlEnd { get; set; } = string.Empty;
        public string ResVlStart { get; set; } = string.Empty;
        public string ResVlEnd { get; set; } = string.Empty;
        public string DateIMStart { get; set; } = string.Empty;
        public string DateImEnd { get; set; } = string.Empty;
        public string ResImStart { get; set; } = string.Empty;
        public string ResImEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; } = false;
        public bool SelectDieDate { get; set; } = false;
        public bool SelectDieCourse { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectIb { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectInvalid { get; set; } = false;
        public bool SelectCorrespIllnesses { get; set; } = false;
        public bool SelectSchema { get; set; } = false;
        public bool SelectSchemaMedecine { get; set; } = false;
        public bool SelectMedecine { get; set; } = false;
        public bool SelectMedecineGive { get; set; } = false;
        public bool SelectDoctor { get; set; } = false;
        public bool SelectGiveDate { get; set; } = false;
        public bool SelectSchemaChange { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectSchemaDate { get; set; } = false;
        public bool SelectFinSource { get; set; } = false;
        public bool SelectArt { get; set; } = false;
        public bool SelectRangeTherapy { get; set; } = false;
        public bool SelectVlDate { get; set; } = false;
        public bool SelectVlRes { get; set; } = false;
        public bool SelectImDate { get; set; } = false;
        public bool SelectImRes { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchTreatmentInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectSex")
                    {
                        columName.Add("Пол");
                        selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectDieDate")
                    {
                        columName.Add("Дата смерти");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".die_date");
                        columName.Add("Дата смерти от СПИДа");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".die_aids_date");
                    }

                    if (key.Name == "SelectDieCourse")
                    {
                        columName.Add("Причина смерти");
                        selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_long");
                        columName.Add("МКБ причина смерти");
                        selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_short");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectShowIllnes")
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

                    if (key.Name == "SelectIb")
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

                    if (key.Name == "SelectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
                    }

                    if (key.Name == "SelectInvalid")
                    {
                        columName.Add("Группа инвалидности");
                        selectGroupSrt.AppendLine(",\"tblInvalid\".invalid_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectCorrespIllnesses")
                    {
                        columName.Add("Сопутствующее заболевание");
                        selectGroupSrt.AppendLine(",\"tblCorrespIllness\".corresp_illness_long");

                        columName.Add("Сопутствующее заболевание дата");
                        selectGroupSrt.AppendLine(",\"tblPatientCorrespIllness\".datetime1");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
                    }

                    if (key.Name == "SelectSchemaDate")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Дата назн.схемы");
                        selectGroupSrt.AppendLine(",\"tblPatientCureSchema\".start_date");
                    }

                    if (key.Name == "SelectSchema")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Схема лечения");
                        selectGroupSrt.AppendLine(",\"tblCureSchema\".cure_schema_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                    }

                    if (key.Name == "SelectSchemaMedecine")
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

                    if (key.Name == "SelectGiveDate")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Дата выдачи препарата");
                        selectGroupSrt.AppendLine(",\"tblPatientPrescrM\".give_date");
                    }

                    if (key.Name == "SelectDoctor")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Персонал");
                        selectGroupSrt.AppendLine(",\"tblDoctor\".doctor_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
                    }

                    if (key.Name == "SelectMedecine")
                    {
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

                        columName.Add("Препарат прописанный");
                        selectGroupSrt.AppendLine(",\"tblMedicine\".medicine_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                    }

                    if (key.Name == "SelectMedecineGive")
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

                    if (key.Name == "SelectSchemaChange")
                    {
                        columName.Add("Причина смены схемы леч.");
                        selectGroupSrt.AppendLine(",\"tblCureChange\".cure_change_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                    }

                    if (key.Name == "SelectCardNo")
                    {
                        columName.Add("№ карты");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".card_no");
                    }

                    if (key.Name == "SelectArt")
                    {
                        columName.Add("АРТ");
                        selectGroupSrt.AppendLine(",\"tblArvt\".arvt_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectRangeTherapy")
                    {
                        columName.Add("Ряд терапии");
                        selectGroupSrt.AppendLine(",\"tblRangeTherapy\".range_therapy_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
                    }

                    #region Добавление результаток исследований TODO
                    if (key.Name == "SelectVlDate")
                    {
                        columName.Add("Дата опред.вир.нагр.");
                        selectGroupSrt.AppendLine(",\"vn\".acl_sample_date");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);

                    }

                    if (key.Name == "SelectVlRes")
                    {
                        columName.Add("Вирусн.нагр.");
                        selectGroupSrt.AppendLine(",\"vn\".acl_result");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);
                    }

                    if (key.Name == "SelectImDate")
                    {
                        columName.Add("Дата опред.иммун.стат.");
                        selectGroupSrt.AppendLine(",\"im\".acl_sample_date");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);
                    }

                    if (key.Name == "SelectImRes")
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

            if (Sex.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqualString("\"tblSex\".sex_short", Sex);
            }

            if (DateDieStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_date", DateOnly.Parse(DateDieStart).ToString("dd-MM-yyyy"));
            }

            if (DateDieEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_date", DateOnly.Parse(DateDieEnd).ToString("dd-MM-yyyy"));
            }

            if (DateDieAidsStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_aids_date", DateOnly.Parse(DateDieAidsStart).ToString("dd-MM-yyyy"));
            }

            if (DateDieAidsEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_aids_date", DateOnly.Parse(DateDieAidsEnd).ToString("dd-MM-yyyy"));
            }

            if (DieCourse[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".die_course_long", DieCourse);
            }

            if (DiePreset == "ВИЧ")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", new[] { "1", "3" });
            }

            if (DiePreset == "Не связанные с ВИЧ")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "2");
            }

            if (DiePreset == "СПИД")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "3");
            }

            if (ShowIllnes[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                whereStr.AddWhereSqlIn("\"tblShowIllness\".show_illness_long", ShowIllnes);
            }

            if (DateShowIllnesStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                whereStr.AddWhereSqlDateMore("\"tblPatientShowIllness\".start_date", DateOnly.Parse(DateShowIllnesStart).ToString("dd-MM-yyyy"));
            }

            if (DateShowIllnesEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                whereStr.AddWhereSqlDateLess("\"tblPatientShowIllness\".end_date", DateOnly.Parse(DateShowIllnesEnd).ToString("dd-MM-yyyy"));
            }

            if (IbRes.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblIbResult", field: "ib_result_id", table: "tblPatientBlot");
                whereStr.AddWhereSqlEqualString("\"tblIbResult\".ib_result_short", IbRes);
            }

            if (DateIbResStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".blot_date", DateOnly.Parse(DateIbResStart).ToString("dd-MM-yyyy"));
            }

            if (DateIbResEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".blot_date", DateOnly.Parse(DateIbResEnd).ToString("dd-MM-yyyy"));
            }

            if (IbNum.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblPatientBlot\".blot_no", IbNum);
            }

            if (DateInpIbStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".datetime1", DateOnly.Parse(DateInpIbStart).ToString("dd-MM-yyyy"));
            }

            if (DateInpIbEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".datetime1", DateOnly.Parse(DateInpIbEnd).ToString("dd-MM-yyyy"));
            }

            if (IbSelect == "Первый")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
            }

            if (IbSelect == "Последний")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }

            if (IbSelect == "Перв.и посл.")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }

            if (UfsinYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".ufsin_date");
            }

            if (UfsinYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".ufsin_date");
            }

            if (DateUfsinStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".ufsin_date", DateOnly.Parse(DateUfsinStart).ToString("dd-MM-yyyy"));
            }

            if (DateUfsinEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".ufsin_date", DateOnly.Parse(DateUfsinEnd).ToString("dd-MM-yyyy"));
            }

            if (Invalid[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblInvalid\".invalid_long", Invalid);
            }

            if (CorrespIllnesses[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
                whereStr.AddWhereSqlIn("\"tblCorrespIllness\".corresp_illness_long", CorrespIllnesses);
            }

            if (DateCorrespIllnessesStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(DateCorrespIllnessesStart).ToString("dd-MM-yyyy"));
            }

            if (DateCorrespIllnessesEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(DateCorrespIllnessesEnd).ToString("dd-MM-yyyy"));
            }

            if (Schema[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblCureSchema\".cure_schema_long", Schema);
            }

            if (SchemaLast == true)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlTrue("\"tblPatientCureSchema\".\"lastYN\"");
            }

            if (SchemaMedecine[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR", field: "cure_schema_id", table: "tblPatientCureSchema");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                       fieldLeft: "medicine_id",
                                                       fieldRight: "medforschema_id",
                                                       table: "tblSchemaMedicineR");
                whereStr.AddWhereSqlIn("\"tblMedicineForSchema\".medforschema_long", SchemaMedecine);
            }

            if (Medecine[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                whereStr.AddWhereSqlIn("\"tblMedicine\".medicine_long", Medecine);
            }

            if (MedecineGive[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
                whereStr.AddWhereSqlIn("\"tblGiveMedicine\".medicine_long", MedecineGive);
            }

            if (Doctor[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
                whereStr.AddWhereSqlIn("\"tblDoctor\".doctor_long", Doctor);
            }

            if (DateGiveStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientPrescrM\".give_date", DateOnly.Parse(DateGiveStart).ToString("dd-MM-yyyy"));
            }

            if (DateGiveEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientPrescrM\".give_date", DateOnly.Parse(DateGiveEnd).ToString("dd-MM-yyyy"));
            }

            if (SchemaChange[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblCureChange\".cure_change_long", SchemaChange);
            }

            if (SchemaChange[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblCureChange\".cure_change_long", SchemaChange);
            }

            if (CardNo.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".card_no", CardNo);
            }

            if (DateSchemaStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientCureSchema\".start_date", DateOnly.Parse(DateSchemaStart).ToString("dd-MM-yyyy"));
            }

            if (DateSchemaEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientCureSchema\".start_date", DateOnly.Parse(DateSchemaEnd).ToString("dd-MM-yyyy"));
            }

            if (Art[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblArvt\".arvt_long", Art);
            }

            if (RangeTherapy[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
                whereStr.AddWhereSqlIn("\"tblRangeTherapy\".range_therapy_long", RangeTherapy);
            }

            if (DateVlStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"vn\".acl_sample_date", DateOnly.Parse(DateVlStart).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (DateVlEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"vn\".acl_sample_date", DateOnly.Parse(DateVlEnd).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (ResVlStart != null && ResVlStart.Length != 0)
            {
                whereStr.AddWhereIntConvertMore("\"vn\".acl_mcn_code", Int32.Parse(ResVlStart));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (ResVlEnd != null && ResVlEnd.Length != 0)
            {
                whereStr.AddWhereIntConvertLess("\"vn\".acl_mcn_code", Int32.Parse(ResVlEnd));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (DateIMStart?.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"im\".acl_sample_date", DateOnly.Parse(DateIMStart).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (DateImEnd?.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"im\".acl_sample_date", DateOnly.Parse(DateImEnd).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            //                //(resImStart.Length != 0 && IsImStart ? e.ImResult >= ResImStart : true) &&
            //                //(resImEnd.Length != 0 && IsImEnd ? e.ImResult <= ResImEnd : true)

            #endregion
        }
    }
}
