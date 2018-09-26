<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewRegistration.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Wizball</title>

    <script src="../Public/jQuery/jQuery.min.js"></script>

    <link rel="shortcut icon" type="image/x-icon" href="../Public/Imgs/Wizball/logo_dark_ico.ico" />

     <!-- Bootstrap 4 -->
    <link href="../Public/Bootstrap/Bootstrap4.css" rel="stylesheet" />

    <!-- CSS -->
    <link href="/Public/Styling/ViewRegistration.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        
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



<%--        <!-- Trigger/Open The Modal -->
        <button type="button" id="myBtn" >Open Modal</button>--%>

        <!-- The Modal -->
        <div id="myModal" class="modal">

          <!-- Modal content -->
          <div class="modal-content">
            <span id="close">&times;</span>
            <h2>Registration successful!</h2>
            <h4>Thank You...</h4>
          </div>

        </div>



        <!-- Javascript -->
        <script src="/Public/Javascript/ViewRegistration.js"></script>

    </form>
</body>
</html>
