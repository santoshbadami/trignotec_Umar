<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuotationPrint.ascx.cs"
    Inherits="Windows_QuotationPrint" %>
<style type="text/css">
    #tbl
    {
        width: 50%;
    }
</style>
<script type="text/javascript">
    function goBack() {
        debugger;
        window.history.back();
    }
</script>
<div class="row" id="check">
    <div class="col-md-12">
        <h2 class="mb-3 line-head">
            Quotation</h2>
    </div>
</div>
<div class="row">
    <div class="col-md-12 text-center">
        <div class="form-group">
            <asp:Button ID="btnPrint" runat="server" class="btn btn-success" Text="Print" OnClick="btnPrint_Click" />
            <input type="button" value="Back" onclick="goBack()" class="btn btn-primary" />
            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-default" OnClick="btnEdit_Click" />
        </div>
    </div>
</div>
<table id="tbl" class="table table-hover table-bordered table-responsive-md">
    <tr>
        <td class="text-right colorBlue">
            <b>Customer Name</b>
        </td>
        <td>
            <b>
                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
            </b>
        </td>
    </tr>
    <tr>
        <td class="text-right colorBlue">
            <b>Quotation No.</b>
        </td>
        <td>
            <b>
                <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
            </b>
        </td>
    </tr>
    <tr>
        <td class="text-right colorBlue">
            <b>Quotation Date.</b>
        </td>
        <td>
            <b>
                <asp:Label ID="lblQuotationDate" runat="server"></asp:Label>
            </b>
        </td>
    </tr>
</table>
<br />
<br />
<table class="table table-hover table-bordered table-responsive-md">
    <thead>
        <tr class="colorBlue">
            <th rowspan="2">
                رقم البند
                <br />
                Item<br />
                No.
            </th>
            <th rowspan="2" style="width: 35%; text-align: center;">
                البیان<br />
                Description
            </th>
            <th rowspan="2" style="width: 10%;">
                العدد<br />
                Qty.
            </th>
            <th colspan="2" class="text-center">
                Unit Price<br />
                سعرالوحدة
            </th>
            <th colspan="2" class="text-center">
                Total Price<br />
                المبالغ الإجمالي
            </th>
        </tr>
        <tr class="colorBlue">
            <th class="text-center">
                S.R.&nbsp;&nbsp;&nbsp;&nbsp; ربال
            </th>
            <th class="text-center">
                H.&nbsp;&nbsp;&nbsp;&nbsp; ها
            </th>
            <th class="text-center">
                S.R.&nbsp;&nbsp;&nbsp;&nbsp; ربال
            </th>
            <th class="text-center">
                H.&nbsp;&nbsp;&nbsp;&nbsp; ها
            </th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptQuotationDetails" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("prodDescription")%>
                    </td>
                    <td>
                        <%#Eval("qty")%>
                    </td>
                    <td class="text-right">
                        <%#Eval("prodPrice").ToString().Split('.')[0]%>
                    </td>
                    <td>
                        <%#Eval("prodPrice").ToString().Split('.')[1]%>
                    </td>
                    <td class="text-right">
                        <%#Eval("totalPrice").ToString().Split('.')[0]%>
                    </td>
                    <td>
                        <%#Eval("totalPrice").ToString().Split('.')[1]%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="5" class="text-right colorBlue">
                <b>Total Exclusive Vat
                    <asp:Label ID="lblVat1" runat="server"></asp:Label>
                    %</b>
            </td>
            <td class="text-right">
                <b>
                    <asp:Label ID="lblAmtExVatSR" runat="server"></asp:Label></b>
            </td>
            <td>
                <b>
                    <asp:Label ID="lblAmtExVatH" runat="server"></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td colspan="5" class="text-right colorBlue">
                <b>Vat <b>
                    <asp:Label ID="lblVat2" runat="server"></asp:Label></b> %</b>
            </td>
            <td class="text-right">
                <b>
                    <asp:Label ID="lblVatAmtSR" runat="server"></asp:Label></b>
            </td>
            <td>
                <b>
                    <asp:Label ID="lblVatAmtH" runat="server"></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td colspan="5" class="text-right">
                <b><span class="colorBlue">Total :</span>
                    <asp:Label ID="lblTotalInWords" runat="server" Style="text-decoration: underline;"></asp:Label>
                    <span class="colorBlue">: المجموع </span></b>
            </td>
            <td class="text-right">
                <b>
                    <asp:Label ID="lblAmtInVatSR" runat="server"></asp:Label></b>
            </td>
            <td>
                <b>
                    <asp:Label ID="lblAmtInVatH" runat="server"></asp:Label></b>
            </td>
        </tr>
    </tbody>
</table>
<h5>
    <u>Terms & Conditions :</u></h5>
<br />
<asp:Label ID="lblTermsAndConditions" runat="server"></asp:Label>
