+<%@ Page Title="" Language="C#" MasterPageFile="~/pages/CredMaster.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="WebApp.pages.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- USERNAME -->
    <label for="inputUName" class="sr-only">Username</label>
    <asp:textbox textmode="SingleLine" cssclass="form-control" clientidmode="Static" id="inputUName" runat="server" placeholder="Username" required="" autofocus=""></asp:textbox>
    <asp:regularexpressionvalidator id="RegularExpressionValidatorStreet" runat="server" errormessage="This is wrong!" validationexpression="^[a-z0-9_-]{3,15}$" controltovalidate="inputUName"></asp:regularexpressionvalidator>
    
    <!-- ^[a-zA-Z\s][0-9]$ -->

    <!-- E-MAIL -->
    <label for="inputEmail" class="sr-only">Email address</label>
    <asp:textbox textmode="SingleLine" cssclass="form-control" clientidmode="Static" id="inputEmail" runat="server" placeholder="Email address" required="" autofocus="" autocompletetype="Email"></asp:textbox>

    <!-- CONFIRM SIGN-UP -->
    <asp:button cssclass="btn btn-lg btn-primary btn-block btn-dark" id="RecoverBtn" runat="server" text="Send E-Mail" OnClick="RecoverBtn_Click" />


    <p class="mt-5 mb-3 text-muted">© 2017-2018</p>

    <asp:panel id="ErrorP" runat="server">
        
        <div class="alert alert-danger alert-dismissible fade show">
            <asp:Label ID="ErrorL" runat="server" Text=""></asp:Label>
        </div>

    </asp:panel>
</asp:Content>
