<%@ Page 
    Title="" 
    Language="C#"
    MasterPageFile="~/Pages/MasterView.Master" 
    AutoEventWireup="true" 
    CodeBehind="ViewMatches.aspx.cs" 
    Inherits="FrontOffice.Pages.Default" 
%>



<%--Header--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src ="../Public/Javascript/GridNextMatchesControl.js"></script> 
    <link   href="../Public/Styling/GridNextMatchesControl.css" rel="stylesheet" />

</asp:Content>



<%--Body--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterViewPlaceHolderNextMatches" runat="server">


    <%-- Place holder GridNextMatchesControl--%>
    <asp:PlaceHolder ID="phGridNextMatchesControl" runat="server" ></asp:PlaceHolder>


</asp:Content>

