using HIVBackend.Models.Enums;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchVisitInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
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
                        _queryBuilder.AddSelectSex();

                    if (key.Name == "SelectShowIllnes")
                        _queryBuilder.AddSelectShowIllnes();

                    if (key.Name == "SelectUfsin")
                        _queryBuilder.AddSelectUfsin();

                    if (key.Name == "SelectRegDate")
                        _queryBuilder.AddSelectRegDate();

                    if (key.Name == "SelectCheckDate")
                        _queryBuilder.AddSelectCheckDate();

                    if (key.Name == "SelectDoctor")
                        _queryBuilder.AddSelectDoctorReg();

                    if (key.Name == "SelectCardNo")
                        _queryBuilder.AddSelectCardNo();

                    if (key.Name == "SelectArt")
                        _queryBuilder.AddSelectArt();

                    if (key.Name == "SelectRegCheck")
                        _queryBuilder.AddSelectRegCheck();
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (Sex.Length != 0)
                _queryBuilder.AddWhereSex(Sex);

            if (ShowIllnes[0] != "Все")
                _queryBuilder.AddWhereShowIllnes(ShowIllnes);

            if (DateShowIllnesStart.Length != 0)
                _queryBuilder.AddWhereDateShowIllnesStart(DateShowIllnesStart);

            if (DateShowIllnesEnd.Length != 0)
                _queryBuilder.AddWhereDateShowIllnesEnd(DateShowIllnesEnd);

            if (UfsinYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereUfsinYNA(UfsinYNA);

            if (DateUfsinStart.Length != 0)
                _queryBuilder.AddWhereDateUfsinStart(DateUfsinStart);

            if (DateUfsinEnd.Length != 0)
                _queryBuilder.AddWhereDateUfsinEnd(DateUfsinEnd);

            if (RegDateStart.Length != 0)
                _queryBuilder.AddWhereRegDateStart(RegDateStart);

            if (RegDateEnd.Length != 0)
                _queryBuilder.AddWhereRegDateEnd(RegDateEnd);

            if (CheckDateStart.Length != 0)
                _queryBuilder.AddWhereCheckDateStart(CheckDateStart);

            if (CheckDateEnd.Length != 0)
                _queryBuilder.AddWhereCheckDateEnd(CheckDateEnd);

            if (Doctor[0] != "Все")
                _queryBuilder.AddWhereDoctorReg(Doctor);

            if (CardNo.Length != 0)
                _queryBuilder.AddWhereCardNo(CardNo);

            if (Art[0] != "Все")
                _queryBuilder.AddWhereArt(Art);

            if (RegCheck != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereRegCheck(RegCheck);

            #endregion
        }
    }
}
