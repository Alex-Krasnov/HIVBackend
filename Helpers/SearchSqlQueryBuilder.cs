﻿using HIVBackend.Data;
using HIVBackend.Models.Enums;
using System.Text;

namespace HIVBackend.Helpers
{
    /// <summary>
    /// отвечает за логику генерации sql строк (столбцы, таблицы)
    /// </summary>
    public class SearchSqlQueryBuilder
    {
        public List<string> columName;
        public StringBuilder selectGroupSrt;
        public StringBuilder joinStr;
        public StringBuilder whereStr;

        public SearchSqlQueryBuilder()
        {
            columName = new List<string> { "Ид пациента" };
            selectGroupSrt = new StringBuilder("\"tblPatientCard\".patient_id");
            joinStr = new StringBuilder(" FROM \"tblPatientCard\"");
            whereStr = new StringBuilder("WHERE \"tblPatientCard\".is_active = true");
        }

        #region Select

        public void AddSelectAddr()
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

        public void AddSelectBirthDate()
        {
            columName.Add("Дата рождения");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".birth_date");
        }

        public void AddSelectCheckCourse()
        {
            columName.Add("Причина обращения");
            selectGroupSrt.AppendLine(",\"tblCheckCourse\".check_course_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
        }

        public void AddSelectCountry()
        {
            columName.Add("Страна");
            selectGroupSrt.AppendLine(",\"tblCountry\".country_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
        }

        public void AddSelectFio()
        {
            columName.Add("Фамилия");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".family_name");
            columName.Add("Имя");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".first_name");
            columName.Add("Отчество");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".third_name");
        }

        public void AddSelectFr()
        {
            columName.Add("Внесено в ФР");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_zam_med_part");
            columName.Add("Зав АПО");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_head_physician");
        }

        public void AddSelectInfectCourse()
        {
            columName.Add("Причина заражения");
            selectGroupSrt.AppendLine(",\"tblInfectCourse\".infect_course_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
        }

        public void AddSelectInpDate()
        {
            columName.Add("Дата ввода");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".input_date");
        }

        public void AddSelectRegion()
        {
            columName.Add("Регион");
            selectGroupSrt.AppendLine(",\"tblRegion\".region_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
        }

        public void AddSelectRegionFact()
        {
            columName.Add("Регион (факт.)");
            selectGroupSrt.AppendLine(",\"tblRegionFact\".region_long");

            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                   fieldLeft: "fact_region_id",
                                                   fieldRight: "region_id",
                                                   table: "tblPatientCard",
                                                   alias: "tblRegionFact");
        }

        public void AddSelectRegOnDate()
        {
            columName.Add("Дата постановки на учет");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".reg_on_date");
            columName.Add("Дата снятия с учета");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".reg_off_date");
            columName.Add("Причина снятия с учета");
            selectGroupSrt.AppendLine(",\"regOff\".infect_course_long");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblInfectCourse",
                                                   fieldLeft: "reg_off_reason",
                                                   fieldRight: "infect_course_id",
                                                   table: "tblPatientCard",
                                                   alias: "regOff");
        }

        public void AddSelectSnils()
        {
            columName.Add("СНИЛС");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".snils");
        }

        public void AddSelectStage()
        {
            columName.Add("Стадия");
            selectGroupSrt.AppendLine(",stage.diagnosis_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
        }

        public void AddSelectTransfArea()
        {
            columName.Add("Дата передачи в район");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".transf_area_date");
        }

        public void AddSelectUnrz()
        {
            columName.Add("УНРЗ");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".unrz_fr");
        }

        public void AddSelectAgeDay()
        {
            columName.Add("Возраст в днях");
            selectGroupSrt.AppendLine(",now()::date - \"tblPatientCard\".birth_date");
        }

        public void AddSelectSex()
        {
            columName.Add("Пол");
            selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
        }

        public void AddSelectDieDate()
        {
            columName.Add("Дата смерти");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".die_date");
            columName.Add("Дата смерти от СПИДа");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".die_aids_date");
        }

        public void AddSelectShowIllnes()
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

        public void AddSelectCardNo()
        {
            columName.Add("№ карты");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".card_no");
        }

        public void AddSelectArt()
        {
            columName.Add("АРТ");
            selectGroupSrt.AppendLine(",\"tblArvt\".arvt_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
        }

        public void AddSelectFamilyType()
        {
            columName.Add("Состав семьи");
            selectGroupSrt.AppendLine(",\"tblFamilyType\".family_type_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblFamilyType", field: "family_type_id", table: "tblPatientCard");
        }

        public void AddSelectFirstCheckDate()
        {
            columName.Add("Дата 1-го визита");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".check_first_date");
        }

        public void AddSelectChildPlace()
        {
            columName.Add("Распол отказ реб");
            selectGroupSrt.AppendLine(",\"tblChildPlace\".child_place_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPlace", field: "child_place_id", table: "tblPatientCard");
        }

        public void AddSelectBreastMonthNo()
        {
            columName.Add("Месяц грудного вскармливания");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".breast_month_no");
        }

        public void AddSelectChildPhp()
        {
            columName.Add("Профилактика ПХП");
            selectGroupSrt.AppendLine(",\"tblChildPHP\".child_php_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPHP", field: "child_php_id", table: "tblPatientCard");
        }

        public void AddSelectParent()
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

        public void AddSelectMaterHome()
        {
            columName.Add("Роддом");
            selectGroupSrt.AppendLine(",\"tblMaterHome\".materhome_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "tblPatientCard");
        }

        public void AddSelectForm309()
        {
            columName.Add("Форма 309");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".forma_309");
        }

        public void AddSelectBlotCheckPlace()
        {
            columName.Add("Место лаб. исследования");
            selectGroupSrt.AppendLine(",\"tblCheckPlace\".check_place_long");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckPlace", field: "check_place_id", table: "tblPatientBlot");
        }

        public void AddSelectDieCourse()
        {
            columName.Add("Причина смерти");
            selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_long");
            columName.Add("МКБ причина смерти");
            selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_short");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");

            AddDieCauseColumns(
                columName,
                selectGroupSrt,
                joinStr,
                "Непосредственная причина смерти",
                "die_course_id1",
                "tblTempDieCureMKB10List1"
            );

            AddDieCauseColumns(
                columName,
                selectGroupSrt,
                joinStr,
                "Патологическое состояние, которое привело к возникновению смерти",
                "die_course_id2",
                "tblTempDieCureMKB10List2"
            );

            AddDieCauseColumns(
                columName,
                selectGroupSrt,
                joinStr,
                "Первоначальная причина смерти",
                "die_course_id3",
                "tblTempDieCureMKB10List3"
            );

            AddDieCauseColumns(
                columName,
                selectGroupSrt,
                joinStr,
                "Внешняя причина смерти",
                "die_course_id4",
                "tblTempDieCureMKB10List4"
            );

            AddDieCauseColumns(
                columName,
                selectGroupSrt,
                joinStr,
                "Прочие состояния, способствовавшие смерти",
                "die_course_id5",
                "tblTempDieCureMKB10List5"
            );
        }

        public void AddSelectIb()
        {
            columName.Add("Результат референс");
            selectGroupSrt.AppendLine(",\"tblIbResult\".ib_result_short");

            columName.Add("Дата референс");
            selectGroupSrt.AppendLine(",\"tblPatientBlot\".blot_date");

            columName.Add("Номер");
            selectGroupSrt.AppendLine(",\"tblPatientBlot\".blot_no");

            columName.Add("Первый");
            selectGroupSrt.AppendLine(",\"tblPatientBlot\".first1");

            columName.Add("Последний");
            selectGroupSrt.AppendLine(",\"tblPatientBlot\".last1");

            columName.Add("Дата ввода");
            selectGroupSrt.AppendLine(",\"tblPatientBlot\".datetime1");

            columName.Add("Референс");
            selectGroupSrt.AppendLine(",\"tblListReferenceMo\".reference_mo_name");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListReferenceMo", field: "reference_mo_id", table: "tblPatientBlot");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblIbResult", field: "ib_result_id", table: "tblPatientBlot");
        }

        public void AddSelectHospCourse()
        {
            columName.Add("Причина госпитализации");
            selectGroupSrt.AppendLine(",\"tblHospCourse\".hosp_course_long");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHosp", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospCourse", field: "hosp_course_id", table: "tblPatientHosp");
        }

        public void AddSelectAge()
        {
            columName.Add("Возраст");
            selectGroupSrt.AppendLine(",date_part('year'::text, age(\"tblPatientCard\".birth_date::timestamp with time zone))::integer");
        }

        public void AddSelectMkb10()
        {
            columName.Add("Код МКБ10");
            selectGroupSrt.AppendLine(",\"tblTempDieCureMKB10List\".die_course_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
        }

        public void AddSelectTransfFeder()
        {
            columName.Add("Дата передачи в субъект федерации");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".transf_feder_date");
        }

        public void AddSelectUfsin()
        {
            columName.Add("Дата постановки на учет УФСИН");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
        }

        public void AddSelectAids12()
        {
            columName.Add("Вич 1 2");
            selectGroupSrt.AppendLine(",\"tblAids12\".aids12_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblAids12", field: "aids12_id", table: "tblPatientCard");
        }

        public void AddSelectDtMailReg()
        {
            columName.Add("Дата письма в др.регион");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".dt_mail_reg");
        }

        public void AddSelectEdu()
        {
            columName.Add("Образование");
            selectGroupSrt.AppendLine(",\"tblListEducation\".edu_name");

            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListEducation",
                                                   fieldLeft: "edu_id",
                                                   fieldRight: "education_id",
                                                   table: "tblPatientCard");
        }

        public void AddSelectFamilyStatus()
        {
            columName.Add("Семейное положение");
            selectGroupSrt.AppendLine(",\"tblListFamilyStatus\".fammily_status_name");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListFamilyStatus", field: "family_status_id", table: "tblPatientCard");
        }

        public void AddSelectEmployment()
        {
            columName.Add("Занятость");
            selectGroupSrt.AppendLine(",\"tblListEmployment\".employment_name");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListEmployment", field: "employment_id", table: "tblPatientCard");
        }

        public void AddSelectTrans()
        {
            columName.Add("Трансгендерность");
            selectGroupSrt.AppendLine(",\"tblListTrans\".trans_name");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTrans", field: "trans_id", table: "tblPatientCard");
        }

        public void AddSelectPlaceCheck()
        {
            columName.Add("Место выявления");
            selectGroupSrt.AppendLine(",\"tblListPlaceCheck\".place_check_name");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListPlaceCheck", field: "place_check_id", table: "tblPatientCard");
        }

        public void AddSelectSituationDetect()
        {
            columName.Add("Обст. выявления");
            selectGroupSrt.AppendLine(",\"tblListSituationDetect\".situation_detect_name");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListSituationDetect", field: "situation_detect_id", table: "tblPatientCard");
        }

        public void AddSelectTransmisionMech()
        {
            columName.Add("Вер. мех. передачи");
            selectGroupSrt.AppendLine(",\"tblListTransmisionMech\".transmisiom_mech_name");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTransmisionMech", field: "transmission_mech_id", table: "tblPatientCard");
        }

        public void AddSelectVulnerableGroup()
        {
            columName.Add("Кат. уязвимой группы");
            selectGroupSrt.AppendLine(",\"tblListVulnerableGroup\".vulnerable_group_name");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListVulnerableGroup", field: "vulnerable_group_id", table: "tblPatientCard");
        }

        public void AddSelectCovidVac()
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

        public void AddSelectCovid()
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

        public void AddSelectChemsex()
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

        public void AddSelectPavInj()
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

        public void AddSelectPavNotInj()
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

        public void AddSelectTimeInfect()
        {
            columName.Add("Вероятные сроки инфиц. с");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".epidem_time_infect_start");

            columName.Add("Вероятные сроки инфиц. по");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".epidem_time_infect_end");
        }

        public void AddSelectEpidDescr()
        {
            columName.Add("Эпид. примечание");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".epidem_descr");
        }

        public void AddSelectPatientCall()
        {
            columName.Add("Дата звонка");
            selectGroupSrt.AppendLine(",\"tblPatientCall\".call_date");

            columName.Add("Статус звонка");
            selectGroupSrt.AppendLine(",\"tblListCallStatus\".long_name");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListCallStatus", field: "call_status_id", table: "tblPatientCall");
        }

        public void AddSelectDateHospIn()
        {
            columName.Add("Дата госп");
            selectGroupSrt.AppendLine(",\"tblPatientHospResultR\".date_hosp_in");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectDateHospOut()
        {
            columName.Add("Дата выписки");
            selectGroupSrt.AppendLine(",\"tblPatientHospResultR\".date_hosp_out");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectLpu()
        {
            columName.Add("МО");
            selectGroupSrt.AppendLine(",\"tblLpu\".lpu_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblLpu", field: "lpu_id", table: "tblPatientHospResultR");
        }

        public void AddSelectHospResult()
        {
            columName.Add("Исход госпитализации");
            selectGroupSrt.AppendLine(",\"tblHospResult\".hosp_result_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospResult", field: "hosp_result_id", table: "tblPatientHospResultR");
        }

        public void AddSelectArchive()
        {
            columName.Add("Архив");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".snils_fed");
        }

        public void AddSelectChemprof()
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

        public void AddSelectDieDiag()
        {
            columName.Add("Диагноз посмертно");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_diagnosis_after_death");
        }

        public void AddSelectDateReg()
        {
            columName.Add("Дата регистрации нач");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".dt_reg_beg");

            columName.Add("Дата регистрации кон");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".dt_reg_end");
        }

        public void AddSelectPasSer()
        {
            columName.Add("Паспорт серия");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_ser");
        }

        public void AddSelectPasNum()
        {
            columName.Add("Паспорт номер");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_num");
        }

        public void AddSelectPasWhom()
        {
            columName.Add("Паспорт выдан");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_when");
        }

        public void AddSelectPasWhen()
        {
            columName.Add("Паспорт Дата выдачи");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".pas_whom");
        }

        public void AddSelectDateDiagnosis()
        {
            columName.Add("Дата установления диагноза");
            selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_diagnosis");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");

        }

        public void AddSelectPlaceDiagnosis()
        {
            columName.Add("Место установл.диагноза");
            selectGroupSrt.AppendLine(",\"tblRegionNonresident\".region_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");

            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                               alias: "tblRegionNonresident",
                                               fieldRight: "region_id",
                                               table: "tblPatientNonresident",
                                               fieldLeft: "place_diagnosis");
        }

        public void AddSelectDateRegistration()
        {
            columName.Add("Дата регистрации с");
            selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_registration_from");
            columName.Add("Дата регистрации по");
            selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_registration_to");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectDateDeparture()
        {
            columName.Add("Дата убытия");
            selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_departure");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectPregCheck()
        {
            columName.Add("Выявление");
            selectGroupSrt.AppendLine(",\"tblPregCheck\".preg_check_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPregCheck", field: "preg_check_id", table: "tblPatientCard");
        }

        public void AddSelectPregMonthNo()
        {
            columName.Add("Срок беременности");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".preg_month_no");
        }

        public void AddSelectBirthType()
        {
            columName.Add("Вид родов");
            selectGroupSrt.AppendLine(",\"tblBirthType\".birth_type_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblBirthType", field: "birth_type_id", table: "tblPatientPregnantM");
        }

        public void AddSelectMedecineStartMonthNo()
        {
            columName.Add("Срок начала приёма медик.");
            selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".medicine_st_month_no_old");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectChildBirthDate()
        {
            columName.Add("Дата родов");
            selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_birth_date");

            columName.Add("Дата начала берем");
            selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".preg_date");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectChildFio()
        {
            columName.Add("Фамилия ребёнка");
            selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_family_name");

            columName.Add("Имя ребёнка");
            selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_first_name");

            columName.Add("Отчество ребёнка");
            selectGroupSrt.AppendLine(",\"tblPatientPregnantM\".child_third_name");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectPhpSchema1()
        {
            AddSelectPhpSchemaInternal("ПХП1 схема", "phpschema_id1", "php1");
        }

        public void AddSelectPhpSchema2()
        {
            AddSelectPhpSchemaInternal("ПХП2 схема", "phpschema_id2", "php2");
        }

        public void AddSelectPhpSchema3()
        {
            AddSelectPhpSchemaInternal("ПХП3 схема", "phpschema_id3", "php3");
        }

        public void AddSelectMedecineForSchema1()
        {
            AddSelectMedecineForSchemaInternal(
                columnName: "ПХП1 препарат",
                schemaField: "phpschema_id1",
                phpAlias: "php1",
                medicineRAlias: "tblSchemaMedicineR1",
                medicineAlias: "tblMedicineForSchema1");
        }

        public void AddSelectMedecineForSchema2()
        {
            AddSelectMedecineForSchemaInternal(
                columnName: "ПХП2 препарат",
                schemaField: "phpschema_id2",
                phpAlias: "php2",
                medicineRAlias: "tblSchemaMedicineR2",
                medicineAlias: "tblMedicineForSchema2");
        }

        public void AddSelectMedecineForSchema3()
        {
            AddSelectMedecineForSchemaInternal(
                columnName: "ПХП3 препарат",
                schemaField: "phpschema_id3",
                phpAlias: "php3",
                medicineRAlias: "tblSchemaMedicineR3",
                medicineAlias: "tblMedicineForSchema3");
        }

        public void AddSelectMaterhome()
        {
            columName.Add("Роддом");
            selectGroupSrt.AppendLine(",\"tblMaterHome\".materhome_long");

            columName.Add("Ид ребёнка");
            selectGroupSrt.AppendLine(",\"qryParentChild\".child_id");

            joinStr.AddLeftJoinIfNotExist(joinTable: "qryParentChild", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "qryParentChild");
        }

        public void AddSelectAclDate()
        {
            columName.Add("Дата опред.иммун.стат.");
            selectGroupSrt.AppendLine(",\"tblPatientAclResult\".acl_sample_date");

            string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                         $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                         $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);
        }

        public void AddSelectAclMcnCode()
        {
            columName.Add("CD4+(abc)");
            selectGroupSrt.AppendLine(",\"tblPatientAclResult\".acl_mcn_code");

            string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                         $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                         $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);
        }

        public void AddSelectRegDate()
        {
            columName.Add("Дата записи");
            selectGroupSrt.AppendLine(",\"tblPatientRegistry\".reg_date");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectCheckDate()
        {
            columName.Add("Дата приема на выезде");
            selectGroupSrt.AppendLine(",\"tblPatientCheckOut\".check_date");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCheckOut", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectDoctorReg()
        {
            columName.Add("Специалист");
            selectGroupSrt.AppendLine(",\"tblDoctor\".doctor_long");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblDoctor", fieldLeft: "reg_doctor_id", fieldRight: "doctor_id", table: "tblPatientRegistry");
        }

        public void AddSelectRegCheck()
        {
            columName.Add("Явка");
            selectGroupSrt.AppendLine(",\"tblPatientRegistry\".reg_check");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
        }

        public void AddSelectInvalid()
        {
            columName.Add("Группа инвалидности");
            selectGroupSrt.AppendLine(",\"tblInvalid\".invalid_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
        }

        public void AddSelectCorrespIllnesses()
        {
            columName.Add("Сопутствующее заболевание");
            selectGroupSrt.AppendLine(",\"tblCorrespIllness\".corresp_illness_long");

            columName.Add("Сопутствующее заболевание дата");
            selectGroupSrt.AppendLine(",\"tblPatientCorrespIllness\".datetime1");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
        }

        public void AddSelectSchemaDate()
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

            columName.Add("Дата назн.схемы");
            selectGroupSrt.AppendLine(",\"tblPatientCureSchema\".start_date");
        }

        public void AddSelectSchema()
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");

            columName.Add("Схема лечения");
            selectGroupSrt.AppendLine(",\"tblCureSchema\".cure_schema_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
        }

        public void AddSelectSchemaMedecine()
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

        public void AddSelectGiveDate()
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

            columName.Add("Дата выдачи препарата");
            selectGroupSrt.AppendLine(",\"tblPatientPrescrM\".give_date");
        }

        public void AddSelectDoctorMedecine()
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

            columName.Add("Персонал");
            selectGroupSrt.AppendLine(",\"tblDoctor\".doctor_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
        }

        public void AddSelectMedecine()
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");

            columName.Add("Препарат прописанный");
            selectGroupSrt.AppendLine(",\"tblMedicine\".medicine_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
        }

        public void AddSelectMedecineGive()
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

        public void AddSelectSchemaChange()
        {
            columName.Add("Причина смены схемы леч.");
            selectGroupSrt.AppendLine(",\"tblCureChange\".cure_change_long");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
        }

        public void AddSelectRangeTherapy()
        {
            columName.Add("Ряд терапии");
            selectGroupSrt.AppendLine(",\"tblRangeTherapy\".range_therapy_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
        }

        public void AddSelectVlDate()
        {
            columName.Add("Дата опред.вир.нагр.");
            selectGroupSrt.AppendLine(",\"vn\".acl_sample_date");

            string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

        }

        public void AddSelectVlRes()
        {
            columName.Add("Вирусн.нагр.");
            selectGroupSrt.AppendLine(",\"vn\".acl_result");

            string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);
        }

        public void AddSelectImDate()
        {
            columName.Add("Дата опред.иммун.стат.");
            selectGroupSrt.AppendLine(",\"im\".acl_sample_date");

            string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);
        }

        public void AddSelectImRes()
        {
            columName.Add("CD4+(abc)");
            selectGroupSrt.AppendLine(",\"im\".acl_result");

            string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);
        }

        public void AddSelectDeathTransferSub()
        {
            columName.Add("Смерть передана в субъект РФ");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".death_transfer_sub");
        }

        public void AddSelectDesc()
        {
            columName.Add("Примечание");
            selectGroupSrt.AppendLine(",addr_name");
        }

        #endregion

        #region Where

        public void AddWhereCity(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".city_name", namePart.ToLower());
        }

        public void AddWhereLocation(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".location_name", namePart.ToLower());
        }

        public void AddWhereIndx(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_ind", namePart.ToLower());
        }

        public void AddWhereStreet(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_street", namePart.ToLower());
        }

        public void AddWhereHome(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_house", namePart.ToLower());
        }

        public void AddWhereBirthDateStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".birth_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereBirthDateEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".birth_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereCheckCourse(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblCheckCourse\".check_course_long", names);
        }

        public void AddWhereCountry(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblCountry\".country_long", names);
        }

        public void AddWhereFamilyName(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".family_name", namePart.ToLower());
        }

        public void AddWhereFirstName(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".first_name", namePart.ToLower());
        }

        public void AddWhereThirdName(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".third_name", namePart.ToLower());
        }

        public void AddWhereFrYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".flg_zam_med_part";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereZavApoYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".flg_head_physician";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);
            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereInfectCourse(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblInfectCourse\".infect_course_long", names);
        }

        public void AddWhereDateInpStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".input_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateInpEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".input_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWherePatientId(string name)
        {
            whereStr.AddWhereSqlEqual("\"tblPatientCard\".patient_id", name);
        }

        public void AddWhereRegionReg(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblRegion\".region_long", names);
        }

        public void AddWhereRegionPreset(string regionReset)
        {
            var enumValue = EnumExtension.GetEnumFromDescription<RegionPresetEnum>(regionReset);

            switch (enumValue)
            {
                case RegionPresetEnum.Mo:
                    joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                    whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", ((int)RegionPresetEnum.Mo).ToString());
                    break;
                case RegionPresetEnum.Nonresidents:
                    joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                    whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", ((int)RegionPresetEnum.Nonresidents).ToString());
                    break;
                case RegionPresetEnum.Foreign:
                    joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                    whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", ((int)RegionPresetEnum.Foreign).ToString());
                    break;

            }
        }

        public void AddWhereRegionFact(string[] names)
        {
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                   fieldLeft: "fact_region_id",
                                                   fieldRight: "region_id",
                                                   table: "tblPatientCard",
                                                   alias: "tblRegionFact");

            whereStr.AddWhereSqlIn("\"tblRegionFact\".region_long", names);
        }

        public void AddWhereFactRegionPreset(string regionReset)
        {
            var enumValue = EnumExtension.GetEnumFromDescription<RegionPresetEnum>(regionReset);

            switch (enumValue)
            {
                case RegionPresetEnum.Mo:
                    joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                           fieldLeft: "fact_region_id",
                                                           fieldRight: "region_id",
                                                           table: "tblPatientCard",
                                                           alias: "tblRegionFact");

                    whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", ((int)RegionPresetEnum.Mo).ToString());
                    break;
                case RegionPresetEnum.Nonresidents:
                    joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                           fieldLeft: "fact_region_id",
                                                           fieldRight: "region_id",
                                                           table: "tblPatientCard",
                                                           alias: "tblRegionFact");

                    whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", ((int)RegionPresetEnum.Nonresidents).ToString());
                    break;
                case RegionPresetEnum.Foreign:
                    joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                           fieldLeft: "fact_region_id",
                                                           fieldRight: "region_id",
                                                           table: "tblPatientCard",
                                                           alias: "tblRegionFact");

                    whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", ((int)RegionPresetEnum.Foreign).ToString());
                    break;

            }
        }

        public void AddWhereDateRegOnStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_on_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateRegOnEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_on_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateUnRegStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_off_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateUnRegEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_off_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereUnRegCourse(string name)
        {
            joinStr.AddLeftJoinIfNotExistDiffField(
                joinTable: "tblInfectCourse",
                fieldLeft: "reg_off_reason",
                fieldRight: "infect_course_id",
                table: "tblPatientCard",
                alias: "regOff");
            whereStr.AddWhereSqlContainsString("\"regOff\".infect_course_long", name);
        }

        public void AddWhereSnilsYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".snils";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereSnils(string namePart)
        {
            whereStr.AddWhereSqlContainsString("\"tblPatientCard\".snils", namePart);
        }

        public void AddWhereStage(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
            whereStr.AddWhereSqlIn("stage.diagnosis_long", names);
        }

        public void AddWhereTransfAreaYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".transf_area_date";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereDateTransfAreaStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".transf_area_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateTransfAreaEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".transf_area_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereUnrz(string namePart)
        {
            whereStr.AddWhereSqlContainsString("\"tblPatientCard\".unrz_fr", namePart);
        }

        public void AddWhereUnrzYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".unrz_fr";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereSex(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
            whereStr.AddWhereSqlContainsString("\"tblSex\".sex_short", name);
        }

        public void AddWhereDateDieStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateDieEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateDieAidsStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".die_aids_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateDieAidsEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".die_aids_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereShowIllnes(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
            whereStr.AddWhereSqlIn("\"tblShowIllness\".show_illness_long", names);
        }

        public void AddWhereDateShowIllnesStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
            whereStr.AddWhereSqlDateMore("\"tblPatientShowIllness\".start_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateShowIllnesEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
            whereStr.AddWhereSqlDateLess("\"tblPatientShowIllness\".end_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereCardNo(string namePart)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".card_no", namePart);
        }

        public void AddWhereArt(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblArvt", field: "arvt_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblArvt\".arvt_long", names);
        }

        public void AddWhereAgeDayStart(string date)
        {
            whereStr.AddWhereIntConvertMore("now()::date - \"tblPatientCard\".birth_date", int.Parse(date));
        }

        public void AddWhereAgeDayEnd(string date)
        {
            whereStr.AddWhereIntConvertLess("now()::date - \"tblPatientCard\".birth_date", int.Parse(date));
        }

        public void AddWhereFamilyType(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblFamilyType", field: "family_type_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblFamilyType\".family_type_long", names);
        }

        public void AddWhereFirstCheckDateStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".check_first_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereFirstCheckDateEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".check_first_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereChildPlace(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPlace", field: "child_place_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblChildPlace\".child_place_long", names);
        }

        public void AddWhereBreastMonthNoStart(string date)
        {
            whereStr.AddWhereIntConvertMore("\"tblPatientCard\".breast_month_no", int.Parse(date));
        }

        public void AddWhereBreastMonthNoEnd(string date)
        {
            whereStr.AddWhereIntConvertLess("\"tblPatientCard\".breast_month_no", int.Parse(date));
        }

        public void AddWhereChildPhp(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblChildPHP", field: "child_php_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblChildPHP\".child_php_long", names);
        }

        public void AddWhereMotherPatientId(string name)
        {
            whereStr.AddWhereSqlEqual("\"tblPatientCard\".mother_patient_id", name);
        }

        public void AddWhereFatherPatientId(string name)
        {
            whereStr.AddWhereSqlEqual("\"tblPatientCard\".father_patient_id", name);
        }

        public void AddWhereMaterHome(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblMaterHome\".materhome_long", names);
        }

        public void AddWhereForm309YNA(string ynaName)
        {
            // TODO: надо привести данные в бд к соответствию с енамкой

            var fieldName = "\"tblPatientCard\".forma_309";

            if (ynaName == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlEqual(fieldName, "1");
            }
            else
            {
                whereStr.AddWhereSqlEqual(fieldName, "2");
            }
        }

        public void AddWhereBlotCheckPlace(string[] names)
        {
            whereStr.AddWhereSqlIn("\"tblCheckPlace\".check_place_long", names);

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckPlace", field: "check_place_id", table: "tblPatientBlot");
        }

        public void AddWhereDieCourse(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".die_course_long", names);
        }

        public void AddWhereDiePreset(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");

            if (name == DiePresetEnum.Hiv.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", new[] { "1", "3" });
            }

            if (name == DiePresetEnum.NotHiv.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "2");
            }

            if (name == DiePresetEnum.Aids.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlEqual("\"tblTempDieCureMKB10List\".\"Dethtype_id\"", "3");
            }
        }

        public void AddWhereIbRes(string namePart)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblIbResult", field: "ib_result_id", table: "tblPatientBlot");
            whereStr.AddWhereSqlContainsString("\"tblIbResult\".ib_result_short", namePart);
        }

        public void AddWhereDateIbResStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".blot_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateIbResEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".blot_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereIbNum(string namePart)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlEqual("\"tblPatientBlot\".blot_no", namePart);
        }

        public void AddWhereDateInpIbStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientBlot\".datetime1", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateInpIbEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientBlot\".datetime1", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereIbSelect(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");

            if (name == "Первый")
            {
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
            }

            if (name == "Последний")
            {
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }

            if (name == "Перв.и посл.")
            {
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".first1");
                whereStr.AddWhereSqlTrue("\"tblPatientBlot\".last1");
            }
        }

        public void AddWhereHospCourse(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHosp", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospCourse", field: "hosp_course_id", table: "tblPatientHosp");
            whereStr.AddWhereSqlIn("\"tblShowIllness\".show_illness_long", names);
        }

        // TODO: выглядит как что-то очень тяжелое, надо как-то пересмотреть
        public void AddWhereAge(string[] names)
        {
            const string field = "date_part('year'::text, age(\"tblPatientCard\".birth_date::timestamp with time zone))::integer";

            var ages = new List<string>();

            using (HivContext context = new())
            {
                foreach (var item in names)
                {
                    var tblAgegr = context.TblAgegrs.FirstOrDefault(e => e.AgegrLong == item);

                    if (tblAgegr.Start1 == null || tblAgegr.End1 == null)
                        continue;

                    for (int i = (int)tblAgegr.Start1; i <= (int)tblAgegr.End1; i++)
                        ages.Add($"{i}");
                }
            }

            whereStr.AddWhereSqlIn(field, ages.ToArray());
        }

        public void AddWhereMkb10(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblTempDieCureMKB10List", field: "die_course_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblTempDieCureMKB10List\".die_course_long", names);
        }

        public void AddWhereTransfFederYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".transf_feder_date";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereDateTransfFederStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".transf_feder_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateTransfFederEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".transf_feder_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereUfsinYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".ufsin_date";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereDateUfsinStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".ufsin_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateUfsinEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".ufsin_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereAids12(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblAids12", field: "aids12_id", table: "tblPatientCard");
            whereStr.AddWhereSqlContainsString("\"tblAids12\".aids12_long", name);
        }

        public void AddWhereDtMailRegStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".dt_mail_reg", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDtMailRegEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".dt_mail_reg", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereEducation(string[] names)
        {
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListEducation",
                                                   fieldLeft: "edu_id",
                                                   fieldRight: "education_id",
                                                   table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListEducation\".edu_name", names);
        }

        public void AddWhereFamilyStatus(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListFamilyStatus", field: "family_status_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListFamilyStatus\".fammily_status_name", names);
        }

        public void AddWhereEmployment(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListEmployment", field: "employment_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListEmployment\".employment_name", names);
        }

        public void AddWhereTrans(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTrans", field: "trans_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListTrans\".trans_name", names);
        }

        public void AddWherePlaceCheck(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListPlaceCheck", field: "place_check_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListPlaceCheck\".place_check_name", names);
        }

        public void AddWhereSituationDetect(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListSituationDetect", field: "situation_detect_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListSituationDetect\".situation_detect_name", names);
        }

        public void AddWhereTransmisionMech(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListTransmisionMech", field: "transmission_mech_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListTransmisionMech\".transmisiom_mech_name", names);
        }

        public void AddWhereVulnerableGroup(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListVulnerableGroup", field: "vulnerable_group_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblListVulnerableGroup\".vulnerable_group_name", names);
        }

        public void AddWhereVacName(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID_vac", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListVac", field: "vac_id", table: "tblCOVID_vac");
            whereStr.AddWhereSqlContainsString("\"tblListVac\".vac_name", name);
        }

        public void AddWhereVacDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID_vac", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblCOVID_vac\".d_vac1", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereVacDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID_vac", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblCOVID_vac\".d_vac1", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereCovidMkb10(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListMkb10COVID",
                                                   fieldLeft: "covid_MKB10",
                                                   fieldRight: "MKB10_id",
                                                   table: "tblCOVID");
            whereStr.AddWhereSqlContainsString("\"tblListMkb10COVID\".mkb10_long_name", name);
        }

        public void AddWhereCovidDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblCOVID\".d_positiv_res_covid", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereCovidDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCOVID", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblCOVID\".d_positiv_res_covid", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereChemsexYNA(string ynaName)
        {
            var fieldName = "\"tblListYNChemsex\".y_n_name";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

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

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereChemsexContactType(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactChemsex", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblInfectCourse",
                                                   fieldLeft: "contact_type",
                                                   fieldRight: "infect_course_id",
                                                   table: "tblPatientContactChemsex",
                                                   alias: "ChemSexContactType");
            whereStr.AddWhereSqlContainsString("\"ChemSexContactType\".infect_course_long", name);
        }

        public void AddWherePavInjYNA(string ynaName)
        {
            var fieldName = "\"tblListYNPavInj\".y_n_name";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                   fieldLeft: "y_n_id",
                                                   fieldRight: "id_y_n",
                                                   table: "tblPatientContactPavInj",
                                                   alias: "tblListYNPavInj");

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWherePavInjDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientContactPavInj\".date_start", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWherePavInjDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavInj", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientContactPavInj\".date_start", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWherePavNotInjYNA(string ynaName)
        {
            var fieldName = "\"tblListYNPavNotInj\".y_n_name";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);


            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblListYN",
                                                   fieldLeft: "y_n_id",
                                                   fieldRight: "id_y_n",
                                                   table: "tblPatientContactPavNotInj",
                                                   alias: "tblListYNPavNotInj");

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWherePavNotInjDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientContactPavNotInj\".date_start", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWherePavNotInjDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientContactPavNotInj", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientContactPavNotInj\".date_start", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereTimeInfectDateStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".epidem_time_infect_start", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereTimeInfectDateEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".epidem_time_infect_start", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereEpidDescr(string name)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".epidem_descr", name);
        }

        public void AddWhereCallStatus(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListCallStatus", field: "call_status_id", table: "tblPatientCall");
            whereStr.AddWhereSqlIn("\"tblListCallStatus\".long_name", names);
        }

        public void AddWhereCallDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientCall\".call_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereCallDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCall", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientCall\".call_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateHospInStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientHospResultR\".date_hosp_in", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateHospInEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientHospResultR\".date_hosp_in", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateHospOutStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientHospResultR\".date_hosp_out", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateHospOutEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientHospResultR\".date_hosp_out", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereLpu(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblLpu", field: "lpu_id", table: "tblPatientHospResultR");
            whereStr.AddWhereSqlIn("\"tblLpu\".lpu_long", names);
        }

        public void AddWhereHospResult(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospResult", field: "hosp_result_id", table: "tblPatientHospResultR");
            whereStr.AddWhereSqlIn("\"tblHospResult\".hosp_result_long", names);
        }

        public void AddWhereFioChange(string name)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".fio_change", name);
        }

        public void AddWhereReferenceMO(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientBlot", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblListReferenceMo", field: "reference_mo_id", table: "tblPatientBlot");
            whereStr.AddWhereSqlContainsString("\"tblListReferenceMo\".reference_mo_name", name);
        }

        public void AddWhereArchiveYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".snils_fed";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereDieDiagYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".flg_diagnosis_after_death";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereChemprof(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblChemop", field: "chemop_id", table: "tblPatientChemop");
            whereStr.AddWhereSqlContainsString("\"tblChemop\".chemop_long", name);
        }

        public void AddWhereDateChemprofStartStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientChemop\".chemop_date_from", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateChemprofStartEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientChemop\".chemop_date_from", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateChemprofEndStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientChemop\".chemop_date_to", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateChemprofEndEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientChemop", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientChemop\".chemop_date_to", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateRegStart(string date)
        {
            whereStr.AddWhereSqlDateMore("\"tblPatientCard\".dt_reg_beg", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateRegEnd(string date)
        {
            whereStr.AddWhereSqlDateLess("\"tblPatientCard\".dt_reg_beg", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateDiagnosisStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientNonresident\".date_diagnosis", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateDiagnosisEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientNonresident\".date_diagnosis", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWherePlaceDiagnosis(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                        alias: "tblRegionNonresident",
                                                        fieldRight: "region_id",
                                                        table: "tblPatientNonresident",
                                                        fieldLeft: "place_diagnosis");
            whereStr.AddWhereSqlIn("\"tblRegionNonresident\".region_long", names);
        }

        public void AddWhereDateRegistrationYNA(string ynaName)
        {
            var fieldName = "\"tblPatientNonresident\".date_registration_from";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereDateRegistrationStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientNonresident\".date_registration_from", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateRegistrationEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientNonresident\".date_registration_from", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateDepartureYNA(string ynaName)
        {
            var fieldName = "\"tblPatientNonresident\".date_departure";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereDateDepartureStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientNonresident\".date_departure", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateDepartureEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientNonresident\".date_departure", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void OnlyPregnant()
        {
            whereStr.Append($" AND (\"tblPatientCard\".preg_month_no IS NOT NULL " +
                                    $"OR \"tblPatientPregnantM\".preg_id IS NOT NULL " +
                                    $"OR \"tblPatientCard\".preg_check_id IS NOT NULL)");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
        }

        public void AddWherePregCheck(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPregCheck", field: "preg_check_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblPregCheck\".preg_check_long", names);
        }

        public void AddWherePregMonthNo(string name)
        {
            whereStr.AddWhereSqlEqual("\"tblPatientCard\".preg_month_no", name);
        }

        public void AddWhereBirthType(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblBirthType", field: "birth_type_id", table: "tblPatientPregnantM");
            whereStr.AddWhereSqlIn("\"tblBirthType\".birth_type_long", names);
        }

        public void AddWhereMedecineStartMonthNo(string name)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlEqual("\"tblPatientPregnantM\".medicine_st_month_no_old", name);
        }

        public void AddWhereChildBirthDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientPregnantM\".child_birth_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereChildBirthDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientPregnantM\".child_birth_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereChildFamilyName(string name)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientPregnantM\".child_family_name", name);
        }

        public void AddWhereChildFirstName(string name)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientPregnantM\".child_first_name", name);
        }

        public void AddWhereChildThirdName(string name)
        {
            whereStr.AddWhereSqlStartWhith("\"tblPatientPregnantM\".child_third_name", name);
        }

        public void AddWherePhpSchema1(string[] names)
        {
            AddPhpSchemaCondition("phpschema_id1", "php1", names);
        }

        public void AddWherePhpSchema2(string[] names)
        {
            AddPhpSchemaCondition("phpschema_id2", "php2", names);
        }

        public void AddWherePhpSchema3(string[] names)
        {
            AddPhpSchemaCondition("phpschema_id3", "php3", names);
        }

        public void AddWhereMedecineForSchema1(string[] names)
        {
            AddMedicineForSchemaCondition(
                schemaField: "phpschema_id1",
                phpAlias: "php1",
                medicineRAlias: "tblSchemaMedicineR1",
                medicineAlias: "tblMedicineForSchema1",
                medicineValues: names);
        }

        public void AddWhereMedecineForSchema2(string[] names)
        {
            AddMedicineForSchemaCondition(
                schemaField: "phpschema_id2",
                phpAlias: "php2",
                medicineRAlias: "tblSchemaMedicineR2",
                medicineAlias: "tblMedicineForSchema2",
                medicineValues: names);
        }

        public void AddWhereMedecineForSchema3(string[] names)
        {
            AddMedicineForSchemaCondition(
                schemaField: "phpschema_id3",
                phpAlias: "php3",
                medicineRAlias: "tblSchemaMedicineR3",
                medicineAlias: "tblMedicineForSchema3",
                medicineValues: names);
        }

        public void AddWhereMaterhome(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "qryParentChild", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblMaterHome", field: "materhome_id", table: "qryParentChild");
            whereStr.AddWhereSqlIn("\"tblMaterHome\".materhome_long", names);
        }

        public void AddWhereAclDateStart(string date)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                         $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                         $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereSqlDateMore("\"tblPatientAclResult\".acl_sample_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereAclDateEnd(string date)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" " +
                         $"ON \"tblPatientCard\".\"patient_id\" = \"tblPatientAclResult\".\"patient_id\" " +
                         $"AND \"tblPatientAclResult\".\"acl_test_code\" in (\'И0025\',\'И0070\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereSqlDateLess("\"tblPatientAclResult\".acl_sample_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereRegDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientRegistry\".reg_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereRegDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientRegistry\".reg_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereCheckDateStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCheckOut", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientCheckOut\".check_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereCheckDateEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCheckOut", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientCheckOut\".check_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDoctorReg(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblDoctor", fieldLeft: "reg_doctor_id", fieldRight: "doctor_id", table: "tblPatientRegistry");
            whereStr.AddWhereSqlIn("\"tblDoctor\".doctor_long", names);
        }

        public void AddWhereRegCheck(string ynaName)
        {
            var fieldName = "\"tblPatientRegistry\".reg_check";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereInvalid(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblInvalid", field: "invalid_id", table: "tblPatientCard");
            whereStr.AddWhereSqlIn("\"tblInvalid\".invalid_long", names);
        }

        public void AddWhereCorrespIllnesses(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCorrespIllness", field: "corresp_illness_id", table: "tblPatientCorrespIllness");
            whereStr.AddWhereSqlIn("\"tblCorrespIllness\".corresp_illness_long", names);
        }

        public void AddWhereDateCorrespIllnessesStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateCorrespIllnessesEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCorrespIllness", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientCorrespIllness\".datetime1", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereSchema(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
            whereStr.AddWhereSqlIn("\"tblCureSchema\".cure_schema_long", names);
        }

        public void AddWhereSchemaLast()
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlTrue("\"tblPatientCureSchema\".\"lastYN\"");
        }

        public void AddWhereSchemaMedecine(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureSchema", field: "cure_schema_id", table: "tblPatientCureSchema");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR", field: "cure_schema_id", table: "tblPatientCureSchema");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                   fieldLeft: "medicine_id",
                                                   fieldRight: "medforschema_id",
                                                   table: "tblSchemaMedicineR");
            whereStr.AddWhereSqlIn("\"tblMedicineForSchema\".medforschema_long", names);
        }

        public void AddWhereMedecine(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
            whereStr.AddWhereSqlIn("\"tblMedicine\".medicine_long", names);
        }

        public void AddWhereMedecineGive(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblMedicine", field: "medicine_id", table: "tblPatientPrescrM");
            whereStr.AddWhereSqlIn("\"tblGiveMedicine\".medicine_long", names);
        }

        public void AddWhereDoctorMedecine(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblDoctor", field: "doctor_id", table: "tblPatientPrescrM");
            whereStr.AddWhereSqlIn("\"tblDoctor\".doctor_long", names);
        }

        public void AddWhereDateGiveStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientPrescrM\".give_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateGiveEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPrescrM", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientPrescrM\".give_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereSchemaChange(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblCureChange", field: "cure_change_id", table: "tblPatientCureSchema");
            whereStr.AddWhereSqlIn("\"tblCureChange\".cure_change_long", names);
        }

        public void AddWhereDateSchemaStart(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateMore("\"tblPatientCureSchema\".start_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateSchemaEnd(string date)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            whereStr.AddWhereSqlDateLess("\"tblPatientCureSchema\".start_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereRangeTherapy(string[] names)
        {
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCureSchema", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblRangeTherapy", field: "range_therapy_id", table: "tblPatientCureSchema");
            whereStr.AddWhereSqlIn("\"tblRangeTherapy\".range_therapy_long", names);
        }

        public void AddWhereDateVlStart(string date)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereSqlDateMore("\"vn\".acl_sample_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateVlEnd(string date)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereSqlDateLess("\"vn\".acl_sample_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereResVlStart(string res)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereIntConvertMore("\"vn\".acl_mcn_code", Int32.Parse(res));
        }

        public void AddWhereResVlEnd(string res)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" \"vn\" ON \"tblPatientCard\".\"patient_id\" = \"vn\".\"patient_id\" AND \"vn\".\"acl_test_code\" in (\'П0030\',\'П0060\')";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereIntConvertLess("\"vn\".acl_mcn_code", Int32.Parse(res));
        }

        public void AddWhereDateIMStart(string date)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereSqlDateMore("\"im\".acl_sample_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDateImEnd(string date)
        {
            string str = $"LEFT JOIN \"tblPatientAclResult\" \"im\" ON \"tblPatientCard\".\"patient_id\" = \"im\".\"patient_id\" AND \"im\".\"acl_test_code\" = \'И0025\'";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);

            whereStr.AddWhereSqlDateLess("\"im\".acl_sample_date", DateOnly.Parse(date).ToString("dd-MM-yyyy"));
        }

        public void AddWhereDeathTransferSubYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".death_transfer_sub";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereDesc(string name)
        {
            whereStr.AddWhereSqlContainsString("\"tblPatientCard\".addr_name", name);
        }

        #endregion

        #region приватные методы

        private void AddWhereYNAEnum(string fieldName, YNAEnum yna)
        {
            switch (yna)
            {
                case YNAEnum.Yes:
                    whereStr.AddWhereSqlTrue(fieldName);
                    break;
                case YNAEnum.No:
                    whereStr.AddWhereSqlFalseOrNull(fieldName);
                    break;
            }
        }

        private void AddSelectPhpSchemaInternal(string columnName, string schemaField, string alias)
        {
            columName.Add(columnName);
            selectGroupSrt.AppendLine($",\"{alias}\".cure_schema_long");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM", field: "patient_id", table: "tblPatientCard");
            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                   fieldLeft: schemaField,
                                                   fieldRight: "cure_schema_id",
                                                   table: "tblPatientPregnantM",
                                                   alias: alias);
        }

        private void AddSelectMedecineForSchemaInternal(string columnName, string schemaField, string phpAlias, string medicineRAlias, string medicineAlias)
        {
            columName.Add(columnName);

            selectGroupSrt.AppendLine($",\"{medicineAlias}\".medforschema_long");

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientPregnantM",
                                          field: "patient_id",
                                          table: "tblPatientCard");

            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblCureSchema",
                                                   fieldLeft: schemaField,
                                                   fieldRight: "cure_schema_id",
                                                   table: "tblPatientPregnantM",
                                                   alias: phpAlias);

            joinStr.AddLeftJoinIfNotExist(joinTable: "tblSchemaMedicineR",
                                          field: "cure_schema_id",
                                          table: phpAlias,
                                          alias: medicineRAlias);

            joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblMedicineForSchema",
                                                   fieldLeft: "medicine_id",
                                                   fieldRight: "medforschema_id",
                                                   table: medicineRAlias,
                                                   alias: medicineAlias);
        }
        
        private void AddPhpSchemaCondition(string schemaField, string alias, string[] schemaValues)
        {
            joinStr.AddLeftJoinIfNotExist(
                joinTable: "tblPatientPregnantM",
                field: "patient_id",
                table: "tblPatientCard");

            joinStr.AddLeftJoinIfNotExistDiffField(
                joinTable: "tblCureSchema",
                fieldLeft: schemaField,
                fieldRight: "cure_schema_id",
                table: "tblPatientPregnantM",
                alias: alias);

            whereStr.AddWhereSqlIn($"\"{alias}\".cure_schema_long", schemaValues);
        }

        private void AddMedicineForSchemaCondition(string schemaField, string phpAlias, string medicineRAlias, string medicineAlias, string[] medicineValues)
        {
            joinStr.AddLeftJoinIfNotExist(
                joinTable: "tblPatientPregnantM",
                field: "patient_id",
                table: "tblPatientCard");

            joinStr.AddLeftJoinIfNotExistDiffField(
                joinTable: "tblCureSchema",
                fieldLeft: schemaField,
                fieldRight: "cure_schema_id",
                table: "tblPatientPregnantM",
                alias: phpAlias);

            joinStr.AddLeftJoinIfNotExist(
                joinTable: "tblSchemaMedicineR",
                field: "cure_schema_id",
                table: phpAlias,
                alias: medicineRAlias);

            joinStr.AddLeftJoinIfNotExistDiffField(
                joinTable: "tblMedicineForSchema",
                fieldLeft: "medicine_id",
                fieldRight: "medforschema_id",
                table: medicineRAlias,
                alias: medicineAlias);

            whereStr.AddWhereSqlIn($"\"{medicineAlias}\".medforschema_long", medicineValues);
        }

        private void AddDieCauseColumns(
            List<string> columName,
            StringBuilder selectGroupSrt,
            StringBuilder joinStr,
            string description,
            string fieldLeft,
            string alias)
        {
            columName.Add(description);
            selectGroupSrt.AppendLine($",\"{alias}\".die_course_long");

            columName.Add($"МКБ {description}");
            selectGroupSrt.AppendLine($",\"{alias}\".die_course_short");

            joinStr.AddLeftJoinIfNotExistDiffField(
                joinTable: "tblTempDieCureMKB10List",
                fieldLeft: fieldLeft,
                fieldRight: "die_course_id",
                table: "tblPatientCard",
                alias: alias
            );
        }

        #endregion
    }
}