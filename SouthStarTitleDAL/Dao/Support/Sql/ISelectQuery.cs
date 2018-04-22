
namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public interface ISelectQuery : ISqlQuery
    {
        // Methods
        void Add(string columnName);
        void Add(string tableName, string columnName);
        void AddAll();
        void AddColumnAlias(string columnName, string alias);
        void AddColumnAlias(string tableName, string columnName, string alias);
        void AddCount(string columnName);
        void AddCountAll();
        void AddGroupBy(string columnName);
        void AddGroupBy(params string[] columns);
        void AddJoin(string secondTable, string firstTableColumn, string secondTableColumn, JoinType type);
        void AddJoin(string secondTable, string firstTableColumn, string secondTableColumn, string thirdTable, string thirdTableColumn, string fourthTable, string fourtTableColumn, JoinType joinType);
        void AddOrderBy(string columnName);
        void AddOrderBy(string columnName, OrderBy orderBy);
        void AddOrderBy(string tableName, string columnName);
        void AddOrderBy(string tableName, string columnName, OrderBy orderBy);
        void AddOrderByColumns(params string[] columns);
        void SetLimit(int maxRecords);

        // Properties
        OrderBy OrderBy { get; set; }
    }
}
