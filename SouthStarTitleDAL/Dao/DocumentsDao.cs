using System.Data;
using System.Data.SqlClient;
using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Model;
using SouthStarTitleDAL.Dao.Support.Data;
using System;

namespace SouthStarTitleDAL.Dao
{
    public class DocumentsDao : BaseDao<Documents, int>
    {
        public DocumentsDao()
            : base(DbConstants.DatabaseProviderType, DbConstants.DatabaseType, "DOCUMENTS", DbConstants.ConnectionString) 
        {
        }

        public DataSet GetDocuments(int entityId)
        {
            var ds = new DataSet();
            using (var sqlConnection = (SqlConnection)CreateConnection())
            {
                var myCommand = new SqlCommand("GetDocuments", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                };
                myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;

                var sqlDataAdapter = new SqlDataAdapter {SelectCommand = myCommand};

                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }

            return ds;
        }

        public DataSet GetDocumentsByUserId(int entityId, int userId)
        {
            var ds = new DataSet();
            using (var sqlConnection = (SqlConnection)CreateConnection())
            {
                var myCommand = new SqlCommand("GetDocumentsByUserId", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                };
                myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;
                myCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;

                var sqlDataAdapter = new SqlDataAdapter { SelectCommand = myCommand };

                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }

            return ds;
        }

        public void DeleteDocumentById(int userId, int documentId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("DeleteDocumentById", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;
                    myCommand.Parameters.Add(new SqlParameter("@documentId", SqlDbType.Int)).Value = documentId;
                  

                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteDocumentById Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public void InsertDocumentToUsers(int userId, int documentId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("InsertDocumentToUsers", sqlConnection)
                    { 
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;
                    myCommand.Parameters.Add(new SqlParameter("@documentId", SqlDbType.Int)).Value = documentId;


                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("InsertDocumentToUsers Stored Procedure :: Error Ocurred.", ex);
            }
        
        }

        public int InsertDocument(int entityId, byte[] document, string filename)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("InsertDocument", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;
                    myCommand.Parameters.Add(new SqlParameter("@document", SqlDbType.VarBinary)).Value = document;
                    myCommand.Parameters.Add(new SqlParameter("@filename", SqlDbType.VarChar)).Value = filename;

                    var param = new SqlParameter
                    {
                        Direction = ParameterDirection.ReturnValue,
                        ParameterName = "@ReturnValue",
                        SqlDbType = SqlDbType.Int
                    };

                    myCommand.Parameters.Add(param);
                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                    return int.Parse(myCommand.Parameters["@ReturnValue"].Value.ToString());

                }
            }
            catch (Exception ex)
            {

                throw new Exception("InsertDocument Stored Procedure :: Error Ocurred.", ex);
            }

        }

        public DataSet DowndloadDocumentById(int documentId)
        {
            var ds = new DataSet();
            using (var sqlConnection = (SqlConnection)CreateConnection())
            {
                var myCommand = new SqlCommand("DownloadDocumentById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                };
                myCommand.Parameters.Add(new SqlParameter("@documentId", SqlDbType.Int)).Value = documentId;

                var sqlDataAdapter = new SqlDataAdapter { SelectCommand = myCommand };

                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }

            return ds;
        }
               

        protected override Documents MapObject(IDataReader dr)
        {
            throw new System.NotImplementedException();
        }

        protected override IDbCommand CreateSelectOneCommand(object id)
        {
            throw new System.NotImplementedException();
        }
    }
}
