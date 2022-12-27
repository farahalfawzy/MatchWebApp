<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="MatchWebApp.Fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Matches that still have available tickets!!



            <br />
            <br />
                        &nbsp;Date of the match :
                        <asp:TextBox ID="date" runat="server" placeholder="From" type="date" value="11-11-1900"></asp:TextBox>
        &nbsp;Time of the match:&nbsp; 
                  <asp:TextBox ID="time" runat="server" placeholder="From" type="time" ></asp:TextBox>


            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="View Matches & Purchase!" OnClick="Button1_Click" />

            <br />





        </div>
    </form>
</body>
</html>
