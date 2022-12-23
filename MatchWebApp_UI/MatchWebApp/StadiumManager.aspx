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
            <asp:Button ID="Stadinfo" runat="server" Text="Stadium Information" OnClick="Stadinfo_Click" />
            <br />
            <br />
            <asp:Button ID="allreq" runat="server" Text="      All requests      " />
            <br />
            <br />
            <asp:Button ID="allreq0" runat="server" Text="  Accept a request  " />
            <br />
            <br />
            <asp:Button ID="allreq1" runat="server" Text="  Reject a request  " Width="175px" />
        </div>
    </form>
</body>
</html>
