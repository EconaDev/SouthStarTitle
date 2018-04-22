using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using SouthStarTitleDAL.Model;
using SouthStarTitleBLL.BLL.Support;
using System.Data;

namespace SouthStarTitle
{
    /// <summary>
    /// Summary description for SouthStarTitleWebService
    /// </summary>
    [WebService(Namespace = "http://SouthStarTitle.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class SouthStarTitleWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true, XmlSerializeString = false)]
        public DataSet GetUsersFromEntities(int entityId)
        {
            return BLLManager.RelUserEntityBLL.GetUsersFromEntities(entityId);
        }
    }
}
