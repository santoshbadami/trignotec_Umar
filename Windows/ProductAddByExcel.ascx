﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAddByExcel.ascx.cs"
    Inherits="Windows_ProductAddByExcel" %>
<div class="row">
    <div class="col-md-12">
        <h2 class="mb-3 line-head">
            Add Product By Excel</h2>
    </div>
</div>
<div class="content">
    <div class="content_wrapper">
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1"
                        CssClass="required" Display="Dynamic" SetFocusOnError="true" ErrorMessage="*"
                        ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" class="btn btn-primary" ValidationGroup="vg"
                        OnClick="btnUpload_Click" />
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" class="btn btn-success"
                        Visible="false" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Button ID="btnDownload" runat="server" Text="Download Excel Format" class="btn btn-default"
                        OnClick="btnDownload_Click" />
                </div>
            </div>
        </div>
        <hr />
        <div id="tbl" runat="server" visible="false">
            <table class="table table-hover table-bordered table-responsive-md" id="sampleTable">
                <thead>
                    <tr>
                        <th>
                            #
                        </th>
                        <th>
                            Description
                        </th>
                        <th>
                            Unit Price
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptProductExcel" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Container.ItemIndex+1 %>
                                </td>
                                <td>
                                    <%#Eval("Description")%>
                                </td>
                                <td>
                                    <%#Eval("Unit Price")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
        <script src="js/notifyScripts.js" type="text/javascript"></script>
    </div>
</div>
