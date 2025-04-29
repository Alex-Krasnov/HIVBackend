using HIVBackend.Models.Enums;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchEpidInputForm : BaseSearchInputForm
    {
        #region поля

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
        public string[] HospCourse { get; set; } = new string[] { "Все" };
        public string[] Age { get; set; } = new string[] { "Все" };
        public string CardNo { get; set; } = string.Empty;
        public string[] Art { get; set; } = new string[] { "Все" };
        public string[] Mkb10 { get; set; } = new string[] { "Все" };
        public string TransfFederYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateTransfFederStart { get; set; } = string.Empty;
        public string DateTransfFederEnd { get; set; } = string.Empty;
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string Aids12 { get; set; } = string.Empty;

        public string DtMailRegStart { get; set; } = string.Empty;
        public string DtMailRegEnd { get; set; } = string.Empty;
        public string[] Education { get; set; } = new string[] { "Все" };
        public string[] FamilyStatus { get; set; } = new string[] { "Все" };
        public string[] Employment { get; set; } = new string[] { "Все" };
        public string[] Trans { get; set; } = new string[] { "Все" };
        public string[] PlaceCheck { get; set; } = new string[] { "Все" };
        public string[] SituationDetect { get; set; } = new string[] { "Все" };
        public string[] TransmisionMech { get; set; } = new string[] { "Все" };
        public string[] VulnerableGroup { get; set; } = new string[] { "Все" };
        public string VacName { get; set; } = string.Empty;
        public string VacDateStart { get; set; } = string.Empty;
        public string VacDateEnd { get; set; } = string.Empty;
        public string CovidMkb10 { get; set; } = string.Empty;
        public string CovidDateStart { get; set; } = string.Empty;
        public string CovidDateEnd { get; set; } = string.Empty;
        public string ChemsexYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string ChemsexContactType { get; set; } = string.Empty;
        public string PavInjYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string PavInjDateStart { get; set; } = string.Empty;
        public string PavInjDateEnd { get; set; } = string.Empty;
        public string PavNotInjYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string PavNotInjDateStart { get; set; } = string.Empty;
        public string PavNotInjDateEnd { get; set; } = string.Empty;
        public string TimeInfectDateStart { get; set; } = string.Empty;
        public string TimeInfectDateEnd { get; set; } = string.Empty;
        public string EpidDescr { get; set; } = string.Empty;
        public string[] CallStatus { get; set; } = new string[] { "Все" };
        public string CallDateStart { get; set; } = string.Empty;
        public string CallDateEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; } = false;
        public bool SelectBlotCheckPlace { get; set; } = false;
        public bool SelectDieDate { get; set; } = false;
        public bool SelectDieCourse { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectIb { get; set; } = false;
        public bool SelectHospCourse { get; set; } = false;
        public bool SelectAge { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectArt { get; set; } = false;
        public bool SelectMkb10 { get; set; } = false;
        public bool SelectTransfFeder { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectAids12 { get; set; } = false;

        public bool SelectDtMailReg { get; set; } = false;
        public bool SelectEdu { get; set; } = false;
        public bool SelectFamilyStatus { get; set; } = false;
        public bool SelectEmployment { get; set; } = false;
        public bool SelectTrans { get; set; } = false;
        public bool SelectPlaceCheck { get; set; } = false;
        public bool SelectSituationDetect { get; set; } = false;
        public bool SelectTransmisionMech { get; set; } = false;
        public bool SelectVulnerableGroup { get; set; } = false;
        public bool SelectCovidVac { get; set; } = false;
        public bool SelectCovid { get; set; } = false;
        public bool SelectChemsex { get; set; } = false;
        public bool SelectPavInj { get; set; } = false;
        public bool SelectPavNotInj { get; set; } = false;
        public bool SelectTimeInfect { get; set; } = false;
        public bool SelectEpidDescr { get; set; } = false;
        public bool SelectPatientCall {  get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchEpidInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
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

                    if (key.Name == "SelectTransfFeder")
                        _queryBuilder.AddSelectTransfFeder();

                    if (key.Name == "SelectUfsin")
                        _queryBuilder.AddSelectUfsin();

                    if (key.Name == "SelectAids12")
                        _queryBuilder.AddSelectAids12();

                    if (key.Name == "SelectDtMailReg")
                        _queryBuilder.AddSelectDtMailReg();

                    if (key.Name == "SelectEdu")
                        _queryBuilder.AddSelectEdu();

                    if (key.Name == "SelectFamilyStatus")
                        _queryBuilder.AddSelectFamilyStatus();

                    if (key.Name == "SelectEmployment")
                        _queryBuilder.AddSelectEmployment();

                    if (key.Name == "SelectTrans")
                        _queryBuilder.AddSelectTrans();

                    if (key.Name == "SelectPlaceCheck")
                        _queryBuilder.AddSelectPlaceCheck();

                    if (key.Name == "SelectSituationDetect")
                        _queryBuilder.AddSelectSituationDetect();

                    if (key.Name == "SelectTransmisionMech")
                        _queryBuilder.AddSelectTransmisionMech();

                    if (key.Name == "SelectVulnerableGroup")
                        _queryBuilder.AddSelectVulnerableGroup();

                    if (key.Name == "SelectCovidVac")
                        _queryBuilder.AddSelectCovidVac();

                    if (key.Name == "SelectCovid")
                        _queryBuilder.AddSelectCovid();

                    if (key.Name == "SelectChemsex")
                        _queryBuilder.AddSelectChemsex();

                    if (key.Name == "SelectPavInj")
                        _queryBuilder.AddSelectPavInj();

                    if (key.Name == "SelectPavNotInj")
                        _queryBuilder.AddSelectPavNotInj();

                    if (key.Name == "SelectTimeInfect")
                        _queryBuilder.AddSelectTimeInfect();

                    if (key.Name == "SelectEpidDescr")
                        _queryBuilder.AddSelectEpidDescr();

                    if (key.Name == "SelectPatientCall")
                        _queryBuilder.AddSelectPatientCall();
                }
            }

            #endregion

            #region Генерация строки WHERE

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

            if (DtMailRegStart.Length != 0)
                _queryBuilder.AddWhereDtMailRegStart(DtMailRegStart);

            if (DtMailRegEnd.Length != 0)
                _queryBuilder.AddWhereDtMailRegEnd(DtMailRegEnd);

            if (Education[0] != "Все")
                _queryBuilder.AddWhereEducation(Education);

            if (FamilyStatus[0] != "Все")
                _queryBuilder.AddWhereFamilyStatus(FamilyStatus);

            if (Employment[0] != "Все")
                _queryBuilder.AddWhereEmployment(Employment);

            if (Trans[0] != "Все")
                _queryBuilder.AddWhereTrans(Trans);

            if (PlaceCheck[0] != "Все")
                _queryBuilder.AddWherePlaceCheck(PlaceCheck);

            if (SituationDetect[0] != "Все")
                _queryBuilder.AddWhereSituationDetect(SituationDetect);

            if (TransmisionMech[0] != "Все")
                _queryBuilder.AddWhereTransmisionMech(TransmisionMech);

            if (VulnerableGroup[0] != "Все")
                _queryBuilder.AddWhereVulnerableGroup(VulnerableGroup);

            if (VacName.Length != 0)
                _queryBuilder.AddWhereVacName(VacName);

            if (VacDateStart.Length != 0)
                _queryBuilder.AddWhereVacDateStart(VacDateStart);

            if (VacDateEnd.Length != 0)
                _queryBuilder.AddWhereVacDateEnd(VacDateEnd);

            if (CovidMkb10.Length != 0)
                _queryBuilder.AddWhereCovidMkb10(CovidMkb10);

            if (CovidDateStart.Length != 0)
                _queryBuilder.AddWhereCovidDateStart(CovidDateStart);

            if (CovidDateEnd.Length != 0)
                _queryBuilder.AddWhereCovidDateEnd(CovidDateEnd);

            if (ChemsexYNA == YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereChemsexYNA(ChemsexYNA);

            if (ChemsexContactType.Length != 0)
                _queryBuilder.AddWhereChemsexContactType(ChemsexContactType);

            if (PavInjYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWherePavInjYNA(PavInjYNA);

            if (PavInjDateStart.Length != 0)
                _queryBuilder.AddWherePavInjDateStart(PavInjDateStart);

            if (PavInjDateEnd.Length != 0)
                _queryBuilder.AddWherePavInjDateEnd(PavInjDateEnd);

            if (PavNotInjYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWherePavNotInjYNA(PavNotInjYNA);

            if (PavNotInjDateStart.Length != 0)
                _queryBuilder.AddWherePavNotInjDateStart(PavNotInjDateStart);

            if (PavNotInjDateEnd.Length != 0)
                _queryBuilder.AddWherePavNotInjDateEnd(PavNotInjDateEnd);

            if (TimeInfectDateStart.Length != 0)
                _queryBuilder.AddWhereTimeInfectDateStart(TimeInfectDateStart);

            if (TimeInfectDateEnd.Length != 0)
                _queryBuilder.AddWhereTimeInfectDateEnd(TimeInfectDateEnd);

            if (EpidDescr.Length != 0)
                _queryBuilder.AddWhereEpidDescr(EpidDescr);

            if (CallStatus[0] != "Все")
                _queryBuilder.AddWhereCallStatus(CallStatus);

            if (CallDateStart.Length != 0)
                _queryBuilder.AddWhereCallDateStart(CallDateStart);

            if (CallDateEnd.Length != 0)
                _queryBuilder.AddWhereCallDateEnd(CallDateEnd);

            #endregion
        }
    }
}