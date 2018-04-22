using System;

namespace SouthStarTitleDAL.Dao.Support.Data
{
    public class DbTypeConverter
    {
        // Methods
        public static string Convert(DbType t)
        {
            switch (t)
            {
                case DbType.UNKNOWN:
                    return "UNKNOWN";

                case DbType.ACCESS:
                    return "ACCESS";

                case DbType.SQLSERVER:
                    return "SQLSERVER";

                case DbType.MYSQL:
                    return "MYSQL";

                case DbType.ORACLE:
                    return "ORACLE";

                case DbType.DB2:
                    return "DB2";
            }
            throw new Exception("DbType " + t + " not found.");
        }

        public static DbType Convert(string s)
        {
            switch (s.Trim().ToLower())
            {
                case "unknown":
                    return DbType.UNKNOWN;

                case "access":
                    return DbType.ACCESS;

                case "db2":
                    return DbType.DB2;

                case "mysql":
                    return DbType.MYSQL;

                case "oraclenative":
                case "oracle":
                    return DbType.ORACLE;

                case "sqlserver":
                case "sqlclient":
                    return DbType.SQLSERVER;
            }
            throw new Exception("DbType " + s + " not found.");
        }
    }
}
