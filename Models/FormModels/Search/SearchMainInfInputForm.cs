using HIVBackend.Models.Enums;
using HIVBackend.Helpers;
using System.Reflection;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchMainInfInputForm : BaseSearchInputForm
    {
        #region поля

        public string FioChange { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string[] BlotCheckPlace { get; set; } = new string[] { "Все" };
        public string DateDieStart { get; set; } = string.Empty;
        public string DateDieEnd { get; set; } = string.Empty;
        public string DateDieAidsStart { get; set; } = string.Empty;
        public string DateDieAidsEnd { get; set; } = string.Empty;
        public string[] DieCourse { get; set; } = new string[] { "Все" };
        public string DiePreset { get; set; } = string.Empty;
        public string[] ShowIllnes { get; set; } = new string[] { "Все" };
        public string DateShowIllnesStart { get; set; } = string.Empty;
        public string DateShowIllnesEnd { get; set; } = string.Empty;
        public string IbRes { get; set; } = string.Empty;
        public string DateIbResStart { get; set; } = string.Empty;
        public string DateIbResEnd { get; set; } = string.Empty;
        public string IbNum { get; set; } = string.Empty;
        public string DateInpIbStart { get; set; } = string.Empty;
        public string DateInpIbEnd { get; set; } = string.Empty;
        public string IbSelect { get; set; } = string.Empty;
        public string ReferenceMO { get; set; } = string.Empty;
        public string[] HospCourse { get; set; } = new string[] { "Все" };
        public string[] Age { get; set; } = new string[] { "Все" };
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };
        public string[] Mkb10 { get; set; } = new string[] { "Все" };
        public string ArchiveYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string Archive { get; set; } = string.Empty;
        public string TransfFederYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateTransfFederStart { get; set; } = string.Empty;
        public string DateTransfFederEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string Aids12 { get; set; } = string.Empty;
        public string DieDiagYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string Chemprof { get; set; } = string.Empty;
        public string DateChemprofStartStart { get; set; } = string.Empty;
        public string DateChemprofStartEnd { get; set; } = string.Empty;
        public string DateChemprofEndStart { get; set; } = string.Empty;
        public string DateChemprofEndEnd { get; set; } = string.Empty;
        public string DateRegStart { get; set; } = string.Empty;
        public string DateRegEnd { get; set; } = string.Empty;
        public string DeathTransferSubYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string Desc { get; set; } = string.Empty;

        #endregion

        #region select поля

        [Order(7.5)]
        public bool SelectIb { get; set; } = false;
        public bool SelectSex { get; set; } = false;
        public bool SelectBlotCheckPlace { get; set; } = false;
        public bool SelectDieDate { get; set; } = false;
        public bool SelectDieCourse { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectHospCourse { get; set; } = false;
        public bool SelectAge { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectArt { get; set; } = false;
        public bool SelectMkb10 { get; set; } = false;
        public bool SelectArchive { get; set; } = false;
        public bool SelectTransfFeder { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectAids12 { get; set; } = false;
        public bool SelectChemprof { get; set; } = false;
        public bool SelectDieDiag { get; set; } = false;
        public bool SelectDateReg { get; set; } = false;
        public bool SelectPasSer { get; set; } = false;
        public bool SelectPasNum { get; set; } = false;
        public bool SelectPasWhom { get; set; } = false;
        public bool SelectPasWhen { get; set; } = false;
        public bool SelectDeathTransferSub { get; set; } = false;
        public bool SelectDesc { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchMainInfInputForm).GetProperties()
                                                              .Where(e => e.Name.StartsWith("Select"))
                                                              .OrderBy(p => p.GetCustomAttribute<OrderAttribute>()?.Order ?? double.MaxValue))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectSex")
                        _queryBuilder.AddSelectSex();

                    if (key.Name == "SelectBlotCheckPlace")
                        _queryBuilder.AddSelectBlotCheckPlace();

                    if (key.Name == "SelectDieDate")
                        _queryBuilder.AddSelectDieDate();

                    if (key.Name == "SelectDieCourse")
                        _queryBuilder.AddSelectDieCourse();

                    if (key.Name == "SelectShowIllnes")
                        _queryBuilder.AddSelectShowIllnes();

                    if (key.Name == "SelectIb")
                        _queryBuilder.AddSelectIb();

                    if (key.Name == "SelectHospCourse")
                        _queryBuilder.AddSelectHospCourse();

                    if (key.Name == "SelectAge")
                        _queryBuilder.AddSelectAge();

                    if (key.Name == "SelectCardNo")
                        _queryBuilder.AddSelectCardNo();

                    if (key.Name == "SelectArt")
                        _queryBuilder.AddSelectArt();

                    if (key.Name == "SelectMkb10")
                        _queryBuilder.AddSelectMkb10();

                    if (key.Name == "SelectArchive")
                        _queryBuilder.AddSelectArchive();

                    if (key.Name == "SelectTransfFeder")
                        _queryBuilder.AddSelectTransfFeder();

                    if (key.Name == "SelectUfsin")
                        _queryBuilder.AddSelectUfsin();

                    if (key.Name == "SelectAids12")
                        _queryBuilder.AddSelectAids12();

                    if (key.Name == "SelectChemprof")
                        _queryBuilder.AddSelectChemprof();

                    if (key.Name == "SelectDieDiag")
                        _queryBuilder.AddSelectDieDiag();

                    if (key.Name == "SelectDateReg")
                        _queryBuilder.AddSelectDateReg();

                    if (key.Name == "SelectPasSer")
                        _queryBuilder.AddSelectPasSer();

                    if (key.Name == "SelectPasNum")
                        _queryBuilder.AddSelectPasNum();

                    if (key.Name == "SelectPasWhom")
                        _queryBuilder.AddSelectPasWhom();

                    if (key.Name == "SelectPasWhen")
                        _queryBuilder.AddSelectPasWhen();

                    if (key.Name == "SelectDeathTransferSub")
                        _queryBuilder.AddSelectDeathTransferSub();

                    if (key.Name == "SelectDesc")
                        _queryBuilder.AddSelectDesc();
                }
            }

            #endregion

            #region Генерация строки WHERE

            if (FioChange.Length != 0)
                _queryBuilder.AddWhereFioChange(FioChange);

            if (Sex.Length != 0)
                _queryBuilder.AddWhereSex(Sex);

            if (BlotCheckPlace[0] != "Все")
                _queryBuilder.AddWhereBlotCheckPlace(BlotCheckPlace);

            if (DateDieStart.Length != 0)
                _queryBuilder.AddWhereDateDieStart(DateDieStart);

            if (DateDieEnd.Length != 0)
                _queryBuilder.AddWhereDateDieEnd(DateDieEnd);

            if (DateDieAidsStart.Length != 0)
                _queryBuilder.AddWhereDateDieAidsStart(DateDieAidsStart);

            if (DateDieAidsEnd.Length != 0)
                _queryBuilder.AddWhereDateDieAidsEnd(DateDieAidsEnd);

            if (DieCourse[0] != "Все")
                _queryBuilder.AddWhereDieCourse(DieCourse);

            if (DiePreset != DiePresetEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereDiePreset(DiePreset);

            if (ShowIllnes[0] != "Все")
                _queryBuilder.AddWhereShowIllnes(ShowIllnes);

            if (DateShowIllnesStart.Length != 0)
                _queryBuilder.AddWhereDateShowIllnesStart(DateShowIllnesStart);

            if (DateShowIllnesEnd.Length != 0)
                _queryBuilder.AddWhereDateShowIllnesEnd(DateShowIllnesEnd);

            if (IbRes.Length != 0)
                _queryBuilder.AddWhereIbRes(IbRes);

            if (DateIbResStart.Length != 0)
                _queryBuilder.AddWhereDateIbResStart(DateIbResStart);

            if (DateIbResEnd.Length != 0)
                _queryBuilder.AddWhereDateIbResEnd(DateIbResEnd);

            if (IbNum.Length != 0)
                _queryBuilder.AddWhereIbNum(IbNum);

            if (DateInpIbStart.Length != 0)
                _queryBuilder.AddWhereDateInpIbStart(DateInpIbStart);

            if (DateInpIbEnd.Length != 0)
                _queryBuilder.AddWhereDateInpIbEnd(DateInpIbEnd);

            if (IbSelect != "Все")
                _queryBuilder.AddWhereIbSelect(IbSelect);

            if (ReferenceMO.Length != 0)
                _queryBuilder.AddWhereReferenceMO(ReferenceMO);

            if (HospCourse[0] != "Все")
                _queryBuilder.AddWhereHospCourse(HospCourse);

            if (Age[0] != "Все")
                _queryBuilder.AddWhereAge(Age);

            if (CardNo.Length != 0)
                _queryBuilder.AddWhereCardNo(CardNo);

            if (Art[0] != "Все")
                _queryBuilder.AddWhereArt(Art);

            if (Mkb10[0] != "Все")
                _queryBuilder.AddWhereMkb10(Mkb10);

            if (ArchiveYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereArchiveYNA(ArchiveYNA);

            if (TransfFederYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereTransfFederYNA(TransfFederYNA);

            if (DateTransfFederStart.Length != 0)
                _queryBuilder.AddWhereDateTransfFederStart(DateTransfFederStart);

            if (DateTransfFederEnd.Length != 0)
                _queryBuilder.AddWhereDateTransfFederEnd(DateTransfFederEnd);

            if (UfsinYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereUfsinYNA(UfsinYNA);

            if (DateUfsinStart.Length != 0)
                _queryBuilder.AddWhereDateUfsinStart(DateUfsinStart);

            if (DateUfsinEnd.Length != 0)
                _queryBuilder.AddWhereDateUfsinEnd(DateUfsinEnd);

            if (Aids12.Length != 0)
                _queryBuilder.AddWhereAids12(Aids12);

            if (DieDiagYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereDieDiagYNA(DieDiagYNA);

            if (Chemprof.Length != 0)
                _queryBuilder.AddWhereChemprof(Chemprof);

            if (DateChemprofStartStart.Length != 0)
                _queryBuilder.AddWhereDateChemprofStartStart(DateChemprofStartStart);

            if (DateChemprofStartEnd.Length != 0)
                _queryBuilder.AddWhereDateChemprofStartEnd(DateChemprofStartEnd);

            if (DateChemprofEndStart.Length != 0)
                _queryBuilder.AddWhereDateChemprofEndStart(DateChemprofEndStart);

            if (DateChemprofEndEnd.Length != 0)
                _queryBuilder.AddWhereDateChemprofEndEnd(DateChemprofEndEnd);

            if (DateRegStart.Length != 0)
                _queryBuilder.AddWhereDateRegStart(DateRegStart);

            if (DateRegEnd.Length != 0)
                _queryBuilder.AddWhereDateRegEnd(DateRegEnd);

            if (DeathTransferSubYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereDeathTransferSubYNA(DeathTransferSubYNA);

            if (Desc.Length != 0)
                _queryBuilder.AddWhereDesc(Desc);

            #endregion
        }
    }
}
