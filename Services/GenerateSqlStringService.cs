using DocumentFormat.OpenXml.Drawing;
using System.Text;

namespace HIVBackend.Services
{
    public static class GenerateSqlStringService
    {
        /// <summary>
        /// Добваляем строку типа $" AND {column} = {condition}"
        /// </summary>
        public static void AddWhereSqlEqual(this StringBuilder whereStr, string column, string condition)
        {
            whereStr.Append($" AND {column} = {condition}");
        }

        /// <summary>
        /// Добваляем строку типа $" AND {column} >= '{condition}'"
        /// </summary>
        public static void AddWhereSqlDateMore(this StringBuilder whereStr, string column, string condition)
        {
            whereStr.Append($" AND {column} >= '{condition}'");
        }

        /// <summary>
        /// Добавляем строку типа $" AND {coiumn} <= '{condition}'"
        /// </summary>
        public static void AddWhereSqlDateLess(this StringBuilder whereStr, string column, string condition)
        {
            whereStr.Append($" AND {column} <= '{condition}'");
        }

        /// <summary>
        /// Добваляем строку типа $" AND lower({column}) LIKE '{condition}%'"
        /// </summary>
        public static void AddWhereSqlStartWhith(this StringBuilder whereStr, string column, string condition)
        {
            whereStr.Append($" AND lower({column}) LIKE '{condition}%'");
        }

        /// <summary>
        /// Добваляем строку типа $" AND {column} LIKE '{condition}'"
        /// </summary>
        public static void AddWhereSqlEqualString(this StringBuilder whereStr, string column, string condition)
        {
            whereStr.Append($" AND {column} LIKE '{condition}'");
        }

        /// <summary>
        /// Добваляем строку типа $" AND {column} IN ('{string.Join("','", condition)}')"
        /// </summary>
        public static void AddWhereSqlIn(this StringBuilder whereStr, string column, string[] condition)
        {
            whereStr.Append($" AND {column} IN ('{string.Join("','", condition)}')");
        }

        /// <summary>
        /// Добваляем строку типа $" AND {column} IS NULL"
        /// </summary>
        public static void AddWhereSqlIsNull(this StringBuilder whereStr, string column)
        {
            whereStr.Append($" AND {column} IS NULL");
        }

        /// <summary>
        /// Добваляем строку типа $" AND {column} IS NOT NULL"
        /// </summary>
        public static void AddWhereSqlIsNotNull(this StringBuilder whereStr, string column)
        {
            whereStr.Append($" AND {column} IS NOT NULL");
        }

        /// <summary>
        /// Добваляем строку типа $" AND {column} = TRUE"
        /// </summary>
        public static void AddWhereSqlTrue(this StringBuilder whereStr, string column)
        {
            whereStr.Append($" AND {column} = TRUE");
        }

        /// <summary>
        /// Добваляем строку типа $" AND ({column} = False OR {column} IS NULL)"
        /// </summary>
        public static void AddWhereSqlFalseOrNull(this StringBuilder whereStr, string column)
        {
            whereStr.Append($" AND ({column} = False OR {column} IS NULL)");
        }

        /// <summary>
        /// Добавляет LEFT JOIN если такого еще нет
        /// </summary>
        public static void AddLeftJoinIfNotExist(this StringBuilder joinStr, string joinTable, string field, string table, string? alias = null)
        {
            string str = alias != null && alias.Length != 0 ?
                $"LEFT JOIN \"{joinTable}\" \"{alias}\" ON \"{table}\".\"{field}\" = \"{alias}\".\"{field}\""
                : $"LEFT JOIN \"{joinTable}\" ON \"{table}\".\"{field}\" = \"{joinTable}\".\"{field}\"";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);
        }

        /// <summary>
        /// Добавляет LEFT JOIN если такого еще нет с разными полями
        /// </summary>
        public static void AddLeftJoinIfNotExistDiffField(this StringBuilder joinStr, 
                                                          string joinTable, 
                                                          string fieldLeft, 
                                                          string fieldRight, 
                                                          string table, 
                                                          string? alias = null)
        {
            string str = alias != null && alias.Length != 0 ?
                $"LEFT JOIN \"{joinTable}\" \"{alias}\" ON \"{table}\".\"{fieldLeft}\" = \"{alias}\".\"{fieldRight}\""
                : $"LEFT JOIN \"{joinTable}\" ON \"{table}\".\"{fieldLeft}\" = \"{joinTable}\".\"{fieldRight}\"";

            if (!joinStr.ToString().Contains(str))
                joinStr.AppendLine(str);
        }
    }
}
