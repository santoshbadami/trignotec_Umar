<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerAdd.ascx.cs" Inherits="Windows_CustomerAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="row">
    <div class="col-md-12">
        <h2 class="mb-3 line-head">
            Customer Details Add</h2>
    </div>
</div>
<div class="content">
    <div class="content_wrapper">
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <br />
                <div class="form-group">
                    <label>
                        Company Name</label>
                    <asp:TextBox runat="server" ID="txtCompanyName" class="form-control" autofocus></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompanyName"
                        CssClass="required" Display="None" SetFocusOnError="true" ErrorMessage="Company Name is required"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                    </asp:ValidatorCalloutExtender>
                </div>
                <div class="form-group">
                    <label>
                        Address</label>
                    <asp:TextBox runat="server" ID="txtAddress" class="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                        CssClass="required" Display="None" SetFocusOnError="true" ErrorMessage="Address is required"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="validatorcalloutextender2" runat="server" TargetControlID="requiredfieldvalidator2">
                    </asp:ValidatorCalloutExtender>
                </div>
                <div class="form-group">
                    <label>
                        Mobile</label>
                    <asp:TextBox runat="server" ID="txtMobile" class="form-control" type="number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile"
                        CssClass="required" Display="None" SetFocusOnError="true" ErrorMessage="Mobile is required"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                    </asp:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile"
                        ErrorMessage="Should contains 10 numbers" ValidationGroup="vg" CssClass="required"
                        Display="None" SetFocusOnError="true" ValidationExpression="[0-9]{10}" ForeColor="Red" />
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator3">
                    </asp:ValidatorCalloutExtender>
                </div>
                <div class="form-group">
                    <label>
                        Phone No.</label>
                    <asp:TextBox runat="server" ID="txtPhoneNo" class="form-control" type="number"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhoneNo"
                        CssClass="required" Display="None" SetFocusOnError="true" ErrorMessage="Phone No. is required"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                    </asp:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhoneNo"
                        ErrorMessage="Should contains 10 numbers" ValidationGroup="vg" CssClass="required"
                        Display="None" SetFocusOnError="true" ValidationExpression="[0-9]{10}" ForeColor="Red" />
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator1">
                    </asp:ValidatorCalloutExtender>--%>
                </div>
                <div class="form-group">
                    <label>
                        Email ID</label>
                    <asp:TextBox runat="server" ID="txtEmailID" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmailID"
                        CssClass="required" Display="None" SetFocusOnError="true" ErrorMessage="Email ID is required"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5">
                    </asp:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Valid Email ID"
                        ValidationGroup="vg" ControlToValidate="txtEmailID" CssClass="required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        SetFocusOnError="true" Display="None" ForeColor="Red">
                    </asp:RegularExpressionValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RegularExpressionValidator2">
                    </asp:ValidatorCalloutExtender>
                </div>
                <div class="form-group">
                    <label>
                        Vat No.</label>
                    <asp:TextBox runat="server" ID="txtVatNo" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="modal-footer">
                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success" ValidationGroup="vg"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
<script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
<script src="js/notifyScripts.js" type="text/javascript"></script>
