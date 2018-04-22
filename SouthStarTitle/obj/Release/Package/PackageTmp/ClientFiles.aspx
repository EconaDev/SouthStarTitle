<%@ Page Title="" Language="C#" MasterPageFile="~/Extended.Master" AutoEventWireup="true"
    CodeBehind="ClientFiles.aspx.cs" Inherits="SouthStarTitle.ClientFiles" %>

<%@ Register Src="Controls/ClientMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <table style="width: 100%; height: 400px;">
        <tr>
            <td align="left" style="width: 150px" valign="top">
                <uc1:AdminMenu ID="ClientMenu1" runat="server" />
            </td>
            <td>
                <table style="width: 94%; height: 400px;">
                    <tr>
                        <td>
                            <div class="contact-sub">
                                Client Files</div>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:Label ID="lblEntity" runat="server" CssClass="titleOrderlabel" Text="Choose an entity to check your files"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:DropDownList ID="ddlEntity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEntity_SelectedIndexChanged">
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
                            &nbsp;
                            <asp:Label ID="lblResults" runat="server" Width="500px" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:GridView ID="FilesGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                DataKeyNames="USER_ID" ForeColor="#333333" GridLines="None" Width="718px" OnRowCommand="OnRowCommand_Download">
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Link" Text="download" CommandName="downloadCommand" />
                                    <asp:BoundField DataField="USER_ID" HeaderText="Document Id" Visible="False" ReadOnly="True"
                                        SortExpression="USER_ID" />
                                    <asp:BoundField DataField="FILENAME" HeaderText="File Name" SortExpression="FILENAME" />
                                    <asp:BoundField DataField="CREATED_TIMESTAMP" HeaderText="Upload Date Time" SortExpression="CREATED_TIMESTAMP" />
                                </Columns>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 200px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
