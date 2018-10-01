<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRequests.aspx.cs" Inherits="BackOffice.pages.UserRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Wizball - User Requests</title>

    <!-- Stylesheets section -->

    <!-- Favicon img -->
    <link rel="shortcut icon" type="image/x-icon" href="/resources/imgs/icon.ico" />

    <!-- Bootstrap and font-awesome stylesheets -->
    <link href="/resources/css/plugins/bootstrap.css" rel="stylesheet" />
    <link href="/resources/css/plugins/font-awesome.min.css" rel="stylesheet" />

    <!-- Custom paging stylesheet -->
    <link href="/resources/css/pagination.css" rel="stylesheet" />

    <!-- Custom toggle stylesheet -->
    <link href="/resources/css/plugins/toggle/bootstrap2-toggle.min.css" rel="stylesheet" />

    <!-- Global BackOffice stylesheet -->
    <link href="/resources/css/style_all.css" rel="stylesheet" />
    <link href="/resources/css/data-table.css" rel="stylesheet" />


</head>
<body>

    <!-- top navigation bar -->
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="Users.aspx">

                    <img src="/resources/imgs/logo_with_name.png" />
                </a>
            </div>
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar"
                aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <div id="navbar" class="collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <!-- Aqui vai ter as tabelas para alteração de dados e o sync -->
                    <li><a href="DataManagment.aspx">DATA MANAGEMENT</a></li>

                    <!-- Aqui vai ter uma tabela dos users e o admin vai poder fazer a gestão dos mesmos -->
                    <li><a href="Users.aspx">USERS</a></li>

                    <!-- Aqui vai ter uma tabela dos users que se registaram recentemente e ainda não foram aceites -->
                    <!-- e o admin vai poder garantir ou negar o acesso ao Website -->
                    <li class="active"><a>USER REQUESTS</a></li>

                    <!-- Aqui vai ser feita toda a gestão de newletter -->
                    <li><a href="Newsletter.aspx">NEWSLETTER</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <!-- Este sino estará a dourado (ou outra cor) se houver pedidos de acesso ao site -->
                    <li><a href=""><i class="glyphicon glyphicon-bell"></i></a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                            aria-expanded="false">
                            <label id="username"></label>
                            <span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu">
                            <li><a href="#">Profile</a></li>
                            <li><a id="logout" href="#">Logout</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>
    <!-- / top navigation bar -->

    <div id="st-container" class="st-container st-effect-1">

        <!-- Central content -->
        <div class="st-pusher">
            <div class="st-content">

                <div class="head-container">

                    <!-- title -->
                    <h3>User Requests</h3>

                    <div class="row">
                        <div class="col-lg-6 col-xs-12">
                            <p class="select-actions">
                                <select class="selectpicker">
                                    <option disabled selected>Order</option>
                                    <option>Mais recentes</option>
                                    <option>Mais Antigos</option>
                                </select>
                            </p>
                        </div>
                        <div class="col-lg-6 col-xs-12 text-right">
                            <!-- search by -->
                            <span class="search-by">
                                <p>
                                    <input type="text" name="" placeholder="Pesquisar utilizadores" />
                                    <select class="selectpicker">
                                        <option>Tudo</option>
                                        <option>Bloqueados</option>
                                        <option>Pendentes</option>
                                        <option>Ativos</option>
                                    </select>
                                </p>
                            </span>
                        </div>
                    </div>

                </div>

                <div class="body-container">
                    <div class="row">
                        <div class="col-lg-12">
                            <!-- list/table-->
                            <div class="content table-full-width" style="position: relative;">
                                <table id="users_table" class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th style="width: 8%;" class="text-center">
                                                <input type="checkbox" /></th>
                                            <th style="width: 10%;">Photo</th>
                                            <th style="width: 17%;"><a class="order-by-desc">Username<i class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th style="width: 29%;"><a class="order-by-desc">E-mail<i class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th style="width: 21%;"><a class="order-by-desc">Status<i class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th style="width: 15%;" colspan="2">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody id="users_table_body">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!-- / Central content -->

    </div>
    <!-- Scripts Section-->

    <!-- JQuery scripts -->
    <script src="/resources/js/plugins/jquery/jquery.min.js"></script>
    <script src="/resources/js/plugins/jquery/jquery-ui.min.js"></script>

    <!-- Custom table paging script -->
    <%--<script src="/resources/js/plugins/pagination/data-tables.js"></script>--%>
    
    <!-- Bootstrap script -->
    <script src="/resources/js/plugins/bootstrap/bootstrap.min.js"></script>

    <!-- Custom toggle script -->
    <script src="/resources/js/plugins/toggle/bootstrap2-toggle.min.js"></script>

    <!-- Side bar effects scripts -->
    <script src="/resources/js/plugins/sidebar/classie.js"></script>
    <script src="/resources/js/plugins/sidebar/sidebar-effects.js"></script>

    <!-- Custom alert script -->
    <script src="/resources/js/plugins/sweetalert/sweetalert.min.js"></script>

    <!-- JQuery session script -->
    <script src="/resources/js/plugins/jquery/jquery.session.js"></script>

    <!-- General script -->
    <script src="/resources/js/general.js"></script>

    <!-- Users management script -->
    <script src="/resources/js/user_requests.js"></script>
</body>
</html>
