<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerfan.aspx.cs" Inherits="MatchWebApp.registerfan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form2" runat="server">
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
            National ID:&nbsp;
            <asp:TextBox ID="NID" runat="server"></asp:TextBox>
            <br />
            <br />
            Phone number: <asp:TextBox ID="phoneno" runat="server"></asp:TextBox>
            <br />
            <br />
            Birthdate:
            <asp:TextBox ID="birthdate" runat="server" placeholder="From" type="date" value="11-11-1900"></asp:TextBox>
            <br />
            <br />
            Address:
            <asp:TextBox ID="add" runat="server"></asp:TextBox>
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
