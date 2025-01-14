using HIVBackend.Enums;
using HIVBackend.Services;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchVisitInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = string.Empty;
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;

        public string RegDateStart { get; set; } = string.Empty;
        public string RegDateEnd { get; set; } = string.Empty;
        public string CheckDateStart { get; set; } = string.Empty;
        public string CheckDateEnd { get; set; } = string.Empty;
        public string[] Doctor { get; set; } = new string[] { "Все" };
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };
        public string RegCheck { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; }
        public bool SelectShowIllnes { get; set; }
        public bool SelectUfsin { get; set; }

        public bool SelectRegDate { get; set; }
        public bool SelectCheckDate { get; set; }
        public bool SelectDoctor { get; set; }
        public bool SelectCardNo { get; set; }
        public bool SelectArt { get; set; }
        public bool SelectRegCheck { get; set; }

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchVisitInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectSex")
                    {
                        columName.Add("Пол");
                        selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
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

                    if (key.Name == "SelectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
                    }

                    if (key.Name == "SelectRegDate")
                    {
                        columName.Add("Дата записи");
                        selectGroupSrt.AppendLine(",\"tblPatientRegistry\".reg_date");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectCheckDate")
                    {
                        columName.Add("Дата приема на выезде");
                        selectGroupSrt.AppendLine(",\"tblPatientCheckOut\".check_date");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCheckOut", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectDoctor")
                    {
                        columName.Add("Специалист");
                        selectGroupSrt.AppendLine(",\"tblDoctor\".doctor_long");

                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblDoctor", fieldLeft: "reg_doctor_id", fieldRight: "doctor_id", table: "tblPatientRegistry");
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

                    if (key.Name == "SelectRegCheck")
                    {
                        columName.Add("Явка");
                        selectGroupSrt.AppendLine(",\"tblPatientRegistry\".reg_check");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
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

            if (RegDateStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientRegistry\".reg_date", DateOnly.Parse(RegDateStart).ToString("dd-MM-yyyy"));

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            }

            if (RegDateEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientRegistry\".reg_date", DateOnly.Parse(RegDateEnd).ToString("dd-MM-yyyy"));

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            }

            if (CheckDateStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientCheckOut\".check_date", DateOnly.Parse(CheckDateStart).ToString("dd-MM-yyyy"));

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCheckOut", field: "patient_id", table: "tblPatientCard");
            }

            if (CheckDateEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientCheckOut\".check_date", DateOnly.Parse(CheckDateEnd).ToString("dd-MM-yyyy"));

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientCheckOut", field: "patient_id", table: "tblPatientCard");
            }

            if (Doctor[0] != "Все")
            {
                whereStr.AddWhereSqlIn("\"tblDoctor\".doctor_long", Doctor);

                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExistDiffField(joinTable: "tblDoctor", fieldLeft: "reg_doctor_id", fieldRight: "doctor_id", table: "tblPatientRegistry");
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

            if (RegCheck == YNAEnum.Yes.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNotNull("\"tblPatientRegistry\".reg_check");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            }

            if (RegCheck == YNAEnum.No.ToEnumDescriptionNameString())
            {
                whereStr.AddWhereSqlIsNull("\"tblPatientRegistry\".reg_check");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientRegistry", field: "patient_id", table: "tblPatientCard");
            }

            #endregion
        }
    }
}
