<%@ Page Title="" Language="C#" MasterPageFile="~/Extended.Master" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="SouthStarTitle.Client" %>
<%@ Register Src="Controls/ClientMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <table style="width: 100%; height: 400px;">
    <tr>
        <td align="left" style="width: 150px" valign="top">
            <uc1:AdminMenu ID="ClientMenu1" runat="server" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
