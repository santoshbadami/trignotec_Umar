<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuotaionView.ascx.cs"
    Inherits="Windows_QuotaionView" %>
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
                Quotation No
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
                View
            </th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptQuotationView" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("custName")%>
                    </td>
                    <td>
                        Q<%#Eval("quotNo")%>
                    </td>
                    <td>
                        <%#Eval("quotDate", "{0:dd/MM/yyyy}")%>
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
                            ToolTip="Edit" CommandArgument='<%#Eval("quotId") %>' OnClick="lblView_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" Text="<i class='fa fa-trash'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="Delete" CommandArgument='<%#Eval("quotId") %>' OnClientClick="return confirm('Are you sure?');"
                            OnClick="lbDelete_Click"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
<script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
<script src="js/notifyScripts.js" type="text/javascript"></script>
