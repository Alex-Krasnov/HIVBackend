namespace HIVBackend.Models.FormModels.Search
{
    public class SearchFastInputForm : BaseSearchInputForm
    {
        public string CardNo { get; set; } = string.Empty;

        public override void SetSearchData()
        {
            SelectFio = true;
            SelectBirthDate = true;
            SelectRegion = true;
            SelectAddr = true;

            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            _queryBuilder.AddSelectCardNo();

            _queryBuilder.AddSelectSex();

            #endregion

            #region Генерация строки WHERE

            if (CardNo.Length != 0)
                _queryBuilder.AddWhereCardNo(CardNo);

            #endregion
        }

    }
}
