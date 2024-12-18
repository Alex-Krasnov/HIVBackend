using HIVBackend.Enums;
using HIVBackend.Services;
using System.Text;

namespace HIVBackend.Models.FormModels.Search
{
    public abstract class BaseSearchInputForm
    {
        #region Общие поля

       // Адрес
        public string City { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Iindx { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Home { get; set; } = string.Empty;

        // Дата рождения
        public string BirthDateStart { get; set; } = string.Empty;
        public string BirthDateEnd { get; set; } = string.Empty;

        // Причина обращения
        public string[] CheckCourse { get; set; } = new string[] { "Все" };

        // Страна
        public string[] Country { get; set; } = new string[] { "Все" };

        // ФИО
        public string FamilyName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;

        // ФР / Зав. АПО
        public string FrYNA { get; set; } = YNAEnum.All.ToString();
        public string ZavApoYNA { get; set; } = YNAEnum.All.ToString();

        // Фактор риска заражения
        public string[] InfectCourse { get; set; } = new string[] { "Все" };

        // Дата ввода
        public string DateInpStart { get; set; } = string.Empty;
        public string DateInpEnd { get; set; } = string.Empty;

        // ИД пациента
        public string PatientId { get; set; } = string.Empty;

        // Регион (рег.)
        public string[] RegionReg { get; set; } = new string[] { RegionPresetEnum.All.ToString() };
        public string RegionPreset { get; set; } = RegionPresetEnum.All.ToString();

        // Регион (факт.)
        public string[] RegionFact { get; set; } = new string[] { RegionPresetEnum.All.ToString() };
        public string FactRegionPreset { get; set; } = RegionPresetEnum.All.ToString();

        // Дата пост.на учёт / снят.с учёта
        public string DateRegOnStart { get; set; } = string.Empty;
        public string DateRegOnEnd { get; set; } = string.Empty;
        public string DateUnRegStart { get; set; } = string.Empty;
        public string DateUnRegEnd { get; set; } = string.Empty;
        public string UnRegCourse { get; set; } = string.Empty;

        // СНИЛС
        public string SnilsYNA { get; set; } = YNAEnum.All.ToString();
        public string Snils { get; set; } = string.Empty;

        // Стадия
        public string[] Stage { get; set; } = new string[] { "Все" };

        // Передан в район
        public string TransfAreaYNA { get; set; } = YNAEnum.All.ToString();
        public string DateTransfAreaStart { get; set; } = string.Empty;
        public string DateTransfAreaEnd { get; set; } = string.Empty;

        // УНРЗ
        public string UnrzYNA { get; set; } = YNAEnum.All.ToString();
        public string Unrz { get; set; } = string.Empty;

        public int Page { get; set; } = 1;
        public bool Excel { get; set; } = false;

        public List<string> columName = new() { "Ид пациента" };
        public StringBuilder selectGroupSrt = new();
        public StringBuilder joinStr = new();
        public StringBuilder whereStr = new();

        #endregion

        #region Общие select поля

        public bool SelectAddr { get; set; } = false;
        public bool SelectBirthDate { get; set; } = false;
        public bool SelectCheckCourse { get; set; } = false;
        public bool SelectCountry { get; set; } = false;
        public bool SelectFio { get; set; } = false;
        public bool SelectFr { get; set; } = false;
        public bool SelectInfectCourse { get; set; } = false;
        public bool SelectInpDate { get; set; } = false;
        public bool SelectPatientId { get; set; } = false;
        public bool SelectRegion { get; set; } = false;
        public bool SelectRegionFact { get; set; } = false;
        public bool SelectRegOnDate { get; set; } = false;
        public bool SelectSnils { get; set; } = false;
        public bool SelectStage { get; set; } = false;
        public bool SelectTransfArea { get; set; } = false;
        public bool SelectUnrz { get; set; } = false;

        #endregion

        /// <summary>
        /// наполняем columName selectGroupSrt joinStr whereStr для дальнейшего поиска
        /// </summary>
        public virtual void SetSearchData()
        {
            selectGroupSrt.Append("\"tblPatientCard\".patient_id");
            joinStr.Append(" FROM \"tblPatientCard\"");
            whereStr.Append("WHERE true");

            #region Общая генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(BaseSearchInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectAddr")
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

                    if (key.Name == "SelectBirthDate")
                    {
                        columName.Add("Дата рождения");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".birth_date");
                    }

                    if (key.Name == "SelectCheckCourse")
                    {
                        columName.Add("Причина обращения");
                        selectGroupSrt.AppendLine(",\"tblCheckCourse\".check_course_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectCountry")
                    {
                        columName.Add("Страна");
                        selectGroupSrt.AppendLine(",\"tblCountry\".country_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectFio")
                    {
                        columName.Add("Фамилия");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".family_name");
                        columName.Add("Имя");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".first_name");
                        columName.Add("Отчество");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".third_name");
                    }

                    if (key.Name == "SelectFr")
                    {
                        columName.Add("Внесено в ФР");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_zam_med_part");
                        columName.Add("Зав АПО");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".flg_head_physician");
                    }

                    if (key.Name == "SelectInfectCourse")
                    {
                        columName.Add("Причина заражения");
                        selectGroupSrt.AppendLine(",\"tblInfectCourse\".infect_course_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectInpDate")
                    {
                        columName.Add("Дата ввода");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".input_date");
                    }

                    if (key.Name == "SelectRegion")
                    {
                        columName.Add("Регион");
                        selectGroupSrt.AppendLine(",\"tblRegion\".region_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectRegionFact")
                    {
                        columName.Add("Регион (факт.)");
                        selectGroupSrt.AppendLine(",\"tblRegionFact\".region_long");

                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                               fieldLeft: "fact_region_id",
                                                               fieldRight: "region_id",
                                                               table: "tblPatientCard",
                                                               alias: "tblRegionFact");
                    }

                    if (key.Name == "SelectRegOnDate")
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

                    if (key.Name == "SelectSnils")
                    {
                        columName.Add("СНИЛС");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".snils");
                    }

                    if (key.Name == "SelectStage")
                    {
                        columName.Add("Стадия");
                        selectGroupSrt.AppendLine(",stage.diagnosis_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
                    }

                    if (key.Name == "SelectTransfArea")
                    {
                        columName.Add("Дата передачи в район");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".transf_area_date");
                    }

                    if (key.Name == "SelectUnrz")
                    {
                        columName.Add("УНРЗ");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".unrz_fr");
                    }
                }
            }

            #endregion

            #region Общая генерация строки WHERE

            if (City.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".city_name", City.ToLower());
            }

            if (Location.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".location_name", Location.ToLower());
            }

            if (Iindx.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_ind", Iindx.ToLower());
            }

            if (Street.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_street", Street.ToLower());
            }

            if (Home.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".addr_house", Home.ToLower());
            }

            if (BirthDateStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".birth_date", DateOnly.Parse(BirthDateStart).ToString("dd-MM-yyyy"));
            }

            if (BirthDateEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".birth_date", DateOnly.Parse(BirthDateEnd).ToString("dd-MM-yyyy"));
            }

            if (CheckCourse[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCheckCourse", field: "check_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblCheckCourse\".check_course_long", CheckCourse);
            }

            if (Country[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblCountry", field: "country_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblCountry\".country_long", Country);
            }

            if (FamilyName.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".family_name", FamilyName.ToLower());
            }

            if (FirstName.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".first_name", FirstName.ToLower());
            }

            if (ThirdName.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".third_name", ThirdName.ToLower());
            }

            if (FrYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlTrue("\"tblPatientCard\".flg_zam_med_part");
            }

            if (FrYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlFalseOrNull("\"tblPatientCard\".flg_zam_med_part");
            }

            if (ZavApoYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlTrue("\"tblPatientCard\".flg_head_physician");
            }

            if (ZavApoYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlFalseOrNull("\"tblPatientCard\".flg_head_physician");
            }

            if (InfectCourse[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblInfectCourse", field: "infect_course_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblInfectCourse\".infect_course_long", InfectCourse);
            }

            if (DateInpStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".input_date", DateOnly.Parse(DateInpStart).ToString("dd-MM-yyyy"));
            }

            if (DateInpEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".input_date", DateOnly.Parse(DateInpEnd).ToString("dd-MM-yyyy"));
            }

            if (PatientId.Length != 0)
            {
                whereStr.AddWhereSqlEqual("\"tblPatientCard\".patient_id", PatientId);
            }

            if (RegionReg[0] != RegionPresetEnum.All.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                whereStr.AddWhereSqlIn("\"tblRegion\".region_long", RegionReg);
            }

            if (RegionPreset == RegionPresetEnum.Mo.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", ((int)RegionPresetEnum.Mo).ToString());
            }

            if (RegionPreset == RegionPresetEnum.Nonresidents.ToEnumDescriptionNameString())
            {
               joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
               whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", ((int)RegionPresetEnum.Nonresidents).ToString());
            }

            if (RegionPreset == RegionPresetEnum.Foreign.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
                whereStr.AddWhereSqlEqual("\"tblRegion\".regtype_id", ((int)RegionPresetEnum.Foreign).ToString());
            }

            if (RegionFact[0] != RegionPresetEnum.All.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                whereStr.AddWhereSqlIn("\"tblRegionFact\".region_long", RegionFact);
            }

            if (FactRegionPreset == RegionPresetEnum.Mo.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", ((int)RegionPresetEnum.Mo).ToString());
            }

            if (FactRegionPreset == RegionPresetEnum.Nonresidents.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", ((int)RegionPresetEnum.Nonresidents).ToString());
            }

            if (FactRegionPreset == RegionPresetEnum.Foreign.ToEnumDescriptionNameString())
            {
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                       fieldLeft: "fact_region_id",
                                                       fieldRight: "region_id",
                                                       table: "tblPatientCard",
                                                       alias: "tblRegionFact");

                whereStr.AddWhereSqlEqual("\"tblRegionFact\".regtype_id", ((int)RegionPresetEnum.Foreign).ToString());
            }

            if (DateRegOnStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_on_date", DateOnly.Parse(DateRegOnStart).ToString("dd-MM-yyyy"));
            }

            if (DateRegOnEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_on_date", DateOnly.Parse(DateRegOnEnd).ToString("dd-MM-yyyy"));
            }

            if (DateUnRegStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".reg_off_date", DateOnly.Parse(DateUnRegStart).ToString("dd-MM-yyyy"));
            }

            if (DateUnRegEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".reg_off_date", DateOnly.Parse(DateUnRegEnd).ToString("dd-MM-yyyy"));
            }

            if (UnRegCourse.Length != 0)
            {
                joinStr.AddLeftJoinIfNotExistDiffField(
                    joinTable: "tblInfectCourse",
                    fieldLeft: "reg_off_reason",
                    fieldRight: "infect_course_id",
                    table: "tblPatientCard",
                    alias: "regOff");
                whereStr.AddWhereSqlEqualString("\"regOff\".infect_course_long", UnRegCourse);
            }

            if (SnilsYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".snils");
            }

            if (SnilsYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".snils");
            }

            if (Snils.Length != 0)
            {
                whereStr.AddWhereSqlEqualString("\"tblPatientCard\".snils", Snils);
            }

            if (Stage[0] != "Все")
            {
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientDiagnosis", field: "patient_id", table: "tblPatientCard", alias: "patientStage");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblDiagnosis", field: "diagnosis_id", table: "patientStage", alias: "stage");
                whereStr.AddWhereSqlIn("stage.diagnosis_long", Stage);
            }

            if (TransfAreaYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".transf_area_date");
            }

            if (TransfAreaYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".transf_area_date");
            }

            if (DateTransfAreaStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCard\".transf_area_date", DateOnly.Parse(DateTransfAreaStart).ToString("dd-MM-yyyy"));
            }

            if (DateTransfAreaEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCard\".transf_area_date", DateOnly.Parse(DateTransfAreaEnd).ToString("dd-MM-yyyy"));
            }

            if (Unrz.Length != 0)
            {
                whereStr.AddWhereSqlEqualString("\"tblPatientCard\".unrz_fr", Unrz);
            }

            if (UnrzYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".unrz_fr");
            }

            if (UnrzYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientCard\".unrz_fr");
            }

            #endregion
        }
    }
}
