<%@ page title="" language="C#" masterpagefile="~/pages/CredMaster.Master" autoeventwireup="true" codebehind="Register.aspx.cs" inherits="WebApp.pages.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img class="mb-4" src="../resources/imgs/favicon.jpg" alt="" width="72" height="72" />
    <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
    <label for="inputUName" class="sr-only">Username</label>
    <asp:TextBox TextMode="SingleLine" CssClass="form-control" ClientIDMode="Static" ID="inputUName" runat="server" placeholder="Username" required="" autofocus=""></asp:TextBox>
    <label for="inputEmail" class="sr-only">Email address</label>
    <asp:TextBox TextMode="SingleLine" CssClass="form-control" ClientIDMode="Static" ID="inputEmail" runat="server" placeholder="Email address" required="" autofocus="" AutoCompleteType="Email"></asp:TextBox>
    <label for="inputPassword" class="sr-only">Password</label>
    <asp:TextBox TextMode="Password" CssClass="form-control" Style="margin: 0;" ClientIDMode="Static" ID="inputPassword" runat="server" placeholder="Password" required=""></asp:TextBox>
    <label for="inputPasswordConf" class="sr-only">Password</label>
    <asp:TextBox TextMode="Password" CssClass="form-control" ClientIDMode="Static" ID="inputPasswordConf" runat="server" placeholder="Confirm Password" required=""></asp:TextBox>
    <asp:Button CssClass="btn btn-lg btn-primary btn-block btn-dark" ID="RegisterBtn" runat="server" Text="Resgister" OnClick="RegisterBtn_Click" />
    <p class="mt-5 mb-3 text-muted">© 2017-2018</p>

    <asp:Panel ID="ErrorP" runat="server">
        <div class="alert alert-danger alert-dismissible fade show">
            The Passwords <strong>do not</strong> match!
        </div>
    </asp:Panel>
</asp:Content>
