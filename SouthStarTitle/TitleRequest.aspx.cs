using System;
using System.Web.UI;
using System.Net.Mail;

namespace SouthStarTitle
{
    public partial class TitleRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MaskTextBoxes();
                CheckBoxPropertyAddressValidation();
            }
        }

        private void MaskTextBoxes()
        {
            txtContactTelephone.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtContactTelephone.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtContactFax.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtContactFax.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtHomeTelephone.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtHomeTelephone.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtWorkTelephone.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtWorkTelephone.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtSellerHomeTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtSellerHomeTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");

            txtSellerWorkTel.Attributes.Add("onkeydown", "javascript:backspacerDOWN(this,event);");
            txtSellerWorkTel.Attributes.Add("onkeyup", "javascript:backspacerUP(this,event);");


        }


        protected void CheckBoxPropertyAddressValidation()
        {
            chkAddressSameAsBuyer.Attributes.Add("onclick", "chkPropertyValidation(this)");

        }


        protected void btnGoBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


        private string PropertyAddressCheck()
        {
            string addressCheck;

            if (chkAddressSameAsBuyer.Checked)
            {
                addressCheck = "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Address:</td>" +
                            "<td>" +
                            txtBorrowerAddress.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "City:</td>" +
                            "<td>" +
                            txtBorrowerCIty.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "State:</td>" +
                            "<td>" +
                            ddlBorrowerState.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Zip:</td>" +
                            "<td>" +
                            txtBorrowerZip.Text +
                            "</td>" +
                            "</tr>";
            }
            else
            {

                addressCheck = "<tr>" +
                           "<td style='font-weight:bold; width: 130px;'>" +
                           "Property Address:</td>" +
                           "<td>" +
                           txtPropertyAddress.Text +
                           "</td>" +
                           "</tr>" +

                           "<tr>" +
                           "<td style='font-weight:bold; width: 130px;'>" +
                           "City:</td>" +
                           "<td>" +
                           txtPropertyCity.Text +
                           "</td>" +
                           "</tr>" +

                           "<tr>" +
                           "<td style='font-weight:bold; width: 130px;'>" +
                           "State:</td>" +
                           "<td>" +
                           ddlPropertyState.SelectedValue +
                           "</td>" +
                           "</tr>" +

                           "<tr>" +
                           "<td style='font-weight:bold; width: 130px;'>" +
                           "Zip:</td>" +
                           "<td>" +
                           txtPropertyZip.Text +
                           "</td>" +
                           "</tr>";
            }

            return addressCheck;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //create the mail message
                var message = new MailMessage();
                var mail = message;

                //set the addresses
                mail.From = new MailAddress("info@southstartitle.com");
                mail.To.Add("docs@southstartitle.com");
                //mail.To.Add("ayecona@hotmail.com");
                mail.IsBodyHtml = true;

                //set the content
                mail.Subject = "New Title Order request from ";
                mail.Body = "<table style='width: 400px;'  border='0' cellpadding='0' cellspacing='0'>" +
                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px; color: Red;'>" +
                            "Contact Information:</td>" +
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
                            "Ordered By:</td>" +
                            "<td>" +
                            ddlOrderedBy.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Company Name:</td>" +
                            "<td>" +
                            txtCompanyName.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Company Address:</td>" +
                            "<td>" +
                            txtCompanyAddress.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Company City:</td>" +
                            "<td>" +
                            txtCompanyCity.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Company State:</td>" +
                            "<td>" +
                            ddlCompanyState.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Company Zip:</td>" +
                            "<td>" +
                            txtCompanyZip.Text +
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
                            "Contact Telephone:</td>" +
                            "<td>" +
                            txtContactTelephone.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Company Fax:</td>" +
                            "<td>" +
                            txtContactFax.Text +
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
                            "<td style='font-weight:bold; width: 450px; color: Red;'>" +
                            "Loan Officer & Processor Information:</td>" +
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
                            "Loan Officer:</td>" +
                            "<td>" +
                            txtLoanOfficer.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Loan Processor:</td>" +
                            "<td>" +
                            txtLoanProcessor.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Transaction Type:</td>" +
                            "<td>" +
                            ddlTransactionType.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Loan Amount:</td>" +
                            "<td>" +
                            txtLoanAmount.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Purchase Amount:</td>" +
                            "<td>" +
                            txtPurchaseAmount.Text +
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
                            "<td style='font-weight:bold; width: 450px; color: Red;'>" +
                            "Borrower/Buyer Information:</td>" +
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
                            "Borrower:</td>" +
                            "<td>" +
                            txtBorrower.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Borrower SSN#:</td>" +
                            "<td>" +
                            txtBuyerSSN.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Home Telephone:</td>" +
                            "<td>" +
                            txtHomeTelephone.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Work Telephone:</td>" +
                            "<td>" +
                            txtWorkTelephone.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Address:</td>" +
                            "<td>" +
                            txtBorrowerAddress.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "City:</td>" +
                            "<td>" +
                            txtBorrowerCIty.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "State:</td>" +
                            "<td>" +
                            ddlBorrowerState.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Zip:</td>" +
                            "<td>" +
                            txtBorrowerZip.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Co-Borrower:</td>" +
                            "<td>" +
                            txtCoBorrower.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "SSN#:</td>" +
                            "<td>" +
                            txtCoBorrowerSSN.Text +
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
                            "<td style='font-weight:bold; width: 450px; color: Red;'>" +
                            "Seller Information:</td>" +
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
                            "Seller:</td>" +
                            "<td>" +
                            txtSeller.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "SSN#:</td>" +
                            "<td>" +
                            txtSellerSSN.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Home Telephone:</td>" +
                            "<td>" +
                            txtSellerHomeTel.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Work Telephone:</td>" +
                            "<td>" +
                            txtSellerWorkTel.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Address:</td>" +
                            "<td>" +
                            txtSellerAddress.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "City:</td>" +
                            "<td>" +
                            txtSellerCity.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "State:</td>" +
                            "<td>" +
                            ddlSellerState.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Zip:</td>" +
                            "<td>" +
                            txtSellerZip.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Co-Seller:</td>" +
                            "<td>" +
                            txtCoSeller.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "SSN#:</td>" +
                            "<td>" +
                            txtCoSellerSSN.Text +
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
                            "<td style='font-weight:bold; width: 450px; color: Red;'>" +
                            "Property Information:</td>" +
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


                            PropertyAddressCheck() +


                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Who Orders Payoff:</td>" +
                            "<td>" +
                            ddlWhoOrdersPayoff.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "How Many Payoffs:</td>" +
                            "<td>" +
                            ddlHowManyPayoffs.SelectedValue +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Name of Bank Being Paid Off:</td>" +
                            "<td>" +
                            txtBankName.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Account Number:</td>" +
                            "<td>" +
                            txtAccountNumber.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Sale Price (if purchased):</td>" +
                            "<td>" +
                            txtSalePrice.Text +
                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='font-weight:bold; width: 130px;'>" +
                            "Loan Amount:</td>" +
                            "<td>" +
                            txtPropertyLoanAmount.Text +
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
                            "<td style='font-weight:bold; width: 450px; color: Red;'>" +
                            "Special Instructions:</td>" +
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
                            "Instructions:</td>" +
                            "<td>" +
                            txtSpecialInstructions.Text +
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
                            "<td style='font-weight:bold; width: 450px; color: Red;'>" +
                            "Payoff Information:</td>" +
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
                            "Information:</td>" +
                            "<td>" +
                            txtPayoffInformation.Text +
                            "</td>" +
                            "</tr>" +

                            "</table>";

                //send the message
                var smtp = new SmtpClient("relay-hosting.secureserver.net");
                smtp.Send(mail);

                //create a status message
                lblOrderStatus.Text = "Email Sent, Someone will be contacting you promptly";
                orderstatus.Visible = true;
                order.Visible = false;
            }
            catch (Exception ex)
            {
                lblOrderStatus.Text = "";
                lblOrderStatus.Text = ex.Message;
                orderstatus.Visible = true;
                order.Visible = false;
            }
        }

    }
}
