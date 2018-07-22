<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerView.ascx.cs"
    Inherits="Windows_CustomerView" %>
<table class="table table-hover table-bordered table-responsive-md" id="sampleTable">
    <thead>
        <tr>
            <th>
                #
            </th>
            <th>
                Company Name
            </th>
            <th>
                Address
            </th>
            <th>
                Mobile
            </th>
            <th>
                Phone No.
            </th>
            <th>
                Email ID
            </th>
            <th>
                Vat No.
            </th>
            <th>
                Action
            </th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptCustomer" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("custName")%>
                    </td>
                    <td>
                        <%#Eval("address")%>
                    </td>
                    <td>
                        <%#Eval("phone")%>
                    </td>
                    <td>
                        <%#Eval("mobile")%>
                    </td>
                    <td>
                        <%#Eval("emailId")%>
                    </td>
                    <td>
                        <%#Eval("vatNo")%>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbEdit" runat="server" Text="<i class='fa fa-edit'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="Edit" CommandArgument='<%#Eval("custId") %>' OnClick="lbEdit_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" Text="<i class='fa fa-trash'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="Delete" CommandArgument='<%#Eval("custId") %>' OnClientClick="return confirm('Are you sure?');"
                            OnClick="lbDelete_Click"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
<script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
<script src="js/notifyScripts.js" type="text/javascript"></script>
