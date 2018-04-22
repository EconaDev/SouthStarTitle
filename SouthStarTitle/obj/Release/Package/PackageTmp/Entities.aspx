<%@ Page Title="" Language="C#" MasterPageFile="~/Extended.Master" AutoEventWireup="true"
    CodeBehind="Entities.aspx.cs" Inherits="SouthStarTitle.Entities" %>

<%@ Register Src="Controls/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <table style="width: 100%; height: 400px;">
        <tr>
            <td align="left" style="width: 150px" valign="top">
                <uc1:AdminMenu ID="AdminMenu1" runat="server" />
            </td>
            <td valign="top">
                <table>
                    <tr>
                        <td>
                            <div class="contact-sub">
                                Add an Entity
                            </div>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table runat="server" id="tblEntityGrid">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblResults" runat="server" Width="311px" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddEntity" runat="server" Text="Add Entity" OnClick="btnAddEntity_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:GridView ID="EntitiesGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            DataKeyNames="ID" ForeColor="#333333" GridLines="None" Width="718px" OnRowEditing="EntitiesGridView_RowEditing"
                                            OnRowDeleting="EntitiesGridView_RowDeleting" OnRowCreated="EntitiesGridView_RowCreated">
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="true"/>
                                                <asp:CommandField ShowEditButton="true"/>
                                                <asp:BoundField DataField="ID" HeaderText="Entity Id" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="ID" />
                                                <asp:BoundField DataField="ENTITY_NAME" HeaderText="Entity Name" SortExpression="ENTITY_NAME" />
                                                <asp:BoundField DataField="ENTITY_ADDRESS_ID" HeaderText="Entity Address" SortExpression="ENTITY_ADDRESS_ID" />
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
                        <td>
                            <table runat="server" id="tblEntityForm">
                                <tr valign="middle">
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right">
                                        <div align="right">
                                            <asp:Label ID="lblEntity" CssClass="titleOrderlabel" runat="server" Text="Entity Name:"></asp:Label>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEntity" CssClass="input" Width="200px" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEntityName" runat="server" ControlToValidate="txtEntity"
                                            Display="Dynamic" ErrorMessage="Required" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right">
                                        <asp:Label ID="lblEntityAddress" CssClass="titleOrderlabel" runat="server" Text="Address: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEntityAddress" CssClass="input" Width="200px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <div align="right">
                                            <asp:Label ID="lblEntityAddressCont" CssClass="titleOrderlabel" runat="server" Text="Address cont."></asp:Label>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEntityAddressCont" CssClass="input" Width="200px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td colspan="2">
                                        <table border="0" align="center" cellpadding="2" cellspacing="0">
                                            <tr valign="middle">
                                                <td>
                                                    <div align="right">
                                                        <asp:Label ID="lblEntityCity" CssClass="titleOrderlabel" runat="server" Text="City: "></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEntityCity" CssClass="input" Width="100px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        <asp:Label ID="lblEntityState" CssClass="titleOrderlabel" runat="server" Text="State: "></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlEntityState" CssClass="dropdown" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <div align="left">
                                                        <asp:Label ID="lblEntityZip" CssClass="titleOrderlabel" runat="server" Text="Zip: "></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEntityZip" CssClass="input" Width="50px" runat="server" MaxLength="5"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="regvEntityZip" runat="server" ControlToValidate="txtEntityZip"
                                                        ErrorMessage="Invalid Zip" ValidationExpression="\d{5}(-\d{4})?" Font-Size="Smaller"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr valign="middle">
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <div align="right">
                                            <asp:Label ID="lblEntiyWorkTel" CssClass="titleOrderlabel" runat="server" Text="Work Telephone: "></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtEntityWorkTel" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                                            MaxLength="14"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <asp:Label ID="lblEntityFax" CssClass="titleOrderlabel" runat="server" Text="Fax: "></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtEntityFax" CssClass="input" Width="90px" runat="server" ToolTip="(xxx) xxx-xxxx"
                                            MaxLength="14"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <asp:Label ID="lblEntityOtherPhone" CssClass="titleOrderlabel" runat="server" Text="Other:"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtEntityOtherTel" CssClass="input" Width="90px" runat="server"
                                            ToolTip="(xxx) xxx-xxxx" MaxLength="14"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <asp:Button ID="btnEditEntity" runat="server" Text="Edit Entity" Style="height: 26"
                                            OnClick="btnEditEntity_Click" />
                                        <asp:Button ID="btnSubmitEntity" runat="server" Text="Submit Entity" Style="height: 26"
                                            OnClick="btnSubmitEntity_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                            CausesValidation="False" />
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
