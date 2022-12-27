<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMatches.aspx.cs" Inherits="MatchWebApp.ViewMatches" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td class="auto-style1"> Host Club name </td>                        
            <td class="auto-style2"> Guest Club name </td>            
            <td>Stadium name</td> 
            <td>Stadium Location</td>    

        </tr>
                <%=getWhileLoopData()%>

    </table>
        </div>
        <br />
        To Purchase Ticket choose Stadium the match will be played on<br />
        <br />
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Purchase" OnClick="Button1_Click" />
    </form>
</body>
</html>
