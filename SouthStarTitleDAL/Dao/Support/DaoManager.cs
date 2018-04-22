
namespace SouthStarTitleDAL.Dao.Support
{
    public class DaoManager
    {
        public static readonly UserDao UserDao = new UserDao();
        public static readonly DocumentsDao DocumentsDao = new DocumentsDao();
        public static readonly EntityDao EntityDao = new EntityDao();
        public static readonly AddressDao AddressDao = new AddressDao();
        public static readonly LuStateDao LuStateDao = new LuStateDao();
        public static readonly LuUserTypeDao LuUserTypeDao = new LuUserTypeDao();
        public static readonly RelUserEntityDao RelUserEntityDao = new RelUserEntityDao();
        

    }
}
