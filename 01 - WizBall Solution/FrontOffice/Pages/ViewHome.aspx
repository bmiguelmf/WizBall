<%@ Page 
    Title="" 
    Language="C#" 
    MasterPageFile="~/Pages/MasterView.Master" 
    AutoEventWireup="true" 
    CodeBehind="ViewHome.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewHome" %>




<asp:Content ID="viewHomeContentHead" ContentPlaceHolderID="masterViewContentHead" runat="server">
   
    <link rel="stylesheet" href="../Public/Styling/MatchesTipsGrid.css" />

</asp:Content>




<asp:Content ID="viewHomeContentBody" ContentPlaceHolderID="masterViewContentBody" runat="server">

    <asp:PlaceHolder ID="placeHolderMatchesTipsGrid" runat="server"></asp:PlaceHolder>

</asp:Content>




<asp:Content ID="viewHomeContentJavascript" ContentPlaceHolderID="masterViewContentJavascript" runat="server">

    <script src="../Public/Javascript/MatchesTipsGrid.js"></script>

</asp:Content>