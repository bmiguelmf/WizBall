<%@ Page 
    Title="" 
    Language="C#"
    MasterPageFile="~/Pages/Main.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="FrontOffice.Pages.Default" 
%>



<%--Header--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>



<%--Body--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%-- Place holder competitions --%>
    <asp:PlaceHolder ID="phCompetitions" runat="server"></asp:PlaceHolder>


    <%-- Place holder matches list --%>
    <asp:PlaceHolder ID="phMatchesList" runat="server"></asp:PlaceHolder>


</asp:Content>

