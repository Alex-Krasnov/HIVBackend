using DocumentFormat.OpenXml.Presentation;
using HIVBackend.Enums;
using HIVBackend.Helpers;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchPregnantInputForm : BaseSearchInputForm
    {
        #region поля

        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };

        public string[] PregCheck { get; set; } = new string[] { "Все" };
        public string PregMonthNo { get; set; } = string.Empty;
        public string[] BirthType { get; set; } = new string[] { "Все" };
        public string MedecineStartMonthNo { get; set; } = string.Empty;
        public string ChildBirthDateStart { get; set; } = string.Empty;
        public string ChildBirthDateEnd { get; set; } = string.Empty;
        public string ChildFamilyName { get; set; } = string.Empty;
        public string ChildFirstName { get; set; } = string.Empty;
        public string ChildThirdName { get; set; } = string.Empty;
        public string[] PhpSchema1 { get; set; } = new string[] { "Все" };
        public string[] PhpSchema2 { get; set; } = new string[] { "Все" };
        public string[] PhpSchema3 { get; set; } = new string[] { "Все" };
        public string[] MedecineForSchema1 { get; set; } = new string[] { "Все" };
        public string[] MedecineForSchema2 { get; set; } = new string[] { "Все" };
        public string[] MedecineForSchema3 { get; set; } = new string[] { "Все" };
        public string[] Materhome { get; set; } = new string[] { "Все" };
        public string AclDateStart { get; set; } = string.Empty;
        public string AclDateEnd { get; set; } = string.Empty;
        public string AclMcnCodeStart { get; set; } = string.Empty;
        public string AclMcnCodeEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectArt { get; set; } = false;

        public bool SelectPregCheck { get; set; } = false;
        public bool SelectPregMonthNo { get; set; } = false;
        public bool SelectBirthType { get; set; } = false;
        public bool SelectMedecineStartMonthNo { get; set; } = false;
        public bool SelectChildBirthDate { get; set; } = false;
        public bool SelectChildFio { get; set; } = false;
        public bool SelectPhpSchema1 { get; set; } = false;
        public bool SelectPhpSchema2 { get; set; } = false;
        public bool SelectPhpSchema3 { get; set; } = false;
        public bool SelectMedecineForSchema1 { get; set; } = false;
        public bool SelectMedecineForSchema2 { get; set; } = false;
        public bool SelectMedecineForSchema3 { get; set; } = false;
        public bool SelectMaterhome { get; set; } = false;
        public bool SelectAclDate { get; set; } = false;
        public bool SelectAclMcnCode { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchPregnantInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
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

                    if (key.Name == "SelectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
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

                    if (key.Name == "SelectPregCheck")
                    {
                        columName.Add("Выявление");
                        selectGroupSrt.AppendLine(",\"tblPregCheck\".preg_check_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPregCheck", field: "preg_check_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectPregMonthNo")
                    {
                        columName.Add("Срок беременности");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".preg_month_no");
                    }

                    if (key.Name == "SelectBirthType")
                    {
                        columName.Add("Вид родов");
                        selectGroupSrt.AppendLine(",\"tblBirthType\".birth_type_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblBirthType", field: "birth_type_id", table: "tblPatientPregnantM");
                    }

                    if (key.Name == "SelectMedecineStartMonthNo")
                    {
                        columName.Add("Срок начала приёма медик.");
                        selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".medicine_st_month_no_old");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectChildBirthDate")
                    {
                        columName.Add("Дата родов");
                        selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_birth_date");

                        columName.Add("Дата начала берем");
                        selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".preg_date");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectChildFio")
                    {
                        columName.Add("Фамилия ребёнка");
                        selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_family_name");

                        columName.Add("Имя ребёнка");
                        selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_first_name");

                        columName.Add("Отчество ребёнка");
                        selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_third_name");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectPhpSchema1")
                    {
                        columName.Add("ПХП1 схема");
                        selectGroupSrt.AppendLine(",\"php1\".cure_schema_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema", 
                                                               fieldLeft: "phpschema_id1", 
                                                               fieldRight: "cure_schema_id", 
                                                               table: "tblPatientPregnantM",
                                                               alias: "php1");
                    }

                    if (key.Name == "SelectPhpSchema2")
                    {
                        columName.Add("ПХП2 схема");
                        selectGroupSrt.AppendLine(",\"php2\".cure_schema_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                               fieldLeft: "phpschema_id2",
                                                               fieldRight: "cure_schema_id",
                                                               table: "tblPatientPregnantM",
                                                               alias: "php2");
                    }

                    if (key.Name == "SelectPhpSchema3")
                    {
                        columName.Add("ПХП3 схема");
                        selectGroupSrt.AppendLine(",\"php3\".cure_schema_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                               fieldLeft: "phpschema_id3",
                                                               fieldRight: "cure_schema_id",
                                                               table: "tblPatientPregnantM",
                                                               alias: "php3");
                    }

                    if (key.Name == "SelectMedecineForSchema1")
                    {
                        columName.Add("ПХП1 препарат");
                        selectGroupSrt.AppendLine(",\"tblMedicineForSchema1\".medforschema_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                               fieldLeft: "phpschema_id1",
                                                               fieldRight: "cure_schema_id",
                                                               table: "tblPatientPregnantM",
                                                               alias: "php1");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR",
                                                      field: "cure_schema_id",
                                                      table: "php1",
                                                      alias: "tblSchemaMedicineR1");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                               fieldLeft: "medicine_id",
                                                               fieldRight: "medforschema_id",
                                                               table: "tblSchemaMedicineR1",
                                                               alias: "tblMedicineForSchema1");
                    }

                    if (key.Name == "SelectMedecineForSchema2")
                    {
                        columName.Add("ПХП2 препарат");
                        selectGroupSrt.AppendLine(",\"tblMedicineForSchema2\".medforschema_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                               fieldLeft: "phpschema_id2",
                                                               fieldRight: "cure_schema_id",
                                                               table: "tblPatientPregnantM",
                                                               alias: "php2");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR",
                                                      field: "cure_schema_id",
                                                      table: "php2",
                                                      alias: "tblSchemaMedicineR2");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                               fieldLeft: "medicine_id",
                                                               fieldRight: "medforschema_id",
                                                               table: "tblSchemaMedicineR2",
                                                               alias: "tblMedicineForSchema2");
                    }

                    if (key.Name == "SelectMedecineForSchema3")
                    {
                        columName.Add("ПХП3 препарат");
                        selectGroupSrt.AppendLine(",\"tblMedicineForSchema3\".medforschema_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                               fieldLeft: "phpschema_id3",
                                                               fieldRight: "cure_schema_id",
                                                               table: "tblPatientPregnantM",
                                                               alias: "php3");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR",
                                                      field: "cure_schema_id",
                                                      table: "php3",
                                                      alias: "tblSchemaMedicineR3");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                               fieldLeft: "medicine_id",
                                                               fieldRight: "medforschema_id",
                                                               table: "tblSchemaMedicineR3",
                                                               alias: "tblMedicineForSchema3");
                    }

                    if (key.Name == "SelectMaterhome")
                    {
                        columName.Add("Роддом");
                        selectGroupSrt.AppendLine(",\"tblMaterHome\".materhome_long");

                        columName.Add("Ид ребёнка");
                        selectGroupSrt.AppendLine(",\"qryParentChild\".child_id");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "qryParentChild", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "qryParentChild");
                    }

                    if (key.Name == "SelectAclDate")
                    {
                        columName.Add("Дата опред.иммун.стат.");
                        selectGroupSrt.AppendLine(",\"tblPatientAclResult\".acl_sample_date");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                                     $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                                     $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);
                    }

                    if (key.Name == "SelectAclMcnCode")
                    {
                        columName.Add("CD4+(abc)");
                        selectGroupSrt.AppendLine(",\"tblPatientAclResult\".acl_mcn_code");

                        string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                                     $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                                     $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

                        if (!joinStr.ToString().Contains(str))
                            joinStr.AppendLine(str);
                    }
                }
            }

            #endregion

            #region Генерация строки WHERE

            // чтобы были только беременые
            whereStr.Append($" AND (\"tblPatientCard\".preg_month_no IS NOT NULL " +
                                    $"OR \"tblPatientPregnantM\".preg_id IS NOT NULL " +
                                    $"OR \"tblPatientCard\".preg_check_id IS NOT NULL)");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");

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

            if (CardNo.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".card_no", CardNo);
            }

            if (Art[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblArvt\".arvt_long", Art);
            }

            if (PregCheck[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPregCheck", field: "preg_check_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblPregCheck\".preg_check_long", PregCheck);
            }

            if (PregMonthNo.Length != 0)
            {
                whereStr.AddWhereSqlEqual("\"tblPatientCard\".preg_month_no", PregMonthNo);
            }

            if (BirthType[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblBirthType", field: "birth_type_id", table: "tblPatientPregnantM");
                whereStr.AddWhereSqlIn("\"tblBirthType\".birth_type_long", BirthType);
            }

            if (MedecineStartMonthNo.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblPatientPregnantM\".medicine_st_month_no_old", MedecineStartMonthNo);
            }

            if (ChildBirthDateStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientPregnantM\".child_birth_date", DateOnly.Parse(ChildBirthDateStart).ToString("dd-MM-yyyy"));
            }

            if (ChildBirthDateEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientPregnantM\".child_birth_date", DateOnly.Parse(ChildBirthDateEnd).ToString("dd-MM-yyyy"));
            }

            if (ChildFamilyName.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientPregnantM\".child_family_name", ChildFamilyName);
            }

            if (ChildFirstName.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientPregnantM\".child_first_name", ChildFirstName);
            }

            if (ChildThirdName.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientPregnantM\".child_third_name", ChildThirdName);
            }

            if (PhpSchema1[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                       fieldLeft: "phpschema_id1",
                                                       fieldRight: "cure_schema_id",
                                                       table: "tblPatientPregnantM",
                                                       alias: "php1");
                whereStr.AddWhereSqlIn("\"php1\".cure_schema_long", PhpSchema1);
            }

            if (PhpSchema2[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                       fieldLeft: "phpschema_id2",
                                                       fieldRight: "cure_schema_id",
                                                       table: "tblPatientPregnantM",
                                                       alias: "php2");
                whereStr.AddWhereSqlIn("\"php2\".cure_schema_long", PhpSchema2);
            }

            if (PhpSchema3[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                       fieldLeft: "phpschema_id3",
                                                       fieldRight: "cure_schema_id",
                                                       table: "tblPatientPregnantM",
                                                       alias: "php3");
                whereStr.AddWhereSqlIn("\"php3\".cure_schema_long", PhpSchema3);
            }

            if (MedecineForSchema1[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");

                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                       fieldLeft: "phpschema_id1",
                                                       fieldRight: "cure_schema_id",
                                                       table: "tblPatientPregnantM",
                                                       alias: "php1");

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR",
                                              field: "cure_schema_id",
                                              table: "php1",
                                              alias: "tblSchemaMedicineR1");

                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                       fieldLeft: "medicine_id",
                                                       fieldRight: "medforschema_id",
                                                       table: "tblSchemaMedicineR1",
                                                       alias: "tblMedicineForSchema1");

                whereStr.AddWhereSqlIn("\"tblMedicineForSchema1\".medforschema_long", MedecineForSchema1);
            }

            if (MedecineForSchema2[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");

                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                       fieldLeft: "phpschema_id2",
                                                       fieldRight: "cure_schema_id",
                                                       table: "tblPatientPregnantM",
                                                       alias: "php2");

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR",
                                              field: "cure_schema_id",
                                              table: "php2",
                                              alias: "tblSchemaMedicineR2");

                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                       fieldLeft: "medicine_id",
                                                       fieldRight: "medforschema_id",
                                                       table: "tblSchemaMedicineR2",
                                                       alias: "tblMedicineForSchema2");

                whereStr.AddWhereSqlIn("\"tblMedicineForSchema2\".medforschema_long", MedecineForSchema2);
            }

            if (MedecineForSchema3[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");

                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                       fieldLeft: "phpschema_id3",
                                                       fieldRight: "cure_schema_id",
                                                       table: "tblPatientPregnantM",
                                                       alias: "php3");

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR",
                                              field: "cure_schema_id",
                                              table: "php3",
                                              alias: "tblSchemaMedicineR3");

                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                       fieldLeft: "medicine_id",
                                                       fieldRight: "medforschema_id",
                                                       table: "tblSchemaMedicineR3",
                                                       alias: "tblMedicineForSchema3");

                whereStr.AddWhereSqlIn("\"tblMedicineForSchema3\".medforschema_long", MedecineForSchema3);
            }

            if (Materhome[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "qryParentChild", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "qryParentChild");
                whereStr.AddWhereSqlIn("\"tblMaterHome\".materhome_long", Materhome);
            }

            if (AclDateStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientAclResult\".acl_sample_date", DateOnly.Parse(AclDateStart).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                             $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                             $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            if (AclDateEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientAclResult\".acl_sample_date", DateOnly.Parse(AclDateEnd).ToString("dd-MM-yyyy"));

                string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                             $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                             $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

                if (!joinStr.ToString().Contains(str))
                    joinStr.AppendLine(str);
            }

            #endregion
        }
    }
}
