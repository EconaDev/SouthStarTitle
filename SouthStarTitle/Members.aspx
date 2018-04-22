<%@ Page Title="" Language="C#" MasterPageFile="~/Extended.Master" AutoEventWireup="true"
    CodeBehind="Members.aspx.cs" Inherits="SouthStarTitle.Members" %>

<%@ Register Src="Controls/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
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
                                Add a User
                            </div>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table runat="server" id="tblUserGrid">
                                <tr>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblEntity" runat="server" CssClass="titleOrderlabel" Text="Choose an entity to add a user to:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px">
                                        <asp:DropDownList ID="ddlEntity" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlEntity_SelectedIndexChanged" CssClass="dropdown">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px">
                                        <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click"
                                            Width="75px" />
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
                                            DataKeyNames="ID" ForeColor="#333333" GridLines="None" Width="718px" OnRowEditing="UserGridView_RowEditing"
                                            OnRowDeleting="UserGridView_RowDeleting">
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                                <asp:BoundField DataField="ID" HeaderText="User Id" Visible="False" ReadOnly="True"
                                                    SortExpression="ID" />
                                                <asp:BoundField DataField="FIRST_NAME" HeaderText="First Name" SortExpression="FIRST_NAME" />
                                                <asp:BoundField DataField="MIDDLE_NAME" HeaderText="Middle Name" SortExpression="MIDDLE_NAME" />
                                                <asp:BoundField DataField="LAST_NAME" HeaderText="Last Name" SortExpression="LAST_NAME" />
                                                <asp:BoundField DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL" />
                                               
                                                <asp:BoundField DataField="USER_TYPE" HeaderText="User Type" SortExpression="USER_TYPE" />
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
                                    <td align="right" width="70px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td align="right" width="70px">
                                        &nbsp;</td>
                                    <td width="100px">
                                        &nbsp;</td>
                                    <td width="70px">
                                        &nbsp;</td>
                                    <td style="width: 100px">
                                        &nbsp;</td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                            <asp:Label ID="lblUserType" CssClass="titleOrderlabel" runat="server" Text="User Type"
                                                Width="70px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="dropdown" 
                                            Width="75px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" width="70px">
                                        &nbsp;</td>
                                    <td width="100px">
                                        &nbsp;</td>
                                    <td width="70px">
                                        &nbsp;</td>
                                    <td style="width: 100px">
                                        &nbsp;</td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtFirstName"
                                            Display="Dynamic" ErrorMessage="Required" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" width="70px">
                                        &nbsp;
                                    </td>
                                    <td width="100px">
                                        &nbsp;
                                    </td>
                                    <td width="70px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px">
                                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                            Display="Dynamic" ErrorMessage="Required" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                        <div align="right">
                                            <asp:Label ID="lblFirstName" CssClass="titleOrderlabel" runat="server" Text="First Name:"
                                                Width="70px"></asp:Label>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right" width="70px">
                                        <asp:Label ID="lblMiddleName" CssClass="titleOrderlabel" runat="server" Text="Middle Name:"
                                            Width="70px"></asp:Label>
                                    </td>
                                    <td width="100px">
                                        <asp:TextBox ID="txtMiddleName" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right" width="70px">
                                        <asp:Label ID="lblLastName" CssClass="titleOrderlabel" runat="server" Text="Last Name:"
                                            Width="70px"></asp:Label>
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtLastName" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px">
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="Required" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                    </td>
                                    <td width="70px">
                                        &nbsp;
                                    </td>
                                    <td width="100px">
                                        &nbsp;
                                    </td>
                                    <td width="70px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px">
                                        <asp:RequiredFieldValidator ID="rfvWorkTel" runat="server" ControlToValidate="txtWorkTel"
                                            Display="Dynamic" ErrorMessage="Required" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                            <asp:Label ID="lblEmail" CssClass="titleOrderlabel" runat="server" Text="E-Mail:"
                                                Width="70px"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtEmail" CssClass="input" Width="160px" runat="server"
                                            MaxLength="250"></asp:TextBox>
                                    </td>
                                    <td width="100px">
                                        &nbsp;</td>
                                    <td width="70px" align="right">
                                            <asp:Label ID="lblWorkTel" CssClass="titleOrderlabel" runat="server" Text="Work Phone:"
                                                Width="70px"></asp:Label>
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtWorkTel" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                                            MaxLength="14"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" width="70px">
                                        &nbsp;</td>
                                    <td style="width: 100px">
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid E-Mail" 
                                            Font-Size="Smaller" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                    <td width="70px">
                                        &nbsp;</td>
                                    <td width="100px">
                                        &nbsp;</td>
                                    <td width="70px">
                                        &nbsp;</td>
                                    <td style="width: 100px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="70px">
                                        <div align="right">
                                            <asp:Label ID="lblHomeTel" CssClass="titleOrderlabel" runat="server" Text="Home Phone:"
                                                Width="70px"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        <asp:TextBox ID="txtHomeTel" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                                            MaxLength="14"></asp:TextBox>
                                    </td>
                                    <td valign="top" align="right" width="70px">
                                        <asp:Label ID="lblCellTel" CssClass="titleOrderlabel" runat="server" Text="Cell Phone:"
                                            Width="70px"></asp:Label>
                                    </td>
                                    <td valign="top" width="100px">
                                        <asp:TextBox ID="txtCellTel" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                                            MaxLength="14"></asp:TextBox>
                                    </td>
                                    <td valign="top" align="right" width="70px">
                                        <asp:Label ID="lblOthertel" CssClass="titleOrderlabel" runat="server" Text="Other Phone:"
                                            Width="70px"></asp:Label>
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        <asp:TextBox ID="txtOtherTel" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                                            MaxLength="14"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="100px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="100px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="70px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" style="width: 100px">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="70px">
                                        <asp:Button ID="btnEditUser" runat="server" Text="Edit User" Style="height: 26" OnClick="btnEditUser_Click"
                                            Width="75px" />
                                    </td>
                                    <td valign="top" width="100px" align="center">
                                        <asp:Button ID="btnSubmitUser" runat="server" Text="Submit User" Style="height: 26"
                                            OnClick="btnSubmitUser_Click" Width="80px" />
                                    </td>
                                    <td valign="top" width="70px">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                            CausesValidation="False" Width="75px" />
                                    </td>
                                    <td valign="top" style="width: 100px">
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
