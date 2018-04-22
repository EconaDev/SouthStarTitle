using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class SqlServerCriteria : Criteria
    {
        // Methods
        public SqlServerCriteria()
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER)
        {
        }

        public SqlServerCriteria(string sql)
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER, sql)
        {
        }
    }
}
