using HIVBackend.Models.Enums;

namespace HIVBackend.Models.FormModels.Search
{
    /// <summary>
    /// данные пришедшие с фронта (фильтры поиска)
    /// </summary>
    public class SearchTreatmentInputForm : BaseSearchInputForm
    {
        #region поля

        public string Sex { get; set; } = string.Empty;
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
        public string UfsinYNA { get; set; } = YNAEnum.All.ToEnumDescriptionNameString();
        public string DateUfsinStart { get; set; } = string.Empty;
        public string DateUfsinEnd { get; set; } = string.Empty;
        public string[] Invalid { get; set; } = new string[] { "Все" };
        public string[] CorrespIllnesses { get; set; } = new string[] { "Все" };
        public string DateCorrespIllnessesStart { get; set; } = string.Empty;
        public string DateCorrespIllnessesEnd { get; set; } = string.Empty;
        public string[] Schema { get; set; } = new string[] { "Все" };
        public bool SchemaLast { get; set; } = false;
        public string[] SchemaMedecine { get; set; } = new string[] { "Все" };
        public string[] Medecine { get; set; } = new string[] { "Все" };
        public string[] MedecineGive { get; set; } = new string[] { "Все" };
        public string[] Doctor { get; set; } = new string[] { "Все" };
        public string DateGiveStart { get; set; } = string.Empty;
        public string DateGiveEnd { get; set; } = string.Empty;
        public string[] SchemaChange { get; set; } = new string[] { "Все" };
        public string CardNo { get; set; } = string.Empty;
        public string DateSchemaStart { get; set; } = string.Empty;
        public string DateSchemaEnd { get; set; } = string.Empty;
        public string[] FinSource { get; set; } = new string[] { "Все" };
        public string[] Art { get; set; } = new string[] { "Все" };
        public string[] RangeTherapy { get; set; } = new string[] { "Все" };
        public string DateVlStart { get; set; } = string.Empty;
        public string DateVlEnd { get; set; } = string.Empty;
        public string ResVlStart { get; set; } = string.Empty;
        public string ResVlEnd { get; set; } = string.Empty;
        public string DateIMStart { get; set; } = string.Empty;
        public string DateImEnd { get; set; } = string.Empty;
        public string ResImStart { get; set; } = string.Empty;
        public string ResImEnd { get; set; } = string.Empty;

        #endregion

        #region select поля

        public bool SelectSex { get; set; } = false;
        public bool SelectDieDate { get; set; } = false;
        public bool SelectDieCourse { get; set; } = false;
        public bool SelectShowIllnes { get; set; } = false;
        public bool SelectIb { get; set; } = false;
        public bool SelectUfsin { get; set; } = false;
        public bool SelectInvalid { get; set; } = false;
        public bool SelectCorrespIllnesses { get; set; } = false;
        public bool SelectSchema { get; set; } = false;
        public bool SelectSchemaMedecine { get; set; } = false;
        public bool SelectMedecine { get; set; } = false;
        public bool SelectMedecineGive { get; set; } = false;
        public bool SelectDoctor { get; set; } = false;
        public bool SelectGiveDate { get; set; } = false;
        public bool SelectSchemaChange { get; set; } = false;
        public bool SelectCardNo { get; set; } = false;
        public bool SelectSchemaDate { get; set; } = false;
        public bool SelectFinSource { get; set; } = false;
        public bool SelectArt { get; set; } = false;
        public bool SelectRangeTherapy { get; set; } = false;
        public bool SelectVlDate { get; set; } = false;
        public bool SelectVlRes { get; set; } = false;
        public bool SelectImDate { get; set; } = false;
        public bool SelectImRes { get; set; } = false;

        #endregion

        public override void SetSearchData()
        {
            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            foreach (var key in typeof(SearchTreatmentInputForm).GetProperties().Where(e => e.Name.StartsWith("Select")))
            {
                if ((bool)key.GetValue(this) == true)
                {
                    if (key.Name == "SelectSex")
                        _queryBuilder.AddSelectSex();

                    if (key.Name == "SelectDieDate")
                        _queryBuilder.AddSelectDieDate();

                    if (key.Name == "SelectDieCourse")
                        _queryBuilder.AddSelectDieCourse();

                    if (key.Name == "SelectShowIllnes")
                        _queryBuilder.AddSelectShowIllnes();

                    if (key.Name == "SelectIb")
                        _queryBuilder.AddSelectIb();

                    if (key.Name == "SelectUfsin")
                        _queryBuilder.AddSelectUfsin();

                    if (key.Name == "SelectInvalid")
                        _queryBuilder.AddSelectInvalid();

                    if (key.Name == "SelectCorrespIllnesses")
                        _queryBuilder.AddSelectCorrespIllnesses();

                    if (key.Name == "SelectSchemaDate")
                        _queryBuilder.AddSelectSchemaDate();

                    if (key.Name == "SelectSchema")
                        _queryBuilder.AddSelectSchema();

                    if (key.Name == "SelectSchemaMedecine")
                        _queryBuilder.AddSelectSchemaMedecine();

                    if (key.Name == "SelectGiveDate")
                        _queryBuilder.AddSelectGiveDate();

                    if (key.Name == "SelectDoctor")
                        _queryBuilder.AddSelectDoctorMedecine();

                    if (key.Name == "SelectMedecine")
                        _queryBuilder.AddSelectMedecine();

                    if (key.Name == "SelectMedecineGive")
                        _queryBuilder.AddSelectMedecineGive();

                    if (key.Name == "SelectSchemaChange")
                        _queryBuilder.AddSelectSchemaChange();

                    if (key.Name == "SelectCardNo")
                        _queryBuilder.AddSelectCardNo();

                    if (key.Name == "SelectArt")
                        _queryBuilder.AddSelectArt();

                    if (key.Name == "SelectRangeTherapy")
                        _queryBuilder.AddSelectRangeTherapy();

                    if (key.Name == "SelectVlDate")
                        _queryBuilder.AddSelectVlDate();

                    if (key.Name == "SelectVlRes")
                        _queryBuilder.AddSelectVlRes();

                    if (key.Name == "SelectImDate")
                        _queryBuilder.AddSelectImDate();

                    if (key.Name == "SelectImRes")
                        _queryBuilder.AddSelectImRes();
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

            if (UfsinYNA != YNAEnum.All.ToEnumDescriptionNameString())
                _queryBuilder.AddWhereUfsinYNA(UfsinYNA);

            if (DateUfsinStart.Length != 0)
                _queryBuilder.AddWhereDateUfsinStart(DateUfsinStart);

            if (DateUfsinEnd.Length != 0)
                _queryBuilder.AddWhereDateUfsinEnd(DateUfsinEnd);

            if (Invalid[0] != "Все")
                _queryBuilder.AddWhereInvalid(Invalid);

            if (CorrespIllnesses[0] != "Все")
                _queryBuilder.AddWhereCorrespIllnesses(CorrespIllnesses);

            if (DateCorrespIllnessesStart.Length != 0)
                _queryBuilder.AddWhereDateCorrespIllnessesStart(DateCorrespIllnessesStart);

            if (DateCorrespIllnessesEnd.Length != 0)
                _queryBuilder.AddWhereDateCorrespIllnessesEnd(DateCorrespIllnessesEnd);

            if (Schema[0] != "Все")
                _queryBuilder.AddWhereSchema(Schema);

            if (SchemaLast)
                _queryBuilder.AddWhereSchemaLast();

            if (SchemaMedecine[0] != "Все")
                _queryBuilder.AddWhereSchemaMedecine(SchemaMedecine);

            if (Medecine[0] != "Все")
                _queryBuilder.AddWhereMedecine(Medecine);

            if (MedecineGive[0] != "Все")
                _queryBuilder.AddWhereMedecineGive(MedecineGive);

            if (Doctor[0] != "Все")
                _queryBuilder.AddWhereDoctorMedecine(Doctor);

            if (DateGiveStart.Length != 0)
                _queryBuilder.AddWhereDateGiveStart(DateGiveStart);

            if (DateGiveEnd.Length != 0)
                _queryBuilder.AddWhereDateGiveEnd(DateGiveEnd);

            if (SchemaChange[0] != "Все")
                _queryBuilder.AddWhereSchemaChange(SchemaChange);

            if (CardNo.Length != 0)
                _queryBuilder.AddWhereCardNo(CardNo);

            if (DateSchemaStart.Length != 0)
                _queryBuilder.AddWhereDateSchemaStart(DateSchemaStart);

            if (DateSchemaEnd.Length != 0)
                _queryBuilder.AddWhereDateSchemaEnd(DateSchemaEnd);

            if (Art[0] != "Все")
                _queryBuilder.AddWhereArt(Art);

            if (RangeTherapy[0] != "Все")
                _queryBuilder.AddWhereRangeTherapy(RangeTherapy);

            if (DateVlStart.Length != 0)
                _queryBuilder.AddWhereDateVlStart(DateVlStart);

            if (DateVlEnd.Length != 0)
                _queryBuilder.AddWhereDateVlEnd(DateVlEnd);

            if (ResVlStart != null && ResVlStart.Length != 0)
                _queryBuilder.AddWhereResVlStart(ResVlStart);

            if (ResVlEnd != null && ResVlEnd.Length != 0)
                _queryBuilder.AddWhereResVlEnd(ResVlEnd);

            if (DateIMStart?.Length != 0)
                _queryBuilder.AddWhereDateIMStart(DateIMStart);

            if (DateImEnd?.Length != 0)
                _queryBuilder.AddWhereDateImEnd(DateImEnd);

            //                //(resImStart.Length != 0 && IsImStart ? e.ImResult >= ResImStart : true) &&
            //                //(resImEnd.Length != 0 && IsImEnd ? e.ImResult <= ResImEnd : true)

                #endregion
        }
    }
}
