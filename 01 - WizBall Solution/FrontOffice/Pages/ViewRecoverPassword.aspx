<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewRecoverPassword.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewRecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="txtEmail" runat="server" TextMode="Password" placeholder="Email"></asp:TextBox>

            <asp:Button ID="btnRecover" runat="server" Text="Recover"/>

            <asp:Label ID="lblStatus" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
