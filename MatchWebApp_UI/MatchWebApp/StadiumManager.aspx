<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="MatchWebApp.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 356px; width: 510px; margin-left: 0px">
            <br />
            Welcome,<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Stadinfo" runat="server" Text="Show Stadium Info" OnClick="Stadinfo_Click" />
            <br />
            <br />
            <asp:Button ID="allreq" runat="server" Text="      All requests      " OnClick="allreq_Click" />
            <br />
            <br />
            <asp:Button ID="handle" runat="server" Text="  handle a request  " OnClick="allreq0_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
