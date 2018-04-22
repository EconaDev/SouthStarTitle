using System;
using System.Net.Mail;
using System.Web.UI;

namespace SouthStarTitle
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MaskTextBoxes();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //create the mail message
                var message = new MailMessage();
                var mail = message;

                //set the addresses
                mail.From = new MailAddress("info@southstartitle.com");
                mail.To.Add("contact@southstarmtg.com");
                //mail.To.Add("ayecona@hotmail.com");
                mail.IsBodyHtml = true;
                

                //set the content
                mail.Subject = "New contact request from " + txtFirstName.Text + " " + txtLastName.Text;
                mail.Body = "<table style='width: 400px;'  border='0' cellpadding='0' cellspacing='0'>" +
                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Contact From:</td>" +
                            "<td>" +
                            "&nbsp;" +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "&nbsp;</td>" +
                            "<td>" +
                            "&nbsp;" +
                            "</td>" +
                            "</tr>" +


                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "First Name:</td>" +
                            "<td>" +
                            txtFirstName.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Last Name:</td>" +
                            "<td>" +
                            txtLastName.Text +
                            "</td>" +
                            "</tr>" +


                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Email:</td>" +
                            "<td>" +
                            txtEmail.Text +
                            "</td>" +
                            "</tr>" +


                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Street Address:</td>" +
                            "<td>" +
                            txtStreetAddress.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "State:</td>" +
                            "<td>" +
                            txtCity.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "State:</td>" +
                            "<td>" +
                            ddlState.SelectedValue +
                            "</td>" +
                            "</tr>" +


                           "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Primary Phone:</td>" +
                            "<td>" +
                            txtPrimaryPhone.Text +
                            "</td>" +
                            "</tr>" +


                           "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Secondary Phone:</td>" +
                            "<td>" +
                            txtSecondaryPhone.Text +
                            "</td>" +
                            "</tr>" +


                           "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Best Time To Call:</td>" +
                            "<td>" +
                            ddlBestTime.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "&nbsp;</td>" +
                            "<td>" +
                            "&nbsp;" +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Comments:</td>" +
                            "<td>" +
                            txtComments.Text +
                            "</td>" +
                            "</tr>" +


                            "</table>";


                //send the message
                var smtp = new SmtpClient("relay-hosting.secureserver.net");
                smtp.Send(mail);

                //create a status message
                lblContactStatus.Text = "Email Sent, Someone will be contacting you promptly";
                contactstatus.Visible = true;
                contactintro.Visible = false;
                container.Visible = false;
            }
            catch (Exception ex)
            {
                lblContactStatus.Text = "";
                lblContactStatus.Text = ex.Message;
                contactstatus.Visible = true;
                contactintro.Visible = false;
                container.Visible = false;
            }
        }

        protected void btnGoBackToContact_Click(object sender, EventArgs e)
        {
            lblContactStatus.Text = "";
            contactstatus.Visible = false;
            contactintro.Visible = true;
            container.Visible = true;
            btnGoBackToContact.Visible = false;
            btnGoBackToHome.Visible = false;
            ResetFields();
        }

        protected void btnGoBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


        private void MaskTextBoxes()
        {
            txtPrimaryPhone.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);"); 
            txtPrimaryPhone.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtSecondaryPhone.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtSecondaryPhone.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);"); 
        }

        private void ResetFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtStreetAddress.Text = "";
            txtCity.Text = "";
            ddlState.SelectedValue = "Select...";
            txtPrimaryPhone.Text = "";
            txtSecondaryPhone.Text = "";
            ddlBestTime.SelectedValue = "Select...";
            txtComments.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

    }
}
