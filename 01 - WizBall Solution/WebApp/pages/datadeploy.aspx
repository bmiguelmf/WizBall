<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datadeploy.aspx.cs" Inherits="WebApp.datadeploy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="InAreas" runat="server" Text="InAreas" OnClick="InAreas_Click" />
            <asp:Button ID="InSeasons" runat="server" Text="InSeasons" OnClick="InSeasons_Click" />
            <asp:Button ID="InComps" runat="server" Text="InComps" OnClick="InComps_Click" />
            <asp:Button ID="InTeams" runat="server" Text="InTeams" OnClick="InTeams_Click" />
        </div>
    </form>
</body>
</html>
