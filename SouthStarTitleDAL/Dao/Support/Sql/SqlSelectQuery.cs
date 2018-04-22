using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class SqlSelectQuery : SelectQuery
    {
        // Methods
        public SqlSelectQuery()
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER)
        {
        }

        public SqlSelectQuery(string tableName)
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER, tableName)
        {
        }
    }
}
