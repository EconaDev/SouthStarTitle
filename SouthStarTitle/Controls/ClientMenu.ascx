<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientMenu.ascx.cs" Inherits="SouthStarTitle.Controls.ClientMenu" %>
<asp:Menu ID="Menu1" runat="server" 
    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size=".9em" 
    ForeColor="#990000" Height="50px" StaticSubMenuIndent="10px" 
    onmenuitemclick="Menu1_MenuItemClick">
    <StaticSelectedStyle BackColor="#FFCC66" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
    <DynamicMenuStyle BackColor="#FFFBD6" />
    <DynamicSelectedStyle BackColor="#FFCC66" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
    <Items>
        <asp:MenuItem Text="Check Your Files" Value="Check Your Files" 
            NavigateUrl="~/ClientFiles.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Log Out" Value="Log Out"></asp:MenuItem>
    </Items>
</asp:Menu>