
using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public interface ISqlQuery : IQuery
    {
        // Methods
        ICriteria CreateCriteria();
        void SetCriteria(ICriteria c);
        void SetTable(string tableName);

        // Properties
        ICriteria Criteria { get; }
        DbProviderType DbProviderType { get; set; }
        string Statement { get; }
    }
}
