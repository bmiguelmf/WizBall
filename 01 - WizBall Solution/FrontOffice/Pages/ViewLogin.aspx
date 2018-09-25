<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewLogin.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Log me in" OnClick="btnLogin_Click"/>
            
        </div>
    </form>
</body>
</html>
