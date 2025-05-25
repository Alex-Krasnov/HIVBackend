using System.Text;

namespace HIVBackend.Helpers
{
    /// <summary>
    /// методы расширения StringBuilder для составление sql строк
    /// </summary>
    public static class GenerateSqlStringExtensions
    {
        #region WHERE

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
        /// Добваляем строку типа $" AND {column} ILIKE '{condition}%'"
        /// </summary>
        public static void AddWhereSqlStartWhith(this StringBuilder whereStr, string column, string condition)
        {
            whereStr.Append($" AND {column} ILIKE '{condition}%'");
        }

        /// <summary>
        /// Добваляем строку типа $" AND {column} LIKE '%{condition}%'"
        /// </summary>
        public static void AddWhereSqlContainsString(this StringBuilder whereStr, string column, string condition)
        {
            whereStr.Append($" AND {column} ILIKE '%{condition}%'");
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
        /// Добваляем строку типа $" AND (to_number(NULLIF(REGEXP_REPLACE(\"{column}\", '[^0-9.]', '', 'g'), ''), '9999999999999999D9999')::numeric >= {condition}::numeric)"
        /// </summary>
        public static void AddWhereIntConvertMore(this StringBuilder whereStr, string column, int condition)
        {
            whereStr.Append($" AND (to_number(NULLIF(REGEXP_REPLACE({column}, '[^0-9.]', '', 'g'), ''), '9999999999999999D9999')::numeric >= {condition}::numeric)");
        }

        /// <summary>
        /// Добваляем строку типа $" AND (to_number(NULLIF(REGEXP_REPLACE(\"{column}\", '[^0-9.]', '', 'g'), ''), '9999999999999999D9999')::numeric <= {condition}::numeric)"
        /// </summary>
        public static void AddWhereIntConvertLess(this StringBuilder whereStr, string column, int condition)
        {
            whereStr.Append($" AND (to_number(NULLIF(REGEXP_REPLACE({column}, '[^0-9.]', '', 'g'), ''), '9999999999999999D9999')::numeric <= {condition}::numeric)");
        }

        #endregion

        #region JOIN

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

        #endregion
    }
}
