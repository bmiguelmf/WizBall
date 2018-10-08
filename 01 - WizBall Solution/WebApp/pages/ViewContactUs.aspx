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
                        <span class="status" style="color: orange"><small id="usernameStatus"></small></span>
                    </div>

                    <div class="sub-groups">
                        <asp:Label ID="lblEmail" CssClass="form-imputs-labels" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                    <asp:TextBox ID="txtEmail"  CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="emailStatus"></small></span>
                    </div>

                    <div class="sub-groups">
                        <asp:Label ID="lblMessage" CssClass="form-imputs-labels" runat="server" Text="What do you want to tell us?" AssociatedControlID="txtMessage"></asp:Label>
                        <asp:TextBox ID="txtMessage" Multiline="true" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Write your message here..."></asp:TextBox>
                        <span class="status" style="color: orange"><small id="passwordStatus"></small></span>
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


               <button type="button" id="btnSubmit" class="btn btn-success form-submit" onclick="IsFormValid();" >Submit</button>
                            
            </div>
            
        </div>

         
        
        <!-- Modal update profile confirmation -->
        <div id="outter-modal" class="outter-modal">

            <div id="inner-modal">

                <div id="modal-header">
                    <a href="/Pages/ViewHome.aspx">
                        <img id="modal-logo" src="/Public/Imgs/Wizball/logo_dark.png" />
                    </a>
                </div>


                <div id="modal-message">
                    <p id="modal-primary-message">Update confirmation</p>
                    <input type="password" id="currentPassword" placeholder="Current password" class="form-control form-control-sm" />
                    <span class="currentPasswordStatus" style="color: orange"><small id="currentPasswordStatus"></small></span>
                </div>

                
                <div id="modal-footer">
     
                    <button type="button" id="btnModalCancel" class="btn btn-danger btn-sm modal-btn"><i class="fas fa-undo"></i> Cancel</button>        
                    <button type="submit" id="btnModalConfirm" class="btn btn-success btn-sm modal-btn" onclick="return passwordValitation();"><i class="fas fa-check"></i> Confirm</button>
               
                </div>
                
            </div>

        </div>



        <!-- Javascript -->
        <script src="/Public/Javascript/ViewEditProfile.js"></script>

</asp:Content>



<%-- Javascript content--%>
<asp:Content ID="viewContactUsContentJavascript" ContentPlaceHolderID="masterViewContentJavascript" runat="server">

    <script src="../Public/Javascript/MatchesTipsGrid.js"></script>

</asp:Content>
