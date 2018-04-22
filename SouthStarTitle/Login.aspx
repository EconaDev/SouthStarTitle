<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SouthStarTitle.Login" %>

<asp:Content ID="content" ContentPlaceHolderID="Content" runat="server">
    <div style="text-align: center; vertical-align: middle;" >
        <table border="0" cellpadding="0" cellspacing="0" style="height: 300px; width: 550px;"
            align="center">
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td colspan="2" valign="250px">
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td colspan="2" valign="250px">
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td colspan="2" valign="250px">
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td colspan="2" valign="250px">
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td colspan="2" valign="250px">

                </td>
                <td width="150px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td valign="250px">
                    Username:
                </td>
                <td valign="250px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="150px" />
                </td>
                <td align="left" width="150px">
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                        ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="required" 
                        Font-Size="Smaller"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td valign="250px">
                    Password:
                </td>
                <td valign="250px">
                    <asp:TextBox ID="txtPassword" TextMode="password" runat="server" 
                        Width="150px" />
                </td>
                <td align="left" width="150px">
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                        ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="required" 
                        Font-Size="Smaller"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td colspan="2" valign="250px">
               
                        <asp:Button ID="btnLoginButton" Text="Log In" runat="server" OnClick="btnLoginButton_Click" />
                    
                </td>
                <td width="150px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="150px">
                    &nbsp;</td>
                <td colspan="2" valign="250px">
                    <asp:Label ID="lblLoginError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td width="150px">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
