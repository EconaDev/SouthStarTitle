using System;
using System.Web.UI;
using SouthStarTitleDAL.Model;
using SouthStarTitleBLL.BLL.Support;
using System.Web.UI.WebControls;
using System.Data;

namespace SouthStarTitle
{
    public partial class Entities : Page
    {
        protected ObjectDataSource odsResults;


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AdminValidate"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            if (!IsPostBack)
            {
                MaskTextBoxes();
                LoadStates();
                BindGridViewResults();
                tblEntityForm.Visible = false;
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

        private DropDownList DdlEntityState
        {
            get
            {
                if (ddlEntityState == null)
                {
                    ddlEntityState = new DropDownList();
                }
                return ddlEntityState;
            }
        }

        public Int32 EntityId
        {
            get
            {
                return (Int32)ViewState["EntityId"];
            }

            set
            {
                ViewState["EntityId"] = value;
            }
        }

        public Int32 EntityAddressId
        {
            get
            {
                return (Int32)ViewState["EntityAddressId"];
            }

            set
            {
                ViewState["EntityAddressId"] = value;
            }
        }

        private void MaskTextBoxes()
        {
            txtEntityWorkTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtEntityWorkTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtEntityFax.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtEntityFax.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtEntityOtherTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtEntityOtherTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");
        }

        private void BindGridViewResults()
        {

            OdsResults.EnablePaging = false;
            OdsResults.TypeName = "SouthStarTitleBLL.BLL.EntityBLL";
            OdsResults.SelectMethod = "GetEntities";
            EntitiesGridView.AllowPaging = false;
            EntitiesGridView.AllowSorting = false;
            EntitiesGridView.DataSourceID = OdsResults.ID;
            EntitiesGridView.DataSource = OdsResults;
            EntitiesGridView.DataBind();
        }

        private void UpsertAddress(string val)
        {

                var entityAddress = new Address();

                entityAddress.StreetAddress1 = txtEntityAddress.Text;
                entityAddress.StreetAddress2 = txtEntityAddressCont.Text;
                entityAddress.City = txtEntityCity.Text;
                entityAddress.StateId = Convert.ToInt32(DdlEntityState.SelectedValue);
                entityAddress.Zip = txtEntityZip.Text;
                entityAddress.WorkPhone = txtEntityWorkTel.Text;
                entityAddress.FaxPhone = txtEntityFax.Text;
                entityAddress.OtherPhone = txtEntityOtherTel.Text;

            if (val == "I")
            {
                var addressId = BLLManager.AddressBLL.UpsertEntityAddress(entityAddress, val, 0);
                UpsertEntity(addressId, val);
            }
            else
            {
                BLLManager.AddressBLL.UpsertEntityAddress(entityAddress, val, EntityAddressId);
                UpsertEntity(EntityAddressId, val);
            }

        }

        private void UpsertEntity(int addressId, string val)
        {
            var entity = new Entity();
            entity.EntityName = txtEntity.Text;
            entity.EntityAddressId = addressId;

            if (val == "I")
            {
                BLLManager.EntityBLL.UpsertEntity(entity, val, 0);
            }
            else
            {
                BLLManager.EntityBLL.UpsertEntity(entity, val, EntityId);   
            }
            

        }

        private void LoadStates()
        {
            DdlEntityState.DataSource = BLLManager.LuStateBLL.SelectAllStates();
            DdlEntityState.Width = Unit.Pixel(100);
            DdlEntityState.DataTextField = "stateName";
            DdlEntityState.DataValueField = "Id";   
            DdlEntityState.DataBind();
            DdlEntityState.Items.Insert(0, new ListItem("Select State", "0"));
        }

        private void ClearFields()
        {
            txtEntity.Text = "";
            txtEntityAddress.Text = "";
            txtEntityAddressCont.Text = "";
            txtEntityCity.Text = "";
            DdlEntityState.SelectedValue = "0";
            txtEntityZip.Text = "";
            txtEntityWorkTel.Text = "";
            txtEntityFax.Text = "";
            txtEntityOtherTel.Text = "";
        }

        private void DeleteEntityById(int entityId)
        {
            BLLManager.EntityBLL.DeleteEntityById(entityId);

            BindGridViewResults();
        }

        private void EditEntityById(int entityId)
        {
            ClearFields();

            Entity entity = BLLManager.EntityBLL.EditEntityById(entityId);
            EntityAddressId = entity.EntityAddressId;

            txtEntity.Text = entity.EntityName;
            txtEntityAddress.Text = entity.Address.StreetAddress1;
            txtEntityAddressCont.Text = entity.Address.StreetAddress2;
            txtEntityCity.Text = entity.Address.City;
            DdlEntityState.SelectedValue = Convert.ToString(entity.Address.LuState.Id);
            txtEntityZip.Text = entity.Address.Zip;
            txtEntityWorkTel.Text = entity.Address.WorkPhone;
            txtEntityFax.Text = entity.Address.FaxPhone;
            txtEntityOtherTel.Text = entity.Address.OtherPhone;


        }

        protected void EntitiesGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                if (((DataRowView)(e.Row.DataItem)).Row.ItemArray[1].ToString() == "SouthStar Title & Escrow, LLC")
                {
                    e.Row.Cells[0].Controls.Clear();

                }
            }

        } 

        protected void EntitiesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (EntitiesGridView != null)
            {
                var entityId = (int)EntitiesGridView.DataKeys[e.RowIndex].Value;
                DeleteEntityById(entityId);
            }
        }

        protected void EntitiesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (EntitiesGridView != null)
            {
                var entityId = (int)EntitiesGridView.DataKeys[e.NewEditIndex].Value;
                EntityId = entityId;
                tblEntityGrid.Visible = false;
                tblEntityForm.Visible = true;
                btnAddEntity.Enabled = false;
                btnEditEntity.Visible = true;
                btnSubmitEntity.Visible = false;
                EditEntityById(entityId);
            }
        }

        protected void btnAddEntity_Click(object sender, EventArgs e)
        {
            ClearFields();
            tblEntityGrid.Visible = false;
            tblEntityForm.Visible = true;
            btnAddEntity.Enabled = false;
            btnEditEntity.Visible = false;
            btnSubmitEntity.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tblEntityForm.Visible = false;
            tblEntityGrid.Visible = true;
            btnAddEntity.Enabled = true;
            BindGridViewResults();
            EntitiesGridView.EditIndex = -1;
            EntitiesGridView.DataBind();
        }

        protected void btnSubmitEntity_Click(object sender, EventArgs e)
        {
            const string val = "I";
            
            UpsertAddress(val); 
            ClearFields();
            BindGridViewResults();
            tblEntityForm.Visible = false;
            tblEntityGrid.Visible = true;
            btnAddEntity.Enabled = true;
        }

        protected void btnEditEntity_Click(object sender, EventArgs e)
        {
            const string val = "E";
            UpsertAddress(val);
            ClearFields();
            BindGridViewResults();
            tblEntityGrid.Visible = true;
            tblEntityForm.Visible = false;
            btnAddEntity.Enabled = true;
            EntitiesGridView.EditIndex = -1;
            EntitiesGridView.DataBind();
        }
    }
}
