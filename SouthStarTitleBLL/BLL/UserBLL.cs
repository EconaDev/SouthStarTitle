using System;
using System.Collections.Generic;
using SouthStarTitleDAL.Model;
using SouthStarTitleDAL.Dao.Support;
using System.Data;

namespace SouthStarTitleBLL.BLL
{
    public class UserBLL
    {
        public void UpsertUser(User user, string val, Int32 userId, Int32 entityId)
        {
            DaoManager.UserDao.UpsertUser(user, val, userId, entityId);
        }

        public void UpsertUserPassword(User user)
        {
            DaoManager.UserDao.UpsertUserPassword(user);
        }

        public List<User> SelectAllUsers()
        {
            return DaoManager.UserDao.GetUserList();
        }

        public static DataSet GetUsers(int maximumRows, int startRowIndex, string sortExpression)
        {
            //taking care of sortexpression being a null value
            if (string.IsNullOrEmpty(sortExpression))
            {
                sortExpression = "FIRST_NAME";
                return DaoManager.UserDao.GetUsers(maximumRows, startRowIndex, sortExpression);
            }
            return DaoManager.UserDao.GetUsers(maximumRows, startRowIndex, sortExpression);
        }

        public Int32 GetUsersCount(string sortExpression)
        {
            return DaoManager.UserDao.GetUsersCount(sortExpression);
        }

        public static DataSet GetUsersPermissions(string username, string password)
        {
            return DaoManager.UserDao.GetUsersPermissions(username, password);
        }

        public void DeleteUserById(int userId, int entityId)
        {
            DaoManager.UserDao.DeleteUserById(userId, entityId);
        }

        public User EditUserById(int userId)
        {
            return DaoManager.UserDao.EditUserById(userId);
        }
    }
}
