using System;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using SouthStarTitleBLL.BLL.Support;
using System.Collections;


namespace SouthStarTitle
{
    public partial class UploadFiles : Page
    {
        protected ObjectDataSource odsResults;
        private ListBox lbAvailablePeople;
        private ListBox lbSelectedPeople;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnClear;


        #region Page LifeCycle

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AdminValidate"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            if (!IsPostBack)
            {
                LoadEntities();
                BindGridViewResults();
                
            }
            this.InitializeComponents();

        }

        #endregion

        #region Controls

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

        private Button BTNAdd
        {
            get
            {
                if (this.btnAdd == null)
                {
                    this.btnAdd = new Button();
                    this.btnAdd.ID = "_BTNAdd";
                    this.btnAdd.Text = ">>";
                    this.btnAdd.Width = Unit.Pixel(50);
                    this.btnAdd.CssClass = "actionButton";
                    this.btnAdd.Enabled = false;
                    this.btnAdd.Click += new EventHandler(btnAdd_Click);
                }
                return this.btnAdd;
            }
        }

        private Button BTNRemove
        {
            get
            {
                if (this.btnRemove == null)
                {
                    this.btnRemove = new Button();
                    this.btnRemove.ID = "_BTNRemove";
                    this.btnRemove.Text = "<<";
                    this.btnRemove.Width = Unit.Pixel(50);
                    this.btnRemove.CssClass = "actionButton";
                    this.btnRemove.Enabled = false;
                    this.btnRemove.Click += new EventHandler(btnRemove_Click);
                }
                return this.btnRemove;
            }
        }

        private Button BTNClear
        {
            get
            {
                if (this.btnClear == null)
                {
                    this.btnClear = new Button();
                    this.btnClear.Text = "Clear";
                    this.btnClear.Width = Unit.Pixel(50);
                    this.btnClear.CssClass = "actionButton";
                    this.btnClear.Click += new EventHandler(btnClear_Click);
                }
                return this.btnClear;
            }
        }

        private ListBox LbAvailablePeople
        {
            get
            {
                if (this.lbAvailablePeople == null)
                {
                    this.lbAvailablePeople = new ListBox();
                    this.lbAvailablePeople.ID = "_LbAvailablePeople";
                    this.lbAvailablePeople.Rows = 4;
                    this.lbAvailablePeople.CssClass = "listbox";
                    this.lbAvailablePeople.SelectionMode = ListSelectionMode.Multiple;
                    this.lbAvailablePeople.Attributes.Add("OnChange", "CheckIfSelected(this, '" + this.BTNAdd.ID + "')");
                    this.lbAvailablePeople.DataSource = this.GetDataSourceForAvailablePeopleLists();
                    this.lbAvailablePeople.DataTextField = "NAME";
                    this.lbAvailablePeople.DataValueField = "ID";
                    this.lbAvailablePeople.DataBind();
                    this.lbAvailablePeople.Width = Unit.Pixel(337);
                    this.lbAvailablePeople.Height = Unit.Pixel(185);
                }
                return this.lbAvailablePeople;
            }
        }

        private ListBox LbSelectedPeople
        {
            get
            {
                if (this.lbSelectedPeople == null)
                {
                    this.lbSelectedPeople = new ListBox();
                    this.lbSelectedPeople.ID = "_LbSelectedPeople";
                    this.lbSelectedPeople.Rows = 4;
                    this.lbSelectedPeople.CssClass = "listbox";
                    this.lbSelectedPeople.SelectionMode = ListSelectionMode.Multiple;
                    this.lbSelectedPeople.Attributes.Add("OnChange", "CheckIfSelected(this, '" + this.BTNRemove.ID + "')");
                    this.lbSelectedPeople.Width = Unit.Pixel(337);
                    this.lbSelectedPeople.Height = Unit.Pixel(185);
                }
                return this.lbSelectedPeople;

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

        #endregion

        #region Method Helpers

        private void InitializeComponents()
        {
            this.pnlAvailablePeople.Controls.Add(this.LbAvailablePeople);
            this.pnlSelectedPeople.Controls.Add(this.LbSelectedPeople);
            this.pnlBtnAdd.Controls.Add(this.BTNAdd);
            this.pnlBtnRemove.Controls.Add(this.BTNRemove);
            this.pnlBtClear.Controls.Add(this.BTNClear);
            //this.pnlBtUpload.Controls.Add(this.BTNUpload);
           
        }

        private void LoadEntities()
        {
            DdlEntity.DataSource = BLLManager.EntityBLL.SelectAllEntities();
            DdlEntity.DataTextField = "entityName";
            DdlEntity.DataValueField = "Id";
            DdlEntity.DataBind();
        }

        private void DeleteDocumentById(int userId, int documentId)
        {
            BLLManager.DocumentsBLL.DeleteDocumentById(userId, documentId);
            lblResults.Text = "";
            BindGridViewResults();
        }

        private void LoadToDb()
        {

            //var con = new SqlConnection("Data Source=localhost; Initial Catalog=southstardb; User ID=southstardb; Password='Santiago1'");
            
            //var con = new SqlConnection("Data Source=southstardb.db.2225184.hostedresource.com; Initial Catalog=southstardb; User ID=southstardb; Password='Santiago1'");
            //var da = new SqlDataAdapter("Select * From Documents", con);
            //var cb = new SqlCommandBuilder(da);


            //var ds = new DataSet();

            //da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            int documentId = 0;

            if (FileUpload1 != null)
            {
                var fs = FileUpload1.FileContent;


                var myData = new byte[fs.Length + 1];
                fs.Read(myData, 0, (int)fs.Length);
                fs.Close();
                //con.Open();

                //da.Fill(ds, "DOCUMENTS");


                //var myRow = ds.Tables["DOCUMENTS"].NewRow();


                //myRow["ENTITY_ID"] = ddlEntity.SelectedValue;
                //myRow["UPLOADED_DOCUMENT"] = myData;

                var fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                //myRow["FILENAME"] = fileName;
                //myRow["ACTIVE_FLAG"] = 1;
                //myRow["CREATED_TIMESTAMP"] = DateTime.Now;
                //myRow["UPDATED_TIMESTAMP"] = DateTime.Now;
                //ds.Tables["DOCUMENTS"].Rows.Add(myRow);


                documentId = BLLManager.DocumentsBLL.InsertDocument(Convert.ToInt32(ddlEntity.SelectedValue), myData, fileName);

            }
            //da.UpdateCommand = cb.GetUpdateCommand();
            //da.Update(ds, "DOCUMENTS");

            //con.Close();



            IList userIdList = new ArrayList();
            foreach (ListItem item in LbSelectedPeople.Items)
            {
                BLLManager.DocumentsBLL.InsertDocumentToUsers(Convert.ToInt32(item.Value), documentId);
            }

        }

        private void BindGridViewResults()
        {

            OdsResults.EnablePaging = false;
            OdsResults.TypeName = "SouthStarTitleBLL.BLL.DocumentsBLL";
            OdsResults.SelectMethod = "GetDocuments";
            OdsResults.SelectParameters.Add("entityId", ddlEntity.SelectedValue);
            FilesGridView.AllowPaging = false;
            FilesGridView.AllowSorting = false;
            FilesGridView.DataSourceID = OdsResults.ID;
            FilesGridView.DataSource = OdsResults;
            FilesGridView.DataBind();



        }

        #endregion

        #region Listbox Method Helpers

        private DataSet GetDataSourceForAvailablePeopleLists()
        {


            DataSet bindingList = new DataSet();
            bindingList = this.BindAvailablePeopleList();
            ViewState["LookupListData"] = bindingList;

            return (DataSet)ViewState["LookupListData"];
        }

        private DataSet BindAvailablePeopleList()
        {
            return BLLManager.RelUserEntityBLL.GetPeopleFromEntities(Convert.ToInt32(ddlEntity.SelectedValue));
        }

        private void CheckShowSelectedPeopleFull()
        {
            if (this.LbSelectedPeople.Items.Count == 0)
            {

                this.BTNRemove.Enabled = false;
                btnUpload.Enabled = false;
         
            }
            else
            {
                this.BTNRemove.Enabled = true;
                btnUpload.Enabled = true;
            }

        }

        private void CheckIfAvailablePeopleSelected()
        {
            foreach (ListItem item in this.LbAvailablePeople.Items)
            {
                if (item.Selected == true)
                {
                    this.BTNAdd.Enabled = true;
                    return;
                }
                else
                {
                    this.BTNAdd.Enabled = false;
                }
            }
        }

        private void CheckIfListSelectedPeopleSelected()
        {
            foreach (ListItem item in this.LbSelectedPeople.Items)
            {
                if (item.Selected == true)
                {
                    this.BTNRemove.Enabled = true;
                    return;
                }
                else
                {
                    this.BTNRemove.Enabled = false;
                }
            }
        }

        private void ClearSelectedPeopleList()
        {
            for (int i = 0; i < this.lbSelectedPeople.Items.Count; i++)
            {

                this.lbAvailablePeople.Items.Add(this.lbSelectedPeople.Items[i]);
                this.lbSelectedPeople.Items.Remove(this.lbSelectedPeople.Items[i]);
                i--;

            }

            this.lbAvailablePeople.ClearSelection();
            this.CheckShowSelectedPeopleFull();
            this.lbAvailablePeople.DataBind();
            this.CheckIfAvailablePeopleSelected();
            this.CheckIfListSelectedPeopleSelected();
        }

        private void GetAvailablePeopleList()
        {
            this.lbAvailablePeople.DataSource = this.GetDataSourceForAvailablePeopleLists();
            this.lbAvailablePeople.DataBind();

            this.CheckShowSelectedPeopleFull();
            this.CheckIfAvailablePeopleSelected();
            this.CheckIfListSelectedPeopleSelected();
        }

        #endregion

        #region Events

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.lbAvailablePeople.SelectedIndex > -1)
            {
                for (int i = 0; i < this.lbAvailablePeople.Items.Count; i++)
                {
                    if (this.lbAvailablePeople.Items[i].Selected)
                    {
                        this.lbSelectedPeople.Items.Add(this.lbAvailablePeople.Items[i]);
                        string itemSelected = this.lbAvailablePeople.Items[i].Text;
                        this.lbAvailablePeople.Items.Remove(this.lbAvailablePeople.Items[i]);
                        i--;
                        if (this.lbSelectedPeople.Items.Contains(this.lbSelectedPeople.Items.FindByText(itemSelected)))
                        {
                            this.lbSelectedPeople.ClearSelection();
                            this.lbSelectedPeople.Items.FindByText(itemSelected).Selected = true;
                        }
                    }
                }
                this.CheckShowSelectedPeopleFull();
                this.CheckIfAvailablePeopleSelected();
                this.CheckIfListSelectedPeopleSelected();
            }

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lbSelectedPeople.SelectedIndex > -1)
            {
                for (int i = 0; i < this.lbSelectedPeople.Items.Count; i++)
                {
                    if (this.lbSelectedPeople.Items[i].Selected)
                    {
                        this.lbAvailablePeople.Items.Add(this.lbSelectedPeople.Items[i]);
                        this.lbSelectedPeople.Items.Remove(this.lbSelectedPeople.Items[i]);
                        i--;
                    }
                }
                this.lbSelectedPeople.ClearSelection();
                this.lbAvailablePeople.ClearSelection();
                this.CheckShowSelectedPeopleFull();
                //this.lbAvailablePeople.DataBind();
                this.CheckIfAvailablePeopleSelected();
                this.CheckIfListSelectedPeopleSelected();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearSelectedPeopleList();
        }

        protected void ddlEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResults.Text = "";
            BindGridViewResults();

            for (int i = 0; i < this.lbSelectedPeople.Items.Count; i++)
            {
                this.lbSelectedPeople.Items.Remove(this.lbSelectedPeople.Items[i]);
                i--;

            }

            this.GetAvailablePeopleList();
        }

        protected void FilesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (FilesGridView != null)
            {
                var userId = (int)FilesGridView.DataKeys[e.RowIndex].Values["USER_ID"];
                var documentId = (int)FilesGridView.DataKeys[e.RowIndex].Values["DOC_ID"];
                
                DeleteDocumentById(userId, documentId);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var fileOk = false;
            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();

                string[] allowedExtensions = {
                                                 ".pdf"
                                             };

                for (int i = 0; i <= allowedExtensions.Length - 1; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOk = true;
                    }
                }

                if (fileOk)
                {
                    try
                    {
                        //****************
                        //Load to database or file upload to upload folder
                        //Both will not work at the same time
                        //****************
                        LoadToDb();

                        lblResults.Text = "File uploaded!";
                        BindGridViewResults();
                    }
                    catch (Exception ex)
                    {
                        lblResults.Text = ex.Message + ex.InnerException;
                    }
                }
                else
                {
                    lblResults.Text = "Cannot accept files of this type.";
                }
            }

        }

        #endregion


    }
}
