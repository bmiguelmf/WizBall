<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BackOffice.pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>WizBall - Dashborad</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/resources/imgs/icon.ico" />
    <link href="~/styling/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="~/styling/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="~/styling/css/style.css" rel="stylesheet" />
    <link href="~/styling/css/estilos.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="animated fadeInDown loginpanel">
        <div class="container">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="col-md-6 formpanel">
                        <div class="middle-box text-center loginscreen animated fadeInDown">
                            <div>
                                <h2>Título bonito</h2>
                                <p>
                                    Frase bonita bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla<br />
                                </p>
                                <form name="login" method="post" class="m-t" role="form">
                                    <label id="erro"></label>
                                    <div class="form-group">
                                        <label for="username" hidden="hidden" class="col-sm-2 control-label">Username</label>
                                        <input id="username" name="username" class="form-control" placeholder="Username" required="" />
                                    </div>
                                    <div class="form-group">
                                        <input name="password" type="password" id="pwd" class="form-control" placeholder="Password" required="" />
                                        <i id="eye" class="fa fa-eye showpassword"></i>
                                    </div>
                                    <button type="submit" class="btn btn-primary block full-width m-b">Login</button>

                                    <input class="getusername" type="button" onclick="getUsername()" value="Esqueceu a password?" />
                                </form>
                                <p class="m-t"></p>
                                <div class="logo text-center">
                                    <%--<div class="col-md-6 center">
                                    <img src="~/resources/imgs/logo-atec.png"/>
                                    <br/>
                                    <span>powered by</span>
                                </div>--%>
                                    <div class="col-md-12 center">
                                        <img id="" src="/resources/imgs/logo-atec.png" />
                                        <br/>
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

</body>
   <%-- <script>
    function show() {
        var p = document.getElementById('pwd');
        p.setAttribute('type', 'text');
    }
    function hide() {
        var p = document.getElementById('pwd');
        p.setAttribute('type', 'password');
    }
    var pwShown = 0;
    document.getElementById("eye").addEventListener("click", function () {
        if (pwShown == 0) {
            pwShown = 1;
            show();
            document.getElementById("eye").className = "fa fa-eye-slash";
        } else {
            pwShown = 0;
            hide();
            document.getElementById("eye").className = "fa fa-eye";
        }
    }, false);

    function getUsername(){
        window.location="file:///C:/wamp64/www/siteRefood/refood_project/refood2/recuperar-password.html";

    };
</script>--%>
<script src="/js/jquery/jquery.min.js"></script>
<script src="/js/login.js"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</html>
