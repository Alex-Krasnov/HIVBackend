using DocumentFormat.OpenXml.Drawing.Charts;
using HIVBackend.Enums;
using HIVBackend.Services;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchHospInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = string.Empty;
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string DateHospInStart { get; set; } = string.Empty;
        public string DateHospInEnd { get; set; } = string.Empty;
        public string DateHospOutStart { get; set; } = string.Empty;
        public string DateHospOutEnd { get; set; } = string.Empty;
        public string[] Lpu { get; set; } = new string[] { "Все" };
        public string[] HospCourse { get; set; } = new string[] { "Все" };
        public string[] HospResult { get; set; } = new string[] { "Все" };

        #endregion

        #region select поля

        public bool selectSex { get; set; } = false;
        public bool selectUfsin { get; set; } = false;
        public bool selectDateHospIn { get; set; } = false;
        public bool selectDateHospOut { get; set; } = false;
        public bool selectLpu { get; set; } = false;
        public bool selectHospCourse { get; set; } = false;
        public bool selectHospResult { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchHospInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectSex")
                    {
                        columName.Add("Пол");
                        selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");
                    }

                    if (key.Name == "SelectUfsin")
                    {
                        columName.Add("Дата постановки на учет УФСИН");
                        selectGroupSrt.AppendLine(",\"tblPatientCard\".ufsin_date");
                    }

                    if (key.Name == "selectDateHospIn")
                    {
                        columName.Add("Дата госп");
                        selectGroupSrt.AppendLine(",\"tblPatientHospResultR\".date_hosp_in");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectDateHospOut")
                    {
                        columName.Add("Дата выписки");
                        selectGroupSrt.AppendLine(",\"tblPatientHospResultR\".date_hosp_out");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                    }

                    if (key.Name == "selectLpu")
                    {
                        columName.Add("МО");
                        selectGroupSrt.AppendLine(",\"tblLpu\".lpu_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblLpu", field: "lpu_id", table: "tblPatientHospResultR");
                    }

                    if (key.Name == "selectHospCourse")
                    {
                        columName.Add("Причина госпитализации");
                        selectGroupSrt.AppendLine(",\"tblHospCourse\".hosp_course_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospCourse", field: "hosp_course_id", table: "tblPatientHospResultR");
                    }

                    if (key.Name == "selectHospResult")
                    {
                        columName.Add("Исход госпитализации");
                        selectGroupSrt.AppendLine(",\"tblHospResult\".hosp_result_long");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                        joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospResult", field: "hosp_result_id", table: "tblPatientHospResultR");
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

            if (DateHospInStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientHospResultR\".date_hosp_in", DateOnly.Parse(DateHospInStart).ToString("dd-MM-yyyy"));
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            }

            if (DateHospInEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientHospResultR\".date_hosp_in", DateOnly.Parse(DateHospInEnd).ToString("dd-MM-yyyy"));
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            }

            if (DateHospOutStart.Length != 0)
            {
                whereStr.AddWhereSqlDateMore("\"tblPatientHospResultR\".date_hosp_out", DateOnly.Parse(DateHospOutStart).ToString("dd-MM-yyyy"));
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            }

            if (DateHospOutEnd.Length != 0)
            {
                whereStr.AddWhereSqlDateLess("\"tblPatientHospResultR\".date_hosp_out", DateOnly.Parse(DateHospOutEnd).ToString("dd-MM-yyyy"));
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
            }

            if (Lpu[0] != "Все")
            {
                whereStr.AddWhereSqlIn("\"tblLpu\".lpu_long", Lpu);
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblLpu", field: "lpu_id", table: "tblPatientHospResultR");
            }

            if (HospCourse[0] != "Все")
            {
                whereStr.AddWhereSqlIn("\"tblHospCourse\".hosp_course_long", HospCourse);
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospCourse", field: "hosp_course_id", table: "tblPatientHospResultR");
            }

            if (HospResult[0] != "Все")
            {
                whereStr.AddWhereSqlIn("\"tblHospResult\".hosp_result_long", HospCourse);
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblPatientHospResultR", field: "patient_id", table: "tblPatientCard");
                joinStr.AddLeftJoinIfNotExist(joinTable: "tblHospResult", field: "hosp_result_id", table: "tblPatientHospResultR");
            }

            #endregion
        }
    }
}
