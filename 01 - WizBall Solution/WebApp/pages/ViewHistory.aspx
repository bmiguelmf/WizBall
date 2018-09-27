<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterView.Master" AutoEventWireup="true" CodeBehind="ViewHistory.aspx.cs" Inherits="WebApp.pages.ViewHistory" %>

<asp:Content ID="viewHistoryContentHead" ContentPlaceHolderID="masterViewContentHead" runat="server">

    <link rel="stylesheet" href="../Public/Styling/MatchesTipsGrid.css" />

</asp:Content>



<asp:Content ID="viewHistoryContentBody" ContentPlaceHolderID="masterViewContentBody" runat="server">

    <div class="container mt-3">
        <asp:Panel CssClass="alert alert-dark" runat="server">
        <div class="card-body third">
            <input type="date" name="startRange" id="startRange" runat="server" />

            <input type="date" name="endRange" id="endRange" value="2005/6/6" runat="server" />

            <asp:Button Text="Filtrar" id="Filter_Btn" OnClick="Filter_Btn_Click" runat="server" />
        </div>
            
        </asp:Panel>
    </div>




    <asp:PlaceHolder ID="placeHolderHistoryTips" runat="server"></asp:PlaceHolder>

</asp:Content>
