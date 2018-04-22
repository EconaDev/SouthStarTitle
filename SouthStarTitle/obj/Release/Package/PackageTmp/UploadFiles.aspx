<%@ Page Title="" Language="C#" MasterPageFile="~/Extended.Master" AutoEventWireup="true"
    CodeBehind="UploadFiles.aspx.cs" Inherits="SouthStarTitle.UploadFiles" %>

<%@ Register Src="Controls/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <table style="width: 100%; height: 400px;">
        <tr>
            <td align="left" style="width: 150px" valign="top">
                <uc1:AdminMenu ID="AdminMenu1" runat="server" />
            </td>
            <td>
                <table style="width: 94%; height: 400px;">
                    <tr>
                        <td>
                            <div class="contact-sub">
                                Upload a File
                            </div>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:Label ID="lblEntity" runat="server" CssClass="titleOrderlabel" Text="Choose an entity:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:DropDownList ID="ddlEntity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEntity_SelectedIndexChanged"
                                CssClass="dropdown">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 94%;" valign="bottom">
                            <asp:UpdatePanel ID="upnlColumnChooser" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlFieldSetColumnChooser" runat="server" Width="100%">
                                        <fieldset>
                                            <legend class="titleOrderlabel">Choose people to attach documents:</legend>
                                            <table style="width: 100%; height: 190px">
                                                <tr>
                                                    <td style="width: 350px; text-align: center; height: 14px;">
                                                    </td>
                                                    <td style="width: 100px; height: 14px; text-align: center;" align="center" valign="middle">
                                                    </td>
                                                    <td style="width: 350px; text-align: right; height: 14px;" align="right">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 350px; text-align: center; height: 15px;">
                                                        <asp:Label ID="lblAvailablePeople" CssClass="listboxtitles" runat="server" Text="Available People: "></asp:Label>
                                                    </td>
                                                    <td style="width: 100px; height: 15px; text-align: center;" align="center" valign="middle">
                                                    </td>
                                                    <td align="right" style="width: 350px; text-align: center; height: 15px;">
                                                        <asp:Label ID="lblSelectedPeople" CssClass="listboxtitles" runat="server" Text="People to assign documents: "></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td rowspan="6" align="center">
                                                        <asp:Panel ID="pnlAvailablePeople" runat="server">
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="width: 100px; text-align: center;" align="center" valign="middle">
                                                    </td>
                                                    <td rowspan="6" align="center">
                                                        <asp:Panel ID="pnlSelectedPeople" runat="server">
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: center;" align="center" valign="middle">
                                                        <asp:Panel ID="pnlBtnAdd" runat="server">
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: center;" align="center" valign="middle">
                                                        <asp:Panel ID="pnlBtnRemove" runat="server">
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: center;" align="center" valign="middle">
                                                        <asp:Panel ID="pnlBtClear" runat="server">
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Width="454px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <asp:UpdatePanel ID="upnlButtonUpload" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Panel ID="pnlBtUpload" runat="server">
                                        <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="actionButton" Width="50px" 
                                        OnClick="btnUpload_Click" Enabled="false" />
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                                DataKeyNames="USER_ID, DOC_ID" ForeColor="#333333" GridLines="None" Width="718px" OnRowDeleting="FilesGridView_RowDeleting">
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="USER_ID" HeaderText="User Id" Visible="False" ReadOnly="True"
                                        SortExpression="ID" />
                                    <asp:BoundField DataField="DOC_ID" HeaderText="Document Id" Visible="False" ReadOnly="True"
                                        SortExpression="ID" />
                                    <asp:BoundField DataField="FILENAME" HeaderText="File Name" SortExpression="FILENAME" />
                                    <asp:BoundField DataField="CREATED_TIMESTAMP" HeaderText="Created Time" SortExpression="CREATED_TIMESTAMP" />
                                    <asp:BoundField DataField="FIRST_NAME" HeaderText="First Name" SortExpression="FIRST_NAME" />
                                    <asp:BoundField DataField="MIDDLE_NAME" HeaderText="Middle Name" SortExpression="MIDDLE_NAME" />
                                    <asp:BoundField DataField="LAST_NAME" HeaderText="Last Name" SortExpression="LAST_NAME" />
                                    <asp:BoundField DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL" />
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
