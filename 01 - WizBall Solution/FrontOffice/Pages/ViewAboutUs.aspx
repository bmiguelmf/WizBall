<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterView.Master" AutoEventWireup="true" CodeBehind="ViewAboutUs.aspx.cs" Inherits="FrontOffice.Pages.ViewAboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="masterViewContentHead" runat="server">
    <link href="../Public/Styling/ViewAboutUs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterViewContentBody" runat="server">
    <div class="form-body">

        <h5 id="FormTitle" runat="server">About Us</h5>
        <hr />

        <h2 class="text-center"><i>WizBall Project</i> </h2>
        <div class="AUTxt">
            <p>
                This project was born out of our client's (<i>Ricardo Batista</i>) necessity to have a better Tips system.
                The system he was using, beyond lacking automation and practicality, was prone to failures and, as such, he desired to create a solution that was automated and could learn and improve from past matches.
            </p>

            <p>
                That's why he came to us with the concept of this project. He invited us to create a project that was soon named <i>WizBall</i> (sort of a play of words with "Ball Wizard").<br />
            </p>
            <p>
                We accepted this challenge and from it came the FrontOffice (that is what you are visiting right now) and the BackOffice (the Control Panel for administration), which both give substance to the application, in terms of usability.
            </p>
        </div>

        <div class="images">
            <asp:Image ImageUrl="~/Public/Imgs/Wizball/logo.png" runat="server" />
            <%--<div class="vl"></div>--%>
            <asp:Image ImageUrl="~/Public/Imgs/Wizball/logoLogin.png" runat="server" />
        </div>
        
        <div class="people">
            <hr />
            <div>

                <ul>
                    <li><span class="blT">Ricardo Baptista:</span> Our Client;</li>
                    <li></li>
                    <li><span class="blT">Bruno Ferreira:</span> Project Manager, also responsible for the Business Logic and DAL along with help on the FrontOffice design;</li>
                    <li><span class="blT">João Santos:</span> Responsible for the FrontOffice;</li>
                    <li><span class="blT">Luís Passeira:</span> Responsible for the BackOffice.</li>
                </ul>

            </div>

        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterViewContentJavascript" runat="server">
</asp:Content>
