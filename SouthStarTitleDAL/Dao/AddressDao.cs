using System;
using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Model;
using SouthStarTitleDAL.Dao.Support.Data;
using System.Data.SqlClient;
using System.Data;

namespace SouthStarTitleDAL.Dao
{
    public class AddressDao : BaseDao<Address, int>
    {
        public AddressDao()
            : base(DbConstants.DatabaseProviderType, DbConstants.DatabaseType, "ADDRESS", DbConstants.ConnectionString) 
        {
        }


        public int UpsertEntityAddress(Address address, string val, Int32 entityAddressId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("UpsertEntityAddress", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@entityAddressId", SqlDbType.Int)).Value = entityAddressId;
                    myCommand.Parameters.Add(new SqlParameter("@val", SqlDbType.VarChar, 4)).Value = val;
                    myCommand.Parameters.Add(new SqlParameter("@streetAddress1", SqlDbType.VarChar, 250)).Value = address.StreetAddress1;
                    myCommand.Parameters.Add(new SqlParameter("@streetAddress2", SqlDbType.VarChar, 50)).Value = address.StreetAddress2;
                    myCommand.Parameters.Add(new SqlParameter("@city", SqlDbType.VarChar, 50)).Value = address.City;
                    myCommand.Parameters.Add(new SqlParameter("@state", SqlDbType.Int)).Value = address.StateId;
                    myCommand.Parameters.Add(new SqlParameter("@zip", SqlDbType.VarChar, 5)).Value = address.Zip;
                    myCommand.Parameters.Add(new SqlParameter("@workPhone", SqlDbType.VarChar, 15)).Value = address.WorkPhone;
                    myCommand.Parameters.Add(new SqlParameter("@faxPhone", SqlDbType.VarChar, 15)).Value = address.FaxPhone;
                    myCommand.Parameters.Add(new SqlParameter("@otherPhone", SqlDbType.VarChar, 15)).Value = address.OtherPhone;

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
                        
                throw new Exception("InsertAddress Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public int UpsertUserAddress(Address address, string val, Int32 entityAddressId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("UpsertUserAddress", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@userAddressId", SqlDbType.Int)).Value = entityAddressId;
                    myCommand.Parameters.Add(new SqlParameter("@val", SqlDbType.VarChar, 4)).Value = val;
                    myCommand.Parameters.Add(new SqlParameter("@homePhone", SqlDbType.VarChar, 15)).Value = address.HomePhone;
                    myCommand.Parameters.Add(new SqlParameter("@cellPhone", SqlDbType.VarChar, 15)).Value = address.CellPhone;
                    myCommand.Parameters.Add(new SqlParameter("@otherPhone", SqlDbType.VarChar, 15)).Value = address.OtherPhone;
                    myCommand.Parameters.Add(new SqlParameter("@workPhone", SqlDbType.VarChar, 15)).Value = address.WorkPhone;

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

                throw new Exception("InsertAddress Stored Procedure :: Error Ocurred.", ex);
            }
        }

        protected override Address  MapObject(IDataReader dr)
        {
 	        throw new NotImplementedException();
        }

        protected override IDbCommand  CreateSelectOneCommand(object id)
        {
 	        throw new NotImplementedException();
        }
    }
}
