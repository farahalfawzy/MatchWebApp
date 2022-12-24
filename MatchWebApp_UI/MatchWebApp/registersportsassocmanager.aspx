<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registersportsassocmanager.aspx.cs" Inherits="MatchWebApp.registersportsassocmanager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            Please fill the following form to register<br />
            <br />
            Name:&nbsp;&nbsp;
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <br />
            Username:&nbsp;&nbsp;
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp;
            <asp:TextBox ID="Password" runat="server" TextMode="Password" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            <br />
        </div>
    </form>
</body>
</html>
