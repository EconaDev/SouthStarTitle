
using System.Collections.Generic;
using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Model;

namespace SouthStarTitleBLL.BLL
{
    public class LuStateBLL
    {

        public List<LuState> SelectAllStates()
        {
            return DaoManager.LuStateDao.GetStateList();
        }

    }
}
