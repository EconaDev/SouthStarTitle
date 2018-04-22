using System;
using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class CriteriaFactory
    {
        // Methods
        public static ICriteria CreateCriteria(DbType type)
        {
            switch (type)
            {
                //case DbType.ACCESS:
                //    return new AccessCriteria();

                case DbType.SQLSERVER:
                    return new SqlServerCriteria();

                //case DbType.MYSQL:
                //    return new MySqlCriteria();

                //case DbType.ORACLE:
                //    return new OracleCriteria();
            }
            throw new Exception("DbType " + type + " not supported currently.");
        }
    }

 

}
