<%@ Page Title=""
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ViewContactUs.aspx.cs"
    Inherits="WebApp.pages.ContactUs" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<%-- Head content --%>
<head>
    <title>WizBall</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Wizball</title>

    <link rel="shortcut icon" type="image/x-icon" href="../Public/Imgs/Wizball/logo_dark_ico.ico" />

    <!-- Bootstrap 4 -->
    <link href="../Public/Bootstrap/Bootstrap4.css" rel="stylesheet" />

    <!-- ViewLogin CSS Styling -->
    <link href="/Public/Styling/ViewContactUs.css" rel="stylesheet" />
</head>
<body onload="CheckUser()">
    <%-- Body content--%>
    <form id="form1" runat="server">

        <!-- Background Img -->
        <div id="background">
        </div>

        <asp:HiddenField ID="UNameHF" ClientIDMode="Static" runat="server" />
        <asp:HiddenField ID="UEmailHF" ClientIDMode="Static" runat="server" />

        <!-- Registration form -->
        <div class="form-wrapper">

            <div class="form-body">

                <h5 runat="server">Contact Us</h5>
                <hr />


                <div class="form-checkbox">
                    <div class="form-check">
                        <label class="" style="color: white;">
                            <input id="cbUserToggle" onload="CheckUser()" name="UserDetChkBox" type="checkbox" /> Fill fields with User info
                        </label>
                        <label class="form-check-label" style="color: white;">
                            <asp:FileUpload ID="attachmentInp" ClientIDMode="Static" AllowMultiple="true" name="AttachmentInp" runat="server" />
                        </label>
                        
                    </div>
                </div>

                <div class="form-groups">
                    <div class="sub-groups">
                        <asp:Label ID="lblName" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                        <asp:TextBox ID="txtName" name="txtName" CssClass="form-inputs form-control form-control-sm" runat="server" placeholder="Name"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="nameStatus"></small></span>
                    </div>

                    <div class="sub-groups">
                        <asp:Label ID="lblEmail" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                        <asp:TextBox ID="txtEmail" name="txtEmail" CssClass="form-inputs form-control form-control-sm" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="emailStatus"></small></span>
                    </div>
                    <div class="sub-groups">
                        <asp:Label ID="lblSubject" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="What is the subject you wish to discuss?" AssociatedControlID="txtSubject"></asp:Label>
                        <asp:TextBox ID="txtSubject" Multiline="true" CssClass="form-inputs form-control form-control-sm" runat="server" placeholder="Write the subject here..."></asp:TextBox>
                        <span class="status" style="color: orange"><small id="subjectStatus"></small></span>
                    </div>
                    <div class="sub-groups">
                        <asp:Label ID="lblMessage" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="What do you want to tell us?" AssociatedControlID="txtMessage"></asp:Label>
                        <asp:TextBox ID="txtMessage" Style="height: 120px;" Multiline="true" CssClass="form-inputs form-control form-textarea form-control-sm" runat="server" TextMode="MultiLine" placeholder="Write your message here..."></asp:TextBox>
                        <span class="status" style="color: orange"><small id="messageStatus"></small></span>
                    </div>
                </div>

                <div class="form-attachment">
                    

                    <asp:Button Text="Send Message" CssClass="btn btn-success form-submit" ID="Send" ClientIDMode="Static" OnClick="Send_Click" runat="server" />


                </div>
            </div>
        </div>

    </form>
    <!-- Javascript -->

    <script type="text/javascript">
        const UserDetChkBox = document.getElementById("cbUserToggle");
        var txtName = document.getElementById("txtName");
        var txtEmail = document.getElementById("txtEmail");
        var UNameHF = document.getElementById("UNameHF");
        var UEmailHF = document.getElementById("UEmailHF");
        var oldNameVal = "";
        var oldEmailVal = "";

        document.addEventListener("load", CheckUser);

        function CheckUser() {
            if (UNameHF.value == "guestXwb") {
                UserDetChkBox.disabled = true;
            }
        }



        UserDetChkBox.addEventListener('change', (event) => {
            if (event.target.checked) {
                oldNameVal = txtName.value;
                oldEmailVal = txtEmail.value;
                txtName.value = UNameHF.value;
                txtEmail.value = UEmailHF.value;
                txtName.disabled = true;
                txtEmail.disabled = true;
            } else {
                txtName.value = oldNameVal;
                txtEmail.value = oldEmailVal;
                txtName.disabled = false;
                txtEmail.disabled = false;
            }
        })

    </script>





    <%-- Javascript content--%>
</body>

</html>












