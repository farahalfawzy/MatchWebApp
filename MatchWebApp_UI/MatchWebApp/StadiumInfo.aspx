<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumInfo.aspx.cs" Inherits="MatchWebApp.StadiumInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome,<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Stadium ID:<asp:Label ID="ID" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Stadium Name: <asp:Label ID="name" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Stadium Capacity:<asp:Label ID="cap" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Stadium Location:<asp:Label ID="location" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Stadium Status:<asp:Label ID="status" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
