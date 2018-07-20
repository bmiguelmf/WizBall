<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp.pages._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <li class="nav-item">
                            <asp:Button ID="LoginBtn" CssClass="btn btn-light nav-link" runat="server" Text="Login" OnClick="LoginBtn_Click" />
                        </li>
                        <li class="nav-item">
                            <asp:Button ID="RegisterBtn" CssClass="btn btn-light nav-link" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
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
   

</asp:Content>
