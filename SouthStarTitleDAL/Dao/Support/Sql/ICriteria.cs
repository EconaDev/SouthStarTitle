using System.Collections;
using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public interface ICriteria
    {
        // Methods
        void AddAnd();
        void AddAndCriteria(ICriteria pc);
        void AddBetween(string columnName, object value1, object value2);
        void AddEqualTo(string columnName);
        void AddEqualTo(string columnName, object columnValue);
        void AddEqualTo(string tableName, string columnName);
        void AddEqualTo(string tableName, string columnName, object columnValue);
        void AddEqualToOptimistic(string columnName);
        void AddExists(ISqlQuery subSqlQuery);
        void AddGreaterThan(string columnName, object columnValue);
        void AddGreaterThanOrEqualTo(string columnName, object columnValue);
        void AddIn(string columnName, ISqlQuery subSqlQuery);
        void AddIn(string columnName, ICollection values);
        void AddIsNull(string columnName);
        void AddIsNullOrEqualTo(string columnName);
        void AddLessThan(string columnName, object columnValue);
        void AddLessThanOrEqualTo(string columnName, object columnValue);
        void AddLike(string columnName, object columnValue);
        void AddLike(string tableName, string columnName, object columnValue);
        void AddNotBetween(string columnName, object value1, object value2);
        void AddNotEqualTo(string columnName, object columnValue);
        void AddNotExists(ISqlQuery subSqlQuery);
        void AddNotIn(string columnName, ISqlQuery subSqlQuery);
        void AddNotIn(string columnName, ICollection values);
        void AddNotLike(string columnName, object columnValue);
        void AddNotNull(string columnName);
        void AddOr();
        void AddOrCriteria(ICriteria pc);
        void AddSql(string sql);
        string GetText();

        // Properties
        DbProviderType DbProviderType { get; set; }
        bool Initialized { get; }
        string Statement { get; }
    }
}
