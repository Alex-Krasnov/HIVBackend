using HIVBackend.Enums;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchChildInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
        public string DateDieStart { get; set; } = string.Empty;
        public string DateDieEnd { get; set; } = string.Empty;
        public string DateDieAidsStart { get; set; } = string.Empty;
        public string DateDieAidsEnd { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };

        public string AgeDayStart { get; set; } = string.Empty;
        public string AgeDayEnd { get; set; } = string.Empty;
        public string[] FamilyType { get; set; } = new string[] { "Все" };
        public string FirstCheckDateStart { get; set; } = string.Empty;
        public string FirstCheckDateEnd { get; set; } = string.Empty;
        public string[] ChildPlace { get; set; } = new string[] { "Все" };
        public string BreastMonthNoStart { get; set; } = string.Empty;
        public string BreastMonthNoEnd { get; set; } = string.Empty;
        public string[] ChildPhp { get; set; } = new string[] { "Все" };
        public string MotherPatientId { get; set; } = string.Empty;
        public string FatherPatientId { get; set; } = string.Empty;
        public string[] MaterHome { get; set; } = new string[] { "Все" };
        public string Form309 { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; } = false;
        public bool SelectDieDate { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectArt { get; set; } = false;

        public bool SelectFamilyType { get; set; } = false;
        public bool SelectFirstCheckDate { get; set; } = false;
        public bool SelectChildPlace { get; set; } = false;
        public bool SelectBreastMonthNo { get; set; } = false;
        public bool SelectChildPhp { get; set; } = false;
        public bool SelectParentId { get; set; } = false;
        public bool SelectMaterHome { get; set; } = false;
        public bool SelectForm309 { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchChildInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectBirthDate")
                        _queryBuilder.AddSelectAgeDay();

                    if (key.Name == "SelectSex")
                        _queryBuilder.AddSelectSex();

                    if (key.Name == "SelectDieDate")
                        _queryBuilder.AddSelectDieDate();

                    if (key.Name == "SelectShowIllnes")
                        _queryBuilder.AddSelectShowIllnes();

                    if (key.Name == "SelectCardNo")
                        _queryBuilder.AddSelectCardNo();

                    if (key.Name == "SelectArt")
                        _queryBuilder.AddSelectArt();

                    if (key.Name == "SelectFamilyType")
                        _queryBuilder.AddSelectFamilyType();

                    if (key.Name == "SelectFirstCheckDate")
                        _queryBuilder.AddSelectFirstCheckDate();

                    if (key.Name == "SelectChildPlace")
                        _queryBuilder.AddSelectChildPlace();

                    if (key.Name == "SelectBreastMonthNo")
                        _queryBuilder.AddSelectBreastMonthNo();

                    if (key.Name == "SelectChildPhp")
                        _queryBuilder.AddSelectChildPhp();

                    if (key.Name == "SelectParentId")
                        _queryBuilder.AddSelectParent();

                    if (key.Name == "SelectMaterHome")
                        _queryBuilder.AddSelectMaterHome();

                    if (key.Name == "SelectForm309")
                        _queryBuilder.AddSelectForm309();
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (Sex.Length != 0)
                _queryBuilder.AddWhereSex(Sex);

            if (DateDieStart.Length != 0)
                _queryBuilder.AddWhereDateDieStart(DateDieStart);

            if (DateDieEnd.Length != 0)
                _queryBuilder.AddWhereDateDieEnd(DateDieEnd);

            if (DateDieAidsStart.Length != 0)
                _queryBuilder.AddWhereDateDieAidsStart(DateDieAidsStart);

            if (DateDieAidsEnd.Length != 0)
                _queryBuilder.AddWhereDateDieAidsEnd(DateDieAidsEnd);

            if (ShowIllnes[0] != "Все")
                _queryBuilder.AddWhereShowIllnes(ShowIllnes);

            if (DateShowIllnesStart.Length != 0)
                _queryBuilder.AddWhereDateShowIllnesStart(DateShowIllnesStart);

            if (DateShowIllnesEnd.Length != 0)
                _queryBuilder.AddWhereDateShowIllnesEnd(DateShowIllnesEnd);

            if (CardNo.Length != 0)
                _queryBuilder.AddWhereCardNo(CardNo);

            if (Art[0] != "Все")
                _queryBuilder.AddWhereArt(Art);

            if (AgeDayStart.Length != 0)
                _queryBuilder.AddWhereAgeDayStart(AgeDayStart);

            if (AgeDayEnd.Length != 0)
                _queryBuilder.AddWhereAgeDayEnd(AgeDayEnd);

            if (FamilyType[0] != "Все")
                _queryBuilder.AddWhereFamilyType(FamilyType);

            if (FirstCheckDateStart.Length != 0)
                _queryBuilder.AddWhereFirstCheckDateStart(FirstCheckDateStart);

            if (FirstCheckDateEnd.Length != 0)
                _queryBuilder.AddWhereFirstCheckDateEnd(FirstCheckDateEnd);

            if (ChildPlace[0] != "Все")
                _queryBuilder.AddWhereChildPlace(ChildPlace);

            if (BreastMonthNoStart.Length != 0)
                _queryBuilder.AddWhereBreastMonthNoStart(BreastMonthNoStart);

            if (BreastMonthNoEnd.Length != 0)
                _queryBuilder.AddWhereBreastMonthNoEnd(BreastMonthNoEnd);

            if (ChildPhp[0] != "Все")
                _queryBuilder.AddWhereChildPhp(ChildPhp);

            if (MotherPatientId.Length != 0)
                _queryBuilder.AddWhereMotherPatientId(MotherPatientId);

            if (FatherPatientId.Length != 0)
                _queryBuilder.AddWhereFatherPatientId(FatherPatientId);

            if (MaterHome[0] != "Все")
                _queryBuilder.AddWhereMaterHome(MaterHome);

            if (Form309 != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereForm309YNA(Form309);

            #endregion
        }
    }
}
