<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandleRequests.aspx.cs" Inherits="MatchWebApp.HandleRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 174px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            Welcome&nbsp;
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
&nbsp;<br />
            All Received Unhandled Requests:<br />
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" style="height: 9px" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td>Request No.</td>
            <td class="auto-style1"> Club Represantative </td>                        
            <td class="auto-style2"> Host Club name </td>            
            <td>Guest Club name</td> 
            <td>Match Start Time</td>   
            <td>Match End Time</td>   
            
            
        </tr>
                <%=getWhileLoopData()%>


    </table>
            <br />
            <br />
            Choose the number of request you want to handle:<br />
            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Request no.</asp:ListItem>
                
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;

            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="accept" runat="server" Text="accept" OnClick="accept_Click" Height="26px" Width="68px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="reject" runat="server" Text="reject" OnClick="reject_Click" Width="70px" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             </form>
</body>
</html>
