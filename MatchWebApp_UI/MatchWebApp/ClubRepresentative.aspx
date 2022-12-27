<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentative.aspx.cs" Inherits="MatchWebApp.ClubRepresentative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:TextBox ID="TextBox1" runat="server" placeholder="From" type="date" value="11-11-1900"></asp:TextBox>
            <asp:Button ID="Stadiums" runat="server" Text="View Available Stadiums" OnClick="Stadiums_Click" />
    </form>
</body>
</html>
