using HIVBackend.Enums;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchPregnantInputForm : BaseSearchInputForm
    {
        #region поля

        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };

        public string[] PregCheck { get; set; } = new string[] { "Все" };
        public string PregMonthNo { get; set; } = string.Empty;
        public string[] BirthType { get; set; } = new string[] { "Все" };
        public string MedecineStartMonthNo { get; set; } = string.Empty;
        public string ChildBirthDateStart { get; set; } = string.Empty;
        public string ChildBirthDateEnd { get; set; } = string.Empty;
        public string ChildFamilyName { get; set; } = string.Empty;
        public string ChildFirstName { get; set; } = string.Empty;
        public string ChildThirdName { get; set; } = string.Empty;
        public string[] PhpSchema1 { get; set; } = new string[] { "Все" };
        public string[] PhpSchema2 { get; set; } = new string[] { "Все" };
        public string[] PhpSchema3 { get; set; } = new string[] { "Все" };
        public string[] MedecineForSchema1 { get; set; } = new string[] { "Все" };
        public string[] MedecineForSchema2 { get; set; } = new string[] { "Все" };
        public string[] MedecineForSchema3 { get; set; } = new string[] { "Все" };
        public string[] Materhome { get; set; } = new string[] { "Все" };
        public string AclDateStart { get; set; } = string.Empty;
        public string AclDateEnd { get; set; } = string.Empty;
        public string AclMcnCodeStart { get; set; } = string.Empty;
        public string AclMcnCodeEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectArt { get; set; } = false;

        public bool SelectPregCheck { get; set; } = false;
        public bool SelectPregMonthNo { get; set; } = false;
        public bool SelectBirthType { get; set; } = false;
        public bool SelectMedecineStartMonthNo { get; set; } = false;
        public bool SelectChildBirthDate { get; set; } = false;
        public bool SelectChildFio { get; set; } = false;
        public bool SelectPhpSchema1 { get; set; } = false;
        public bool SelectPhpSchema2 { get; set; } = false;
        public bool SelectPhpSchema3 { get; set; } = false;
        public bool SelectMedecineForSchema1 { get; set; } = false;
        public bool SelectMedecineForSchema2 { get; set; } = false;
        public bool SelectMedecineForSchema3 { get; set; } = false;
        public bool SelectMaterhome { get; set; } = false;
        public bool SelectAclDate { get; set; } = false;
        public bool SelectAclMcnCode { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchPregnantInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectShowIllnes")
                        _queryBuilder.AddSelectShowIllnes();

                    if (key.Name == "SelectUfsin")
                        _queryBuilder.AddSelectUfsin();

                    if (key.Name == "SelectCardNo")
                        _queryBuilder.AddSelectCardNo();

                    if (key.Name == "SelectArt")
                        _queryBuilder.AddSelectArt();

                    if (key.Name == "SelectPregCheck")
                        _queryBuilder.AddSelectPregCheck();

                    if (key.Name == "SelectPregMonthNo")
                        _queryBuilder.AddSelectPregMonthNo();

                    if (key.Name == "SelectBirthType")
                        _queryBuilder.AddSelectBirthType();

                    if (key.Name == "SelectMedecineStartMonthNo")
                        _queryBuilder.AddSelectMedecineStartMonthNo();

                    if (key.Name == "SelectChildBirthDate")
                        _queryBuilder.AddSelectChildBirthDate();

                    if (key.Name == "SelectChildFio")
                        _queryBuilder.AddSelectChildFio();

                    if (key.Name == "SelectPhpSchema1")
                        _queryBuilder.AddSelectPhpSchema1();

                    if (key.Name == "SelectPhpSchema2")
                        _queryBuilder.AddSelectPhpSchema2();

                    if (key.Name == "SelectPhpSchema3")
                        _queryBuilder.AddSelectPhpSchema3();

                    if (key.Name == "SelectMedecineForSchema1")
                        _queryBuilder.AddSelectMedecineForSchema1();

                    if (key.Name == "SelectMedecineForSchema2")
                        _queryBuilder.AddSelectMedecineForSchema2();

                    if (key.Name == "SelectMedecineForSchema3")
                        _queryBuilder.AddSelectMedecineForSchema3();

                    if (key.Name == "SelectMaterhome")
                        _queryBuilder.AddSelectMaterhome();

                    if (key.Name == "SelectAclDate")
                        _queryBuilder.AddSelectAclDate();

                    if (key.Name == "SelectAclMcnCode")
                        _queryBuilder.AddSelectAclMcnCode();
                }
            }

            #endregion

            #region Генерация строки WHERE

            // чтобы были только беременые
            _queryBuilder.OnlyPregnant();

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

            if (CardNo.Length != 0)
                _queryBuilder.AddWhereCardNo(CardNo);

            if (Art[0] != "Все")
                _queryBuilder.AddWhereArt(Art);

            if (PregCheck[0] != "Все")
                _queryBuilder.AddWherePregCheck(PregCheck);

            if (PregMonthNo.Length != 0)
                _queryBuilder.AddWherePregMonthNo(PregMonthNo);

            if (BirthType[0] != "Все")
                _queryBuilder.AddWhereBirthType(BirthType);

            if (MedecineStartMonthNo.Length != 0)
                _queryBuilder.AddWhereMedecineStartMonthNo(MedecineStartMonthNo);

            if (ChildBirthDateStart.Length != 0)
                _queryBuilder.AddWhereChildBirthDateStart(ChildBirthDateStart);

            if (ChildBirthDateEnd.Length != 0)
                _queryBuilder.AddWhereChildBirthDateEnd(ChildBirthDateEnd);

            if (ChildFamilyName.Length != 0)
                _queryBuilder.AddWhereChildFamilyName(ChildFamilyName);

            if (ChildFirstName.Length != 0)
                _queryBuilder.AddWhereChildFirstName(ChildFirstName);

            if (ChildThirdName.Length != 0)
                _queryBuilder.AddWhereChildThirdName(ChildThirdName);

            if (PhpSchema1[0] != "Все")
                _queryBuilder.AddWherePhpSchema1(PhpSchema1);

            if (PhpSchema2[0] != "Все")
                _queryBuilder.AddWherePhpSchema2(PhpSchema2);

            if (PhpSchema3[0] != "Все")
                _queryBuilder.AddWherePhpSchema3(PhpSchema3);

            if (MedecineForSchema1[0] != "Все")
                _queryBuilder.AddWhereMedecineForSchema1(MedecineForSchema1);

            if (MedecineForSchema2[0] != "Все")
                _queryBuilder.AddWhereMedecineForSchema2(MedecineForSchema2);

            if (MedecineForSchema3[0] != "Все")
                _queryBuilder.AddWhereMedecineForSchema3(MedecineForSchema3);

            if (Materhome[0] != "Все")
                _queryBuilder.AddWhereMaterhome(Materhome);

            if (AclDateStart.Length != 0)
                _queryBuilder.AddWhereAclDateStart(AclDateStart);

            if (AclDateEnd.Length != 0)
                _queryBuilder.AddWhereAclDateEnd(AclDateEnd);

            #endregion
        }
    }
}
