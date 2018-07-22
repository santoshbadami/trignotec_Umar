<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="Windows_TopMenu" %>
<style type="text/css">
    .form-control
    {
        font-weight: bold;
    }
</style>
<div class="app-header">
    <a class="app-header__logo" href="#">Trignotec</a>
    <!-- Sidebar toggle button-->
    <a class="app-sidebar__toggle" href="#" data-toggle="sidebar"></a>
    <!-- Navbar Right Menu-->
    <ul class="app-nav">
        <!--Notification Menu-->
        <div id="divNoticationMenu" runat="server">
        </div>
        <!-- User Menu-->
        <li class="dropdown"><a class="app-nav__item" href="#" data-toggle="dropdown"><i
            class="fa fa-user fa-lg"></i></a>
            <ul class="dropdown-menu settings-menu dropdown-menu-right">
                <li><a class="dropdown-item" href="javascript:;"><i class="fa fa-user fa-lg"></i>Profile</a></li>
                <li><a class="dropdown-item" href="javascript:;"><i class="fa fa-sign-out fa-lg"></i>
                    Logout</a></li>
            </ul>
        </li>
    </ul>
</div>
