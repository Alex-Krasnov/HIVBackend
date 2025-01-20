using HIVBackend.Data;
using HIVBackend.Enums;
using HIVBackend.Services;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchEpidInputForm : BaseSearchInputForm
    {
        #region поля

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
        public string TransfFederYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateTransfFederStart { get; set; } = string.Empty;
        public string DateTransfFederEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string Aids12 { get; set; } = string.Empty;

        public string DtMailRegStart { get; set; } = string.Empty;
        public string DtMailRegEnd { get; set; } = string.Empty;
        public string[] Education { get; set; } = new string[] { "Все" };
        public string[] FamilyStatus { get; set; } = new string[] { "Все" };
        public string[] Employment { get; set; } = new string[] { "Все" };
        public string[] Trans { get; set; } = new string[] { "Все" };
        public string[] PlaceCheck { get; set; } = new string[] { "Все" };
        public string[] SituationDetect { get; set; } = new string[] { "Все" };
        public string[] TransmisionMech { get; set; } = new string[] { "Все" };
        public string[] VulnerableGroup { get; set; } = new string[] { "Все" };
        public string VacName { get; set; } = string.Empty;
        public string VacDateStart { get; set; } = string.Empty;
        public string VacDateEnd { get; set; } = string.Empty;
        public string CovidMkb10 { get; set; } = string.Empty;
        public string CovidDateStart { get; set; } = string.Empty;
        public string CovidDateEnd { get; set; } = string.Empty;
        public string ChemsexYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string ChemsexContactType { get; set; } = string.Empty;
        public string PavInjYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string PavInjDateStart { get; set; } = string.Empty;
        public string PavInjDateEnd { get; set; } = string.Empty;
        public string PavNotInjYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string PavNotInjDateStart { get; set; } = string.Empty;
        public string PavNotInjDateEnd { get; set; } = string.Empty;
        public string TimeInfectDateStart { get; set; } = string.Empty;
        public string TimeInfectDateEnd { get; set; } = string.Empty;
        public string EpidDescr { get; set; } = string.Empty;
        public string[] Callstatus { get; set; } = new string[] { "Все" };
        public string CallDateStart { get; set; } = string.Empty;
        public string CallDateEnd { get; set; } = string.Empty;

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
        public bool SelectTransfFeder { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectAids12 { get; set; } = false;

        public bool SelectDtMailReg { get; set; } = false;
        public bool SelectEdu { get; set; } = false;
        public bool SelectFamilyStatus { get; set; } = false;
        public bool SelectEmployment { get; set; } = false;
        public bool SelectTrans { get; set; } = false;
        public bool SelectPlaceCheck { get; set; } = false;
        public bool SelectSituationDetect { get; set; } = false;
        public bool SelectTransmisionMech { get; set; } = false;
        public bool SelectVulnerableGroup { get; set; } = false;
        public bool SelectCovidVac { get; set; } = false;
        public bool SelectCovid { get; set; } = false;
        public bool SelectChemsex { get; set; } = false;
        public bool SelectPavInj { get; set; } = false;
        public bool SelectPavNotInj { get; set; } = false;
        public bool SelectTimeInfect { get; set; } = false;
        public bool SelectEpidDescr { get; set; } = false;
        public bool SelectPatientCall {  get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchEpidInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
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
                        selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
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

                    if (key.Name == "SelectDtMailReg")
                    {
                        columName.Add("Дата письма в др.регион");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".dt_mail_reg");
                    }

                    if (key.Name == "SelectEdu")
                    {
                        columName.Add("Образование");
                        selectGroupSrt.AppendLine(",\"tblListEducation\".edu_name");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListEducation", 
                                                               fieldLeft: "edu_id", 
                                                               fieldRight: "education_id", 
                                                               table: "tblPatientCard");
                    }

                    if (key.Name == "SelectFamilyStatus")
                    {
                        columName.Add("Семейное положение");
                        selectGroupSrt.AppendLine(",\"tblListFamilyStatus\".fammily_status_name");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListFamilyStatus", field: "family_status_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectEmployment")
                    {
                        columName.Add("Занятость");
                        selectGroupSrt.AppendLine(",\"tblListEmployment\".employment_name");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListEmployment", field: "employment_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectTrans")
                    {
                        columName.Add("Трансгендерность");
                        selectGroupSrt.AppendLine(",\"tblListTrans\".trans_name");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTrans", field: "trans_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectPlaceCheck")
                    {
                        columName.Add("Место выявления");
                        selectGroupSrt.AppendLine(",\"tblListPlaceCheck\".place_check_name");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListPlaceCheck", field: "place_check_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectSituationDetect")
                    {
                        columName.Add("Обст. выявления");
                        selectGroupSrt.AppendLine(",\"tblListSituationDetect\".situation_detect_name");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListSituationDetect", field: "situation_detect_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectTransmisionMech")
                    {
                        columName.Add("Вер. мех. передачи");
                        selectGroupSrt.AppendLine(",\"tblListTransmisionMech\".transmisiom_mech_name");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTransmisionMech", field: "transmission_mech_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectVulnerableGroup")
                    {
                        columName.Add("Кат. уязвимой группы");
                        selectGroupSrt.AppendLine(",\"tblListVulnerableGroup\".vulnerable_group_name");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListVulnerableGroup", field: "vulnerable_group_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectCovidVac")
                    {
                        columName.Add("Дата 1 дозы");
                        selectGroupSrt.AppendLine(",\"tblCOVID_vac\".d_vac1");
                        columName.Add("Дата 2 дозы");
                        selectGroupSrt.AppendLine(",\"tblCOVID_vac\".d_vac2");
                        columName.Add("Наименование вакцины");
                        selectGroupSrt.AppendLine(",\"tblListVac\".vac_name");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID_vac", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListVac", field: "vac_id", table: "tblCOVID_vac");
                    }

                    if (key.Name == "SelectCovid")
                    {
                        columName.Add("Дата пол. рез");
                        selectGroupSrt.AppendLine(",\"tblCOVID\".d_positiv_res_covid");

                        columName.Add("Дата отриц. рез");
                        selectGroupSrt.AppendLine(",\"tblCOVID\".d_negative_res_covid");

                        columName.Add("Диагноз МКБ10 COVID");
                        selectGroupSrt.AppendLine(",\"tblListMkb10COVID\".mkb10_long_name");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListMkb10COVID", 
                                                               fieldLeft: "covid_MKB10", 
                                                               fieldRight: "MKB10_id", 
                                                               table: "tblCOVID");
                    }

                    if (key.Name == "SelectChemsex")
                    {
                        columName.Add("Химсекс(Да/Нет)");
                        selectGroupSrt.AppendLine(",\"tblListYNChemsex\".y_n_name");

                        columName.Add("Химсекс(Вид контакта)");
                        selectGroupSrt.AppendLine(",\"ChemSexContactType\".infect_course_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactChemsex", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblInfectCourse",
                                                               fieldLeft: "contact_type",
                                                               fieldRight: "infect_course_id",
                                                               table: "tblPatientContactChemsex",
                                                               alias: "ChemSexContactType");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                               fieldLeft: "y_n_id",
                                                               fieldRight: "id_y_n",
                                                               table: "tblPatientContactChemsex",
                                                               alias: "tblListYNChemsex");
                    }

                    if (key.Name == "SelectPavInj")
                    {
                        columName.Add("ПАВ инек. дата начала");
                        selectGroupSrt.AppendLine(",\"tblPatientContactPavInj\".date_start");

                        columName.Add("ПАВ инек. дата окончания");
                        selectGroupSrt.AppendLine(",\"tblPatientContactPavInj\".date_end");

                        columName.Add("ПАВ инек. (да/нет)");
                        selectGroupSrt.AppendLine(",\"tblListYNPavInj\".y_n_name");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                               fieldLeft: "y_n_id",
                                                               fieldRight: "id_y_n",
                                                               table: "tblPatientContactPavInj",
                                                               alias: "tblListYNPavInj");
                    }

                    if (key.Name == "SelectPavNotInj")
                    {
                        columName.Add("ПАВ неинек. дата начала");
                        selectGroupSrt.AppendLine(",\"tblPatientContactPavNotInj\".date_start");

                        columName.Add("ПАВ неинек. дата окончания");
                        selectGroupSrt.AppendLine(",\"tblPatientContactPavNotInj\".date_end");

                        columName.Add("ПАВ неинек. (да/нет)");
                        selectGroupSrt.AppendLine(",\"tblListYNPavNotInj\".y_n_name");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                               fieldLeft: "y_n_id",
                                                               fieldRight: "id_y_n",
                                                               table: "tblPatientContactPavNotInj",
                                                               alias: "tblListYNPavNotInj");
                    }

                    if (key.Name == "SelectTimeInfect")
                    {
                        columName.Add("Вероятные сроки инфиц. с");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".epidem_time_infect_start");

                        columName.Add("Вероятные сроки инфиц. по");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".epidem_time_infect_end");
                    }

                    if (key.Name == "SelectEpidDescr")
                    {
                        columName.Add("Эпид. примечание");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".epidem_descr");
                    }

                    if (key.Name == "SelectPatientCall")
                    {
                        columName.Add("Дата звонка");
                        selectGroupSrt.AppendLine(",\"tblPatientCall\".call_date");

                        columName.Add("Статус звонка");
                        selectGroupSrt.AppendLine(",\"tblListCallStatus\".long_name");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblListCallStatus", field: "call_status_id", table: "tblPatientCall");
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
                whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", new[] { "1", "3" } );
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
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".die_course_long", Mkb10);
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

            if (DtMailRegStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".dt_mail_reg", DateOnly.Parse(DtMailRegStart).ToString("dd-MM-yyyy"));
            }

            if (DtMailRegEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".dt_mail_reg", DateOnly.Parse(DtMailRegEnd).ToString("dd-MM-yyyy"));
            }

            if (Education[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListEducation",
                                                       fieldLeft: "edu_id",
                                                       fieldRight: "education_id",
                                                       table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListEducation\".edu_name", Education);
            }

            if (FamilyStatus[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListFamilyStatus", field: "family_status_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListFamilyStatus\".fammily_status_name", FamilyStatus);
            }

            if (Employment[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListEmployment", field: "employment_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListEmployment\".employment_name", Employment);
            }

            if (Trans[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTrans", field: "trans_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListTrans\".trans_name", Trans);
            }

            if (PlaceCheck[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListPlaceCheck", field: "place_check_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListPlaceCheck\".place_check_name", PlaceCheck);
            }

            if (SituationDetect[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListSituationDetect", field: "situation_detect_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListSituationDetect\".situation_detect_name", SituationDetect);
            }

            if (TransmisionMech[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTransmisionMech", field: "transmission_mech_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListTransmisionMech\".transmisiom_mech_name", TransmisionMech);
            }

            if (VulnerableGroup[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListVulnerableGroup", field: "vulnerable_group_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblListVulnerableGroup\".vulnerable_group_name", VulnerableGroup);
            }

            if (VacName.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID_vac", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListVac", field: "vac_id", table: "tblCOVID_vac");
                whereStr.AddWhereSqlEqualString("\"tblListVac\".vac_name", VacName);
            }

            if (VacDateStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID_vac", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblCOVID_vac\".d_vac1", DateOnly.Parse(VacDateStart).ToString("dd-MM-yyyy"));
            }

            if (VacDateEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID_vac", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblCOVID_vac\".d_vac1", DateOnly.Parse(VacDateEnd).ToString("dd-MM-yyyy"));
            }

            if (CovidMkb10.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListMkb10COVID",
                                                       fieldLeft: "covid_MKB10",
                                                       fieldRight: "MKB10_id",
                                                       table: "tblCOVID");
                whereStr.AddWhereSqlEqualString("\"tblListMkb10COVID\".mkb10_long_name", CovidMkb10);
            }

            if (CovidDateStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblCOVID\".d_positiv_res_covid", DateOnly.Parse(CovidDateStart).ToString("dd-MM-yyyy"));
            }

            if (CovidDateEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblCOVID\".d_positiv_res_covid", DateOnly.Parse(CovidDateEnd).ToString("dd-MM-yyyy"));
            }

            if (ChemsexYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactChemsex", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblInfectCourse",
                                                       fieldLeft: "contact_type",
                                                       fieldRight: "infect_course_id",
                                                       table: "tblPatientContactChemsex",
                                                       alias: "ChemSexContactType");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                       fieldLeft: "y_n_id",
                                                       fieldRight: "id_y_n",
                                                       table: "tblPatientContactChemsex",
                                                       alias: "tblListYNChemsex");
                whereStr.AddWhereSqlIsNotNull("\"tblListYNChemsex\".y_n_name");
            }

            if (ChemsexYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactChemsex", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblInfectCourse",
                                                       fieldLeft: "contact_type",
                                                       fieldRight: "infect_course_id",
                                                       table: "tblPatientContactChemsex",
                                                       alias: "ChemSexContactType");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                       fieldLeft: "y_n_id",
                                                       fieldRight: "id_y_n",
                                                       table: "tblPatientContactChemsex",
                                                       alias: "tblListYNChemsex");
                whereStr.AddWhereSqlIsNull("\"tblListYNChemsex\".y_n_name");
            }

            if (ChemsexContactType.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactChemsex", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblInfectCourse",
                                                       fieldLeft: "contact_type",
                                                       fieldRight: "infect_course_id",
                                                       table: "tblPatientContactChemsex",
                                                       alias: "ChemSexContactType");
                whereStr.AddWhereSqlEqualString("\"ChemSexContactType\".infect_course_long", ChemsexContactType);
            }

            if (PavInjYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                       fieldLeft: "y_n_id",
                                                       fieldRight: "id_y_n",
                                                       table: "tblPatientContactPavInj",
                                                       alias: "tblListYNPavInj");
                whereStr.AddWhereSqlIsNotNull("\"tblListYNPavInj\".y_n_name");
            }

            if (PavInjYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                       fieldLeft: "y_n_id",
                                                       fieldRight: "id_y_n",
                                                       table: "tblPatientContactPavInj",
                                                       alias: "tblListYNPavInj");
                whereStr.AddWhereSqlIsNull("\"tblListYNPavInj\".y_n_name");
            }

            if (PavInjDateStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientContactPavInj\".date_start", DateOnly.Parse(PavInjDateStart).ToString("dd-MM-yyyy"));
            }

            if (PavInjDateEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientContactPavInj\".date_start", DateOnly.Parse(PavInjDateEnd).ToString("dd-MM-yyyy"));
            }

            if (PavNotInjYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                       fieldLeft: "y_n_id",
                                                       fieldRight: "id_y_n",
                                                       table: "tblPatientContactPavNotInj",
                                                       alias: "tblListYNPavNotInj");
                whereStr.AddWhereSqlIsNotNull("\"tblListYNPavNotInj\".y_n_name");
            }

            if (PavNotInjYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                       fieldLeft: "y_n_id",
                                                       fieldRight: "id_y_n",
                                                       table: "tblPatientContactPavNotInj",
                                                       alias: "tblListYNPavNotInj");
                whereStr.AddWhereSqlIsNull("\"tblListYNPavNotInj\".y_n_name");
            }

            if (PavNotInjDateStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientContactPavNotInj\".date_start", DateOnly.Parse(PavNotInjDateStart).ToString("dd-MM-yyyy"));
            }

            if (PavNotInjDateEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientContactPavNotInj\".date_start", DateOnly.Parse(PavNotInjDateEnd).ToString("dd-MM-yyyy"));
            }

            if (TimeInfectDateStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".epidem_time_infect_start", DateOnly.Parse(TimeInfectDateStart).ToString("dd-MM-yyyy"));
            }

            if (TimeInfectDateEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".epidem_time_infect_start", DateOnly.Parse(TimeInfectDateEnd).ToString("dd-MM-yyyy"));
            }

            if (EpidDescr.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".epidem_descr", EpidDescr);
            }

            if (Callstatus[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblListCallStatus", field: "call_status_id", table: "tblPatientCall");
                whereStr.AddWhereSqlIn("\"tblListCallStatus\".long_name", Callstatus);
            }

            if (CallDateStart.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateMore("\"tblPatientCall\".call_date", DateOnly.Parse(CallDateStart).ToString("dd-MM-yyyy"));
            }

            if (CallDateEnd.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
                whereStr.AddWhereSqlDateLess("\"tblPatientCall\".call_date", DateOnly.Parse(CallDateEnd).ToString("dd-MM-yyyy"));
            }

            #endregion
        }
    }
}