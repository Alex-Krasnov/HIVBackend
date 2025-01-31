using HIVBackend.Enums;
using HIVBackend.Services;
using System;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchChildInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string DateDieStart { get; set; } = string.Empty;
        public string DateDieEnd { get; set; } = string.Empty;
        public string DateDieAidsStart { get; set; } = string.Empty;
        public string DateDieAidsEnd { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };

        public string AgeDayStart { get; set; } = string.Empty;
        public string AgeDayEnd { get; set; } = string.Empty;
        public string[] FamilyType { get; set; } = new string[] { "Все" };
        public string FirstCheckDateStart { get; set; } = string.Empty;
        public string FirstCheckDateEnd { get; set; } = string.Empty;
        public string[] ChildPlace { get; set; } = new string[] { "Все" };
        public string BreastMonthNoStart { get; set; } = string.Empty;
        public string BreastMonthNoEnd { get; set; } = string.Empty;
        public string[] ChildPhp { get; set; } = new string[] { "Все" };
        public string MotherPatientId { get; set; } = string.Empty;
        public string FatherPatientId { get; set; } = string.Empty;
        public string[] MaterHome { get; set; } = new string[] { "Все" };
        public string Form309 { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; } = false;
        public bool SelectDieDate { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectArt { get; set; } = false;

        public bool SelectFamilyType { get; set; } = false;
        public bool SelectFirstCheckDate { get; set; } = false;
        public bool SelectChildPlace { get; set; } = false;
        public bool SelectBreastMonthNo { get; set; } = false;
        public bool SelectChildPhp { get; set; } = false;
        public bool SelectParentId { get; set; } = false;
        public bool SelectMaterHome { get; set; } = false;
        public bool SelectForm309 { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchChildInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectBirthDate")
                    {
                        columName.Add("Возраст в днях");
                        selectGroupSrt.AppendLine(",now()::date - \"tblPatientCard\".birth_date");
                    }

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

                    if (key.Name == "SelectFamilyType")
                    {
                        columName.Add("Состав семьи");
                        selectGroupSrt.AppendLine(",\"tblFamilyType\".family_type_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblFamilyType", field: "family_type_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectFirstCheckDate")
                    {
                        columName.Add("Дата 1-го визита");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".check_first_date");
                    }

                    if (key.Name == "SelectChildPlace")
                    {
                        columName.Add("Распол отказ реб");
                        selectGroupSrt.AppendLine(",\"tblChildPlace\".child_place_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPlace", field: "child_place_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectBreastMonthNo")
                    {
                        columName.Add("Месяц грудного вскармливания");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".breast_month_no");
                    }

                    if (key.Name == "SelectChildPhp")
                    {
                        columName.Add("Профилактика ПХП");
                        selectGroupSrt.AppendLine(",\"tblChildPHP\".child_php_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPHP", field: "child_php_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectParentId")
                    {
                        columName.Add("Зарег. мать");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".mother_patient_id");
                        columName.Add("Зарег. мать фамилия");
                        selectGroupSrt.AppendLine(",\"tblPatientCardMather\".family_name");
                        columName.Add("Зарег. мать имя");
                        selectGroupSrt.AppendLine(",\"tblPatientCardMather\".first_name");
                        columName.Add("Зарег. мать отчество");
                        selectGroupSrt.AppendLine(",\"tblPatientCardMather\".third_name");

                        columName.Add("Зарег. отец");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".father_patient_id");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblPatientCard", 
                                                               fieldLeft: "mother_patient_id", 
                                                               fieldRight: "patient_id", 
                                                               table: "tblPatientCard", 
                                                               alias: "tblPatientCardMather");
                    }

                    if (key.Name == "SelectMaterHome")
                    {
                        columName.Add("Роддом");
                        selectGroupSrt.AppendLine(",\"tblMaterHome\".materhome_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectForm309")
                    {
                        columName.Add("Форма 309");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".forma_309");
                    }
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

            if (CardNo.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".card_no", CardNo);
            }

            if (Art[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblArvt\".arvt_long", Art);
            }

            if (AgeDayStart.Length != 0)
            {
                whereStr.AddWhereIntConvertMore("now()::date - \"tblPatientCard\".birth_date", int.Parse(AgeDayStart));
            }

            if (AgeDayEnd.Length != 0)
            {
                whereStr.AddWhereIntConvertLess("now()::date - \"tblPatientCard\".birth_date", int.Parse(AgeDayEnd));
            }

            if (FamilyType[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblFamilyType", field: "family_type_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblFamilyType\".family_type_long", FamilyType);
            }

            if (FirstCheckDateStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".check_first_date", DateOnly.Parse(FirstCheckDateStart).ToString("dd-MM-yyyy"));
            }

            if (FirstCheckDateEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".check_first_date", DateOnly.Parse(FirstCheckDateEnd).ToString("dd-MM-yyyy"));
            }

            if (ChildPlace[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPlace", field: "child_place_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblChildPlace\".child_place_long", ChildPlace);
            }

            if (BreastMonthNoStart.Length != 0)
            {
                whereStr.AddWhereIntConvertMore("\"tblPatientCard\".breast_month_no", int.Parse(BreastMonthNoStart));
            }

            if (BreastMonthNoEnd.Length != 0)
            {
                whereStr.AddWhereIntConvertLess("\"tblPatientCard\".breast_month_no", int.Parse(BreastMonthNoEnd));
            }

            if (ChildPhp[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPHP", field: "child_php_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblChildPHP\".child_php_long", ChildPhp);
            }

            if (MotherPatientId.Length != 0)
            {
                whereStr.AddWhereSqlEqual("\"tblPatientCard\".mother_patient_id", MotherPatientId);
            }

            if (FatherPatientId.Length != 0)
            {
                whereStr.AddWhereSqlEqual("\"tblPatientCard\".father_patient_id", FatherPatientId);
            }

            if (MaterHome[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblMaterHome\".materhome_long", MaterHome);
            }

            if (Form309 == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlEqual("\"tblPatientCard\".forma_309", "1");
            }

            if (Form309 == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlEqual("\"tblPatientCard\".forma_309", "2");
            }

            #endregion
        }
    }
}
