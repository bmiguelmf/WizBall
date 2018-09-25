<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterView.Master" AutoEventWireup="true" CodeBehind="ViewHistory.aspx.cs" Inherits="WebApp.pages.ViewHistory" %>
<asp:Content ID="viewHistoryContentHead" ContentPlaceHolderID="masterViewContentHead" runat="server">
   
    <link rel="stylesheet" href="../Public/Styling/MatchesTipsGrid.css" />

</asp:Content>



<asp:Content ID="viewHistoryContentBody" ContentPlaceHolderID="masterViewContentBody" runat="server">

    <input type="date" name="startRange" ID="" value="2018-07-22" />

    <asp:PlaceHolder ID="placeHolderHistoryTips" runat="server"></asp:PlaceHolder>

</asp:Content>