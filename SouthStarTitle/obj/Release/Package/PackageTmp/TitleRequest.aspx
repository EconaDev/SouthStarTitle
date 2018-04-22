<%@ Page Title="Order Title Now" Language="C#" MasterPageFile="~/Extended.Master"
    AutoEventWireup="true" CodeBehind="TitleRequest.aspx.cs" Inherits="SouthStarTitle.TitleRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <script type="text/javascript">

        function MM_reloadPage(init) {
            if (init == true) with (navigator) {
                if ((appName == "Netscape") && (parseInt(appVersion) == 4)) {
                    document.MM_pgW = innerWidth; document.MM_pgH = innerHeight; onresize = MM_reloadPage;
                }
            }
            else if (innerWidth != document.MM_pgW || innerHeight != document.MM_pgH) location.reload();
        }
        MM_reloadPage(true);

    </script>
                    <div class="contact-sub">
                    Order title
                </div>
                <br />
    <div id="order" runat="server">
    <table border="0" align="center" cellpadding="2" cellspacing="10">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td height="30" colspan="2" valign="top">
                <asp:Label ID="lblContactInfo" CssClass="contactTitlelabel" runat="server" Text="Please provide us your
                    Contact Information:"></asp:Label>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblOrderedBy" CssClass="titleOrderlabel" runat="server" Text="Ordered By: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:DropDownList ID="ddlOrderedBy" CssClass="dropdown" runat="server">
                    <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                    <asp:ListItem Text="Mortgage Broker" Value="Mortgage Broker" />
                    <asp:ListItem Text="Listing Agent" Value="Listing Agent" />
                    <asp:ListItem Text="Selling Agent" Value="Selling Agent" />
                    <asp:ListItem Text="FSBO" Value="FSBO" />
                    <asp:ListItem Text="Buyer" Value="Buyer" />
                    <asp:ListItem Text="Escrow Agent" Value="Escrow Agent" />
                    <asp:ListItem Text="FSBO" Value="FSBO" />
                    <asp:ListItem Text="Other" Value="Other" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblCompanyName" CssClass="titleOrderlabel" runat="server" Text="Company Name: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyName" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblCompanyAddress" CssClass="titleOrderlabel" runat="server" Text="Company Address: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyAddress" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" bgcolor="#FFFFCC">
            <td colspan="2" bgcolor="#FFFFFF">
                <table border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr valign="middle">
                        <td>
                            <div align="right">
                                <asp:Label ID="lblCity" CssClass="titleOrderlabel" runat="server" Text="City: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyCity" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblState" CssClass="titleOrderlabel" runat="server" Text="State: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCompanyState" CssClass="dropdown" runat="server">
                                <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                                <asp:ListItem Text="District of Columbia" Value="District of Columbia" />
                                <asp:ListItem Text="Maryland" Value="Maryland" />
                                <asp:ListItem Text="Virginia" Value="Virginia" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblZip" CssClass="titleOrderlabel" runat="server" Text="Zip: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyZip" CssClass="input" Width="50px" runat="server" MaxLength="5"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCompanyZip"
                                ErrorMessage="Invalid Zip" ValidationExpression="\d{5}(-\d{4})?" Font-Size="Smaller"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblEmail" CssClass="titleOrderlabel" runat="server" Text="Email: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" CssClass="input" Width="200px" runat="server"></asp:TextBox>
                <span style="color: Red;">*</span>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    Display="Dynamic" Font-Size="Smaller" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regvEmail" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" 
                    ErrorMessage="Invalid Email Format" Font-Size="Smaller" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblContactTelephone" CssClass="titleOrderlabel" runat="server" Text="Contact Telephone: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtContactTelephone" CssClass="input" Width="90px" runat="server"
                    ToolTip="(xxx) xxx-xxxx" MaxLength="14"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblContactFax" CssClass="titleOrderlabel" runat="server" Text="Contact Fax: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtContactFax" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                    MaxLength="14"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td height="25" colspan="2" align="center">
                <asp:Label ID="lblLoanOfficerInfo" CssClass="contactTitlelabel" runat="server" Text="Loan Officer &amp; Processor
                    Information:"></asp:Label>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblLoanOfficer" CssClass="titleOrderlabel" runat="server" Text="Loan Officer: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtLoanOfficer" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblLoanProcessor" CssClass="titleOrderlabel" runat="server" Text="Loan Processor: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtLoanProcessor" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblTransactionType" CssClass="titleOrderlabel" runat="server" Text="Transaction Type: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:DropDownList ID="ddlTransactionType" CssClass="dropdown" runat="server">
                    <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                    <asp:ListItem Text="Refinance" Value="Refinance" />
                    <asp:ListItem Text="Purchase" Value="Purchase" />
                    <asp:ListItem Text="Equity Line of Credit" Value="Equity Line of Credit" />
                    <asp:ListItem Text="Second Mortgage" Value="Second Mortgage" />
                    <asp:ListItem Text="Cash" Value="Cash" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblLoanAmount" CssClass="titleOrderlabel" runat="server" Text="Loan Amount: "></asp:Label>
                </div>
            </td>
            <td align="left">
                <asp:TextBox ID="txtLoanAmount" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblPurchaseAmount" CssClass="titleOrderlabel" runat="server" Text="Purchase Amount: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtPurchaseAmount" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td height="25" colspan="2">
                <asp:Label ID="lblBorrowerBuyer" CssClass="contactTitlelabel" runat="server" Text="Borrower/Buyer Information:"></asp:Label>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblBorrower" CssClass="titleOrderlabel" runat="server" Text="Borrower: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtBorrower" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle" bgcolor="#FFFFFF">
                <div align="right">
                    <asp:Label ID="lblBuyerSSN" CssClass="titleOrderlabel" runat="server" Text="SSN#: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtBuyerSSN" CssClass="input" Width="90px" runat="server" MaxLength="11"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regvBorrowerSSN" runat="server" Font-Size="Smaller"
                    ErrorMessage="Invalid SSN Please follow this format xxx-xx-xxxx" ControlToValidate="txtBuyerSSN"
                    ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblHomeTelephone" CssClass="titleOrderlabel" runat="server" Text="Home Telephone: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtHomeTelephone" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                    MaxLength="14"></asp:TextBox>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblWorktelephone" CssClass="titleOrderlabel" runat="server" Text="Work Telephone: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtWorkTelephone" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                    MaxLength="14"></asp:TextBox>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblAddress" CssClass="titleOrderlabel" runat="server" Text="Address: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtBorrowerAddress" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left">
            <td colspan="2">
                <table border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr valign="middle">
                        <td>
                            <div align="right">
                                <asp:Label ID="lblBorrowerCity" CssClass="titleOrderlabel" runat="server" Text="City: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBorrowerCIty" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblBorrowerState" CssClass="titleOrderlabel" runat="server" Text="State: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBorrowerState" CssClass="dropdown" runat="server">
                                <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                                <asp:ListItem Text="District of Columbia" Value="District of Columbia" />
                                <asp:ListItem Text="Maryland" Value="Maryland" />
                                <asp:ListItem Text="Virginia" Value="Virginia" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblBorrowerZip" CssClass="titleOrderlabel" runat="server" Text="Zip: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBorrowerZip" CssClass="input" Width="50px" runat="server" MaxLength="5"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBorrowerZip"
                                ErrorMessage="Invalid Zip" ValidationExpression="\d{5}(-\d{4})?" Font-Size="Smaller"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <div align="right">
                    <asp:Label ID="lblCoBorrower" CssClass="titleOrderlabel" runat="server" Text="Co-Borrower: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtCoBorrower" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <div align="right">
                    <asp:Label ID="lblCoBorrowerSSN" CssClass="titleOrderlabel" runat="server" Text="SSN#: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtCoBorrowerSSN" CssClass="input" Width="90px" runat="server" MaxLength="11"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regvCoBorrowerSSN" runat="server" Font-Size="Smaller"
                    ErrorMessage="Invalid SSN Please follow this format xxx-xx-xxxx" ControlToValidate="txtCoBorrowerSSN"
                    ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td height="25" colspan="2">
                <asp:Label ID="lblSellerInfo" CssClass="contactTitlelabel" runat="server" Text="Seller Information:"></asp:Label>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblSeller" CssClass="titleOrderlabel" runat="server" Text="Seller: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtSeller" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle" bgcolor="#FFFFFF">
                <div align="right">
                    <asp:Label ID="lblSellerSSN" CssClass="titleOrderlabel" runat="server" Text="SSN#: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtSellerSSN" CssClass="input" Width="90px" runat="server"  MaxLength="11"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regvSellerSSN" runat="server" Font-Size="Smaller"
                    ErrorMessage="Invalid SSN Please follow this format xxx-xx-xxxx" ControlToValidate="txtSellerSSN"
                    ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblSellerHomeTel" CssClass="titleOrderlabel" runat="server" Text="Home Telephone: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtSellerHomeTel" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                    MaxLength="14"></asp:TextBox>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblSellerWorkTel" CssClass="titleOrderlabel" runat="server" Text="Work Telephone: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtSellerWorkTel" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                    MaxLength="14"></asp:TextBox>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblSellerAddress" CssClass="titleOrderlabel" runat="server" Text="Address: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtSellerAddress" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left">
            <td colspan="2">
                <table border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr valign="middle">
                        <td>
                            <div align="right">
                                <asp:Label ID="lblSellerCity" CssClass="titleOrderlabel" runat="server" Text="City: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSellerCity" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblSellerState" CssClass="titleOrderlabel" runat="server" Text="State: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSellerState" CssClass="dropdown" runat="server">
                                <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                                <asp:ListItem Text="District of Columbia" Value="District of Columbia" />
                                <asp:ListItem Text="Maryland" Value="Maryland" />
                                <asp:ListItem Text="Virginia" Value="Virginia" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblSellerZip" CssClass="titleOrderlabel" runat="server" Text="Zip: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSellerZip" CssClass="input" Width="50px" runat="server" MaxLength="5"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regvSellerZip" runat="server" ControlToValidate="txtSellerZip"
                                ErrorMessage="Invalid Zip" ValidationExpression="\d{5}(-\d{4})?" Font-Size="Smaller"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <div align="right">
                    <asp:Label ID="lblCoSeller" CssClass="titleOrderlabel" runat="server" Text="Co-Seller: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtCoSeller" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <div align="right">
                    <asp:Label ID="lblCoSellerSSN" CssClass="titleOrderlabel" runat="server" Text="SSN#: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtCoSellerSSN" CssClass="input" Width="90px" runat="server" MaxLength="11"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regvCoSellerSSN" runat="server" Font-Size="Smaller"
                    ErrorMessage="Invalid SSN Please follow this format xxx-xx-xxxx" ControlToValidate="txtCoSellerSSN"
                    ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td height="25" colspan="2">
                <asp:Label ID="lblPropertyInfo" CssClass="contactTitlelabel" runat="server" Text="Property Information:"></asp:Label>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td colspan="2">
                <asp:CheckBox ID="chkAddressSameAsBuyer" runat="server" />
                <asp:Label ID="lblAddressSameAsBuyer" CssClass="titleOrderlabel" runat="server" Text="Check this box if the property address is the same as
                    the borrower/buyer"></asp:Label>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblPropertyAddress" CssClass="titleOrderlabel" runat="server" Text="Property Address: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtPropertyAddress" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td colspan="2">
                <table border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr valign="middle">
                        <td>
                            <div align="right">
                                <asp:Label ID="lblPropertyCity" CssClass="titleOrderlabel" runat="server" Text="City: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPropertyCity" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblPropertyState" CssClass="titleOrderlabel" runat="server" Text="State: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPropertyState" CssClass="dropdown" runat="server">
                                <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                                <asp:ListItem Text="District of Columbia" Value="District of Columbia" />
                                <asp:ListItem Text="Maryland" Value="Maryland" />
                                <asp:ListItem Text="Virginia" Value="Virginia" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblPropertyZip" CssClass="titleOrderlabel" runat="server" Text="Zip: "></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPropertyZip" CssClass="input" Width="50px" runat="server" MaxLength="5"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPropertyZip"
                                ErrorMessage="Invalid Zip" ValidationExpression="\d{5}(-\d{4})?" Font-Size="Smaller"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblOrderPayoff" CssClass="titleOrderlabel" runat="server" Text="Who Orders Payoff: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:DropDownList ID="ddlWhoOrdersPayoff" CssClass="dropdown" runat="server">
                    <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                    <asp:ListItem Text="Mortgage Broker" Value="Mortgage Broker" />
                    <asp:ListItem Text="Title Company" Value="Title Company" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblHowManyPayoffs" CssClass="titleOrderlabel" runat="server" Text="How Many Payoffs: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:DropDownList ID="ddlHowManyPayoffs" CssClass="dropdown" runat="server">
                    <asp:ListItem Text="Choose One:" Value="Didn't Specify" Selected="True" />
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblBankName" CssClass="titleOrderlabel" runat="server" Text="Name of Bank Being Paid Off: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtBankName" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblAccountNumber" CssClass="titleOrderlabel" runat="server" Text="Account Number: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtAccountNumber" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblSalePrice" CssClass="titleOrderlabel" runat="server" Text="Sale Price (if purchased): "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtSalePrice" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left" valign="middle">
            <td align="right">
                <div align="right">
                    <asp:Label ID="lblPropertyLoanAmount" CssClass="titleOrderlabel" runat="server" Text="Loan Amount: "></asp:Label>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtPropertyLoanAmount" CssClass="input" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td height="25" colspan="2">
                <asp:Label ID="lblSpecialInstructions" CssClass="contactTitlelabel" runat="server"
                    Text="Special Instruction:"></asp:Label>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td colspan="2">
                <asp:TextBox ID="txtSpecialInstructions" CssClass="input" runat="server" Width="500px"
                    Height="100px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td height="25" colspan="2">
                <asp:Label ID="lblPayoffInfo" CssClass="contactTitlelabel" runat="server" Text="Payoff Information:"></asp:Label>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td colspan="2">
                <asp:TextBox ID="txtPayoffInformation" CssClass="input" runat="server" Width="500px"
                    Height="100px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td colspan="2">
                <p>
                    <asp:Button ID="btnSubmit" runat="server" Text="Place Order" 
                        onclick="btnSubmit_Click" />
                </p>
                <p>
                    <span style="color: Red;">* Required Field</span>
                </p>
            </td>
        </tr>
    </table>    
    </div>
    <div id="orderstatus" class="orderstatus" runat="server" visible="false">
        <div>
            <br />
            <br />
            <br />
            <div style="width: 100%; height: 400px; text-align: center; vertical-align: middle">
                <div>
                    <asp:Label ID="lblOrderStatus" CssClass='orderlabelstatus' Width="100%" 
                        runat="server"></asp:Label>
                </div>
                <br />
                <br />
                <div>
                    <asp:Button ID="btnGoBackToHome" runat="server" Text="Home" OnClick="btnGoBackToHome_Click"
                        Style="height: 26px" />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
