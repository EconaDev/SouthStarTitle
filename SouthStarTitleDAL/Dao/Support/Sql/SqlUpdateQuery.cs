using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class SqlUpdateQuery : UpdateQuery
    {
        // Methods
        public SqlUpdateQuery()
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER)
        {
        }

        public SqlUpdateQuery(string tableName)
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER, tableName)
        {
        }
    }
}
