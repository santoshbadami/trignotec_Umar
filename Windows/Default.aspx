<%@ Page Title="" Language="C#" MasterPageFile="~/Windows/Admin.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Windows_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="app-content">
        <div class="title">
            <div class="app-title">
                <div class="col-md-12">
                    <%--<iframe src="Default2.aspx" frameborder="0" scrolling="no" width="100%"></iframe>--%>
                    <asp:PlaceHolder runat="server" ID="pnlControls"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
