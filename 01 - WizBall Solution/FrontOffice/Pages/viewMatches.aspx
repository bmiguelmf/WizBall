<%@ Page 
    Title="" 
    Language="C#"
    MasterPageFile="~/Pages/Main.Master" 
    AutoEventWireup="true" 
    CodeBehind="ViewMatches.aspx.cs" 
    Inherits="FrontOffice.Pages.Default" 
%>



<%--Header--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src ="../Public/Javascript/ViewMatches.js"></script> 
    <link   href="../Public/Styling/ViewMatches.css" rel="stylesheet" />

</asp:Content>



<%--Body--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%-- Place holder competitions --%>
    <asp:PlaceHolder ID="phViewNextMatches" runat="server"></asp:PlaceHolder>


</asp:Content>

