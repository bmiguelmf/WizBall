<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewRegistration.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="txtUsername"   runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtEmail"      runat="server" placeholder="Email"      TextMode="Email"></asp:TextBox>
            <asp:TextBox ID="txtPassword"   runat="server" placeholder="Password"   TextMode="Password"></asp:TextBox>

            <asp:Button ID="btnRegistration" runat="server" Text="Confirm" />

            <asp:Label ID="lblStatus" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
