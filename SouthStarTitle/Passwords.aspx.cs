using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SouthStarTitleDAL.Model;
using SouthStarTitleBLL.BLL.Support;

namespace SouthStarTitle
{
    public partial class Passwords : Page
    {
        protected ObjectDataSource odsResults;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminValidate"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            { 
                BindGridViewResults();
                tblUserForm.Visible = false;
                tblUserGrid.Visible = true;
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

        private string SortExpression
        {
            get
            {
                object o = ViewState["SortExpression"];
                if (o == null)
                {
                    return string.Empty;
                }
                return o.ToString();
            }
            set
            {
                ViewState["SortExpression"] = value;
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

        public Int32 HasPassword
        {
            get
            {
                return (Int32)ViewState["HasPassword"];
            }

            set
            {
                ViewState["HasPassword"] = value;
            }
        }

        private void BindGridViewResults()
        {
            OdsResults.EnablePaging = true;
            OdsResults.MaximumRowsParameterName = "maximumRows";
            OdsResults.StartRowIndexParameterName = "startRowIndex";
            OdsResults.TypeName = "SouthStarTitleBLL.BLL.UserBLL";
            OdsResults.SelectMethod = "GetUsers";
            OdsResults.SelectParameters.Add("sortExpression", SortExpression);
            OdsResults.SelectCountMethod = "GetUsersCount";
            UsersGridView.DataSourceID = OdsResults.ID;
            UsersGridView.DataSource = OdsResults;
            UsersGridView.DataBind();
        }

        private void ClearFields()
        {
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtUserName.Text = "";
        }

        private void EditPasswordByUserId(int userId)
        {
            ClearFields();

            User user = BLLManager.UserBLL.EditUserById(userId);

            txtPassword.Text = user.Password;
            txtConfirmPassword.Text = user.Password;
            txtUserName.Text = user.Login;

            HasPassword = user.ActiveFlag;

            lblFullName.Text = "To add a password to " + 
                user.FirstName + " " + user.MiddleName + " " + user.LastName + 
                " please choose a username and a secured password below. Secured " +
                "password has six characters, one number and one special character(i.e. #,$,@)";
        }

        private void AddPasswordByUserId(int userId)
        {
            User user = new User();
            user.Login = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.UserId = userId;

            BLLManager.UserBLL.UpsertUserPassword(user);

            lblResults.Text = "Password was added to " +
                              user.FirstName + " " + user.MiddleName + " " + user.LastName;
        }

        protected void btnAddPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblPasswordCheck.Text = "Your password and confirmation password do not match.";
            }
            else
            {
                AddPasswordByUserId(UserId);
                BindGridViewResults();
                tblUserGrid.Visible = true;
                tblUserForm.Visible = false;
                UsersGridView.EditIndex = -1;
                UsersGridView.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BindGridViewResults();
            tblUserGrid.Visible = true;
            tblUserForm.Visible = false;
            UsersGridView.EditIndex = -1;
            UsersGridView.DataBind();
        }

        protected void UsersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (UsersGridView != null)
            {
                lblResults.Text = "";
                var userId = (int)UsersGridView.DataKeys[e.NewEditIndex].Value;
                UserId = userId;
                tblUserGrid.Visible = false;
                tblUserForm.Visible = true;
                EditPasswordByUserId(userId);
            }
        }

        protected void UsersGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            String sortParam = "[" + e.SortExpression + "]";
            SortExpression = sortParam;

            OdsResults.EnablePaging = true;
            OdsResults.MaximumRowsParameterName = "maximumRows";
            OdsResults.StartRowIndexParameterName = "startRowIndex";
            OdsResults.TypeName = "SouthStarTitleBLL.BLL.UserBLL";
            OdsResults.SelectMethod = "GetUsers";
            OdsResults.SelectParameters.Add("sortExpression", SortExpression);
            OdsResults.SelectCountMethod = "GetUsersCount";
            UsersGridView.DataSourceID = OdsResults.ID;
            UsersGridView.DataSource = OdsResults;
            UsersGridView.DataBind();
        }

        protected void UsersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            UsersGridView.PageIndex = e.NewPageIndex;
            BindGridViewResults();
        }
    }
}
