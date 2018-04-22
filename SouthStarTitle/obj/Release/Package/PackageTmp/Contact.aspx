<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="SouthStarTitle.Contact" %>

<asp:Content ID="content" ContentPlaceHolderID="Content" runat="server">
    <div style="width: 956px; height: 480px; background-image: url('Images/titlehome5.jpg');">
        <div class="content-sub">
            <div class="contact">
                <div class="contact-sub">
                    Contact us
                </div>
                <br />
                <div class="contactintro" id="contactintro" runat="server">
                    Please fill out the following form to initiate contact with SouthStar Title Company.
                    Your information will be sent to SouthStar Title Company. A representative from
                    SouthStar Title Company will contact you by telephone or email.</div>
                <br />
                <div id="container" class="container" runat="server">
                    <div class="row1">
                        <div class="row1col1">
                            <div class="row1col1cel1top">
                                <asp:Label ID="lblFirstName" CssClass="contactlabel" runat="server" Text="First Name"></asp:Label>
                            </div>
                            <div class="row1col1cel1bottom">
                                <asp:TextBox ID="txtFirstName" CssClass="input" runat="server"></asp:TextBox>
                                <span style="color:Red;">*</span>
                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                    Display="Dynamic" EnableViewState="False" Font-Size="Smaller" ErrorMessage="Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row1col2">
                            <div class="row1col2cel1top">
                                <asp:Label ID="lblLastName" CssClass="contactlabel" runat="server" Text="Last Name"></asp:Label>
                            </div>
                            <div class="row1col2cel1bottom">
                                <asp:TextBox ID="txtLastName" CssClass="input" runat="server"></asp:TextBox>
                                <span style="color:Red;">*</span>
                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                    Display="Dynamic" Font-Size="Smaller" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row1col3">
                            <div class="row1col3cel1top">
                                <asp:Label ID="lblEmail" CssClass="contactlabel" runat="server" Text="Email"></asp:Label>
                            </div>
                            <div class="row1col3cel1bottom">
                                <asp:TextBox ID="txtEmail" CssClass="input" Width="150px" runat="server" ToolTip="YourEmail@domain.com"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    SetFocusOnError="True" ToolTip="YourEmail@domain.com"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row2">
                        <div class="row2col1">
                            <div class="row2col1cel1top">
                                <asp:Label ID="lblStreetAddress" CssClass="contactlabel" runat="server" Text="Street Address"></asp:Label>
                            </div>
                            <div class="row2col1cel1bottom">
                                <asp:TextBox ID="txtStreetAddress" CssClass="input" Width="150px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row2col2">
                            <div class="row2col2cel1top">
                                <asp:Label ID="lblCity" CssClass="contactlabel" runat="server" Text="City"></asp:Label>
                            </div>
                            <div class="row2col2cel1bottom">
                                <asp:TextBox ID="txtCity" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row2col3">
                            <div class="row2col3cel1top">
                                <asp:Label ID="lblState" CssClass="contactlabel" runat="server" Text="State"></asp:Label>
                            </div>
                            <div class="row2col3cel1bottom">
                                <asp:DropDownList ID="ddlState" CssClass="dropdown" runat="server">
                                    <asp:ListItem Text="Select..." Value="Select..." />
                                    <asp:ListItem Text="VA" Value="VA" />
                                    <asp:ListItem Text="MD" Value="MD" />
                                    <asp:ListItem Text="DC" Value="DC" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row3">
                        <div class="row3col1">
                            <div class="row3col1cel1top">
                                <asp:Label ID="lblPrimaryPhone" CssClass="contactlabel" runat="server" Text="Primary Phone"></asp:Label>
                            </div>
                            <div class="row3col1cel1bottom">
                                <asp:TextBox ID="txtPrimaryPhone" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revPrimaryPhone" runat="server" ControlToValidate="txtPrimaryPhone"
                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row3col2">
                            <div class="row3col2cel1top">
                                <asp:Label ID="lblSecondaryPhone" CssClass="contactlabel" runat="server" Text="Secondary Phone"></asp:Label>
                            </div>
                            <div class="row3col2cel1bottom">
                                <asp:TextBox ID="txtSecondaryPhone" CssClass="input" Width="90px" runat="server"
                                    ToolTip="(xxx) xxx-xxxx"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row3col3">
                            <div class="row3col3cel1top">
                                <asp:Label ID="lblBestTime" CssClass="contactlabel" runat="server" Text="Best Time to Call"></asp:Label>
                            </div>
                            <div class="row3col3cel1bottom">
                                <asp:DropDownList ID="ddlBestTime" CssClass="dropdown" runat="server">
                                    <asp:ListItem Text="Select..." Value="Select..." />
                                    <asp:ListItem Text="06:00 am" Value="06:00 am" />
                                    <asp:ListItem Text="07:00 am" Value="07:00 am" />
                                    <asp:ListItem Text="08:00 am" Value="08:00 am" />
                                    <asp:ListItem Text="09:00 am" Value="09:00 am" />
                                    <asp:ListItem Text="10:00 am" Value="10:00 am" />
                                    <asp:ListItem Text="11:00 am" Value="11:00 am" />
                                    <asp:ListItem Text="12:00 pm" Value="12:00 pm" />
                                    <asp:ListItem Text="01:00 pm" Value="01:00 pm" />
                                    <asp:ListItem Text="02:00 pm" Value="02:00 pm" />
                                    <asp:ListItem Text="03:00 pm" Value="03:00 pm" />
                                    <asp:ListItem Text="04:00 pm" Value="04:00 pm" />
                                    <asp:ListItem Text="05:00 pm" Value="05:00 pm" />
                                    <asp:ListItem Text="06:00 pm" Value="06:00 pm" />
                                    <asp:ListItem Text="07:00 pm" Value="07:00 pm" />
                                    <asp:ListItem Text="08:00 pm" Value="08:00 pm" />
                                    <asp:ListItem Text="09:00 pm" Value="09:00 pm" />
                                    <asp:ListItem Text="10:00 pm" Value="10:00 pm" />
                                    <asp:ListItem Text="11:00 pm" Value="11:00 pm" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row4">
                        <div class="row4col2">
                            <div class="row4col2cel1top">
                                <asp:Label ID="lblComments" CssClass="contactlabel" runat="server" Text="Comments"></asp:Label>
                            </div>
                            <div class="row4col2cel1bottom">
                                <asp:TextBox ID="txtComments" CssClass="input" TextMode="MultiLine" Width="500px"
                                    Height="100px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row5">
                        <div class="row5col2">
                            <div class="row5col2cel1top">
                                &nbsp;
                            </div>
                            <div class="row5col2cel1bottom">
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                        </div>
                    </div>
                </div>
                <div id="contactstatus" class="contactstatus" runat="server" visible="false">
                    <div class="row1">
                        <br />
                        <br />
                        <br />
                        <div class="row1col2" style="width: 100%; text-align: center; vertical-align: middle">
                            <div class="row1col2cel1top">
                                <asp:Label ID="lblContactStatus" CssClass="contactlabelstatus" Width="100%" runat="server"
                                    Text=""></asp:Label>
                            </div>
                            <br />
                            <br />
                            <div class="row1col2cel1bottom">
                                <asp:Button ID="btnGoBackToHome" runat="server" Text="Home" OnClick="btnGoBackToHome_Click"
                                    Style="height: 26px" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnGoBackToContact" runat="server" Text="Back" OnClick="btnGoBackToContact_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="content-address">
            700 N. Fairfax Street • Suite 610 • Old Town Alexandria • VA 22314 Tel: 703.548.7979
            • Fax: 703.548.5533
        </div>
    </div>
</asp:Content>
