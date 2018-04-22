using System;
using System.Web.UI.WebControls;

namespace SouthStarTitle.Controls
{
    public partial class ClientMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Text == "Log Out")
            {
                Session.Remove("ClientValidate");
                Session.Remove("ClientId");
                Response.Redirect("Login.aspx");
            }
        }
    }
}