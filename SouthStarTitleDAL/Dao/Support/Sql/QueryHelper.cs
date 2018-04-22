using System;
using SouthStarTitleCommon;
using SouthStarTitleCommon.Text;
using SouthStarTitleDAL.Dao.Support.Data;


namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class QueryHelper
    {
        // Methods
        public static string DressUp(object o, DbType type)
        {
            if (Util.IsNumeric(o))
            {
                return o.ToString();
            }
            if (Util.IsDateTime(o))
            {
                return (GetDateDelimeter(type) + o.ToString() + GetDateDelimeter(type));
            }
            return (GetStringDelimeter(type) + o.ToString().Replace("'", "''") + GetStringDelimeter(type));
        }

        public static string DressUpContains(object o, DbType type)
        {
            if (Util.IsNumeric(o))
            {
                return o.ToString();
            }
            if (Util.IsDateTime(o))
            {
                return (GetDateDelimeter(type) + o.ToString() + GetDateDelimeter(type));
            }
            return (GetStringDelimeter(type) + "%" + o.ToString().Replace("'", "''") + "%" + GetStringDelimeter(type));
        }

        public static string GetAccessLastInsertedCommand(string table, string column)
        {
            return ("SELECT MAX([" + column + "]) FROM [" + table + "];");
        }

        public static char GetDateDelimeter(DbType type)
        {
            switch (type)
            {
                case DbType.ACCESS:
                    return '#';

                case DbType.SQLSERVER:
                    return '\'';

                case DbType.MYSQL:
                    return '\'';

                case DbType.ORACLE:
                    return '\'';
            }
            throw new Exception("DbType " + type + " not supported currently.");
        }

        public static string GetMySqlLastInsertedCommand(string table, string column)
        {
            return ("SELECT `" + column + "` FROM `" + table + "` ORDER BY `" + column + "` DESC LIMIT 1");
        }

        public static string GetOracleLastInsertedCommand(string table, string column)
        {
            return ("SELECT MAX(" + column + ") FROM " + table + ";");
        }

        public static string GetParameterName(string columnName, DbProviderType provider)
        {
            switch (provider)
            {
                case DbProviderType.MYSQL:
                    columnName = StringUtil.RemoveSpaces(columnName);
                    return ("?" + columnName);

                case DbProviderType.ORACLE:
                    columnName = StringUtil.RemoveSpaces(columnName);
                    return (":" + columnName);

                case DbProviderType.SQLSERVER:
                    columnName = StringUtil.RemoveSpaces(columnName);
                    return ("@" + columnName);

                case DbProviderType.OLEDB:
                    return "?";
            }
            throw new Exception("DbProviderType " + provider + " is not currently supported.");
        }

        public static char GetPostDelimeter(DbType type)
        {
            switch (type)
            {
                case DbType.ACCESS:
                    return ']';

                case DbType.SQLSERVER:
                    return ']';

                case DbType.MYSQL:
                    return '`';

                case DbType.ORACLE:
                    return ' ';
            }
            throw new Exception("DbType " + type + " not supported currently.");
        }

        public static char GetPreDelimeter(DbType type)
        {
            switch (type)
            {
                case DbType.ACCESS:
                    return '[';

                case DbType.SQLSERVER:
                    return '[';

                case DbType.MYSQL:
                    return '`';

                case DbType.ORACLE:
                    return ' ';
            }
            throw new Exception("DbType " + type + " not supported currently.");
        }

        public static string GetSqlServerLastInsertedCommand(string table)
        {
            return ("SELECT IDENT_CURRENT('" + table + "');");
        }

        public static string GetSqlServerLastInsertedScopeCommand()
        {
            return "SELECT SCOPE_IDENTITY();";
        }

        public static char GetStringDelimeter(DbType type)
        {
            switch (type)
            {
                case DbType.ACCESS:
                    return '\'';

                case DbType.SQLSERVER:
                    return '\'';

                case DbType.MYSQL:
                    return '\'';

                case DbType.ORACLE:
                    return '\'';
            }
            throw new Exception("DbType " + type + " not supported currently.");
        }
    }
}
