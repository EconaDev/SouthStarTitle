<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Location.aspx.cs" Inherits="SouthStarTitle.Location" %>

<asp:Content ID="content" ContentPlaceHolderID="Content" runat="server">
    <div style="width: 956px; height: 480px;">
        <div style="width: 400px; height: 480px; float: left;">
            <iframe width="600" height="450" frameborder="0" style="border: 0" src="https://www.google.com/maps/embed/v1/place?q=700%20N%20Fairfax%20St%20%23%20610%2C%20Alexandria%2C%20VA%2022314&key=AIzaSyBcvk7Eh9jhifj4oEewaHGJqbBYMVZKh4U" allowfullscreen></iframe>
        </div>
        <div style="float: right">
            <asp:Image ID="Image4" runat="server" Height="480px" ImageUrl="~/Images/OldTown.jpg"
                Width="360px" />
        </div>
    </div>
</asp:Content>