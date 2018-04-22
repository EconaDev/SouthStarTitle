using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SouthStarTitleBLL.BLL.Support;

namespace SouthStarTitle
{
    public partial class ClientFiles : Page
    {
        protected ObjectDataSource odsResults;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ClientValidate"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadEntities();
                BindGridViewResults();
            }

        }

        private ObjectDataSource OdsResults
        {
            get
            {
                if (odsResults == null)
                {
                    odsResults = new ObjectDataSource();
                }
                return odsResults;
            }
        }

        private DropDownList DdlEntity
        {
            get
            {
                if (ddlEntity == null)
                {
                    ddlEntity = new DropDownList();
                }
                return ddlEntity;
            }
        }

        private void LoadEntities()
        {
            DdlEntity.DataSource = BLLManager.EntityBLL.GetEntitiesByUser(Convert.ToInt32(Session["ClientId"]));
            DdlEntity.DataTextField = "ENTITY_NAME";
            DdlEntity.DataValueField = "ID";
            DdlEntity.DataBind();
        }


        private void BindGridViewResults()
        {

            OdsResults.EnablePaging = false;
            OdsResults.TypeName = "SouthStarTitleBLL.BLL.DocumentsBLL";
            OdsResults.SelectMethod = "GetDocumentsByUserId";
            OdsResults.SelectParameters.Add("entityId", ddlEntity.SelectedValue);
            OdsResults.SelectParameters.Add("userId", Session["ClientId"].ToString());
            FilesGridView.AllowPaging = false;
            FilesGridView.AllowSorting = false;
            FilesGridView.DataSourceID = OdsResults.ID;
            FilesGridView.DataSource = OdsResults;
            FilesGridView.DataBind();



        }

        protected void ddlEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResults.Text = "";
            BindGridViewResults();
        }

        private void Download(DataTable dt)
        {
            var bytes = (Byte[])dt.Rows[0]["UPLOADED_DOCUMENT"];

            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["FILENAME"]);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void OnRowCommand_Download(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "downloadCommand")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                DataKey dk = FilesGridView.DataKeys[index];
                int documentId = Convert.ToInt32(dk.Value);

                DataSet ds = BLLManager.DocumentsBLL.DowndloadDocumentById(documentId);
                DataTable dt = ds.Tables[0];
                Download(dt);

            }
        }









    }
}
