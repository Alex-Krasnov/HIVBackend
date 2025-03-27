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
