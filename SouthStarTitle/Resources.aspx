<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="SouthStarTitle.Resources" %>



<asp:Content ID="content" ContentPlaceHolderID="Content" runat="server">

<script type="text/javascript" language="javascript" src="Scripts/resources.js"></script>

    <div style="width: 956px; height: 480px; background-image: url('Images/resources.jpg');">
        <div class="content-sub">
            <div class="contact">
                <div class="contact-sub">
                    Resources
                </div>
                <br />
                <div class="program">
                    <a href="#" id="showbtn" class="resourcelinks" >Glossary of Terms</a>
                    <br />
                    <br />
                    <a href="Login.aspx" id="showbtn1" class="resourcelinks" >Client Files</a>
                    </div>
                <br />
            </div>
        </div>
        <div class="content-address">
            700 N. Fairfax Street • Suite 610 • Old Town Alexandria • VA 22314 Tel: 703.548.7979
            • Fax: 703.548.5533
        </div>
    </div>
</asp:Content>

