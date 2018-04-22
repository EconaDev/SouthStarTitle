using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Dao.Support.Data;
using SouthStarTitleDAL.Model;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SouthStarTitleDAL.Dao
{
    public class RelUserEntityDao : BaseDao<RelUserEntity,int>
    {
        public RelUserEntityDao()
            : base(DbConstants.DatabaseProviderType, DbConstants.DatabaseType, "REL_USER_ENTITY", DbConstants.ConnectionString) 

        {
        }


        public DataSet GetUsersFromEntities(int entityId)
        {
            var ds = new DataSet();
            using (var sqlConnection = (SqlConnection)CreateConnection())
            {
                var myCommand = new SqlCommand("GetUsersFromEntities", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 300
                };
                myCommand.Parameters.Add(new SqlParameter("@entityId", SqlDbType.Int)).Value = entityId;

                var sqlDataAdapter = new SqlDataAdapter { SelectCommand = myCommand };

                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }

            return ds;
        }


        protected override RelUserEntity MapObject(IDataReader r)
        {
            var relUserEntity = new RelUserEntity();

            try
            {
                var ordinal = r.GetOrdinal("ID");
                if (!r.IsDBNull(ordinal)) relUserEntity.Id = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception){ }

            try
            {
                var ordinal = r.GetOrdinal("USER_ID");
                if (!r.IsDBNull(ordinal)) relUserEntity.UserId = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("ENTITY_ID");
                if (!r.IsDBNull(ordinal)) relUserEntity.EntityId = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }


            return relUserEntity;
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
