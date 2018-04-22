using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace SouthStarTitleDAL.Dao.Support.Data
{
    public class DbProviderFactory
    {
        public static IDbCommand CreateCommand(DbProviderType dbProviderType)
        {
            switch (dbProviderType)
            {
                //case DbProviderType.MYSQL:
                //    return new MySqlCommand();

                //case DbProviderType.ORACLE:
                //    return new OracleCommand();

                //case DbProviderType.ORACLENATIVE:
                //    return new OracleCommand();

                case DbProviderType.SQLSERVER:
                    return new SqlCommand();
            }
            return new OleDbCommand();
        }

        public static IDbConnection CreateConnection(DbProviderType dbProviderType)
        {
            switch (dbProviderType)
            {
                //case DbProviderType.MYSQL:
                //    return new MySqlConnection();

                //case DbProviderType.ORACLE:
                //    return new OracleConnection();

                //case DbProviderType.ORACLENATIVE:
                //    return new OracleConnection();

                case DbProviderType.SQLSERVER:
                    return new SqlConnection();
            }
            return new OleDbConnection();
        }

        public static IDataReader CreateDataReader(IDbConnection connection, IDbCommand command, DbProviderType dbProviderType)
        {
            return CreateDataReader(connection, command, CommandBehavior.Default, dbProviderType);
        }

        public static IDataReader CreateDataReader(IDbConnection connection, string command, DbProviderType dbProviderType)
        {
            IDbCommand command2 = CreateCommand(dbProviderType);
            command2.CommandText = command;
            return CreateDataReader(connection, command2, dbProviderType);
        }

        public static IDataReader CreateDataReader(IDbConnection connection, IDbCommand command, CommandBehavior behavior, DbProviderType dbProviderType)
        {
            command.Connection = connection;
            return command.ExecuteReader(behavior);
        }

 

 


    }
}
