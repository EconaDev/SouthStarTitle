using System;
using System.Web.UI;

namespace SouthStarTitle
{
    public partial class Client : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ClientValidate"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
