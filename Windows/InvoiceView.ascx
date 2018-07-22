<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvoiceView.ascx.cs" Inherits="Windows_InvoiceView" %>
<table class="table table-hover table-bordered table-responsive-md" id="sampleTable">
    <thead>
        <tr>
            <th>
                #
            </th>
            <th>
                Customer Name
            </th>
            <th>
                Invoice No
            </th>
            <th>
                Date
            </th>
            <th>
                Amount Excl.<br />
                Vat
            </th>
            <th>
                Vat Amount
            </th>
            <th>
                Amount Incl.<br />
                Vat
            </th>
            <th>
                Action
            </th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptInvoiceView" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("custName")%>
                    </td>
                    <td>
                        <%#Eval("invoiceNo")%>
                    </td>
                    <td>
                        <%#Eval("invoiceDate", "{0:dd/MM/yyyy}")%>
                    </td>
                    <td>
                        <%#Eval("totalExVat")%>
                    </td>
                    <td>
                        <%#Eval("vatAmt")%>
                    </td>
                    <td>
                        <%#Eval("totalInTax")%>
                    </td>
                    <td>
                        <asp:LinkButton ID="lblView" runat="server" Text="<i class='fa fa-eye'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="View" CommandArgument='<%#Eval("invId") %>' OnClick="lblView_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lbEdit" runat="server" Text="<i class='fa fa-edit'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="Edit" CommandArgument='<%#Eval("invId") %>' OnClick="lbEdit_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" Text="<i class='fa fa-trash'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="Delete" CommandArgument='<%#Eval("invId") %>' OnClientClick="return confirm('Are you sure?');"
                            OnClick="lbDelete_Click"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
<script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
<script src="js/notifyScripts.js" type="text/javascript"></script>
