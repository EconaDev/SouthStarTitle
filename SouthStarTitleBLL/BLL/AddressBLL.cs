using SouthStarTitleDAL.Dao.Support;
using SouthStarTitleDAL.Model;
using System;

namespace SouthStarTitleBLL.BLL
{
    public class AddressBLL
    {

        public int UpsertEntityAddress(Address address, string val, Int32 entityAddressId)
        {
            return DaoManager.AddressDao.UpsertEntityAddress(address, val, entityAddressId);
        }

        public int UpsertUserAddress(Address address, string val, Int32 entityAddressId)
        {
            return DaoManager.AddressDao.UpsertUserAddress(address, val, entityAddressId);
        }

    }
}
