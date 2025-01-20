using HIVBackend.Data;
using HIVBackend.Enums;
using HIVBackend.Services;
using System;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchMainInfInputForm : BaseSearchInputForm
    {
        #region поля

        public string FioChange { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string[] BlotCheckPlace { get; set; } = new string[] { "Все" };
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
        public string[] HospCourse { get; set; } = new string[] { "Все" };
        public string[] Age { get; set; } = new string[] { "Все" };
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };
        public string[] Mkb10 { get; set; } = new string[] { "Все" };
        public string ArchiveYNA { get; set; } =  = YNAEnum.All.ToEnumDescriptionNameString();
        public string Archive { get; set; } = string.Empty;
        public string TransfFederYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateTransfFederStart { get; set; } = string.Empty;
        public string DateTransfFederEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string Aids12 { get; set; } = string.Empty;
        public string DieDiagYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string Chemprof { get; set; } = string.Empty;
        public string DateChemprofStartStart { get; set; } = string.Empty;
        public string DateChemprofStartEnd { get; set; } = string.Empty;
        public string DateChemprofEndStart { get; set; } = string.Empty;
        public string DateChemprofEndEnd { get; set; } = string.Empty;
        public string DateRegStart { get; set; } = string.Empty;
        public string DateRegEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; } = false;
        public bool SelectBlotCheckPlace { get; set; } = false;
        public bool SelectDieDate { get; set; } = false;
        public bool SelectDieCourse { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectIb { get; set; } = false;
        public bool SelectHospCourse { get; set; } = false;
        public bool SelectAge { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectArt { get; set; } = false;
        public bool SelectMkb10 { get; set; } = false;
        public bool SelectArchive { get; set; } = false;
        public bool SelectTransfFeder { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectAids12 { get; set; } = false;
        public bool SelectChemprof { get; set; } = false;
        public bool SelectDieDiag { get; set; } = false;
        public bool SelectDateReg { get; set; } = false;
        public bool SelectPasSer { get; set; } = false;
        public bool SelectPasNum { get; set; } = false;
        public bool SelectPasWhom { get; set; } = false;
        public bool SelectPasWhen { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchMainInfInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectSex")
                    {
                        columName.Add("Пол");
                        selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectBlotCheckPlace")
                    {
                        columName.Add("Место лаб. исследования");
                        selectGroupSrt.AppendLine(",\"tblCheckPlace\".check_place_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckPlace", field: "check_place_id", table: "tblPatientBlot");
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

                    if (key.Name == "SelectHospCourse")
                    {
                        columName.Add("Причина госпитализации");
                        selectGroupSrt.AppendLine(",\"tblHospCourse\".hosp_course_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHosp", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospCourse", field: "hosp_course_id", table: "tblPatientHosp");
                    }

                    if (key.Name == "SelectHospCourse")
                    {
                        columName.Add("Причина госпитализации");
                        selectGroupSrt.AppendLine(",\"tblHospCourse\".hosp_course_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHosp", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospCourse", field: "hosp_course_id", table: "tblPatientHosp");
                    }

                    if (key.Name == "SelectAge")
                    {
                        columName.Add("Возраст");
                        selectGroupSrt.AppendLine(",date_part('year'::text, age(\"tblPatientCard\".birth_date::timestamp with time zone))::integer");
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

                    if (key.Name == "SelectMkb10")
                    {
                        columName.Add("Код МКБ10");
                        selectGroupSrt.AppendLine(",\"tblCodeMKB10\".code_mkb10_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCodeMKB10", field: "code_mkb10_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectArchive")
                    {
                        columName.Add("Архив");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".snils_fed");
                    }

                    if (key.Name == "SelectTransfFeder")
                    {
                        columName.Add("Дата передачи в субъект федерации");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".transf_feder_date");
                    }

                    if (key.Name == "SelectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
                    }

                    if (key.Name == "SelectAids12")
                    {
                        columName.Add("Вич 1 2");
                        selectGroupSrt.AppendLine(",\"tblAids12\".aids12_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblAids12", field: "aids12_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectChemprof")
                    {
                        columName.Add("Химиопрофилактика");
                        selectGroupSrt.AppendLine(",\"tblChemop\".chemop_long");

                        columName.Add("Химиопрофилактика с");
                        selectGroupSrt.AppendLine(",\"tblPatientChemop\".chemop_date_from");

                        columName.Add("Химиопрофилактика по");
                        selectGroupSrt.AppendLine(",\"tblPatientChemop\".chemop_date_to");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblChemop", field: "chemop_id", table: "tblPatientChemop");
                    }

                    if (key.Name == "SelectDieDiag")
                    {
                        columName.Add("Диагноз посмертно");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_diagnosis_after_death");
                    }

                    if (key.Name == "SelectDateReg")
                    {
                        columName.Add("Дата регистрации нач");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".dt_reg_beg");

                        columName.Add("Дата регистрации кон");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".dt_reg_end");
                    }

                    if (key.Name == "SelectPasSer")
                    {
                        columName.Add("Паспорт серия");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_ser");
                    }

                    if (key.Name == "SelectPasNum")
                    {
                        columName.Add("Паспорт номер");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_num");
                    }

                    if (key.Name == "SelectPasWhom")
                    {
                        columName.Add("Паспорт выдан");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_when");
                    }

                    if (key.Name == "SelectPasWhen")
                    {
                        columName.Add("Паспорт Дата выдачи");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_whom");
                    }
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (FioChange.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".fio_change", FioChange);
            }

            if (Sex.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqualString("\"tblSex\".sex_short", Sex);
            }

            if (BlotCheckPlace[0] != "Все")
            {
                whereStr.AddWhereSqlIn("\"tblCheckPlace\".check_place_long", BlotCheckPlace);

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckPlace", field: "check_place_id", table: "tblPatientBlot");
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

            if (HospCourse[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHosp", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospCourse", field: "hosp_course_id", table: "tblPatientHosp");
                whereStr.AddWhereSqlIn("\"tblShowIllness\".show_illness_long", HospCourse);
            }

            if (Age[0] != "Все")
            {
                const string sqlAge = "date_part('year'::text, age(\"tblPatientCard\".birth_date::timestamp with time zone))::integer";

                #region age

                var ages = new List<string>();

                using (HivContext context = new())
                {
                    foreach (var item in Age)
                    {
                        var tblAgegr = context.TblAgegrs.FirstOrDefault(e => e.AgegrLong == item);

                        if (tblAgegr.Start1 == null || tblAgegr.End1 == null)
                            continue;

                        for (int i = (int)tblAgegr.Start1; i <= (int)tblAgegr.End1; i++)
                            ages.Add($"{i}");
                    }
                }

                #endregion

                whereStr.AddWhereSqlIn(sqlAge, ages.ToArray());
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

            if (Mkb10[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCodeMKB10", field: "code_mkb10_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblCodeMKB10\".code_mkb10_long", Mkb10);
            }

            if (ArchiveYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".snils_fed");
            }

            if (ArchiveYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".snils_fed");
            }

            if (TransfFederYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".transf_feder_date");
            }

            if (TransfFederYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".transf_feder_date");
            }

            if (DateTransfFederStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".transf_feder_date", DateOnly.Parse(DateTransfFederStart).ToString("dd-MM-yyyy"));
            }

            if (DateTransfFederEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".transf_feder_date", DateOnly.Parse(DateTransfFederEnd).ToString("dd-MM-yyyy"));
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

            if (Aids12.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblAids12", field: "aids12_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqualString("\"tblAids12\".aids12_long", Aids12);
            }

            if (DieDiagYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".flg_diagnosis_after_death");
            }

            if (DieDiagYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".flg_diagnosis_after_death");
            }

            if (Chemprof.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblChemop", field: "chemop_id", table: "tblPatientChemop");
                whereStr.AddWhereSqlEqualString("\"tblChemop\".chemop_long", Chemprof);
            }

            if (DateChemprofStartStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientChemop\".chemop_date_from", DateOnly.Parse(DateChemprofStartStart).ToString("dd-MM-yyyy"));
            }

            if (DateChemprofStartEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientChemop\".chemop_date_from", DateOnly.Parse(DateChemprofStartEnd).ToString("dd-MM-yyyy"));
            }

            if (DateChemprofEndStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientChemop\".chemop_date_to", DateOnly.Parse(DateChemprofEndStart).ToString("dd-MM-yyyy"));
            }

            if (DateChemprofEndEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientChemop\".chemop_date_to", DateOnly.Parse(DateChemprofEndEnd).ToString("dd-MM-yyyy"));
            }

            if (DateRegStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".dt_reg_beg", DateOnly.Parse(DateRegStart).ToString("dd-MM-yyyy"));
            }

            if (DateRegEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".dt_reg_beg", DateOnly.Parse(DateRegEnd).ToString("dd-MM-yyyy"));
            }

            #endregion
        }
    }
}
