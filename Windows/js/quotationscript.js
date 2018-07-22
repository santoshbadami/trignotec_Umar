/// <reference path="jquery-3.2.1.min.js" />
var arr = [];
var arrId = 0;
var qoutId = "";
var quotationNumber = "";
var quotIdEdit = "";

$(document).ready(function () {
    $("#ctl00_ContentPlaceHolder1_ctl00_ddlDescription , #ctl00_ContentPlaceHolder1_ctl00_ddlCustomer").select2();
    bindVatDll();

    var arrEdit = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    if (arrEdit.length == 2) {
        //Edit Quotation
        editQuotation(arrEdit);
    }
    else {
        $("#lblSlNo").text('1');
        $("#btnSave").css("display", "block");
        quotationNumber = $("[id$='txtQuotationNo']").val();
    }
});

function editQuotation(arrEdit) {
    var qid = arrEdit[1].split('=')[1];
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
                    $("[id$='txtQuotationNo']").val(jsonArr.Table[0].quotNo);
                    qoutId = jsonArr.Table[0].quotId;
                    quotationNumber = $("[id$='txtQuotationNo']").val();
                    var dat = jsonArr.Table[0].quotDate.split('T')[0].split('-');
                    $("[id$='txtQuotationDate']").val(dat[2] + "-" + dat[1] + "-" + dat[0]);
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
        quotIdEdit = "";
        createTable(arr);
        clearcontrols();
        //$('#ctl00_ContentPlaceHolder1_ctl00_ddlDescription').select2('open');
    }
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
        if (quotIdEdit == thing.arrId) {
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

function delet(val) {
    var ar = $.grep(arr, function (a) {
        return a.arrId != val;
    });
    arr = ar;
    if (arr.length != 0) {
        quotIdEdit = "";
        createTable(arr);
    }
    else
    { $("#divQuotationTable").html(""); $("#lblSlNo").text('1'); }
}

function bindVatDll() {
    for (var i = 1; i <= 100; i++) {
        $("#ddlVat").append($('<option></option>').val(i).html(i));
    }
    $("#ddlVat").val('5');
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

function save() {
    debugger;
    if ($("[id$='ddlCustomer']").val() == '0') {
        failed('Select Customer!.', '');
    }
    else {
        if ($("[id$='txtQuotationNo']").val() == '') {
            failed('Quotation No Cant be Empty!.', '');
        }
        else {
            if (($("#tbl tr").length) == 0) {
                failed('Add the Products!.', '');
            }
            else {
                debugger;
                $("#btnSave").attr("disabled", "disabled");
                $("#btnSave").prop('value', 'Processing....');
                var jsonArr = new Object();
                jsonArr.custId = $("[id$='ddlCustomer']").val();
                jsonArr.custName = $("[id$='ddlCustomer']").find('option:selected').text();
                jsonArr.quotationNo = $("[id$='txtQuotationNo']").val();
                jsonArr.quotaionDate = $("[id$='txtQuotationDate']").val();
                jsonArr.quotationDetailsArray = arr;
                jsonArr.totExVat = $("#lblTotalExVatSR").text() + "." + $("#lblTotalExVatH").text();
                jsonArr.vatPer = $("[id$='ddlVat']").val();
                jsonArr.vatAmt = $("#lblVatSR").text() + "." + $("#lblVatH").text();
                jsonArr.totInVat = $("#lblVatPlusAmtSR").text() + "." + $("#lblVatPlusAmtH").text();
                jsonArr.termsAndConditions = $("[id$='txtTermsAndConditions']").val();

                var myString = JSON.stringify(jsonArr);
                saveQuotationToDB(myString);
            }
        }
    }
}

function saveQuotationToDB(jsonArr) {
    $.ajax({
        type: "POST",
        url: "WebService.asmx/SaveQuotation",
        data: "{_quotation:'" + jsonArr + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (sub) {
            if (sub.d != '0')
                window.location.href = "Default.aspx?uc=9&qid=" + sub.d;
            else {
                failed('Failed to save Quotation.', '');
                $("#btnSave").removeAttr("disabled");
                $("#btnSave").prop('value', 'Save');
            }
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function addNewProduct() {
    $('#classModal').modal('show');
    $("#lblModalAlert").text("");
    $("[id$='txtDescriptionAddProd']").focus();
}

function calAddProd() {
    var quantity = 0;
    if ($.isNumeric($("#txtQtyAddProd").val()))
        quantity = $("#txtQtyAddProd").val();
    else
        quantity = 1;
    $("#lblTotalPriceAddProd").text(parseFloat(quantity) * parseFloat($("[id$='txtUnitPriceAddProd']").val()));
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

function validateQuotNo(val) {
    qoutId = qoutId == '' ? '0' : qoutId;
    $.ajax({
        type: "POST",
        url: "WebService.asmx/ValidateQuotationNo",
        data: "{_quotationNo:'" + val + "',_quotId:'" + qoutId + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (sub) {
            if (sub.d) {
                failed('Quotation Number ' + val + ' already exist!.', ' And your current Quotation No. is ' + quotationNumber);
                $("[id$='txtQuotationNo']").val("");
            }
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function update() {
    debugger;
    if ($("[id$='ddlCustomer']").val() == '0') {
        failed('Select Customer!.', '');
    }
    else {
        if ($("[id$='txtQuotationNo']").val() == '') {
            failed('Quotation No Cant be Empty!.', '');
        }
        else {
            if (($("#tbl tr").length) == 0) {
                failed('Add the Products!.', '');
            }
            else {
                $("#btnUpdate").attr("disabled", "disabled");
                $("#btnUpdate").prop('value', 'Processing....');
                var jsonArr = new Object();
                jsonArr.quotId = qoutId;
                jsonArr.custId = $("[id$='ddlCustomer']").val();
                jsonArr.custName = $("[id$='ddlCustomer']").find('option:selected').text();
                jsonArr.quotationNo = $("[id$='txtQuotationNo']").val();
                jsonArr.quotaionDate = $("[id$='txtQuotationDate']").val();
                jsonArr.quotationDetailsArray = arr;
                jsonArr.totExVat = $("#lblTotalExVatSR").text() + "." + $("#lblTotalExVatH").text();
                jsonArr.vatPer = $("[id$='ddlVat']").val();
                jsonArr.vatAmt = $("#lblVatSR").text() + "." + $("#lblVatH").text();
                jsonArr.totInVat = $("#lblVatPlusAmtSR").text() + "." + $("#lblVatPlusAmtH").text();
                jsonArr.termsAndConditions = $("[id$='txtTermsAndConditions']").val();

                var myString = JSON.stringify(jsonArr);
                updateQuotationInDB(myString);
            }
        }
    }
}

function updateQuotationInDB(jsonArr) {
    $.ajax({
        type: "POST",
        url: "WebService.asmx/UpdateQuotation",
        data: "{_quotation:'" + jsonArr + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (sub) {
            if (sub.d != '0')
                window.location.href = "Default.aspx?uc=9&qid=" + sub.d;
            else {
                failed('Failed to save Quotation.', '');
                $("#btnUpdate").removeAttr("disabled");
                $("#btnUpdate").prop('value', 'Save');
            }
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function edit(id) {
    quotIdEdit = id;
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
    quotIdEdit = "";
    createTable(arr);
}

function isNumberKey(evt, element) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    else if (element.value.split(".").length > 1) {
        if (element.value.split(".")[1].length > 1) {
            return false;
        }
    }
    else if (element.value.split(".")[0].length > 9) {
        return false;
    }
    else {
        return true;
    }
}


//function myFunction(event) {
//    if (event.charCode == 13) {
//        event.preventDefault();
//    }
//}