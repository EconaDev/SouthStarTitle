
using System.Collections.Generic;
using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Model;

namespace SouthStarTitleBLL.BLL
{
    public class LuUserTypeBLL
    {

        public List<LuUserType> GetUserType()
        {
            return DaoManager.LuUserTypeDao.GetUserType();
        }

    }
}
