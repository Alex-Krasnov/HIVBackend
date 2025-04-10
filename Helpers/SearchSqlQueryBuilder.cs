using HIVBackend.Enums;
using System.Text;

namespace HIVBackend.Helpers
{
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

        public void AddAge()
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
            whereStr.AddWhereSqlEqualString("\"regOff\".infect_course_long", name);
        }

        public void AddWhereSnilsYNA(string ynaName)
        {
            var fieldName = "\"tblPatientCard\".snils";

            var enumValue = EnumExtension.GetEnumFromDescription<YNAEnum>(ynaName);

            AddWhereYNAEnum(fieldName, enumValue);
        }

        public void AddWhereSnils(string namePart)
        {
            whereStr.AddWhereSqlEqualString("\"tblPatientCard\".snils", namePart);
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
            whereStr.AddWhereSqlEqualString("\"tblPatientCard\".unrz_fr", namePart);
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
            whereStr.AddWhereSqlEqualString("\"tblSex\".sex_short", name);
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

        public void AddWhere(string namePart)

        public void AddWhere(string namePart)

        public void AddWhere(string namePart)

        public void AddWhere(string namePart)

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

        #endregion
    }
}
