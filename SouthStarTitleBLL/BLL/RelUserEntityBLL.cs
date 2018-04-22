using System;
using System.Collections.Generic;
using SouthStarTitleDAL.Model;
using SouthStarTitleDAL.Dao.Support;
using System.Data;
using System.Collections;

namespace SouthStarTitleBLL.BLL
{
    public class RelUserEntityBLL
    {

        public DataSet GetUsersFromEntities(int entityId)
        {
            return DaoManager.RelUserEntityDao.GetUsersFromEntities(entityId);
        }

        public DataSet GetPeopleFromEntities(int entityId)
        {


            DataSet dsDetail = DaoManager.RelUserEntityDao.GetUsersFromEntities(entityId);
            dsDetail.Tables[0].Columns.Add(new DataColumn("NAME", Type.GetType("System.String")));

            DataTable dtDetail = dsDetail.Tables["Table"];
            DataRow[] dataRowDetail = dtDetail.Select();

            for (int i = 0; i < dataRowDetail.Length; i++)
            {
                dsDetail.Tables[0].Rows[i][6] = dataRowDetail[i].ItemArray[1] + ", " + dataRowDetail[i].ItemArray[3];
                dsDetail.AcceptChanges();
            }

            return dsDetail;

        }


    }
}
