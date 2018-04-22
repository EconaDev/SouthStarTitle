<%@ Page Title="" Language="C#" MasterPageFile="~/Extended.Master" AutoEventWireup="true"
    CodeBehind="Passwords.aspx.cs" Inherits="SouthStarTitle.Passwords" %>

<%@ Register Src="Controls/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <table style="width: 100%; height: 400px;">
        <tr>
            <td align="left" style="width: 150px" valign="top">
                <uc1:AdminMenu ID="AdminMenu1" runat="server" />
            </td>
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td>
                            <div class="contact-sub">
                                Add Passwords</div>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table runat="server" id="tblUserGrid">
                                <tr>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblEntity" runat="server" Text="Choose a user to add a password" 
                                            ForeColor="#006600"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblResults" runat="server" Width="686px" ForeColor="Red" Font-Size="Smaller"
                                            Style="margin-bottom: 0px" Height="16px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px">
                                        <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            DataKeyNames="ID" AllowPaging="true" AllowSorting="true" ForeColor="#333333" 
                                            GridLines="None" Width="718px" OnRowEditing="UsersGridView_RowEditing" 
                                            OnSorting="UsersGridView_Sorting" PageSize="10" 
                                            OnPageIndexChanging="UsersGridView_PageIndexChanging" >
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333"  />
                                            <Columns>
                                                <asp:CommandField ShowEditButton="True" EditText="Add Password" />
                                                <asp:BoundField DataField="ID" HeaderText="User Id" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="ID" Visible="false"/>
                                                <asp:BoundField DataField="FIRST_NAME" HeaderText="First Name" SortExpression="FIRST_NAME" />
                                                <asp:BoundField DataField="MIDDLE_NAME" HeaderText="Middle Name" SortExpression="MIDDLE_NAME" />
                                                <asp:BoundField DataField="LAST_NAME" HeaderText="Last Name" SortExpression="LAST_NAME" />
                                                <asp:BoundField DataField="LOGIN" HeaderText="Login" SortExpression="LOGIN" />
                                                <asp:BoundField DataField="PASSWORD" HeaderText="Password" SortExpression="PASSWORD" />
                                            </Columns>
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table runat="server" id="tblUserForm" width="510px">
                                <tr valign="middle">
                                    <td align="left" width="70px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right" width="70px">
                                        &nbsp;
                                    </td>
                                    <td width="170px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="left" width="510px" colspan="4">
                                        <asp:Label ID="lblFullName" runat="server" Width="510px" ForeColor="#006600"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td align="right" width="70px">
                                        &nbsp;</td>
                                    <td width="100px">
                                        &nbsp;</td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="170px">
                                        <asp:Label ID="lblUserName" CssClass="titleOrderlabel" runat="server" Text="User Login:"
                                            Width="170px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtUserName" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                                    <span style="color:Red;">*</span>
                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" Display="Dynamic" 
                                            ErrorMessage="Required" ControlToValidate="txtUserName" 
                                            Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        &nbsp;
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="170px">
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="3">
                                        &nbsp;<asp:Label ID="lblPasswordCheck" runat="server" Width="340px" 
                                            Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="170px">
                                        <asp:Label ID="lblPassword" CssClass="titleOrderlabel" runat="server" Text="Password:"
                                            Width="170px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" width="70px" colspan="2">
                                        &nbsp;
                      
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="170px">
                                        &nbsp;</td>
                                    <td align="left" colspan="3">
                                        <ajaxToolkit:PasswordStrength ID="PasswordStrength" runat="server" TextCssClass="error"
                                            HelpStatusLabelID="lblPasswordValidation" MinimumNumericCharacters="1" MinimumSymbolCharacters="1"
                                            DisplayPosition="RightSide" PreferredPasswordLength="6" RequiresUpperAndLowerCaseCharacters="True"
                                            StrengthIndicatorType="Text" TargetControlID="txtPassword" 
                                            TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent">
                                        </ajaxToolkit:PasswordStrength>
                                        <asp:Label ID="lblPasswordValidation" runat="server" Width="340px" 
                                            Font-Size="Smaller" ForeColor="#3333FF"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="170px">
                                        <asp:Label ID="lblConfirmPassword" CssClass="titleOrderlabel" runat="server" Text="Confirm Password:"
                                            Width="170px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" width="70px" colspan="2">
                                        &nbsp;
                                   
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">

                                    </td>
                                    <td align="left" colspan="3">
                                        <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" TextCssClass="error"
                                            HelpStatusLabelID="lblConfirmPasswordValidation" 
                                            MinimumNumericCharacters="1" MinimumSymbolCharacters="1"
                                            DisplayPosition="RightSide" PreferredPasswordLength="6" RequiresUpperAndLowerCaseCharacters="True"
                                            StrengthIndicatorType="Text" TargetControlID="txtConfirmPassword" 
                                            TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent">
                                        </ajaxToolkit:PasswordStrength>
                                        <asp:Label ID="lblConfirmPasswordValidation" runat="server" Font-Size="Smaller" 
                                            ForeColor="#3333FF" Width="340px"></asp:Label>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" width="70px">
                                        &nbsp;
                                    </td>
                                    <td width="100px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px">
                                        &nbsp;
                                    </td>
                                    <td width="70px">
                                        &nbsp;
                                    </td>
                                    <td width="100px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        <asp:Button ID="btnAddPassword" runat="server" Text="Add Password" Style="height: 26"
                                            OnClick="btnAddPassword_Click" Width="100px" />
                                    </td>
                                    <td valign="top" width="70px">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                            CausesValidation="False" Width="75px" />
                                    </td>
                                    <td valign="top" width="100px" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
