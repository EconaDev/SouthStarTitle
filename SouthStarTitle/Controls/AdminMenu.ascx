<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.ascx.cs" Inherits="SouthStarTitle.Controls.AdminMenu" %>
<asp:Menu ID="Menu1" runat="server" DynamicHorizontalOffset="2" Font-Names="Verdana"
    Font-Size=".9em" ForeColor="#990000" Height="124px" 
    StaticSubMenuIndent="10px" onmenuitemclick="Menu1_MenuItemClick">
    <StaticSelectedStyle BackColor="#FFCC66" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
    <DynamicMenuStyle BackColor="#FFFBD6" />
    <DynamicSelectedStyle BackColor="#FFCC66" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
    <Items>
        <asp:MenuItem Text="Manage Entity" Value="Manage Entity" NavigateUrl="~/Entities.aspx">
        </asp:MenuItem>
        <asp:MenuItem Text="Manage Users" Value="Manage Users" NavigateUrl="~/Members.aspx">
        </asp:MenuItem>
        <asp:MenuItem Text="Manage Logins" Value="Manage Logins" NavigateUrl="~/Passwords.aspx">
        </asp:MenuItem>
        <asp:MenuItem Text="Upload Files" Value="Upload Files" NavigateUrl="~/UploadFiles.aspx">
        </asp:MenuItem>
        <asp:MenuItem Text="Log Out" Value="Log Out"></asp:MenuItem>
    </Items>
</asp:Menu>
