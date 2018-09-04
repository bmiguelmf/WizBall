<%@ Page Title="" Language="C#" MasterPageFile="~/pages/CredMaster.Master" AutoEventWireup="true" CodeBehind="ProfileEdit.aspx.cs" Inherits="WebApp.pages.ProfileEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- FILE UPLOAD INPUT FOR USER PROFILE PICTURE -->
    <asp:fileupload id="ProfPic" runat="server" ></asp:fileupload>
    <asp:Button ID="PicBtn" runat="server" Text="Load Picture" OnClick="PicBtn_Click" />
    
    <!-- USERNAME INPUT -->
    <asp:Label Text="Username" CssClass="sr-only" runat="server" />
    <asp:TextBox TextMode="SingleLine" ID="inputUName" ClientIDMode="Static" runat="server" />

    <!-- EMAIL FIELD -->
    <asp:Label ID="EmailField" CssClass="sr-only" ClientIDMode="Static" Text="" runat="server" />
    <asp:TextBox ID="inputEmail" ClientIDMode="Static" TextMode="Email" runat="server" />

    <!-- PASSWORD INPUT -->
    <asp:Label Text="Password" CssClass="sr-only" runat="server" />
    <asp:TextBox TextMode="Password" ID="inputPWD" ClientIDMode="Static" runat="server" />

    <asp:Label Text="Confirm Password" CssClass="sr-only" runat="server" />
    <asp:TextBox TextMode="Password" ID="inputCPWD" ClientIDMode="Static" runat="server" />

    <!-- DIV CONTAINING ERRORS -->
    <asp:Panel ID="ErrorP" CssClass="sr-only" runat="server">
        <asp:Label ID="ErrorL" runat="server" Text=""></asp:Label>
    </asp:Panel>

    <!-- CHANGE CONFIRMATION BUTTON --> 
    <asp:Button ID="ConfButton" runat="server" Text="Load Picture" OnClick="PicBtn_Click"/>

</asp:Content>
