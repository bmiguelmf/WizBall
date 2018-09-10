﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BackOffice.pages.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Wizball - Utilizadores</title>

    <link href="~/styling/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="~/styling/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="~/styling/css/style_all.css" rel="stylesheet" />
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
                    <li><a href="#">JOGOS</a></li>
                    <li><a href="#">EXEMPLO</a></li>
                    <li class="active"><a>UTILIZADORES</a></li>
                    <li><a href="#">EXEMPLO</a></li>
                    <li><a href="#">EXEMPLO</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <!--<li><a href=""><i class="glyphicon glyphicon-bell"></i></a></li>-->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                            aria-expanded="false">
                            <span class="avatar avatar-online">
                                <img src="img/avatar.png" />
                            </span>
                            <label id="username"></label>
                            <span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu">
                            <li><a href="#">Perfil</a></li>
                            <li><a href="#">Terminar sessão</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>
    <!-- / top navigation bar -->

    <div id="st-container" class="st-container">

        <!-- lateral form add/edit -->
        <div class="st-menu st-effect-1" id="menu-1">
            <form class="row" id="form_" name="form_" method="post" class="form-horizontal">

                <div class="col-lg-12">
                    <h4>Editar utilizador</h4>
                </div>

                <div class="col-lg-3">
                    <div class="image-upload">
                        <label for="photo">
                            <img src="img/avatar.png" />
                        </label>

                        <input id="photo" name="photo" type="file" />
                    </div>
                </div>
                <div class="col-lg-9">
                    <div class="col-lg-12">
                        <label for="nomeRefood">Nome</label><br>
                        <input id="nomeRefood" name="nomeRefood" value="" required="" type="text">
                    </div>
                    <div class="col-lg-3">
                        <label for="codPostal">Código Postal</label><br>
                        <select id="codPostal" name="codPostal" title="Digite o código-postal" class="selectpicker "
                            data-live-search="true">
                        </select>
                    </div>
                    <div class="col-lg-9">
                        <label for="rua">Morada</label><br>
                        <select id="ruas" name="rua" title="Escolhe a rua" class="selectpicker " data-live-search="true">
                        </select>
                    </div>
                    <div class="col-lg-6">
                        <label for="localidade">Localidade</label><br>
                        <input id="localidade" name="localidade" class="" required="" type="text" disabled>
                    </div>
                    <div class="col-lg-6">
                        <label for="porta">Nº da Porta</label>
                        <input id="porta" name="porta" class="" required="" type="text">
                    </div>

                    <div class="col-lg-12">
                        <label for="email">Contacto</label><br>
                        <input id="contactinput" name="" type="text" style="width: 50%" />
                        <select id="contactype" class="selectpicker" name="" style="width: 40%">
                            <!--{% for contact in typecontacts %}
                            <option value="{{ contact.getId() }}">{{ contact.getName() }}</option>
                        {% endfor %}-->
                            <option>Telefone</option>
                            <option>Telemóvel</option>
                            <option>Email</option>
                        </select>
                        <button id="newcontact" class="btn-primary no-border">
                            <i class="glyphicon glyphicon-plus"></i>
                        </button>
                    </div>
                    <div class="col-lg-12" style="margin-top: 10px">
                        <input id="" name="" type="text" value="938879854" style="width: 50%" />
                        <select id="" class="selectpicker" name="" style="width: 40%">
                            <option>Telefone</option>
                            <option selected>Telemóvel</option>
                            <option>Email</option>
                        </select>
                        <button class="no-border"><i class="glyphicon glyphicon-minus" style="color: white"></i></button>
                    </div>

                    <div class="col-lg-6">
                        <label for="horario">Abre às</label><br>
                        <div class="clockpicker">
                            <input id="horarioinicio" name="horarioinicio" required="" type="text" />
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <label for="horario">Fecha às</label><br>
                        <div class="clockpicker">
                            <input id="horariofim" name="horariofim" required="" type="text" />
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <label for="nomeResponsavel">Responsável</label><br>
                        <select id="nomeResponsavel" name="nomeResponsavel" class="selectpicker"
                            data-live-search="true">
                        </select>
                    </div>

                    <div class="col-lg-12 clearfix"></div>
                    <div class="col-lg-6 st-menu-buttons">
                        <button name="cancelar" class="btn btn-default" type="button">Cancelar</button>
                    </div>
                    <div class="col-lg-6 st-menu-buttons">
                        <button name="guardar" class="btn btn-primary" type="button"
                            onclick="validateForm(\'form_registarRefood\', \'site\', \'Núcleo inserido com sucesso\')">
                            Guardar
                   
                        </button>
                    </div>
                </div>

            </form>
        </div>
        <!-- / lateral form - add/edit -->


        <!-- conteudo central -->
        <div class="st-pusher">
            <div class="st-content">

                <div class="head-container">

                    <!-- title -->
                    <h3>Utilizadores</h3>

                    <div class="row">
                        <div class="col-lg-6 col-xs-12">
                            <p class="select-actions">
                                <select class="selectpicker">
                                    <option disabled selected>Ordenar</option>
                                    <option>Mais recentes</option>
                                    <option>Mais Antigos</option>
                                </select>
                                <button class="btn btn-primary btn-sm">Ok</button>
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
                            <!-- / search by -->

                            <!-- add new instance -->
                            <span class="st-trigger-effects">
                                <button data-effect="st-effect-1" class="btn btn-primary btn-sm">
                                    Pesquisar<i
                                        class="glyphicon glyphicon-search"></i></button>
                            </span>

                        </div>
                    </div>

                </div>

                <div class="body-container">
                    <div class="row">
                        <div class="col-lg-12">

                            <div class="content table-full-width" style="position: relative;">
                                <!-- list/table-->
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>
                                                <input type="checkbox" /></th>
                                            <th>Foto</th>
                                            <th><a class="order-by-desc" href="">Username <i
                                                class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th><a class="order-by-desc" href="">E-mail <i
                                                class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th><a class="order-by-desc" href="">Estado <i
                                                class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th><a class="order-by-desc" href="">Newsletter <i
                                                class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th colspan="2">Ações</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <input type="checkbox" /></td>
                                            <td>
                                                <span class="avatar avatar-online">
                                                    <img src="img/avatar.png" />
                                                </span>
                                            </td>
                                            <td>Tou Bruh
                                    </td>
                                            <td>bruh.tou@gmail.com
                                    </td>
                                            <td>BLOQUEADO A VERMELHO
                                    </td>
                                            <td>NOOP
                                    </td>
                                            <td class="st-trigger-effects">
                                                <a class="" data-effect="st-effect-1" href="">
                                                    <i class="glyphicon glyphicon-eye-open"></i>
                                                </a>
                                            </td>
                                            <td class="st-trigger-effects">
                                                <a data-effect="st-effect-1" href="">
                                                    <i class="glyphicon glyphicon-pencil"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="checkbox" /></td>
                                            <td>
                                                <span class="avatar avatar-online">
                                                    <img src="img/avatar.png" />
                                                </span>
                                            </td>
                                            <td>Fds bro
                                    </td>
                                            <td>fds.bro@gmail.com
                                    </td>
                                            <td>APROVADO A VERDE
                                    </td>
                                            <td>ÓBIU
                                    </td>
                                            <td class="st-trigger-effects">
                                                <a class="" data-effect="st-effect-1" href="">
                                                    <i class="glyphicon glyphicon-eye-open"></i>
                                                </a>
                                            </td>
                                            <td class="st-trigger-effects">
                                                <a class="" data-effect="st-effect-1" href="">
                                                    <i class="glyphicon glyphicon-pencil"></i>
                                                </a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <!-- / list/table-->
                                <!-- pagination buttons -->
                                <div class="col-lg-6 col-xs-12">
                                    <p class="table-footer">
                                        <a href=""><i class="glyphicon glyphicon-refresh"></i></a>
                                        <span class="pagination">(2-10 de 100)
										</span>
                                        <span class="show-items">Utilizadores por página
										
                                            <select class="selectpicker">
                                                <option>10</option>
                                                <option>30</option>
                                                <option>50</option>
                                                <option>100</option>
                                            </select>
                                        </span>
                                    </p>
                                </div>
                                <div class="col-lg-6 col-xs-12 text-right">
                                    <p class="table-footer">
                                        <span class="pagination-buttons">
                                            <a href=""><i class="glyphicon glyphicon-chevron-left"></i></a>
                                            <input type="text" value="1" />
                                            &nbsp; / &nbsp; 10
										
                                            <a href=""><i class="glyphicon glyphicon-chevron-right"></i></a>
                                        </span>
                                    </p>
                                </div>
                                <!-- / pagination buttons -->
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!-- / conteudo central -->

    </div>
    <script src="/js/jquery/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="/js/jquery/jquery.session.js"></script>
    <script src="/js/users.js"></script>
    <script src="js/sidebarEffects.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

</body>
</html>
