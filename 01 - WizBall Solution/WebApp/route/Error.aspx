<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebApp.pages.Misc.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="error-container">
            
            

            <h1>
                <asp:Label Text="" ClientIDMode="Static" ID="ErrTitle" runat="server" /></h1>
            <p class="return"><asp:Label Text="" ClientIDMode="Static" ID="ErrBody" runat="server" /></p>
        </div>
    </form>
</body>
</html>
