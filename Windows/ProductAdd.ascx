<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAdd.ascx.cs" Inherits="Windows_ProductAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="row">
    <div class="col-md-12">
        <h2 class="mb-3 line-head">
            Product Details Add</h2>
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
                        Description</label>
                    <asp:TextBox runat="server" ID="txtDescription" class="form-control" autofocus></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription"
                        CssClass="required" Display="None" SetFocusOnError="true" ErrorMessage="Description is required"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                    </asp:ValidatorCalloutExtender>
                </div>
                <div class="form-group">
                    <label>
                        Unit Price</label>
                    <asp:TextBox runat="server" ID="txtUnitPrice" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnitPrice"
                        CssClass="required" Display="None" SetFocusOnError="true" ErrorMessage="Unit Price is required"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="modal-footer">
                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success" 
                        ValidationGroup="vg" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" 
                        onclick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
<script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
<script src="js/notifyScripts.js" type="text/javascript"></script>
