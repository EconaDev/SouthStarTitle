using System;
using System.Collections;
using System.Collections.Generic;
using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Dao.Support.Data;
using SouthStarTitleDAL.Model;

namespace SouthStarTitleDAL.Dao
{
    public class LuStateDao : BaseDao<LuState, int>
    {
        public LuStateDao()
            : base(DbConstants.DatabaseProviderType, DbConstants.DatabaseType, "LU_STATE", DbConstants.ConnectionString) 
        {

        }

        public List<LuState> GetStateList()
        {
            return SelectAll();
        }

        protected override LuState MapObject(System.Data.IDataReader r)
        {
            var entity = new LuState();

            try
            {
                var ordinal = r.GetOrdinal("ID");
                if (!r.IsDBNull(ordinal)) entity.Id = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("STATE_NAME");
                if (!r.IsDBNull(ordinal)) entity.StateName = ((string)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("ACTIVE_FLAG");
                if (!r.IsDBNull(ordinal)) entity.ActiveFlag = ((char)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            return entity;
        }

        protected override System.Data.IDbCommand CreateSelectOneCommand(object id)
        {
            throw new NotImplementedException();
        }
    }
}
