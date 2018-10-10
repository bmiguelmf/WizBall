﻿<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewRegistration.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Wizball</title>

    <link rel="shortcut icon" type="image/x-icon" href="../Public/Imgs/Wizball/logo_dark_ico.ico" />

    <!-- jQuery -->
    <script src="../Public/jQuery/jQuery.min.js"></script>

    <!-- Bootstrap 4 -->
    <link href="../Public/Bootstrap/Bootstrap4.css" rel="stylesheet" />

    <!-- Fontawesome -->
    <link href="../Public/Fontawesome/css/all.min.css" rel="stylesheet" />

    <!-- ViewRegistration CSS Styling -->
    <link href="/Public/Styling/ViewRegistration.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        
        <!-- Background Img -->
        <div id="background">
        </div>

        <!-- Registration form -->
        <div class="form-wrapper">

            <div class="form-header">
                
                <a title="Home" href="/Pages/ViewHome.aspx"><img src="../Public/Imgs/Wizball/logo_dark.png" /></a>
           
            </div>
           
            <div class="form-body">

                <h5  runat="server">User registration</h5>
                <hr />
                
                <div class="form-groups">
                    <asp:Label ID="lblUsername" CssClass="form-imputs-labels" runat="server" Text="Username" AssociatedControlID="txtUsername"></asp:Label>
                    <asp:TextBox ID="txtUsername" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Username"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="usernameStatus"></small></span>
                </div>

                <div class="form-groups">
                    <asp:Label ID="lblEmail" CssClass="form-imputs-labels" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                    <asp:TextBox ID="txtEmail"  CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="emailStatus"></small></span>
                </div>

                <div class="form-groups">
                    <asp:Label ID="lblPassword" CssClass="form-imputs-labels" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
                    <asp:TextBox ID="txtPassword" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="passwordStatus"></small></span>
                </div>
                

               <asp:Button ID="btnSubmit" CssClass="btn btn-success form-submit" runat="server" Text="Submit" OnClientClick="return IsFormValid();" />
                            
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
        <script src="/Public/Javascript/ViewRegistration.js"></script>

    </form>
</body>
</html>
