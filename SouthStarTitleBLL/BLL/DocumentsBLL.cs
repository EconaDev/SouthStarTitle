using System.Data;
using SouthStarTitleDAL.Dao.Support;

namespace SouthStarTitleBLL.BLL
{
    public class DocumentsBLL
    {

        public DataSet GetDocumentsByUserId(int entityId, int userId)
        {
            return DaoManager.DocumentsDao.GetDocumentsByUserId(entityId, userId);
        }

        public DataSet GetDocuments(int entityId)
        {
            return DaoManager.DocumentsDao.GetDocuments(entityId);
        }

        public void DeleteDocumentById(int userId, int documentId)
        {
            DaoManager.DocumentsDao.DeleteDocumentById(userId, documentId);
        }

        public void InsertDocumentToUsers(int userId, int documentId)
        {
            DaoManager.DocumentsDao.InsertDocumentToUsers(userId, documentId);
        }

        public int InsertDocument(int entityId, byte[] document, string filename)
        {
            return DaoManager.DocumentsDao.InsertDocument(entityId, document, filename);
        }

        public DataSet DowndloadDocumentById(int documentId)
        {
            return DaoManager.DocumentsDao.DowndloadDocumentById(documentId);
        }


    }
}
