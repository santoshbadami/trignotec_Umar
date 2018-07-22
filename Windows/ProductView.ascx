<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductView.ascx.cs" Inherits="Windows_ProductView" %>
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
            <th>
                Action
            </th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptProduct" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("description")%>
                    </td>
                    <td>
                        <%#Eval("unitPrice")%>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbEdit" runat="server" Text="<i class='fa fa-edit'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="Edit" CommandArgument='<%#Eval("prodId") %>' OnClick="lbEdit_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" Text="<i class='fa fa-trash'></i>" CssClass="btn btn-default btn-sm"
                            ToolTip="Delete" CommandArgument='<%#Eval("prodId") %>' OnClientClick="return confirm('Are you sure?');"
                            OnClick="lbDelete_Click"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
<script src="js/plugins/bootstrap-notify.min.js" type="text/javascript"></script>
<script src="js/notifyScripts.js" type="text/javascript"></script>
