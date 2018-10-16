<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterView.Master" AutoEventWireup="true" CodeBehind="ViewContactUs.aspx.cs" Inherits="WebApp.ViewContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="masterViewContentHead" runat="server">
    <!-- ViewContactUs CSS Styling -->
    <link href="/Public/Styling/ViewContactUs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterViewContentBody" runat="server">
    <!-- Background Img -->
    <div id="background">
    </div>

    <asp:hiddenfield id="UNameHF" clientidmode="Static" runat="server" />
    <asp:hiddenfield id="UEmailHF" clientidmode="Static" runat="server" />

    <!-- Registration form -->
    <div class="form-wrapper">

        <div class="form-body">

            <h5 runat="server">Contact Us</h5>
            <hr />

            <div class="form-user-picture">

                <asp:image id="imgUserPic" runat="server" />
                <asp:fileupload id="attachmentInp" clientidmode="Static" allowmultiple="true" name="AttachmentInp" runat="server" />

                <div class="customFileUpload">
                    <button type="button" id="btnCustomFileUpload"><i class="fas fa-upload"></i>Upload your avatar</button>
                    <p id="upload-status"></p>
                </div>

            </div>

            <div class="form-groups">
                <div class="sub-groups">
                    <asp:label id="lblName" clientidmode="Static" cssclass="form-imputs-labels" runat="server" text="Name" associatedcontrolid="txtName"></asp:label>
                    <asp:textbox id="txtName" name="txtName" cssclass="form-inputs form-control form-control-sm" runat="server" placeholder="Name"></asp:textbox>
                    <span class="status" style="color: orange"><small id="nameStatus"></small></span>
                </div>

                <div class="sub-groups">
                    <asp:label id="lblEmail" clientidmode="Static" cssclass="form-imputs-labels" runat="server" text="Email" associatedcontrolid="txtEmail"></asp:label>
                    <asp:textbox id="txtEmail" name="txtEmail" cssclass="form-inputs form-control form-control-sm" runat="server" placeholder="Email" textmode="Email"></asp:textbox>
                    <span class="status" style="color: orange"><small id="emailStatus"></small></span>
                </div>
                <div class="sub-groups">
                    <asp:label id="lblSubject" clientidmode="Static" cssclass="form-imputs-labels" runat="server" text="What is the subject you wish to discuss?" associatedcontrolid="txtSubject"></asp:label>
                    <asp:textbox id="txtSubject" multiline="true" cssclass="form-inputs form-control form-control-sm" runat="server" placeholder="Write the subject here..."></asp:textbox>
                    <span class="status" style="color: orange"><small id="subjectStatus"></small></span>
                </div>
                <div class="sub-groups">
                    <asp:label id="lblMessage" clientidmode="Static" cssclass="form-imputs-labels" runat="server" text="What do you want to tell us?" associatedcontrolid="txtMessage"></asp:label>
                    <asp:textbox id="txtMessage" style="height: 120px;" multiline="true" cssclass="form-inputs form-control form-textarea form-control-sm" runat="server" textmode="MultiLine" placeholder="Write your message here..."></asp:textbox>
                    <span class="status" style="color: orange"><small id="messageStatus"></small></span>
                </div>
            </div>

            <div class="form-attachment">


                <asp:button text="Send Message" cssclass="btn btn-success form-submit" id="Send" clientidmode="Static" onclick="Send_Click" runat="server" />


            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterViewContentJavascript" runat="server">
    <script src="../Public/Javascript/ViewContactUs.js"></script>
</asp:Content>
