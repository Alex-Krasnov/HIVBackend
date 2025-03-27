using DocumentFormat.OpenXml.Drawing.Charts;
using HIVBackend.Enums;
using HIVBackend.Helpers;
using System.Reflection;

namespace HIVBackend.Models.FormModels.Search
{
    public abstract class BaseSearchInputForm
    {
        #region Общие поля

       // Адрес
        public string City { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Indx { get; set; } = string.Empty;
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
        public string FrYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string ZavApoYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();

        // Фактор риска заражения
        public string[] InfectCourse { get; set; } = new string[] { "Все" };

        // Дата ввода
        public string DateInpStart { get; set; } = string.Empty;
        public string DateInpEnd { get; set; } = string.Empty;

        // ИД пациента
        public string PatientId { get; set; } = string.Empty;

        // Регион (рег.)
        public string[] RegionReg { get; set; } = new string[] { RegionPresetEnum.All.ToEnumDescriptionNameString() };
        public string RegionPreset { get; set; } = RegionPresetEnum.All.ToEnumDescriptionNameString();

        // Регион (факт.)
        public string[] RegionFact { get; set; } = new string[] { RegionPresetEnum.All.ToEnumDescriptionNameString() };
        public string FactRegionPreset { get; set; } = RegionPresetEnum.All.ToEnumDescriptionNameString();

        // Дата пост.на учёт / снят.с учёта
        public string DateRegOnStart { get; set; } = string.Empty;
        public string DateRegOnEnd { get; set; } = string.Empty;
        public string DateUnRegStart { get; set; } = string.Empty;
        public string DateUnRegEnd { get; set; } = string.Empty;
        public string UnRegCourse { get; set; } = string.Empty;

        // СНИЛС
        public string SnilsYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string Snils { get; set; } = string.Empty;

        // Стадия
        public string[] Stage { get; set; } = new string[] { "Все" };

        // Передан в район
        public string TransfAreaYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateTransfAreaStart { get; set; } = string.Empty;
        public string DateTransfAreaEnd { get; set; } = string.Empty;

        // УНРЗ
        public string UnrzYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string Unrz { get; set; } = string.Empty;

        #endregion

        #region Общие select поля

        [Order(1)]
        public bool SelectPatientId { get; set; } = false;
        [Order(2)]
        public bool SelectSnils { get; set; } = false;
        [Order(3)]
        public bool SelectFio { get; set; } = false;
        [Order(4)]
        public bool SelectBirthDate { get; set; } = false;
        [Order(5)]
        public bool SelectRegion { get; set; } = false;
        [Order(6)]
        public bool SelectRegionFact { get; set; } = false;
        [Order(7)]
        public bool SelectAddr { get; set; } = false;
        [Order(8)]
        public bool SelectCheckCourse { get; set; } = false;
        [Order(9)]
        public bool SelectInfectCourse { get; set; } = false;
        [Order(10)]
        public bool SelectStage { get; set; } = false;
        [Order(11)]
        public bool SelectCountry { get; set; } = false;
        [Order(12)]
        public bool SelectFr { get; set; } = false;
        [Order(13)]
        public bool SelectInpDate { get; set; } = false;
        [Order(14)]
        public bool SelectRegOnDate { get; set; } = false;
        [Order(15)]
        public bool SelectTransfArea { get; set; } = false;
        [Order(16)]
        public bool SelectUnrz { get; set; } = false;

        #endregion

        #region Служебные

        public int Page { get; set; } = 1;
        public bool Excel { get; set; } = false;

        public SearchSqlQueryBuilder _queryBuilder;

        #endregion

        public BaseSearchInputForm()
        {
            _queryBuilder = new SearchSqlQueryBuilder();
        }

        /// <summary>
        /// наполняем columName selectGroupSrt joinStr whereStr для дальнейшего поиска
        /// </summary>
        public virtual void SetSearchData()
        {
            #region Общая генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(BaseSearchInputForm).GetProperties()
                                                           .Where(e => e.Name.StartsWith("Select"))
                                                           .OrderBy(p => p.GetCustomAttribute<OrderAttribute>()?.Order ?? double.MaxValue))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectAddr")
                        _queryBuilder.AddSelectAddr();

                    if (key.Name == "SelectBirthDate")
                        _queryBuilder.AddSelectBirthDate();

                    if (key.Name == "SelectCheckCourse")
                        _queryBuilder.AddSelectCheckCourse();

                    if (key.Name == "SelectCountry")
                        _queryBuilder.AddSelectCountry();

                    if (key.Name == "SelectFio")
                        _queryBuilder.AddSelectFio();

                    if (key.Name == "SelectFr")
                        _queryBuilder.AddSelectFr();

                    if (key.Name == "SelectInfectCourse")
                        _queryBuilder.AddSelectInfectCourse();

                    if (key.Name == "SelectInpDate")
                        _queryBuilder.AddSelectInpDate();

                    if (key.Name == "SelectRegion")
                        _queryBuilder.AddSelectRegion();

                    if (key.Name == "SelectRegionFact")
                        _queryBuilder.AddSelectRegionFact();

                    if (key.Name == "SelectRegOnDate")
                        _queryBuilder.AddSelectRegOnDate();

                    if (key.Name == "SelectSnils")
                        _queryBuilder.AddSelectSnils();

                    if (key.Name == "SelectStage")
                        _queryBuilder.AddSelectStage();

                    if (key.Name == "SelectTransfArea")
                        _queryBuilder.AddSelectTransfArea();

                    if (key.Name == "SelectUnrz")
                        _queryBuilder.AddSelectUnrz();
                }
            }

            #endregion

            #region Общая генерация строки WHERE

            if (City.Length != 0)
                _queryBuilder.AddWhereCity(City);

            if (Location.Length != 0)
                _queryBuilder.AddWhereLocation(Location);

            if (Indx.Length != 0)
                _queryBuilder.AddWhereIndx(Indx);

            if (Street.Length != 0)
                _queryBuilder.AddWhereStreet(Street);

            if (Home.Length != 0)
                _queryBuilder.AddWhereHome(Home);

            if (BirthDateStart.Length != 0)
                _queryBuilder.AddWhereBirthDateStart(BirthDateStart);

            if (BirthDateEnd.Length != 0)
                _queryBuilder.AddWhereBirthDateEnd(BirthDateEnd);

            if (CheckCourse[0] != "Все")
                _queryBuilder.AddWhereCheckCourse(CheckCourse);

            if (Country[0] != "Все")
                _queryBuilder.AddWhereCountry(Country);

            if (FamilyName.Length != 0)
                _queryBuilder.AddWhereFamilyName(FamilyName);

            if (FirstName.Length != 0)
                _queryBuilder.AddWhereFirstName(FirstName);

            if (ThirdName.Length != 0)
                _queryBuilder.AddWhereThirdName(ThirdName);

            _queryBuilder.AddWhereFrYNA(FrYNA);

            _queryBuilder.AddWhereZavApoYNA(ZavApoYNA);

            if (InfectCourse[0] != "Все")
                _queryBuilder.AddWhereInfectCourse(InfectCourse);

            if (DateInpStart.Length != 0)
                _queryBuilder.AddWhereDateInpStart(DateInpStart);

            if (DateInpEnd.Length != 0)
                _queryBuilder.AddWhereDateInpEnd(DateInpEnd);

            if (PatientId.Length != 0)
                _queryBuilder.AddWherePatientId(PatientId);

            if (RegionReg[0] != "Все")
                _queryBuilder.AddWhereRegionReg(RegionReg);

            _queryBuilder.AddWhereRegionPreset(RegionPreset);

            if (RegionFact[0] != "Все")
                _queryBuilder.AddWhereRegionFact(RegionFact);

            _queryBuilder.AddWhereFactRegionPreset(FactRegionPreset);

            if (DateRegOnStart.Length != 0)
                _queryBuilder.AddWhereDateRegOnStart(DateRegOnStart);

            if (DateRegOnEnd.Length != 0)
                _queryBuilder.AddWhereDateRegOnEnd(DateRegOnEnd);

            if (DateUnRegStart.Length != 0)
                _queryBuilder.AddWhereDateUnRegStart(DateUnRegStart);

            if (DateUnRegEnd.Length != 0)
                _queryBuilder.AddWhereDateUnRegEnd(DateUnRegEnd);

            if (UnRegCourse.Length != 0)
                _queryBuilder.AddWhereUnRegCourse(UnRegCourse);

            _queryBuilder.AddWhereSnilsYNA(SnilsYNA);

            if (Snils.Length != 0)
                _queryBuilder.AddWhereSnils(Snils);

            if (Stage[0] != "Все")
                _queryBuilder.AddWhereStage(Stage);

            _queryBuilder.AddWhereTransfAreaYNA(TransfAreaYNA);

            if (DateTransfAreaStart.Length != 0)
                _queryBuilder.AddWhereDateTransfAreaStart(DateTransfAreaStart);

            if (DateTransfAreaEnd.Length != 0)
                _queryBuilder.AddWhereDateTransfAreaEnd(DateTransfAreaEnd);

            if (Unrz.Length != 0)
                _queryBuilder.AddWhereUnrz(Unrz);

            _queryBuilder.AddWhereUnrzYNA(UnrzYNA);

            #endregion
        }
    }
}
