using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class SqlInsertQuery : InsertQuery
    {
        // Methods
        public SqlInsertQuery()
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER)
        {
        }

        public SqlInsertQuery(string tableName)
            : base(DbType.SQLSERVER, DbProviderType.SQLSERVER, tableName)
        {
        }
    }
}
