<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuotationGenerate.ascx.cs"
    Inherits="Windows_QuotationGenerate" %>
<script src="js/quotationscript.js" type="text/javascript"></script>
<style type="text/css">
    .datepicker
    {
        top: 175px !important;
    }
</style>
<link href="css/bootstrap-iso.css" rel="stylesheet" type="text/css" />
<div class="row" id="check">
    <div class="col-md-12">
        <h2 class="mb-3 line-head">
            Generate Quotation</h2>
    </div>
</div>
<div class="row">
    <div class="col-md-1">
        <label>
            Customer Name</label>
    </div>
    <div class="col-md-3">
        <asp:DropDownList ID="ddlCustomer" runat="server" class="form-control">
        </asp:DropDownList>
    </div>
    <div class="col-md-1">
        <label>
            Quotation No.</label>
    </div>
    <div class="col-md-3">
        <div class="bootstrap-iso">
            <div class="input-group">
                <span class="input-group-addon"><b>Q</b></span> <b>
                    <asp:TextBox ID="txtQuotationNo" runat="server" class="form-control" type="number"
                        onkeypress="myFunction(event)" onfocusout="validateQuotNo(this.value);"></asp:TextBox></b>
            </div>
        </div>
    </div>
    <div class="col-md-1">
        <label>
            Quotation Date</label>
    </div>
    <div class="col-md-3">
        <asp:TextBox ID="txtQuotationDate" runat="server" class="form-control" onkeydown="javascript:return false"
            onkeypress="myFunction(event)"></asp:TextBox>
    </div>
</div>
<br />
<table class="table table-hover table-bordered table-responsive-md">
    <thead class="colorBlue">
        <tr>
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
            <th rowspan="2">
                Action
            </th>
        </tr>
        <tr>
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
        <tr>
            <td>
                <label id="lblSlNo">
                </label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDescription" runat="server" class="form-control" onchange="javascript: desciption(this.value);">
                </asp:DropDownList>
            </td>
            <td>
                <input type="text" id="txtQty" class="form-control" onkeyup="javascript: qty()" disabled />
            </td>
            <td class="text-right" colspan="2">
                <input type="number" id="txtUnitPrice" value="0.00" class="form-control" onkeyup="javascript: qty()" />
            </td>
            <td class="text-right">
                <b>
                    <label id="lblTotalPriceST">
                        0
                    </label>
                </b>
            </td>
            <td>
                <b>
                    <label id="lblTotalPriceH">
                        0
                    </label>
                </b>
            </td>
            <td>
                <input type="button" value="Add" class="btn btn-primary" onclick="javascript: add()" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <input type="button" value="Add New Product & Service" class="btn btn-default" onclick="addNewProduct();" />
                <%--<input type="button" value="Add New Service" class="btn btn-default" onclick="addNewService();" />--%>
            </td>
            <td colspan="4">
            </td>
            <td class="colorBlue">
                <b>Vat %</b>
            </td>
            <td>
                <select id="ddlVat" class="form-control" onchange="calVat();">
                </select>
            </td>
        </tr>
    </tbody>
</table>
<br />
<div id="divQuotationTable">
</div>
<br />
<div class="row">
    <label>
        <b>Terms & Conditions : </b>
    </label>
    <asp:TextBox ID="txtTermsAndConditions" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="modal-footer">
            <input type="button" id="btnSave" value="Generate Quotation" class="btn btn-success"
                onclick="save();" style="display: none;" />
            <input type="button" id="btnUpdate" value="Update Quotation" class="btn btn-success"
                onclick="update();" style="display: none;" />
            <input type="button" id="btnClear" class="btn btn-danger" value="Clear" />
        </div>
    </div>
</div>
<!--Modal popup-->
<div id="classModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="classInfo"
    aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title" id="classModalLabel">
                    Add New Product
                </h4>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×
                </button>
            </div>
            <div class="modal-body">
                <table class="table table-hover table-bordered table-responsive-md">
                    <thead class="colorBlue">
                        <tr>
                            <th style="width: 35%; text-align: center;">
                                البیان<br />
                                Description
                            </th>
                            <th style="width: 10%;">
                                العدد<br />
                                Qty.
                            </th>
                            <th class="text-center">
                                Unit Price<br />
                                سعرالوحدة
                            </th>
                            <th class="text-center">
                                Total Price<br />
                                المبالغ الإجمالي
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtDescriptionAddProd" runat="server" TextMode="MultiLine" class="form-control"
                                    autofocus></asp:TextBox>
                            </td>
                            <td>
                                <input id="txtQtyAddProd" type="text" class="form-control" onkeyup="calAddProd();"
                                    value="0" />
                            </td>
                            <td>
                                <input id="txtUnitPriceAddProd" type="number" class="form-control" onkeyup="calAddProd();"
                                    value="0.00" />
                            </td>
                            <td>
                                <label id="lblTotalPriceAddProd">
                                    0.00
                                </label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <b>
                    <label id="lblModalAlert" style="color: Red;">
                    </label>
                </b>
            </div>
            <div class="modal-footer">
                <input type="button" id="btnAddNewProduct" value="Add New Product" class="btn btn-success"
                    onclick="addNewProductAndSaveToDB();" />
                <button type="button" class="btn btn-default" data-dismiss="modal" aria-hidden="true">
                    Close
                </button>
            </div>
        </div>
    </div>
</div>
<!--Modal popup-->
<script type="text/javascript" src="js/plugins/bootstrap-datepicker.min.js"></script>
<script type="text/javascript">
    $('#ctl00_ContentPlaceHolder1_ctl00_txtQuotationDate').datepicker({
        format: "dd-mm-yyyy",
        autoclose: true,
        todayHighlight: true
    });
</script>
<script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
<script src="js/notifyScripts.js" type="text/javascript"></script>
