<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterView.Master" AutoEventWireup="true" CodeBehind="ViewAboutUs.aspx.cs" Inherits="FrontOffice.Pages.ViewAboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="masterViewContentHead" runat="server">
    <link href="../Public/Styling/ViewAboutUs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterViewContentBody" runat="server">
    <div class="form-body">

        <h5 id="FormTitle" runat="server">About Us</h5>
        <hr />

        <h2 class="text-center"><i>WizBall Project</i> </h2>
        <span class="AUTxt">
            <p>
                <i>Ricardo Batista</i> was using a non-practical and non-automated system to generate the tips for the matches.
            This system was prone to failures and, as such, he desired to create a solution that was automated.
            </p>

            <p>
                That's when he came to us with the concept of this project. He invited us to create a project that was soon named <i>WizBall</i> (sort of a play of words with "Ball Wizard").<br />
                We accepted this challenge and from it came the FrontOffice (that is what you are visiting right now) and the BackOffice (the Control Panel for administration), which both gisve substance to the application 
            </p>
        </span>

        <div class="images">
            <asp:Image ImageUrl="~/Public/Imgs/Wizball/logo.png" runat="server" />
            <%--<div class="vl"></div>--%>
            <asp:Image ImageUrl="~/Public/Imgs/Wizball/logoLogin.png" runat="server" />
           
        </div>


        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterViewContentJavascript" runat="server">
</asp:Content>
