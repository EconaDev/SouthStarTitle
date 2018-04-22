using System;
using System.Collections.Generic;

using SouthStarTitleDAL.Dao.Support.Sql;
using System.Collections;
using System.Data.SqlClient;
using SouthStarTitleDAL.Dao.Support.Data;
using System.Data;
using DbType=SouthStarTitleDAL.Dao.Support.Data.DbType;


namespace SouthStarTitleDAL.Dao.Support
{
    /// <summary>
    /// A base class for Dao classes that provides all
    /// typically required functionality but allows 
    /// overriding of all methods for customization.
    /// </summary>
    public abstract class BaseDao<TBean, TId>
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// The database provider type
        /// </summary>
        public DbProviderType Provider { get; set; }
        /// <summary>
        /// The database type
        /// </summary>
        public DbType Db { get; set; }
        /// <summary>
        /// The name of the table
        /// </summary>
        public string Table { get; set; }

        protected BaseDao()
        { 
        
        }

        protected BaseDao(DbProviderType providerType, DbType databaseType, string connectionString)
        {
            Provider = providerType;
            Db = databaseType;
            ConnectionString = connectionString;
        }

        protected BaseDao(DbProviderType providerType, DbType databaseType, string tableName, string connectionString)
        {
            Provider = providerType;
            Db = databaseType;
            Table = tableName;
            ConnectionString = connectionString;
        }

        #region CRUD and Main Methods

        internal List<TBean> SelectAll()
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                return SelectAll(connection);
            }
        }

        internal List<TBean> SelectAll(IDbConnection conn)
        {
            IDataReader dr = DbProviderFactory.CreateDataReader(conn, CreateSelectAllCommand(), Provider);
            List<TBean> list = MapObjects(dr);
            dr.Close();
            return list;
        }

        internal TBean SelectById(TId id)
        {
            TBean o;
            using (IDbConnection conn = CreateConnection())
            {
                conn.Open();
                o = SelectById(id, conn);
            }
            return o;
        }

        internal TBean SelectById(TId id, IDbConnection connection)
        {
            TBean o = default(TBean);
            IDataReader dr = DbProviderFactory.CreateDataReader(connection, CreateSelectOneCommand(id), Provider);
            while (dr.Read())
            {
                o = MapObject(dr);
                break;
            }
            dr.Close();

            return o;
        }

        internal List<TBean> MapObjects(IDataReader dr)
        {
            var list = new List<TBean>();
            while (dr.Read())
                list.Add(MapObject(dr));
            return list;
        }

        #endregion

        #region Helper Methods

        ///// <summary>
        ///// Creates a DataSet, using the given command
        ///// </summary>
        ///// <param name="cmd">The command to execute</param>
        ///// <returns></returns>
        //protected DataSet CreateDataSet(IDbCommand cmd)
        //{
        //    return DbProviderFactory.CreateDataSet(connectionString, cmd, provider);
        //}

        ///// <summary>
        ///// Creates a DataSet, using the given command
        ///// </summary>
        ///// <param name="cmd">The command to execute</param>
        ///// <returns></returns>
        //protected DataSet CreateDataSet(string cmd)
        //{
        //    return DbProviderFactory.CreateDataSet(connectionString, CreateCommand(cmd), provider);
        //}

        ///// <summary>
        ///// Creates a DataSet, using the given command
        ///// </summary>
        ///// <param name="cmd">The command to execute</param>
        ///// <param name="conn">The open connection to use</param>
        ///// <returns></returns>
        //protected DataSet GetDataSet(IDbCommand cmd, IDbConnection conn)
        //{
        //    return DbProviderFactory.CreateDataSet(conn, cmd, provider);
        //}

        /// <summary>
        /// Creates a connection with the proper connection string filled in
        /// </summary>
        /// <returns></returns>
        internal IDbConnection CreateConnection()
        {
            IDbConnection connection = DbProviderFactory.CreateConnection(Provider);
            connection.ConnectionString = ConnectionString;
            return connection;
        }

        /// <summary>
        /// Creates a command for the correct database provider
        /// and sets the connection
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns></returns>
        public IDbCommand CreateCommand(string command)
        {
            IDbCommand cmd = DbProviderFactory.CreateCommand(Provider);
            cmd.CommandText = command;
            cmd.Connection = CreateConnection();
            return cmd;
        }

        /// <summary>
        /// Creates a command to select all records
        /// </summary>
        /// <returns></returns>
        protected IDbCommand CreateSelectAllCommand()
        {
            IDbCommand command = DbProviderFactory.CreateCommand(Provider);
            ISelectQuery s = QueryFactory.CreateSelectQuery(Db);
            s.AddAll();
            s.SetTable(Table);
            command.CommandText = s.GetText();
            return command;
        }

        /// <summary>
        /// Creates a command to delete all records
        /// </summary>
        /// <returns></returns>
        protected IDbCommand CreateDeleteAllCommand()
        {
            IDbCommand command = DbProviderFactory.CreateCommand(Provider);
            IDeleteQuery s = QueryFactory.CreateDeleteQuery(Db, Provider);
            s.SetTable(Table);
            command.CommandText = s.GetText();
            return command;
        }

        #endregion

        #region Abstract Items

        /// <summary>
        /// Maps an individual object to a DataReader row
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        protected abstract TBean MapObject(IDataReader dr);

        /// <summary>
        /// Selects one record, using the specified id
        /// </summary>
        /// <param name="id">The id of the record to select</param>
        /// <returns></returns>
        protected abstract IDbCommand CreateSelectOneCommand(object id);

        #endregion

    }
}
