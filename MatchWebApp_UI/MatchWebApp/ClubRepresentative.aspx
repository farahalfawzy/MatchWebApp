<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clubRepresentative.aspx.cs" Inherits="MatchWebApp.clubRepresentative" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            background-color: #333333;
            color: #FFFFFF;
        }
    </style>
</head>
<body style="height: 446px; width: 644px;">
    <form id="form1" runat="server">
        <div style="height: 534px; width: 985px;">
            Club Representative
            <br />
            <br />
        <asp:Button ID="clubInfo" runat="server" Text="Show Club Info" OnClick="clubInfo_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Upcoming_Matches" runat="server" Text="Show Upcoming Matches" OnClick="Upcoming_Matches_Click" />
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="From" type="date" value="11-11-1900"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="From" type="time" ></asp:TextBox>
            <asp:Button ID="Stadiums" runat="server" Text="View Available Stadiums" OnClick="Stadiums_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="stadiumManagers" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="MatchTimes" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Req" runat="server" Text="Request" OnClick="Request_Click"/>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>
        <p style="height: 239px">
            &nbsp;</p>
        <p style="height: 239px">
            &nbsp;</p>
    </form>
</body>
</html>