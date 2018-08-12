<%@ Page Title="" Language="C#" MasterPageFile="~/pages/CredMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <img class="mb-4" src="../resources/imgs/favicon.jpg" alt="" width="72" height="72" />
            <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
            <label for="inputEmail" class="sr-only">Email address</label>
            <asp:TextBox TextMode="SingleLine" CssClass="form-control" ClientIDMode="Static" ID="inputUsername" runat="server" placeholder="Username" required="" autofocus="" AutoCompleteType="DisplayName"></asp:TextBox>
            <label for="inputPassword" class="sr-only">Password</label>
            <asp:TextBox TextMode="Password" CssClass="form-control" ClientIDMode="Static" ID="inputPassword" runat="server" placeholder="Password" required=""></asp:TextBox>
            <div class="checkbox mb-3">
                <label>
                    <asp:CheckBox ID="RemSession" runat="server" />
                    Remember me
                </label>
            </div>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block btn-dark" ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            <p class="mt-5 mb-3 text-muted">© 2017-2018</p>
</asp:Content>
