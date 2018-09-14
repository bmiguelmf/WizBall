<%@ page title="" language="C#" masterpagefile="~/pages/CredMaster.Master" autoeventwireup="true" codebehind="Register.aspx.cs" inherits="WebApp.pages.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img class="mb-4" src="../resources/imgs/favicon.jpg" alt="" width="72" height="72" />
    <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>1

    <!-- USERNAME -->
    <label for="inputUName" class="sr-only">Username</label>
    <asp:textbox textmode="SingleLine" cssclass="form-control" clientidmode="Static" id="inputUName" runat="server" placeholder="Username" required="" autofocus=""></asp:textbox>
    <!--<asp:regularexpressionvalidator id="RegularExpressionValidatorStreet" runat="server" errormessage="This is wrong!" validationexpression="^[a-z0-9_-]{3,15}$" controltovalidate="inputUName"></asp:regularexpressionvalidator>-->
    
    <!-- ^[a-zA-Z\s][0-9]$ -->

    <!-- E-MAIL -->
    <label for="inputEmail" class="sr-only">Email address</label>
    <asp:textbox textmode="SingleLine" CssClass="form-control" clientidmode="Static" id="inputEmail" runat="server" placeholder="Email address" required="" autofocus="" autocompletetype="Email"></asp:textbox>

    <!-- PASSWORD -->
    <label for="inputPassword" class="sr-only">Password</label>
    <asp:textbox textmode="Password" CssClass="form-control" style="margin: 0;" clientidmode="Static" id="inputPassword" runat="server" placeholder="Password" required=""></asp:textbox>

    <!-- CONFIRM PASSWORD -->
    <label for="inputPasswordConf" class="sr-only">Password</label>
    <asp:textbox textmode="Password" CssClass="form-control" clientidmode="Static" id="inputPasswordConf" runat="server" placeholder="Confirm Password" required=""></asp:textbox>

    <!-- NEWSLETTER CHECKBUTTON --> 
    <asp:CheckBox Text="Subscribe Newsletter" ID="NewsletterChkBox" ClientIDMode="Static" Checked="true" runat="server" />
    
    <!-- CONFIRM SIGN-UP -->
    <asp:button cssclass="btn btn-lg btn-primary btn-block btn-dark" id="RegisterBtn" runat="server" text="Register" onclick="RegisterBtn_Click" />
    <br />

    <asp:Label Text="Already Have An Account? " runat="server" />
    <asp:HyperLink ID="LogInHL" Text="Log In!" runat="server" />

    <br />

    <asp:Label Text="Forgot your credentials? " runat="server" />
    <asp:HyperLink ID="RecPWHL" Text="Recover them here!" runat="server" />

    <br />

    <p class="mt-5 mb-3 text-muted">© 2017-2018</p>

    <asp:panel id="ErrorP" runat="server">
        
        <div class="alert alert-danger alert-dismissible fade show">
            <asp:Label ID="ErrorL" runat="server" Text=""></asp:Label>
        </div>
        <script>

</script>
    </asp:panel>
</asp:Content>
