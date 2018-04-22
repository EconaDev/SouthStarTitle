<%@ Page Title="" Language="C#" MasterPageFile="~/Extended.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SouthStarTitle.Admin" %>
<%@ Register src="Controls/AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <table style="width: 100%; height: 400px;">
    <tr>
        <td align="left" style="width: 150px" valign="top">
            <uc1:AdminMenu ID="AdminMenu1" runat="server" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>

</asp:Content>
