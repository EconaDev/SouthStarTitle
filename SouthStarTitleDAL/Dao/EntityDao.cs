using System;
using System.Collections.Generic;
using System.Data;
using SouthStarTitleDAL.Dao.Support.Data;
using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Model;
using System.Data.SqlClient;

namespace SouthStarTitleDAL.Dao
{
    public class EntityDao : BaseDao<Entity, int>
    {
        public EntityDao()
            : base(DbConstants.DatabaseProviderType, DbConstants.DatabaseType, "ENTITY", DbConstants.ConnectionString) 
        {

        }

        public List<Entity> GetEntityList()
        {
            return SelectAll();
        }

        public DataSet GetEntities()
        {
            var ds = new DataSet();
            using (var sqlConnection = (SqlConnection)CreateConnection())
            {
                var myCommand = new SqlCommand("GetEntities", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                };

                var sqlDataAdapter = new SqlDataAdapter { SelectCommand = myCommand };

                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }

            return ds;
        }

        public DataSet GetEntitiesByUser(int userId)
        {
            var ds = new DataSet();
            using (var sqlConnection = (SqlConnection)CreateConnection())
            {
                var myCommand = new SqlCommand("GetEntitiesByUserId", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                };
                myCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;
                var sqlDataAdapter = new SqlDataAdapter { SelectCommand = myCommand };

                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }

            return ds;
        }

        public void UpsertEntity(Entity entity, string val, Int32 entityId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("UpsertEntity", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;
                    myCommand.Parameters.Add(new SqlParameter("@val", SqlDbType.VarChar, 1)).Value = val;
                    myCommand.Parameters.Add(new SqlParameter("@entityName", SqlDbType.VarChar, 250)).Value = entity.EntityName;
                    myCommand.Parameters.Add(new SqlParameter("@entityAddressId", SqlDbType.Int)).Value = entity.EntityAddressId;

                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("UpsertEntity Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public void DeleteEntityById(int entityId)
        {
            try
            {
                using (var sqlConnection = (SqlConnection)CreateConnection())
                {
                    var myCommand = new SqlCommand("DeleteEntityById", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 300
                    };
                    myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;

                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteEntityById Stored Procedure :: Error Ocurred.", ex);
            }
        }

        public Entity EditEntityById(int entityId)
        {
            return SelectById(entityId);
        }


        protected override Entity MapObject(IDataReader r)
        {
            var entity = new Entity();
            var address = new Address();
            var luState = new LuState();
            address.LuState = luState;
            entity.Address = address;

            try
            {
                var ordinal = r.GetOrdinal("ID");
                if (!r.IsDBNull(ordinal)) entity.Id = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("ENTITY_NAME");
                if (!r.IsDBNull(ordinal)) entity.EntityName = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("ENTITY_ADDRESS_ID");
                if (!r.IsDBNull(ordinal)) entity.EntityAddressId = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }


            try
            {
                var ordinal = r.GetOrdinal("ACTIVE_FLAG");
                if (!r.IsDBNull(ordinal)) entity.ActiveFlag = ((char)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("CREATED_TIMESTAMP");
                if (!r.IsDBNull(ordinal)) entity.CreatedTimeStamp = ((DateTime)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("UPDATED_TIMESTAMP");
                if (!r.IsDBNull(ordinal)) entity.UpdatedTimeStamp = ((DateTime)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("STREET_ADDRESS_1");
                if (!r.IsDBNull(ordinal)) entity.Address.StreetAddress1 = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("STREET_ADDRESS_2");
                if (!r.IsDBNull(ordinal)) entity.Address.StreetAddress2 = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("CITY");
                if (!r.IsDBNull(ordinal)) entity.Address.City = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("STATE_NAME");
                if (!r.IsDBNull(ordinal)) entity.Address.LuState.StateName = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("STATE_ID");
                if (!r.IsDBNull(ordinal)) entity.Address.LuState.Id = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("ZIP");
                if (!r.IsDBNull(ordinal)) entity.Address.Zip = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("HOME_PHONE");
                if (!r.IsDBNull(ordinal)) entity.Address.HomePhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("WORK_PHONE");
                if (!r.IsDBNull(ordinal)) entity.Address.WorkPhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("CELL_PHONE");
                if (!r.IsDBNull(ordinal)) entity.Address.CellPhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("FAX_PHONE");
                if (!r.IsDBNull(ordinal)) entity.Address.FaxPhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("OTHER_PHONE");
                if (!r.IsDBNull(ordinal)) entity.Address.OtherPhone = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            return entity;
        }

        protected override IDbCommand CreateSelectOneCommand(object entityId)
        {

            try
            {

                var cmd = CreateCommand("SelectEntityById");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                var cmdParams = cmd.Parameters;

                var parId = cmd.CreateParameter();
                parId.ParameterName = "@entityId";
                parId.Value = entityId;
                cmdParams.Add(parId);

                //var parTable = cmd.CreateParameter();
                //parTable.ParameterName = "@table";
                //parTable.Value = Table;
                //cmdParams.Add(parTable);

                return cmd;
            }
            catch (Exception ex)
            {

                throw new Exception("SelectEntityById Stored Procedure :: Error Ocurred.", ex);
            }

        }
    }
}
