
using System.Data;
using SouthStarTitleDAL.Model;
using SouthStarTitleDAL.Dao.Support;
using System.Collections.Generic;
using System;

namespace SouthStarTitleBLL.BLL
{
    public class EntityBLL
    {
        public void UpsertEntity(Entity entity, string val, Int32 entityid)
        {
            DaoManager.EntityDao.UpsertEntity(entity, val, entityid);
        }

        public List<Entity> SelectAllEntities()
        {
            return DaoManager.EntityDao.GetEntityList();
        }

        public DataSet GetEntitiesByUser(int userId)
        {
            return DaoManager.EntityDao.GetEntitiesByUser(userId);
        }

        public DataSet GetEntities()
        {
            return DaoManager.EntityDao.GetEntities();
        }

        public void DeleteEntityById(int entityId)
        {
            DaoManager.EntityDao.DeleteEntityById(entityId);
        }

        public Entity EditEntityById(int entityId)
        {
            return DaoManager.EntityDao.EditEntityById(entityId);
        }
    }
}
