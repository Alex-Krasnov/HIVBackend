using DocumentFormat.OpenXml.Drawing.Charts;
using HIVBackend.Models.Enums;
using HIVBackend.Helpers;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchHospInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
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

        public bool SelectSex { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectDateHospIn { get; set; } = false;
        public bool SelectDateHospOut { get; set; } = false;
        public bool SelectLpu { get; set; } = false;
        public bool SelectHospCourse { get; set; } = false;
        public bool SelectHospResult { get; set; } = false;

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
                        _queryBuilder.AddSelectSex();

                    if (key.Name == "SelectUfsin")
                        _queryBuilder.AddSelectUfsin();

                    if (key.Name == "SelectDateHospIn")
                        _queryBuilder.AddSelectDateHospIn();

                    if (key.Name == "SelectDateHospOut")
                        _queryBuilder.AddSelectDateHospOut();

                    if (key.Name == "SelectLpu")
                        _queryBuilder.AddSelectLpu();

                    if (key.Name == "SelectHospCourse")
                        _queryBuilder.AddSelectHospCourse();

                    if (key.Name == "SelectHospResult")
                        _queryBuilder.AddSelectHospResult();
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (Sex.Length != 0)
                _queryBuilder.AddWhereSex(Sex);

            if (UfsinYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereUfsinYNA(UfsinYNA);

            if (DateUfsinStart.Length != 0)
                _queryBuilder.AddWhereDateUfsinStart(DateUfsinStart);

            if (DateUfsinEnd.Length != 0)
                _queryBuilder.AddWhereDateUfsinEnd(DateUfsinEnd);

            if (DateHospInStart.Length != 0)
                _queryBuilder.AddWhereDateHospInStart(DateHospInStart);

            if (DateHospInEnd.Length != 0)
                _queryBuilder.AddWhereDateHospInEnd(DateHospInEnd);

            if (DateHospOutStart.Length != 0)
                _queryBuilder.AddWhereDateHospOutStart(DateHospOutStart);

            if (DateHospOutEnd.Length != 0)
                _queryBuilder.AddWhereDateHospOutEnd(DateHospOutEnd);

            if (Lpu[0] != "Все")
                _queryBuilder.AddWhereLpu(Lpu);

            if (HospCourse[0] != "Все")
                _queryBuilder.AddWhereHospCourse(HospCourse);

            if (HospResult[0] != "Все")
                _queryBuilder.AddWhereHospResult(HospResult);

            #endregion
        }
    }
}
