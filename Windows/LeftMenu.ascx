<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="Windows_LeftMenu" %>
<script src="js/jquery-3.2.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var querystrings = "?" + window.location.href.slice(window.location.href.indexOf('?') + 1).split('&')[0];
        var page = document.location.pathname.match(/[^\/]+$/)[0] + querystrings;
        $('a[href="' + page + '"]').addClass("active");
        if ($('a[href="' + page + '"]').closest('ul').hasClass('treeview-menu')) {
            $('a[href="' + page + '"]').closest('ul').parent().addClass('is-expanded');
        }
    });
    
</script>
<div class="app-sidebar__overlay" data-toggle="sidebar">
</div>
<div class="app-sidebar">
    <div class="app-sidebar__user">
        <img class="app-sidebar__user-avatar" alt="User Image" src="images/defaultemppic.png"
            style="width: 40px; height: 40px;" />
        <div>
            <p class="app-sidebar__user-name">
                <asp:Label ID="lblName" runat="server" Text="Administrator"></asp:Label>
            </p>
            <p class="app-sidebar__user-designation">
                <asp:Label ID="lblRole" runat="server" Text="Admin"></asp:Label></p>
        </div>
    </div>
    <ul class="app-menu">
        <li><a class="app-menu__item" href="Default.aspx?uc=1"><i class="app-menu__icon fa fa-dashboard">
        </i><span class="app-menu__label">Dashboard</span></a> </li>
        <li class="treeview"><a class="app-menu__item" href="#" data-toggle="treeview"><i
            class="app-menu__icon fa fa-users"></i><span class="app-menu__label">Customer</span><i
                class="treeview-indicator fa fa-angle-right"></i></a>
            <ul class="treeview-menu">
                <li><a class="treeview-item" href="Default.aspx?uc=2"><i class="icon fa fa-circle-o">
                </i>Add Manually</a></li>
                <li><a class="treeview-item" href="Default.aspx?uc=3"><i class="icon fa fa-circle-o">
                </i>Add By Excel</a></li>
                <li><a class="treeview-item" href="Default.aspx?uc=4"><i class="icon fa fa-circle-o">
                </i>View</a></li>
            </ul>
        </li>
        <li class="treeview"><a class="app-menu__item" href="#" data-toggle="treeview"><i
            class="app-menu__icon fa fa-product-hunt"></i><span class="app-menu__label">Product</span><i
                class="treeview-indicator fa fa-angle-right"></i></a>
            <ul class="treeview-menu">
                <li><a class="treeview-item" href="Default.aspx?uc=5"><i class="icon fa fa-circle-o">
                </i>Add Manually</a></li>
                <li><a class="treeview-item" href="Default.aspx?uc=6"><i class="icon fa fa-circle-o">
                </i>Add By Excel</a></li>
                <li><a class="treeview-item" href="Default.aspx?uc=7"><i class="icon fa fa-circle-o">
                </i>View</a></li>
            </ul>
        </li>
        <li class="treeview"><a class="app-menu__item" href="#" data-toggle="treeview"><i
            class="app-menu__icon fa fa-quora"></i><span class="app-menu__label">Quotation</span><i
                class="treeview-indicator fa fa-angle-right"></i></a>
            <ul class="treeview-menu">
                <li><a class="treeview-item" href="Default.aspx?uc=8"><i class="icon fa fa-circle-o">
                </i>Generate</a></li>
                <li><a class="treeview-item" href="Default.aspx?uc=10"><i class="icon fa fa-circle-o">
                </i>View</a></li>
            </ul>
        </li>
        <li class="treeview"><a class="app-menu__item" href="#" data-toggle="treeview"><i
            class="app-menu__icon fa fa-file"></i><span class="app-menu__label">Invoice</span><i
                class="treeview-indicator fa fa-angle-right"></i></a>
            <ul class="treeview-menu">
                <li><a class="treeview-item" href="Default.aspx?uc=11"><i class="icon fa fa-circle-o">
                </i>Generate</a></li>
                <li><a class="treeview-item" href="Default.aspx?uc=13"><i class="icon fa fa-circle-o">
                </i>View</a></li>
            </ul>
        </li>
        <li class="treeview"><a class="app-menu__item" href="#" data-toggle="treeview"><i
            class="app-menu__icon fa fa-newspaper-o"></i><span class="app-menu__label">Report</span><i
                class="treeview-indicator fa fa-angle-right"></i></a>
            <ul class="treeview-menu">
                <%--<li><a class="treeview-item" href=""><i class="icon fa fa-circle-o"></i></a></li>
                <li><a class="treeview-item" href=""><i class="icon fa fa-circle-o"></i></a></li>--%>
            </ul>
        </li>
        <%--<li class="treeview"><a class="app-menu__item" href="#" data-toggle="treeview"><i
            class="app-menu__icon fa fa-copy"></i><span class="app-menu__label">Invoice</span><i
                class="treeview-indicator fa fa-angle-right"></i></a>
            <ul class="treeview-menu">
                <li><a class="treeview-item" href="Default.aspx?uc=4"><i class="icon fa fa-circle-o">
                </i>Generate</a></li>
                <li><a class="treeview-item" href="#"><i class="icon fa fa-circle-o"></i>View</a></li>
            </ul>
        </li>--%>
    </ul>
</div>
