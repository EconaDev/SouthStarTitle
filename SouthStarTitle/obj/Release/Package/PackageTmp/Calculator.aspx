<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Calculator.aspx.cs" Inherits="SouthStarTitle.Calculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div style="width: 956px; height: 480px; background-image: url('Images/calculator.jpg');">
        <div class="content-sub">
            <div class="contact">
                <div class="contact-sub">
                    Transfer Tax Calculator
                </div>
                <br />
                <div id="ContentContainer" class="ContentContainer">
                    <h3>
                        <a href="#" id="MDLink" onclick="DisplayMD(); return false;" class="ThinActive">Maryland</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="#" id="VALink" onclick="DisplayVA(); return false;" class="Thin">Virginia</a>
                    </h3>
                    <div id="Maryland" style="min-height: 300px;">

                                    <table class="mdcalctable" border="0" cellspacing="0" cellpadding="1">
                                        <tr>
                                            <td>
                                                <label class="calclabel" for="SalePriceMD">
                                                    Sale Price $</label>
                                            </td>
                                            <td style="text-align:left;">
                                                <input style="text-align:left;" class="calinput" name="SalePriceMD" id="SalePriceMD"
                                                    type="text" value="300,000.00" onkeyup="UpdateSalePriceMD();" onblur="FormatSalePriceMD();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="calclabel" for="LoanAmountMD">
                                                    Loan Amount $</label>
                                            </td>
                                            <td style="text-align:left;">
                                                <input style="text-align:left;" class="calinput" name="LoanAmountMD" id="LoanAmountMD"
                                                    type="text" value="240,000.00" onkeyup="UpdateLoanAmountMD();" onblur="FormatLoanAmountMD();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="calclabel" for="BalanceMD">
                                                    Balance to be paid off (only if Refi)</label>
                                            </td>
                                            <td style="text-align:left;">
                                                <input style="text-align: left;" class="calinput" name="BalanceMD" id="BalanceMD"
                                                    type="text" value="45,000.00" onkeyup="UpdateBalanceMD();" onblur="FormatBalanceMD();" />
                                            </td>
                                        </tr>
                                    </table>

                        <p>
                            &nbsp;</p>
                        <table class="caltable" width="700" border="0" cellspacing="0" cellpadding="1" style="margin-top: 10px;">
                            <tr style="border-bottom: 2px solid #000;" class="calcHeader">
                                <td width="100" rowspan="3" style="color: Navy; border-right: 1px solid #000; border-bottom: 2px solid #000;">
                                    Counties
                                </td>
                                <td colspan="2" style="color: Navy; border-right: 1px solid #000;">
                                    State Transfer *
                                </td>
                                <td colspan="2" style="color: Navy; border-right: 1px solid #000;">
                                    Recordation Tax (Refi)
                                </td>
                                <td colspan="2" rowspan="2" style="color: Navy;">
                                    County Transfer
                                </td>
                            </tr>
                            <tr class="calcHeader">
                                <td width="100" style="color: Navy;">
                                    N/A FTHB
                                </td>
                                <td width="100" style="border-right: 1px solid #000;">
                                    &nbsp;
                                </td>
                                <td width="100">
                                    &nbsp;
                                </td>
                                <td width="100" style="color: Navy; border-right: 1px solid #000;">
                                    N/A on Refi's
                                </td>
                            </tr>
                            <tr class="calcHeader">
                                <td width="100" style="color: Navy; border-top: 1px solid #000; border-right: 1px solid #000;
                                    border-bottom: 2px solid #000;">
                                    Full Tax
                                </td>
                                <td width="100" style="color: Navy; border-top: 1px solid #000; border-right: 1px solid #000;
                                    border-bottom: 2px solid #000;">
                                    50/50
                                </td>
                                <td width="100" style="color: Navy; border-top: 1px solid #000; border-right: 1px solid #000;
                                    border-bottom: 2px solid #000;">
                                    Full Tax
                                </td>
                                <td width="100" style="color: Navy; border-top: 1px solid #000; border-right: 1px solid #000;
                                    border-bottom: 2px solid #000;">
                                    50/50
                                </td>
                                <td width="100" style="color: Navy; border-top: 1px solid #000; border-right: 1px solid #000;
                                    border-bottom: 2px solid #000;">
                                    Full Tax
                                </td>
                                <td width="100" style="color: Navy; border-top: 1px solid #000; border-bottom: 2px solid #000;">
                                    50/50
                                </td>
                            </tr>
                            <tr>
                                <td width="100" style="border-right: 1px solid #000;">
                                    <select name="CountyMD" id="CountyMD" onchange="UpdateSalePriceMD();" onkeyup="UpdateSalePriceMD();">
                                        <option id="AnneAr" selected="selected" value="AnneAr">Anne Ar</option>
                                        <option id="BaltimoreCity" value="BaltimoreCity">Baltimore City</option>
                                        <option id="Carroll" value="Carroll">Carroll</option>
                                        <option id="BaltimoreCounty" value="BaltimoreCounty">Baltimore County</option>
                                        <option id="Charles" value="Charles">Charles</option>
                                        <option id="Frederick" value="Frederick">Frederick</option>
                                        <option id="Howard" value="Howard">Howard</option>
                                        <option id="Montgomery" value="Montgomery">Montgomery</option>
                                        <option id="PrinceGeorges" value="PrinceGeorges">Prince George's</option>
                                    </select>
                                </td>
                                <td width="100" style="color: Black; background-color: White; border-right: 1px solid #000;"
                                    id="1A">
                                    &nbsp;
                                </td>
                                <td width="100" style="color: Black; background-color: White; border-right: 1px solid #000;"
                                    id="1B">
                                    &nbsp;
                                </td>
                                <td width="100" style="color: Black; background-color: White; border-right: 1px solid #000;"
                                    id="1C">
                                    &nbsp;
                                </td>
                                <td width="100" style="color: Black; background-color: White; border-right: 1px solid #000;"
                                    id="1D">
                                    &nbsp;
                                </td>
                                <td width="100" style="color: Black; background-color: White; border-right: 1px solid #000;"
                                    id="1E">
                                    &nbsp;
                                </td>
                                <td width="100" id="1F" style="color: Black; background-color: White;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <p>
                            &nbsp;</p>
                        <p>
                            <strong style="color: Green;">* Most of the cases in Maryland the seller pays half of
                                the transfer tax (column 50/50), but it has to be disclosed on Sales Contract.</strong>
                        </p>
                        <p>
                            &nbsp;</p>
                        <table class="caltable" width="300" border="0" cellspacing="0" cellpadding="1">
                            <tr class="calcHeader">
                                <td width="170" style="color: Navy; border-bottom: 1px solid #000; border-right: 1px solid #000;">
                                    MD Title Insurance
                                </td>
                                <td width="100" style="color: Navy; border-bottom: 1px solid #000;">
                                    Total
                                </td>
                            </tr>
                            <tr>
                                <td width="170" style="color: Navy; background-color: White; border-bottom: 1px solid #000;
                                    border-right: 1px solid #000;">
                                    Owner's Title Policy
                                </td>
                                <td width="100" style="color: Black; background-color: White; border-bottom: 1px solid #000;"
                                    id="10A">
                                </td>
                            </tr>
                            <tr>
                                <td width="170" style="color: Navy; background-color: White; border-right: 1px solid #000;">
                                    Lender's Policy
                                </td>
                                <td width="100" id="11A" style="color: Black; background-color: White;">
                                </td>
                            </tr>
                        </table>
                        <p>
                            &nbsp;</p>
                    </div>
                    <div id="Virginia" class="hidden" style="min-height: 300px;">
                        <table class="vacalctable" border="0" cellspacing="0" cellpadding="1">
                            <tr>
                                <td>
                                    <label class="calclabel" for="SalePriceVA">
                                        Sale Price $</label>
                                </td>
                                <td  style="text-align:left;">
                                    <input style="text-align: left;" class="calinput" name="SalePriceVA" id="SalePriceVA"
                                        type="text" value="300,000.00" onkeyup="UpdateSalePriceVA();" onblur="FormatSalePriceVA();" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="calclabel" for="LoanAmountVA">
                                        Loan Amount $</label>
                                </td>
                                <td style="text-align:left;">
                                    <input style="text-align: left;" class="calinput" name="LoanAmountVA" id="LoanAmountVA"
                                        type="text" value="240,000.00" onkeyup="UpdateLoanAmountVA();" onblur="FormatLoanAmountVA();" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="calclabel" for="AssetsValueVA">
                                        Assessment Value (for purchase only) $</label>
                                </td>
                                <td style="text-align:left;">
                                    <input style="text-align: left;" class="calinput" name="AssetsValueVA" id="AssetsValueVA"
                                        type="text" value="0.00" onkeyup="UpdateAssetsValueVA();" onblur="FormatAssetsValueVA();" />
                                </td>
                            </tr>
                        </table>
                        <p>
                            &nbsp;</p>
                        <table class="caltable" width="300" border="0" cellspacing="0" cellpadding="1" style="margin-top: 10px;">
                            <tr>
                                <td class="calcHeader" width="170" style="color: Navy; border-bottom: 1px solid #000;
                                    border-right: 1px solid #000;">
                                    County Transfer Taxes
                                </td>
                                <td width="100" id="12A" style="color: Black; background-color: White; border-bottom: 1px solid #000;">
                                </td>
                            </tr>
                            <tr>
                                <td class="calcHeader" width="170" style="color: Navy; border-right: 1px solid #000;">
                                    State Transfer Taxes
                                </td>
                                <td width="100" id="13A" style="color: Black; background-color: White;">
                                </td>
                            </tr>
                        </table>
                        <p>
                            &nbsp;</p>
                        <table class="caltable" width="300" border="0" cellspacing="0" cellpadding="1">
                            <tr class="calcHeader">
                                <td width="170" style="color: Navy; border-bottom: 1px solid #000; border-right: 1px solid #000;">
                                    VA Title Insurance
                                </td>
                                <td width="100" style="color: Navy; border-bottom: 1px solid #000;">
                                    Total
                                </td>
                            </tr>
                            <tr>
                                <td width="170" style="color: Navy; background-color: White; border-bottom: 1px solid #000;
                                    border-right: 1px solid #000;">
                                    Owner's Title Policy
                                </td>
                                <td width="100" style="color: Black; border-bottom: 1px solid #000; background-color: White;"
                                    id="14A">
                                </td>
                            </tr>
                            <tr>
                                <td width="170" style="color: Navy; background-color: White; border-right: 1px solid #000;">
                                    Lender's Policy
                                </td>
                                <td width="100" id="15A" style="color: Black; background-color: White;">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <p style="font-size: 10px; color: Green;">
                        *Although the calculations on this page are deemed to be accurate, SouthStar Title does
                        not guarantee or warrant the results herein. Because many factors affect the amount
                        of taxes collected by the counties and state, you should speak with one of our representatives
                        or the tax clerk for the county in which the property is located in order to get
                        a more accurate figure.
                    </p>
                </div>
                <br />
            </div>
        </div>
        <div class="content-address">
            700 N. Fairfax Street • Suite 610 • Old Town Alexandria • VA 22314 Tel: 703.548.7979
            • Fax: 703.548.5533
        </div>
    </div>

    <script type="text/javascript" language="javascript" src="Scripts/calculator.js"></script>

</asp:Content>
