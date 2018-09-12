<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BackOffice.pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>WizBall - Dashborad</title>
    <link rel="shortcut icon" type="image/x-icon" href="/resources/imgs/icon.ico" />
    <link href="/resources/css/plugins/bootstrap.css" rel="stylesheet" />
    <link href="/resources/css/plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/resources/css/style.css" rel="stylesheet" />
    <link href="/resources/css/estilos.css" rel="stylesheet" />
   </head> 
<body class="gray-bg">
    <div class="animated fadeInDown loginpanel">
        <div class="container">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="col-md-6 formpanel">
                        <div class="middle-box text-center loginscreen animated fadeInDown">
                            <div>
                                <h2>WizBall Dashboard</h2>
                                <%--<p>Aqui é feita toda a gestão do <a href="https://google.pt">nosso site</a> para que tenhas os melhores resultados nas tuas apostas!<br /></p>--%>
                                <p>Here we work on <a href="https://google.pt">Wizball website</a> maintenance so you can obtain the best results in your bets!</p>
                                <form name="login" method="post" class="m-t" role="form">
                                    <div class="form-group">
                                        <label for="username" hidden="hidden" class="col-sm-2 control-label">Username</label>
                                        <input id="username" name="username" class="form-control" placeholder="Username" required="" />
                                    </div>
                                    <div class="form-group">
                                        <input id="password" name="password" type="password" id="pwd" class="form-control" placeholder="Password" required="" />
                                        <i id="eye" class="fa fa-eye showpassword"></i>
                                    </div>
                                    <span id="login" class="btn btn-primary block full-width m-b">Login</span>
                                </form>
                                <p class="m-t"></p>
                                <div class="logo text-center">
                                    <div class="row center">
                                        <img id="" src="/resources/imgs/logo-atec.png" />
                                        <br />
                                        <span>supported by</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 wizballpanel">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/resources/js/plugins/jquery.min.js"></script>
    <script src="/resources/js/plugins/jquery.session.js"></script>
    <script src="/resources/js/plugins/sweetalert.min.js"></script>

    <script src="/resources/js/login.js"></script>
</body>

</html>
