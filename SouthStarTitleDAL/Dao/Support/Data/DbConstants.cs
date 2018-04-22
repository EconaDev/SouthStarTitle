using System.Configuration;

namespace SouthStarTitleDAL.Dao.Support.Data

{
    public class DbConstants
    {

        public static readonly DbProviderType DatabaseProviderType = DbProviderType.SQLSERVER;

        public static readonly DbType DatabaseType = DbType.SQLSERVER;

        public static string ConnectionString
        {
            get
            {
                string conn = ConfigurationManager.AppSettings["SQLConnectionString"];
                if (string.IsNullOrEmpty(conn))
                    //return @"Data Source=southstardb.db.2225184.hostedresource.com; Initial Catalog=southstardb; User ID=southstardb; Password='Santiago1'";
                    return @"Data Source=localhost; Initial Catalog=southstardb; User ID=southstardb; Password='Santiago1'";
                return conn;
            }
        }
    }
}
