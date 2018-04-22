using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SouthStarTitleDAL.Model;
using SouthStarTitleBLL.BLL.Support;

namespace SouthStarTitle
{
    public partial class Members : Page
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
                LoadEntities();
                LoadUserType();
                MaskTextBoxes();
                BindGridViewResults();
                tblUserForm.Visible = false;
               
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


        public Int32 UserId
        {
            get
            {
                return (Int32)ViewState["UserId"];
            }

            set
            {
                ViewState["UserId"] = value;
            }
        }

        public Int32 UserAddressId
        {
            get
            {
                return (Int32)ViewState["UserAddressId"];
            }

            set
            {
                ViewState["UserAddressId"] = value;
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

        private DropDownList DdlUserType
        {
            get
            {
                if (ddlUserType == null)
                {
                    ddlUserType = new DropDownList();
                }
                return ddlUserType;
            }
        }

        private void BindGridViewResults()
        {

            OdsResults.EnablePaging = false;
            OdsResults.TypeName = "SouthStarTitleBLL.BLL.RelUserEntityBLL";
            OdsResults.SelectMethod = "GetUsersFromEntities";
            OdsResults.SelectParameters.Add("entityId", ddlEntity.SelectedValue);
            UsersGridView.AllowPaging = false;
            UsersGridView.AllowSorting = false;
            UsersGridView.DataSourceID = OdsResults.ID;
            UsersGridView.DataSource = OdsResults;
            UsersGridView.DataBind();
        }

        private void MaskTextBoxes()
        {
            txtCellTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtCellTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtWorkTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtWorkTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtHomeTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtHomeTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtOtherTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtOtherTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");
        }

        private void LoadEntities()
        {
            DdlEntity.DataSource = BLLManager.EntityBLL.SelectAllEntities();
            DdlEntity.DataTextField = "entityName";
            DdlEntity.DataValueField = "Id";
            DdlEntity.DataBind();
        }

        private void LoadUserType()
        {
            DdlUserType.DataSource = BLLManager.LuUserTypeBLL.GetUserType();
            DdlUserType.DataTextField = "userType";
            DdlUserType.DataValueField = "Id";
            DdlUserType.SelectedValue = "2";
            DdlUserType.DataBind();
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtWorkTel.Text = "";
            txtCellTel.Text = "";
            txtHomeTel.Text = "";
            txtOtherTel.Text = "";
        }

        private void DeleteUserById(int userId, int entityId)
        {
            BLLManager.UserBLL.DeleteUserById(userId, entityId);
            BindGridViewResults();
        }

        private void EditUserById(int userId)
        {
            ClearFields();

            User user = BLLManager.UserBLL.EditUserById(userId);
            UserAddressId = user.UserAddressId;

            DdlUserType.SelectedValue = Convert.ToString(user.UserTypeId);
            txtFirstName.Text = user.FirstName;
            txtMiddleName.Text = user.MiddleName;
            txtLastName.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtWorkTel.Text = user.Address.WorkPhone;
            txtHomeTel.Text = user.Address.HomePhone;
            txtCellTel.Text = user.Address.CellPhone;
            txtOtherTel.Text = user.Address.OtherPhone;

        }

      

        private void UpsertAddress(string val)
        {

            var userAddress = new Address();

            userAddress.WorkPhone = txtWorkTel.Text;
            userAddress.HomePhone = txtHomeTel.Text;
            userAddress.CellPhone = txtCellTel.Text;
            userAddress.OtherPhone = txtOtherTel.Text;

            if (val == "I")
            {
                var addressId = BLLManager.AddressBLL.UpsertUserAddress(userAddress, val, 0);
                UpsertUser(addressId, val);
            }
            else
            {
                BLLManager.AddressBLL.UpsertUserAddress(userAddress, val, UserAddressId);
                UpsertUser(UserAddressId, val);
            }

        }

        private void UpsertUser(int addressId, string val)
        {
            var user = new User();
            user.FirstName = txtFirstName.Text;
            user.MiddleName = txtMiddleName.Text;
            user.LastName = txtLastName.Text;
            user.UserAddressId = addressId;
            user.Email = txtEmail.Text;
            user.UserTypeId = Convert.ToInt32(DdlUserType.SelectedValue);

            if (val == "I")
            {
                BLLManager.UserBLL.UpsertUser(user, val, 0, Convert.ToInt32(ddlEntity.SelectedValue));
            }
            else
            {
                BLLManager.UserBLL.UpsertUser(user, val, UserId, Convert.ToInt32(ddlEntity.SelectedValue));
            }
        }


        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            ClearFields();
            tblUserGrid.Visible = false;
            tblUserForm.Visible = true;
            btnAddUser.Enabled = false;
            btnEditUser.Visible = false;
            btnSubmitUser.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tblUserForm.Visible = false;
            tblUserGrid.Visible = true;
            btnAddUser.Enabled = true;
            UsersGridView.EditIndex = -1;
            UsersGridView.DataBind();
            BindGridViewResults();
        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {
            const string val = "I";

            UpsertAddress(val);
            ClearFields();
            BindGridViewResults();
            tblUserForm.Visible = false;
            tblUserGrid.Visible = true;
            btnAddUser.Enabled = true;
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            const string val = "E";
            UpsertAddress(val);
            ClearFields();
            BindGridViewResults();
            tblUserGrid.Visible = true;
            tblUserForm.Visible = false;
            btnAddUser.Enabled = true;
            UsersGridView.EditIndex = -1;
            UsersGridView.DataBind();
        }


        protected void UserGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (UsersGridView != null)
            {
                var userId = (int)UsersGridView.DataKeys[e.RowIndex].Value;
                var entityId = Convert.ToInt32(DdlEntity.SelectedValue);
                DeleteUserById(userId, entityId);
            }
        }

        protected void UserGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (UsersGridView != null)
            {
                var userId = (int)UsersGridView.DataKeys[e.NewEditIndex].Value;
                UserId = userId;
                tblUserGrid.Visible = false;
                tblUserForm.Visible = true;
                btnAddUser.Enabled = false;
                btnEditUser.Visible = true;
                btnSubmitUser.Visible = false;
                EditUserById(userId);
            }
        }

        protected void ddlEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResults.Text = "";
            BindGridViewResults();
        }

    }
}
