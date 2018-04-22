using System;
using System.Data;
using System.Web.UI;
using SouthStarTitleBLL.BLL;

namespace SouthStarTitle
{
    public enum PermissionTypes
    {
        Admin = 1,
        Client = 2
    }

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultButton = btnLoginButton.UniqueID;
        }

        public bool ValidatePermission(string permissionList, PermissionTypes desiredPermission)
        {
            string delimStr = ",";
            char[] delimiter = delimStr.ToCharArray();

            try
            {

                if (permissionList.Length < 1) { return false; }

                string[] permissions = permissionList.Split(delimiter, 100);

                int permission = (int)desiredPermission;

                for (int i = 0; i < permissions.Length; i++)
                {
                    if (permission.ToString() == permissions[i])
                    {
                        return true;
                    }
                }

            }
            catch (Exception)
            { }
            return false;
        }

        public void DbAuthenticate(string strUsername, string strPassword)
        {
            DataSet dsUser = UserBLL.GetUsersPermissions(strUsername, strPassword);

            if (!dsUser.Tables[0].Rows.Count.Equals(0))
            {
                string password = dsUser.Tables[0].Rows[0].ItemArray[4].ToString();

                if (password.Equals(strPassword, StringComparison.Ordinal))
                {
                    string permissionList = dsUser.Tables[0].Rows[0].ItemArray[3].ToString();
                    int userId = Convert.ToInt32(dsUser.Tables[0].Rows[0].ItemArray[0]);



                    if (ValidatePermission(permissionList, PermissionTypes.Admin))
                    {
                        Session.Remove("ClientId");
                        Session.Remove("ClientValidate");
                        Session["AdminValidate"] = "Admin";
                        Response.Redirect("Admin.aspx");
                    }
                    else if (ValidatePermission(permissionList, PermissionTypes.Client))
                    {
                        Session.Remove("AdminValidate");
                        Session["ClientId"] = userId;
                        Session["ClientValidate"] = "Client";
                        Response.Redirect("Client.aspx");
                    }
                    else
                    {
                        lblLoginError.Text = "No Permisions";
                    }
                }
                else
                {
                    lblLoginError.Text = "Incorrect Password";  
                }
                
            }
            else
            {
                lblLoginError.Text = "Incorret User Login or Password";
            }
        }

        protected void btnLoginButton_Click(object sender, EventArgs e)
        {
            DbAuthenticate(txtUserName.Text, txtPassword.Text);
            
        }



    }
}
