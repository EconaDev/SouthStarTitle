using System;
using System.Collections;
using System.Collections.Generic;
using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Dao.Support.Data;
using SouthStarTitleDAL.Model;

namespace SouthStarTitleDAL.Dao
{
    public class LuUserTypeDao : BaseDao<LuUserType, int>
    {
        public LuUserTypeDao()
            : base(DbConstants.DatabaseProviderType, DbConstants.DatabaseType, "LU_USER_TYPE", DbConstants.ConnectionString) 
        {

        }

        public List<LuUserType> GetUserType()
        {
            return SelectAll();
        }

        protected override LuUserType MapObject(System.Data.IDataReader r)
        {
            var entity = new LuUserType();

            try
            {
                var ordinal = r.GetOrdinal("ID");
                if (!r.IsDBNull(ordinal)) entity.Id = ((int)(r.GetValue(ordinal)));
            }
            catch (Exception) { }

            try
            {
                var ordinal = r.GetOrdinal("USER_TYPE");
                if (!r.IsDBNull(ordinal)) entity.UserType = ((string)(r.GetValue(ordinal)));
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
