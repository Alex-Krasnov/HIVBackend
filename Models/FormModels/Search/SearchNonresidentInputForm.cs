using HIVBackend.Enums;
using HIVBackend.Services;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchNonresidentInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = string.Empty;
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string DateDiagnosisStart { get; set; } = string.Empty;
        public string DateDiagnosisEnd { get; set; } = string.Empty;
        public string[] PlaceDiagnosis { get; set; } = new string[] { "Все" };
        public string DateRegistrationYNA { get; set; } = string.Empty;
        public string DateRegistrationStart { get; set; } = string.Empty;
        public string DateRegistrationEnd { get; set; } = string.Empty;
        public string DateDepartureYNA { get; set; } = string.Empty;
        public string DateDepartureStart { get; set; } = string.Empty;
        public string DateDepartureEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool selectSex { get; set; } = false;
        public bool selectShowIllnes { get; set; } = false;
        public bool selectUfsin { get; set; } = false;
        public bool selectDateDiagnosis { get; set; } = false;
        public bool selectPlaceDiagnosis { get; set; } = false;
        public bool selectDateRegistration { get; set; } = false;
        public bool selectDateDeparture { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            // вызываем общую генерацию
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchTreatmentInputForm).GetProperties().Where(e => e.Name.StartsWith("select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectSex")
                    {
                        base.columName.Add("Пол");
                        base.selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
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

                    if (key.Name == "SelectUfsin")
                    {
                        base.columName.Add("Дата постановки на учет УФСИН");
                        base.selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
                    }

                    if (key.Name == "selectDateDiagnosis")
                    {
                        columName.Add("Дата установления диагноза");
                        base.selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_diagnosis");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");

                    }

                    if (key.Name == "selectPlaceDiagnosis")
                    {
                        columName.Add("Место установл.диагноза");
                        base.selectGroupSrt.AppendLine(",\"tblRegionNonresident\".region_long");
                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");

                        base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion", 
                                                           alias: "tblRegionNonresident", 
                                                           fieldRight: "region_id", 
                                                           table: "tblPatientNonresident",
                                                           fieldLeft: "place_diagnosis");
                    }

                    if (key.Name == "selectDateRegistration")
                    {
                        columName.Add("Дата регистрации с");
                        base.selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_registration_from");
                        columName.Add("Дата регистрации по");
                        base.selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_registration_to");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectDateDeparture")
                    {
                        columName.Add("Дата убытия");
                        base.selectGroupSrt.AppendLine(",\"tblPatientNonresident\".date_departure");

                        base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
                    }
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (Sex.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                base.whereStr.AddWhereSqlEqualString("\"tblSex\".sex_short", Sex);
            }

            if (ShowIllnes[0] != "Все")
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                base.whereStr.AddWhereSqlIn("\"tblShowIllness\".show_illness_long", ShowIllnes);
            }

            if (DateShowIllnesStart.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                base.whereStr.AddWhereSqlDateMore("\"tblPatientShowIllness\".start_date", DateOnly.Parse(DateShowIllnesStart).ToString("dd-MM-yyyy"));
            }

            if (DateShowIllnesEnd.Length != 0)
            {
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientShowIllness", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblShowIllness", field: "show_illness_id", table: "tblPatientShowIllness");
                base.whereStr.AddWhereSqlDateLess("\"tblPatientShowIllness\".end_date", DateOnly.Parse(DateShowIllnesEnd).ToString("dd-MM-yyyy"));
            }

            if (UfsinYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                base.whereStr.AddWhereSqlIsNotNull("\"tblPatientCard\".ufsin_date");
            }

            if (UfsinYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                base.whereStr.AddWhereSqlIsNull("\"tblPatientCard\".ufsin_date");
            }

            if (DateUfsinStart.Length != 0)
            {
                base.whereStr.AddWhereSqlDateMore("\"tblPatientCard\".ufsin_date", DateOnly.Parse(DateUfsinStart).ToString("dd-MM-yyyy"));
            }

            if (DateUfsinEnd.Length != 0)
            {
                base.whereStr.AddWhereSqlDateLess("\"tblPatientCard\".ufsin_date", DateOnly.Parse(DateUfsinEnd).ToString("dd-MM-yyyy"));
            }

            if (DateDiagnosisStart.Length != 0)
            {
                base.whereStr.AddWhereSqlDateMore("\"tblPatientNonresident\".date_diagnosis", DateOnly.Parse(DateDiagnosisStart).ToString("dd-MM-yyyy"));
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateDiagnosisEnd.Length != 0)
            {
                base.whereStr.AddWhereSqlDateLess("\"tblPatientNonresident\".date_diagnosis", DateOnly.Parse(DateDiagnosisEnd).ToString("dd-MM-yyyy"));
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (PlaceDiagnosis[0] != "Все")
            {
                base.whereStr.AddWhereSqlIn("\"tblRegionNonresident\".region_long", PlaceDiagnosis);

                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
                base.joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblRegion",
                                                            alias: "tblRegionNonresident",
                                                            fieldRight: "region_id",
                                                            table: "tblPatientNonresident",
                                                            fieldLeft: "place_diagnosis");
            }

            if (DateRegistrationYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                base.whereStr.AddWhereSqlIsNotNull("\"tblPatientNonresident\".date_registration_from");

                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateRegistrationYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                base.whereStr.AddWhereSqlIsNull("\"tblPatientNonresident\".date_registration_from");

                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateRegistrationStart.Length != 0)
            {
                base.whereStr.AddWhereSqlDateMore("\"tblPatientNonresident\".date_registration_from", DateOnly.Parse(DateRegistrationStart).ToString("dd-MM-yyyy"));
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateRegistrationEnd.Length != 0)
            {
                base.whereStr.AddWhereSqlDateLess("\"tblPatientNonresident\".date_registration_from", DateOnly.Parse(DateRegistrationEnd).ToString("dd-MM-yyyy"));
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateDepartureYNA == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                base.whereStr.AddWhereSqlIsNotNull("\"tblPatientNonresident\".date_departure");

                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateDepartureYNA == YNAEnum.No.ToEnumDescriptionNameString())
            {
                base.whereStr.AddWhereSqlIsNull("\"tblPatientNonresident\".date_departure");

                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateDepartureStart.Length != 0)
            {
                base.whereStr.AddWhereSqlDateMore("\"tblPatientNonresident\".date_departure", DateOnly.Parse(DateDepartureStart).ToString("dd-MM-yyyy"));
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            if (DateDepartureEnd.Length != 0)
            {
                base.whereStr.AddWhereSqlDateLess("\"tblPatientNonresident\".date_departure", DateOnly.Parse(DateDepartureEnd).ToString("dd-MM-yyyy"));
                base.joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientNonresident", field: "patient_id", table: "tblPatientCard");
            }

            #endregion
        }
    }
}