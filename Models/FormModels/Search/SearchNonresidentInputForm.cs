using HIVBackend.Models.Enums;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchNonresidentInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string DateDiagnosisStart { get; set; } = string.Empty;
        public string DateDiagnosisEnd { get; set; } = string.Empty;
        public string[] PlaceDiagnosis { get; set; } = new string[] { "Все" };
        public string DateRegistrationYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateRegistrationStart { get; set; } = string.Empty;
        public string DateRegistrationEnd { get; set; } = string.Empty;
        public string DateDepartureYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateDepartureStart { get; set; } = string.Empty;
        public string DateDepartureEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectDateDiagnosis { get; set; } = false;
        public bool SelectPlaceDiagnosis { get; set; } = false;
        public bool SelectDateRegistration { get; set; } = false;
        public bool SelectDateDeparture { get; set; } = false;

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
                        _queryBuilder.AddSelectSex();

                    if (key.Name == "selectShowIllnes")
                        _queryBuilder.AddSelectShowIllnes();

                    if (key.Name == "SelectUfsin")
                        _queryBuilder.AddSelectUfsin();

                    if (key.Name == "SelectDateDiagnosis")
                        _queryBuilder.AddSelectDateDiagnosis();

                    if (key.Name == "SelectPlaceDiagnosis")
                        _queryBuilder.AddSelectPlaceDiagnosis();

                    if (key.Name == "SelectDateRegistration")
                        _queryBuilder.AddSelectDateRegistration();

                    if (key.Name == "SelectDateDeparture")
                        _queryBuilder.AddSelectDateDeparture();
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

            if (DateDiagnosisStart.Length != 0)
                _queryBuilder.AddWhereDateDiagnosisStart(DateDiagnosisStart);

            if (DateDiagnosisEnd.Length != 0)
                _queryBuilder.AddWhereDateDiagnosisEnd(DateDiagnosisEnd);

            if (PlaceDiagnosis[0] != "Все")
                _queryBuilder.AddWherePlaceDiagnosis(PlaceDiagnosis);

            if (DateRegistrationYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereDateRegistrationYNA(DateRegistrationYNA);

            if (DateRegistrationStart.Length != 0)
                _queryBuilder.AddWhereDateRegistrationStart(DateRegistrationStart);

            if (DateRegistrationEnd.Length != 0)
                _queryBuilder.AddWhereDateRegistrationEnd(DateRegistrationEnd);

            if (DateDepartureYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereDateDepartureYNA(DateDepartureYNA);

            if (DateDepartureStart.Length != 0)
                _queryBuilder.AddWhereDateDepartureStart(DateDepartureStart);

            if (DateDepartureEnd.Length != 0)
                _queryBuilder.AddWhereDateDepartureEnd(DateDepartureEnd);

            #endregion
        }
    }
}