using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class SqlDeleteQuery : DeleteQuery
    {
        // Methods
        public SqlDeleteQuery()
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER)
        {
        }

        public SqlDeleteQuery(string tableName)
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER, tableName)
        {
        }
    }
}
