
namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public interface IInsertQuery : INonSelectQuery
    {
        // Methods
        void Add(string columnName);
        void Add(string columnName, object columnValue);
        void AddNull(string columnName);
    }
}
