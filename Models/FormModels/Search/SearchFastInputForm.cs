using HIVBackend.Helpers;

namespace HIVBackend.Models.FormModels.Search
{
    public class SearchFastInputForm : BaseSearchInputForm
    {
        public string CardNo { get; set; } = string.Empty;

        public override void SetSearchData()
        {
            SelectFio = true;
            SelectBirthDate = true;

            base.SetSearchData();

            #region Генерация строк SELECT GROUP BY и LEFT JOIN для запроса

            columName.Add("№ карты");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".card_no");

            columName.Add("Пол");
            selectGroupSrt.AppendLine(",\"tblSex\".sex_short");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblSex", field: "sex_id", table: "tblPatientCard");

            columName.Add("Регион");
            selectGroupSrt.AppendLine(",\"tblRegion\".region_long");
            joinStr.AddLeftJoinIfNotExist(joinTable: "tblRegion", field: "region_id", table: "tblPatientCard");
            
            columName.Add("Город");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".city_name");

            columName.Add("Телефон");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_ind");

            columName.Add("Улица");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_street");

            columName.Add("Дом");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_house");

            columName.Add("Корпус");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_ext");

            columName.Add("Квартира");
            selectGroupSrt.AppendLine(",\"tblPatientCard\".addr_flat");

            #endregion

            #region Генерация строки WHERE

            if (CardNo.Length != 0)
            {
                whereStr.AddWhereSqlStartWhith("\"tblPatientCard\".card_no", CardNo);
            }

            #endregion
        }

    }
}
