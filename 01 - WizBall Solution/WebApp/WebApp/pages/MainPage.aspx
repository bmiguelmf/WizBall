<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApp.pages.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>WizBall</title>
    <link rel="apple-touch-icon" sizes="57x57" href="../resources/favicon/apple-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="../resources/favicon/apple-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="../resources/favicon/apple-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="../resources/favicon/apple-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="../resources/favicon/apple-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="../resources/favicon/apple-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="../resources/favicon/apple-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="../resources/favicon/apple-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="../resources/favicon/apple-icon-180x180.png" />
    <link rel="icon" type="image/png" sizes="192x192" href="../resources/favicon/android-icon-192x192.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="../resources/favicon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="96x96" href="../resources/favicon/favicon-96x96.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="../resources/favicon/favicon-16x16.png" />
    <link rel="manifest" href="/manifest.json" />
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="msapplication-TileImage" content="../resources/favicon/ms-icon-144x144.png" />
    <meta name="theme-color" content="#ffffff">
    <link rel="stylesheet" href="../styling/bootstrap4.css" />
    <link rel="stylesheet" href="../styling/customcode.css" />
    <link rel="stylesheet" href="../styling/general.css" />
    <link rel="stylesheet" href="../styling/font-awesome.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <nav class="navbar navbar-expand-sm bg-light navbar-light">
                    <!-- Brand/logo -->
                    <a class="navbar-brand" href="#">
                        <img src="../resources/imgs/favicon.jpg" alt="logo" style="width: 40px;">
                    </a>

                    <!-- Links -->
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Ligas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Equipas</a>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav ml-auto w-100 justify-content-end">
                        <li class="nav-item btn btn-light">
                            <a class="nav-link" href="#">Login</a>
                        </li>
                        <li class="nav-item btn btn-light">
                            <a class="nav-link" href="#">Register</a>
                        </li>
                    </ul>

                </nav>
                <section class="headerBG">
                    <img src="..\resources\imgs\headerBG.jpg" />
                </section>
            </header>
            <section id="Matches">

                <section id="m-a-n">
        <div class="container">
            <div class="col-6">

                <div class="match">
                    
                    <div class="m-result">
                        <div class="logo-club col-3"><img src="../resources/imgs/man.png"  alt="" /></div>
                        <span class="result col-6">0 <b>:</b> 3</span>
                        <div class="logo-club col-3"><img src="../resources/imgs/fcp.png" alt="" /></div>
                        <div class="club-name col-12">
                            <span class="col-3">Bayern</span>
                            <div class="match-name col-6">Champions League <br> Semi-final <br> <b>25 May 23:00</b></div>
                            <span class="col-3">Arsenal</span>
                        </div>
                    </div>
                </div>
                
            </div>
            <div class="col-4">
                <div class="tab">news</div>
                <div class="tab-small"><a href="#">see all news</a></div>
                <div class="r-box-n">
                    <article>
                        <h3><a href="blog-single.html">Rangers review presents stark picture</a></h3>
                        <p>Praesent risus nisi, iaculis nec condimentum vel, rhoncus vel dolor. Aenean nisi lectus, varius nec tempus</p>
                        <span class="date-n">21 Mar</span>
                    </article>
                    <article>
                        <h3><a href="blog-single.html">Rangers review presents stark picture</a></h3>
                        <p>Praesent risus nisi, iaculis nec condimentum vel, rhoncus vel dolor. Aenean nisi lectus, varius nec tempus</p>
                        <span class="date-n">21 Mar</span>
                    </article>
                    <article>
                        <h3><a href="blog-single.html">Rangers review presents stark picture</a></h3>
                        <p>Praesent risus nisi, iaculis nec condimentum vel, rhoncus vel dolor. Aenean nisi lectus, varius nec tempus</p>
                        <span class="date-n">21 Mar</span>
                    </article>
                </div>
            </div>
        </div>
    </section>
            </section>
        </div>
    </form>
</body>
</html>
