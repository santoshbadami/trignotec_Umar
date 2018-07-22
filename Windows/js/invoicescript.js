/// <reference path="jquery-3.2.1.min.js" />

var arr = [];
var arrId = 0;
var invId = "";
var invoiceNumber = "";
var invIdEdit = "";
var invIdUpdate = "";
var invUniNumber = "";

$(document).ready(function () {
    $("#ctl00_ContentPlaceHolder1_ctl00_ddlQuotationNumber, #ctl00_ContentPlaceHolder1_ctl00_ddlDescription, #ctl00_ContentPlaceHolder1_ctl00_ddlCustomer, #ctl00_ContentPlaceHolder1_ctl00_ddlPendingInvoiceNumber").select2();
    bindVatDll();

    var arrEdit = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    if (arrEdit.length == 2) {
        //Edit Invoice
        $("#divGetDetais").hide();
        editInvoice(arrEdit);
        $("#btnSaveAfterConfirm").hide();
    }
    else {
        $("#divGetDetais").show();
        $("#lblSlNo").text('1');
        $("#btnSave").css("display", "block");
        invoiceNumber = $("[id$='txtInvoiceNo']").val();
        $("#btnUpdateAfterConfirm").hide();
    }
})

function editInvoice(arrEdit) {
    var iid = arrEdit[1].split('=')[1];
    $.ajax({
        type: "POST",
        url: "WebService.asmx/EditInvoice",
        data: "{_invId:'" + iid + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (sub) {
            debugger;
            if (sub.d != '') {
                var jsonArr = JSON.parse(sub.d);
                if (jsonArr.Table.length == 1) {
                    $("[id$='ddlCustomer']").val(jsonArr.Table[0].custId); $("#ctl00_ContentPlaceHolder1_ctl00_ddlCustomer").select2();
                    $("[id$='txtInvoiceNo']").val(jsonArr.Table[0].invoiceNo);
                    invIdUpdate = jsonArr.Table[0].invId;
                    invId = jsonArr.Table[0].invId;
                    invUniNumber = jsonArr.Table[0].invUniqueNo;
                    invoiceNumber = $("[id$='txtInvoiceNo']").val();
                    var dat = jsonArr.Table[0].invoiceDate.split('T')[0].split('-');
                    $("[id$='txtInvoiceDate']").val(dat[2] + "-" + dat[1] + "-" + dat[0]);
                    if (jsonArr.Table1.length > 0) {
                        arr = jsonArr.Table1;
                        $.each(arr, function (idx, thing) {
                            thing.unitPrice = thing.unitPrice.toFixed(2);
                            thing.totalPrice = thing.totalPrice.toFixed(2);
                            arrId = parseFloat(arrId + 1);
                            thing.arrId = arrId;
                        })
                        createTable(jsonArr.Table1);
                    }
                    if (jsonArr.Table2.length == 1) {
                        $("#ddlVat").val(jsonArr.Table2[0].vatPer);
                        calVat();
                        $("[id$='txtTermsAndConditions']").val(jsonArr.Table2[0].termsAndContions);
                        $("#btnUpdate").css("display", "block");
                    }
                }
            }
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function getDetails() {
    debugger;
    var qid = $("[id$='ddlQuotationNumber']").val();
    var iid = $("[id$='ddlPendingInvoiceNumber']").val().split('|')[0];

    if (qid != '0' || iid != '0') {
        if (qid != '0' && iid != '0') {
            failed('Only one can be selected!', '');
        }
        else {
            if (qid != '0') {
                $("#btnGet").attr("disabled", "disabled");
                $("#btnGet").prop('value', 'Processing....');
                $.ajax({
                    type: "POST",
                    url: "WebService.asmx/EditQuotation",
                    data: "{_qid:'" + qid + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (sub) {
                        debugger;
                        if (sub.d != '') {
                            var jsonArr = JSON.parse(sub.d);
                            if (jsonArr.Table.length == 1) {
                                $("[id$='ddlCustomer']").val(jsonArr.Table[0].custId); $("#ctl00_ContentPlaceHolder1_ctl00_ddlCustomer").select2();
                                $("[id$='ddlCustomer']").attr("disabled", false);
                                if (jsonArr.Table1.length > 0) {
                                    arr = jsonArr.Table1;
                                    $.each(arr, function (idx, thing) {
                                        thing.unitPrice = thing.unitPrice.toFixed(2);
                                        thing.totalPrice = thing.totalPrice.toFixed(2);
                                        arrId = parseFloat(arrId + 1);
                                        thing.arrId = arrId;
                                    })
                                    createTable(jsonArr.Table1);
                                    $("#tbl1").show();
                                }
                                if (jsonArr.Table2.length == 1) {
                                    $("#ddlVat").val(jsonArr.Table2[0].vatPer);
                                    calVat();
                                    $("#btnGet").removeAttr("disabled");
                                    $("#btnGet").prop('value', 'Get');
                                }
                            }
                        }
                    },
                    failure: function (msg) {
                        alert(msg);
                    }
                });
            }
            if (iid != '0') {
                debugger;
                $("#btnGet").attr("disabled", "disabled");
                $("#btnGet").prop('value', 'Processing....');
                iid = iid.split(',')[0];
                $.ajax({
                    type: "POST",
                    url: "WebService.asmx/EditInvoice",
                    data: "{_invId:'" + iid + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (sub) {
                        debugger;
                        if (sub.d != '') {
                            var jsonArr = JSON.parse(sub.d);
                            if (jsonArr.Table.length == 1) {
                                $("[id$='ddlCustomer']").val(jsonArr.Table[0].custId); $("#ctl00_ContentPlaceHolder1_ctl00_ddlCustomer").select2();
                                $("[id$='ddlCustomer']").attr("disabled", true);
                                if (jsonArr.Table1.length > 0) {
                                    arr = jsonArr.Table1;
                                    $.each(arr, function (idx, thing) {
                                        thing.unitPrice = thing.unitPrice.toFixed(2);
                                        thing.totalPrice = thing.totalPrice.toFixed(2);
                                        arrId = parseFloat(arrId + 1);
                                        thing.arrId = arrId;
                                    })
                                    createTable(jsonArr.Table1);
                                }
                                if (jsonArr.Table2.length == 1) {
                                    $("#ddlVat").val(jsonArr.Table2[0].vatPer);
                                    calVat();
                                    $("#btnGet").removeAttr("disabled");
                                    $("#btnGet").prop('value', 'Get');
                                }
                            }
                        }
                    },
                    failure: function (msg) {
                        alert(msg);
                    }
                });
            }
        }
    }
    else {
        failed('Make Selections!', '');
    }
}

function bindVatDll() {
    for (var i = 1; i <= 100; i++) {
        $("#ddlVat").append($('<option></option>').val(i).html(i));
    }
    $("#ddlVat").val('5');
}

function createTable(arr) {
    debugger;
    var tbl = "<table id='tbl' class='table table-hover table-bordered table-responsive-md'>";
    tbl += "<thead class='colorBlue'><tr>";
    tbl += "<th rowspan='2'>رقم البند<br />Item<br />No.</th>";
    tbl += "<th rowspan='2' style='width: 35%; text-align: center;'>البیان<br />Description</th>";
    tbl += "<th rowspan='2' style='width: 10%;'>العدد<br />Qty.</th>";
    tbl += "<th colspan='2' class='text-center'>Unit Price<br />سعرالوحدة</th>";
    tbl += "<th colspan='2' class='text-center'>Total Price<br />المبالغ الإجمالي</th>";
    tbl += "<th rowspan='2'>Action</th>";
    tbl += "</tr><tr>";
    tbl += "<th class='text-center'>S.R.&nbsp;&nbsp;&nbsp;&nbsp; ربال</th>";
    tbl += "<th class='text-center'>H.&nbsp;&nbsp;&nbsp;&nbsp; ها</th>";
    tbl += "<th class='text-center'>S.R.&nbsp;&nbsp;&nbsp;&nbsp; ربال</th>";
    tbl += "<th class='text-center'>H.&nbsp;&nbsp;&nbsp;&nbsp; ها</th>";
    tbl += "</tr></thead><tbody>";
    $.each(arr, function (idx, thing) {
        if (invIdEdit == thing.arrId) {
            tbl += "<tr>";
            tbl += "<td>" + parseFloat(idx + 1) + "</td>";
            tbl += "<td><input id='txtEditProduct' type='text' class='form-control' value='" + thing.product + "' /></td>";
            tbl += "<td><input id='txtEditQty' type='text' class='form-control' value='" + thing.qty + "' onkeyup='calEdit();' /></td>";
            tbl += "<td colspan='2'><input id='txtEditUnitPrice' type='number' class='form-control' value='" + thing.unitPrice + "' onkeyup='calEdit();' /></td>";
            tbl += "<td colspan='2'><lable id='lblEditTotalPrice'>" + thing.totalPrice + "</lable></td>";
            tbl += "<td><a onclick='updat(" + thing.arrId + ")' href='javascript:;' class='fa fa-check' title='Update'></a></td>";
            tbl += "</tr>";
        }
        else {
            tbl += "<tr>";
            tbl += "<td>" + parseFloat(idx + 1) + "</td>";
            tbl += "<td>" + thing.product + "</td>";
            tbl += "<td>" + thing.qty + "</td>";
            tbl += "<td  class='text-right'>" + thing.unitPrice.split('.')[0] + "</td>";
            tbl += "<td>" + thing.unitPrice.split('.')[1] + "</td>";
            tbl += "<td class='text-right'>" + thing.totalPrice.split('.')[0] + "</td>";
            tbl += "<td>" + thing.totalPrice.split('.')[1] + "</td>";
            tbl += "<td><a onclick='edit(" + thing.arrId + ")' href='javascript:;' class='fa fa-edit' title='Edit'></a>&nbsp;&nbsp;&nbsp;";
            tbl += "<a onclick='delet(" + thing.arrId + ")' href='javascript:;' class='fa fa-trash' title='Delete'></a></td>";
            tbl += "</tr>";
        }
    })
    tbl += "<tr><td colspan='5'><b style='float: right;'>Total Esclusive Vat <lable id='lblVat'></lable>%</b></td><td><b><label id='lblTotalExVatSR'></label></b></td><td><b><label id='lblTotalExVatH'></label></b></td></tr>";
    tbl += "<tr><td colspan='5'><b style='float: right;'>Vat <lable id='lblVat1'></lable>%</b></td><td><b><label id='lblVatSR'></label></b></td><td><b><label id='lblVatH'></label></b></td></tr>";
    tbl += "<tr><td colspan='5'><b>Total   :           :  المجموع</b></td><td><b><label id='lblVatPlusAmtSR'></label></b></td><td><b><label id='lblVatPlusAmtH'></label></b></td></tr>";
    tbl += "</tbody></table>";
    $("#divQuotationTable").html(tbl);

    var totExTax = 0;
    $.each(arr, function (idx, thing) {
        totExTax = parseFloat(totExTax) + parseFloat(thing.totalPrice);
    })
    totExTax = totExTax.toFixed(2);
    $("#lblTotalExVatSR").text(totExTax.split('.')[0]);
    $("#lblTotalExVatH").text(totExTax.split('.')[1]);
    calVat();
}

function calVat() {
    $("#lblSlNo").text(arr.length + 1);
    $("#lblVat , #lblVat1").text($("#ddlVat").val());
    var tot = $("#lblTotalExVatSR").text() + "." + $("#lblTotalExVatH").text();
    var vat = $("#lblVat").text();
    var vatAmt = (parseFloat(tot) * parseFloat(vat)) / 100;
    var vt = vatAmt.toFixed(2);
    $("#lblVatSR").text(vt.split('.')[0]);
    $("#lblVatH").text(vt.split('.')[1]);
    var amtPlusTax = parseFloat(tot) + parseFloat(vt);
    amtPlusTax = amtPlusTax.toFixed(2);
    $("#lblVatPlusAmtSR").text(amtPlusTax.split('.')[0]);
    $("#lblVatPlusAmtH").text(amtPlusTax.split('.')[1]);
}

function addNewProduct() {
    $('#classModal').modal('show');
    $("#lblModalAlert").text("");
    $("[id$='txtDescriptionAddProd']").focus();
}

function add() {
    debugger;
    if ($("#ctl00_ContentPlaceHolder1_ctl00_ddlDescription").val() == '0') { failed('Select Description.', ''); }
    else if ($("#txtQty").val() == '') { failed('Enter Quantity.', ''); }
    else {
        var prodId, product, qty, unitPrice, totalPrice;
        arrId = parseFloat(arrId + 1);
        //arrId = arr.length == 0 ? 1 : parseFloat(arr[arr.length - 1].arrId) + 1;
        prodId = $("#ctl00_ContentPlaceHolder1_ctl00_ddlDescription").val().split('|')[0];
        product = $('#ctl00_ContentPlaceHolder1_ctl00_ddlDescription').find('option:selected').text();
        qty = $("#txtQty").val();
        unitPrice = parseFloat($("#txtUnitPrice").val()).toFixed(2);
        totalPrice = $("#lblTotalPriceST").text() + "." + $("#lblTotalPriceH").text();

        arr.push({ prodId: prodId, product: product, qty: qty, unitPrice: unitPrice, totalPrice: totalPrice, arrId: arrId });
        invIdEdit = "";
        createTable(arr);
        clearcontrols();
        //$('#ctl00_ContentPlaceHolder1_ctl00_ddlDescription').select2('open');
    }
}

function delet(val) {
    var ar = $.grep(arr, function (a) {
        return a.arrId != val;
    });
    arr = ar;
    if (arr.length != 0) {
        createTable(arr);
    }
    else
    { $("#divQuotationTable").html(""); $("#lblSlNo").text('1'); }
}

function desciption(val) {
    val = val.split('|');
    $("#txtQty").removeAttr("disabled", "disabled");
    $("#txtQty").val('0');
    $("#lblTotalPriceST").text('0');
    $("#lblTotalPriceH").text('0');
    $("#txtUnitPrice").val(val[1]);
}

function qty() {
    var quantity = 0;
    if ($.isNumeric($("#txtQty").val()))
        quantity = $("#txtQty").val();
    else
        quantity = 1;

    var unitPrice = $("#txtUnitPrice").val()
    var totalAmt = parseFloat(quantity) * parseFloat(unitPrice);
    totalAmt = totalAmt.toFixed(2);
    $("#lblTotalPriceST").text(totalAmt.split('.')[0]);
    $("#lblTotalPriceH").text(totalAmt.split('.')[1]);
}

function clearcontrols() {
    $("#ctl00_ContentPlaceHolder1_ctl00_ddlDescription").val('0');
    $("#ctl00_ContentPlaceHolder1_ctl00_ddlDescription").select2();
    $("#txtQty").val('0');
    $("#txtUnitPrice").val('0.00');
    $("#lblTotalPriceST").text('0');
    $("#lblTotalPriceH").text('0');
    $("[id$='txtDescriptionAddProd']").val('');
    $("[id$='txtQtyAddProd']").val('0');
    $("[id$='txtUnitPriceAddProd']").val('0.00');
    $("#lblModalAlert").text('');
}

function save() {
    debugger;
    if ($("[id$='ddlCustomer']").val() == '0') {
        failed('Select Customer!.', '');
    }
    else {
        if ($("[id$='txtInvoiceNo']").val() == '') {
            failed('Invoice No Cant be Empty!.', '');
        }
        else {
            if (($("#tbl tr").length) == 0) {
                failed('Add the Products!.', '');
            }
            else {
                debugger;
                $("#lblConfirmAlert").text('');
                $('#modalConfrim').modal('show');
            }
        }
    }
}

function saveInvoiceAfterConfirm() {
    debugger;
    if ($("[id$='txtInvoiceNo']").val() != '') {
        $("#btnSaveAfterConfirm").attr("disabled", "disabled");
        $("#btnSaveAfterConfirm").prop('value', 'Processing....');
        var jsonArr = new Object();
        jsonArr.quotId = $("[id$='ddlQuotationNumber']").val();
        jsonArr.custId = $("[id$='ddlCustomer']").val().split('|')[0].trim();
        jsonArr.custName = $("[id$='ddlCustomer']").find('option:selected').text();
        jsonArr.invoiceNo = $("[id$='txtInvoiceNo']").val();
        jsonArr.invoiceDate = $("[id$='txtInvoiceDate']").val();
        jsonArr.custVat = "";
        jsonArr.amount = ($("[id$='rbClosed']").prop("checked")) ? "Closed" : "Open";
        jsonArr.invUniqueNo = $("[id$='ddlPendingInvoiceNumber']").val().split('|')[1];
        jsonArr.invoiceDetailsArray = arr;
        jsonArr.totExVat = $("#lblTotalExVatSR").text() + "." + $("#lblTotalExVatH").text();
        jsonArr.vatPer = $("[id$='ddlVat']").val();
        jsonArr.vatAmt = $("#lblVatSR").text() + "." + $("#lblVatH").text();
        jsonArr.totInVat = $("#lblVatPlusAmtSR").text() + "." + $("#lblVatPlusAmtH").text();
        jsonArr.termsAndConditions = $("[id$='txtTermsAndConditions']").val();

        var myString = JSON.stringify(jsonArr);
        saveInvoiceToDB(myString);
    }
    else {
        $("#lblConfirmAlert").text('Invoice No. already exist. And your current Invoice No. is ' + invoiceNumber)
    }
}

function saveInvoiceToDB(jsonArr) {
    $.ajax({
        type: "POST",
        url: "WebService.asmx/SaveInvoice",
        data: "{_invoice:'" + jsonArr + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (sub) {
            if (sub.d != '0')
                window.location.href = "Default.aspx?uc=12&invId=" + sub.d;
            else {
                failed('Failed to save Invoice.', '');
                $("#btnSave").removeAttr("disabled");
                $("#btnSave").prop('value', 'Save');
            }
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function updateInvoiceAfterConfirm() {
    if ($("[id$='txtInvoiceNo']").val() != '') {
        $("#btnUpdateAfterConfirm").attr("disabled", "disabled");
        $("#btnUpdateAfterConfirm").prop('value', 'Processing....');
        var jsonArr = new Object();
        jsonArr.invId = invIdUpdate;
        jsonArr.custId = $("[id$='ddlCustomer']").val();
        jsonArr.custName = $("[id$='ddlCustomer']").find('option:selected').text();
        jsonArr.invoiceNo = $("[id$='txtInvoiceNo']").val();
        jsonArr.invoiceDate = $("[id$='txtInvoiceDate']").val();
        jsonArr.amount = ($("[id$='rbClosed']").prop("checked")) ? "Closed" : "Open";
        jsonArr.invUniqueNo = invUniNumber;
        jsonArr.invoiceDetailsArray = arr;
        jsonArr.totExVat = $("#lblTotalExVatSR").text() + "." + $("#lblTotalExVatH").text();
        jsonArr.vatPer = $("[id$='ddlVat']").val();
        jsonArr.vatAmt = $("#lblVatSR").text() + "." + $("#lblVatH").text();
        jsonArr.totInVat = $("#lblVatPlusAmtSR").text() + "." + $("#lblVatPlusAmtH").text();
        jsonArr.termsAndConditions = $("[id$='txtTermsAndConditions']").val();

        var myString = JSON.stringify(jsonArr);
        updateInvoiceInDB(myString);
    }
    else {
        $("#lblConfirmAlert").text('Invoice No. already exist. And your current Invoice No. is ' + invoiceNumber)
    }
}

function updateInvoiceInDB(jsonArr) {
    $.ajax({
        type: "POST",
        url: "WebService.asmx/UpdateInvoice",
        data: "{_invoice:'" + jsonArr + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (sub) {
            if (sub.d != '0')
                window.location.href = "Default.aspx?uc=12&invId=" + sub.d;
            else {
                failed('Failed to save Invoice.', '');
                $("#btnUpdate").removeAttr("disabled");
                $("#btnUpdate").prop('value', 'Save');
            }
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function addNewProductAndSaveToDB() {
    if ($("[id$='txtDescriptionAddProd']").val() != '' && $("[id$='txtQtyAddProd']").val() != '' && $("[id$='txtUnitPriceAddProd']").val() != '') {
        var product, qty, unitPrice, totalPrice;
        arrId = parseFloat(arrId + 1);
        product = $("[id$='txtDescriptionAddProd']").val();
        qty = $("[id$='txtQtyAddProd']").val();
        unitPrice = parseFloat($("[id$='txtUnitPriceAddProd']").val()).toFixed(2);
        totalPrice = parseFloat($("#lblTotalPriceAddProd").text()).toFixed(2);

        arr.push({ prodId: 0, product: product, qty: qty, unitPrice: unitPrice, totalPrice: totalPrice, arrId: arrId });
        createTable(arr);
        clearcontrols();
        //$("[id$='ddlDescription']").append($('<option></option>').val(prodId + "|" + unitPrice).html(product));
        //$('#ctl00_ContentPlaceHolder1_ctl00_ddlDescription').select2('open');
        $('#classModal').modal('toggle');
    }
    else {
        $("#lblModalAlert").text('Please Fill the above detials to save and add!');
    }
}

function validateInvNo(val) {
    invId = invId == '' ? '0' : invId;
    $.ajax({
        type: "POST",
        url: "WebService.asmx/ValidateInvoiceNo",
        data: "{_invoiceNo:'" + val + "',_invId:'" + invId + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (sub) {
            if (sub.d) {
                failed('Invoice Number ' + val + ' already exist!.', ' And your current Invoice No. is ' + invoiceNumber);
                $("[id$='txtInvoiceNo']").val("");
            }
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function edit(id) {
    invIdEdit = id;
    createTable(arr);
}

function calEdit() {
    var quantity = 0;
    if ($.isNumeric($("#txtEditQty").val()))
        quantity = $("#txtEditQty").val();
    else
        quantity = 1;

    var unitPrice = $("#txtEditUnitPrice").val()
    var totalAmt = parseFloat(quantity) * parseFloat(unitPrice);
    totalAmt = totalAmt.toFixed(2);
    $("#lblEditTotalPrice").text(totalAmt);
}

function updat(id) {
    for (var i in arr) {
        if (arr[i].arrId == id) {
            arr[i].product = $("#txtEditProduct").val();
            arr[i].qty = $("#txtEditQty").val();
            arr[i].unitPrice = parseFloat($("#txtEditUnitPrice").val()).toFixed(2);
            arr[i].totalPrice = parseFloat($("#lblEditTotalPrice").text()).toFixed(2);
            break; //Stop this loop, we found it!
        }
    }
    invIdEdit = "";
    createTable(arr);
}

function calAddProd() {
    var quantity = 0;
    if ($.isNumeric($("#txtQtyAddProd").val()))
        quantity = $("#txtQtyAddProd").val();
    else
        quantity = 1;
    $("#lblTotalPriceAddProd").text(parseFloat(quantity) * parseFloat($("[id$='txtUnitPriceAddProd']").val()));
}