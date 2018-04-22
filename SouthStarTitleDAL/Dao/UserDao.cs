using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Dao.Support.Data;
using SouthStarTitleDAL.Model;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SouthStarTitleDAL.Dao
{
    public class UserDao : BaseDao<User,int>
    {
        public UserDao()
            : base(DbConstants.DatabaseProviderType, DbConstants.DatabaseType, "USER", DbConstants.ConnectionString) 

        {
        }

        public List<User> GetUserList()
        {
            return SelectAll();
        }

        public DataSet GetUsers(int maximumRows, int startRowIndex, string sortExpression)
        {
            var ds = new DataSet();
            using (var sqlConnection = (SqlConnection)CreateConnection())
            {
                var myCommand = new SqlCommand("GetUsers", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                };

                myCommand.Parameters.Add(new SqlParameter("@sortExpression", SqlDbType.NVarChar)).Value = sortExpression;
                myCommand.Parameters.Add(new SqlParameter("@startRowIndex", SqlDbType.Int)).Value = startRowIndex;
                myCommand.Parameters.Add(new SqlParameter("@maximumRows", SqlDbType.Int)).Value = maximumRows;

                var sqlDataAdapter = new SqlDataAdapter { SelectCommand = myCommand };

                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }

            return ds;
        }

        public Int32 GetUsersCount(string sortExpression)
        {
            int recordCount;
            using (SqlConnection sqlConnection = (SqlConnection)this.CreateConnection())
            {
                SqlCommand myCommand = new SqlCommand("GetUsersCount", sqlConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandTimeout = 300;
                myCommand.Parameters.Add(new SqlParameter("@totalRecords", SqlDbType.Int)).Direction = ParameterDirection.Output;
                if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();
                myCommand.ExecuteNonQuery();
                recordCount = (Int32)myCommand.Parameters["@totalRecords"].Value;
            }

            return recordCount;
        }

        public DataSet GetUsersPermissions(string username, string password)
        {

            try
            {
                var ds = new DataSet();
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("UserLogin", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };

                    myCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = username;
                    myCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)).Value = password;

                    var sqlDataAdapter = new SqlDataAdapter { SelectCommand = myCommand };

                    sqlDataAdapter.Fill(ds);
                    sqlDataAdapter.Dispose();
                }

                return ds;

            }
            catch (Exception ex)
            {

                throw new Exception("UserLogin Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public void UpsertUser(User user, string val, Int32 userId, Int32 entityId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("UpsertUser", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;
                    myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;
                    myCommand.Parameters.Add(new SqlParameter("@val", SqlDbType.VarChar, 1)).Value = val;
                    myCommand.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 50)).Value = user.FirstName;
                    myCommand.Parameters.Add(new SqlParameter("@middleName", SqlDbType.VarChar, 50)).Value = user.MiddleName;
                    myCommand.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 50)).Value = user.LastName;
                    myCommand.Parameters.Add(new SqlParameter("@userAddressId", SqlDbType.Int)).Value = user.UserAddressId;
                    myCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50)).Value = user.Email;
                    myCommand.Parameters.Add(new SqlParameter("@userTypeId", SqlDbType.Int)).Value = user.UserTypeId;

                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("UpsertUser Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public void UpsertUserPassword(User user)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("UpsertUserPassword", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = user.UserId;
                    myCommand.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 50)).Value = user.Login;
                    myCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50)).Value = user.Password;

                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("UpsertUserPassword Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public void DeleteUserById(int userId, int entityId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("DeleteUserById", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;
                    myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;

                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteUserById Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public User EditUserById(int userId)
        {
            return SelectById(userId);
        }

        protected override User MapObject(IDataReader r)
        {
            var user = new User();
            var address = new Address();
            user.Address = address;

            try
            {
                var ordinal = r.GetOrdinal("USER_ID");
                if (!r.IsDBNull(ordinal)) user.UserId = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception){ }

            try
            {
                var ordinal = r.GetOrdinal("FIRST_NAME");
                if (!r.IsDBNull(ordinal)) user.FirstName = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("MIDDLE_NAME");
                if (!r.IsDBNull(ordinal)) user.MiddleName = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("LAST_NAME");
                if (!r.IsDBNull(ordinal)) user.LastName = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("USER_ADDRESS_ID");
                if (!r.IsDBNull(ordinal)) user.UserAddressId = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("EMAIL");
                if (!r.IsDBNull(ordinal)) user.Email = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("LOGIN");
                if (!r.IsDBNull(ordinal)) user.Login = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("PASSWORD");
                if (!r.IsDBNull(ordinal)) user.Password = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("HAS_PASSWORD");
                if (!r.IsDBNull(ordinal)) user.HasPassword = ((char)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("WORK_PHONE");
                if (!r.IsDBNull(ordinal)) user.Address.WorkPhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("HOME_PHONE");
                if (!r.IsDBNull(ordinal)) user.Address.HomePhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("CELL_PHONE");
                if (!r.IsDBNull(ordinal)) user.Address.CellPhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("OTHER_PHONE");
                if (!r.IsDBNull(ordinal)) user.Address.OtherPhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("ACTIVE_FLAG");
                if (!r.IsDBNull(ordinal)) user.ActiveFlag = ((char)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("CREATED_TIMESTAMP");
                if (!r.IsDBNull(ordinal)) user.CreatedTimeStamp = ((DateTime)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("UPDATED_TIMESTAMP");
                if (!r.IsDBNull(ordinal)) user.UpdatedTimeStamp = ((DateTime)(r.GetValue(ordinal)));
            }
            catch (Exception) { }
                        
            try
            {
                var ordinal = r.GetOrdinal("USER_TYPE_ID");
                if (!r.IsDBNull(ordinal)) user.UserTypeId = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            return user;
        }

        protected override IDbCommand CreateSelectOneCommand(object id)
        {
          
            try
            {

                var cmd = CreateCommand("SelectUserById");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                var cmdParams = cmd.Parameters;

                var parId = cmd.CreateParameter();
                parId.ParameterName = "@userId";
                parId.Value = id;
                cmdParams.Add(parId);

                //var parTable = cmd.CreateParameter();
                //parTable.ParameterName = "@table";
                //parTable.Value = Table;
                //cmdParams.Add(parTable);

                return cmd;
            }
            catch (Exception ex)
            {

                throw new Exception("SelectUserById Stored Procedure :: Error Ocurred.", ex);
            }
        }
    }
}
