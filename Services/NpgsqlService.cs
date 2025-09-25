using Npgsql;
using System.Data;
using System.Text;

namespace HIVBackend.Services
{
    public class NpgsqlService
    {
        const string DEFAULT_ORDER_BY = "Order by \"tblPatientCard\".family_name,\"tblPatientCard\".first_name,\"tblPatientCard\".third_name,\"tblPatientCard\".patient_id";

        private static readonly string connectionString = $"Host={Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost"};Port={Environment.GetEnvironmentVariable("DB_PORT") ?? "5432"};Database=HIV;Username=vs_test;Password=4100";

        /// <summary>
        /// Получаем кол-во строк
        /// </summary>
        public static int GetCountRow(StringBuilder selectGroupSrt, StringBuilder joinStr, StringBuilder whereStr, int pageSize, int page)
        {
            DataSet ds = new();

            var qry = "SELECT COUNT(DISTINCT(" + selectGroupSrt.ToString() + "))" + "\n"
                      + joinStr.ToString() + "\n"
                      + whereStr.ToString() + "\n"
                      + "LIMIT 1000000";

            using (NpgsqlConnection connetion = new NpgsqlConnection(connectionString))
            {
                connetion.Open();

                NpgsqlCommand cmd = new(qry, connetion);
                using (NpgsqlTransaction tran = connetion.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
                {
                    using (NpgsqlDataAdapter adapter = new(cmd))
                    {
                        try
                        {
                            adapter.Fill(ds);
                        }
                        catch (Npgsql.NpgsqlException ex) when (ex.InnerException.Message.Contains("Timeout during reading attempt"))
                        {
                            throw new Exception("Слишком сложный запрос. Уменьшите кол-во столбцов в выборке или увеличте кол-во условий!!!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Проблема с БД!!!", ex);
                        }
                    }
                }

                connetion.Close();
            }
            return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }

        /// <summary>
        /// Получаем DataSet из базы
        /// </summary>
        public static DataSet GetDBData(StringBuilder selectGroupSrt, StringBuilder joinStr, StringBuilder whereStr, int pageSize, int page, bool isExcel = false, StringBuilder orderByStr = null)
        {
            DataSet ds = new();

            var qry = "SELECT " + selectGroupSrt.ToString()
                      + joinStr.ToString() + "\n"
                      + whereStr.ToString() + "\n"
                      + "Group by " + selectGroupSrt.ToString() + "\n"
                      + (orderByStr?.ToString() ?? DEFAULT_ORDER_BY + "\n");

            if (!isExcel)
                qry += $"LIMIT {pageSize} OFFSET {(page - 1) * pageSize}";
            
            using (NpgsqlConnection connetion = new NpgsqlConnection(connectionString))
            {
                connetion.Open();
                NpgsqlCommand cmd = new(qry, connetion);

                using (NpgsqlTransaction tran = connetion.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
                {
                    using (NpgsqlDataAdapter adapter = new(cmd))
                    {
                        try
                        {
                            adapter.Fill(ds);
                        }
                        catch (NpgsqlException ex) when (ex.InnerException.Message.Contains("Timeout during reading attempt"))
                        {
                            throw new Exception("Слишком сложный запрос. Уменьшите кол-во столбцов в выборке или увеличте кол-во условий!!!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Проблема с БД!!!", ex);
                        }
                    }
                }

                connetion.Close();
            }
            return ds;
        }

        /// <summary>
        /// Парсим DataSet в List<IDictionary<string, object>> 
        /// </summary>
        public static List<IDictionary<string, object>> DataSetToList(DataSet ds)
        {
            List<IDictionary<string, object>> lst = new();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Dictionary<string, object> row = new();
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    object value = dr[dc.ColumnName];
                    if (Convert.IsDBNull(value))
                    {
                        row[dc.ColumnName] = null;
                        continue;
                    }

                    switch (Type.GetTypeCode(dc.DataType))
                    {
                        case TypeCode.DateTime:
                            row[dc.ColumnName] = ((DateTime)value).ToString("dd.MM.yyyy");
                            break;
                        case TypeCode.Boolean:
                            row[dc.ColumnName] = (bool)value == true ? "Да" : "Нет";
                            break;
                        default:
                            row[dc.ColumnName] = value;
                            break;
                    }
                }
                lst.Add(row);  
            }

            return lst;
        }
    }
}
