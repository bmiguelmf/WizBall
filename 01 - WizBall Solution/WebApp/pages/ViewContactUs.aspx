<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/pages/MasterView.Master"
    AutoEventWireup="true"
    CodeBehind="ViewContactUs.aspx.cs"
    Inherits="WebApp.pages.ContactUs" %>

<%-- Head content --%>
<asp:Content ID="viewContactUsContentHead" ContentPlaceHolderID="masterViewContentHead" runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Wizball</title>

    <link rel="shortcut icon" type="image/x-icon" href="../Public/Imgs/Wizball/logo_dark_ico.ico" />

    <!-- Bootstrap 4 -->
    <link href="../Public/Bootstrap/Bootstrap4.css" rel="stylesheet" />

    <!-- ViewLogin CSS Styling -->
    <link href="/Public/Styling/ViewLogin.css" rel="stylesheet" />

</asp:Content>



<%-- Body content--%>
<asp:Content ID="viewContactUsContentBody" ContentPlaceHolderID="masterViewContentBody" runat="server">

    <!-- Background Img -->
        <div id="background">
        </div>

        <asp:HiddenField ID="UNameHF" runat="server" />
        <asp:HiddenField ID="PWordHF" runat="server" />

        <!-- Registration form -->
        <div class="form-wrapper">

            <div class="form-body">

                <h5  runat="server">Edit profile</h5>
                <hr />

                <div class="form-user-picture">
                     
                    <asp:Image ID="imgUserPic" runat="server" />
                    <input type="file" id="fileuploadUserPicture" name="userPicture"  runat="server"/>
                    
                    <div class="customFileUpload">
                        <button type="button" id="btnCustomFileUpload"><i class="fas fa-upload" ></i> Upload your avatar</button>
                        <p id="upload-status"></p>
                    </div>
                    
                </div>

                <div class="form-groups">
                    <div class="sub-groups">
                         <asp:Label ID="lblName" CssClass="form-imputs-labels" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                        <asp:TextBox ID="txtName" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Name"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="nameStatus"></small></span>
                    </div>

                    <div class="sub-groups">
                        <asp:Label ID="lblEmail" CssClass="form-imputs-labels" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                    <asp:TextBox ID="txtEmail"  CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="emailStatus"></small></span>
                    </div>

                    <div class="sub-groups">
                        <asp:Label ID="lblSubject" CssClass="form-imputs-labels" runat="server" Text="What is the subject you wish to discuss?" AssociatedControlID="txtSubject"></asp:Label>
                        <asp:TextBox ID="txtSubject" Multiline="true" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Write the subject here..."></asp:TextBox>
                        <span class="status" style="color: orange"><small id="subjectStatus"></small></span>
                    </div>

                    <div class="sub-groups">
                        <asp:Label ID="lblMessage" CssClass="form-imputs-labels" runat="server" Text="What do you want to tell us?" AssociatedControlID="txtMessage"></asp:Label>
                        <asp:TextBox ID="txtMessage" Multiline="true" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Write your message here..."></asp:TextBox>
                        <span class="status" style="color: orange"><small id="messageStatus"></small></span>
                    </div>
                </div>
              
        

                 <div class="form-checkbox">
                     <div class="form-check">
                        <label class="form-check-label">
                            <input id="cbUserToggle"  class="form-check-input" type="checkbox" runat="server" />
                                Fill fields with User info
                        </label>
                    </div>

                </div>

                <asp:Button Text="text" CssClass="btn btn-success form-submit" ID="Send" OnClick="Send_Click" runat="server" />
            </div>
            
        </div>


        <!-- Javascript -->

</asp:Content>



<%-- Javascript content--%>
<asp:Content ID="viewContactUsContentJavascript" ContentPlaceHolderID="masterViewContentJavascript" runat="server">

    

</asp:Content>
