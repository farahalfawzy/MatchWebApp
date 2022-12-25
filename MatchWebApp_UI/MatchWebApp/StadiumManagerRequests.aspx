<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManagerRequests.aspx.cs" Inherits="MatchWebApp.StadiumManagerRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 177px;
        }
        .auto-style2 {
            width: 113px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
        <div style="height: 28px">
            Welcome,<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            </br>
            All Received Requests
    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td class="auto-style1"> Club Represantative </td>                        
            <td class="auto-style2"> Host Club name </td>            
            <td>Guest Club name</td> 
            <td>Match Start Time</td>   
            <td>Match End Time</td>   
            <td>Status</td>   

        </tr>
                <%=getWhileLoopData()%>

    </table>
        </div>
    </form>
</body>
</html>
