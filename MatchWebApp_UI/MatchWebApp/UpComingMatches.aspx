<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpComingMatches.aspx.cs" Inherits="MatchWebApp.UpComingMatches" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 28px">
            <br />
            </br>
            All Upcoming Matches
    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >                      
            <td class="auto-style2"> Host Club name </td>            
            <td>Guest Club name</td> 
            <td>Match Start Time</td>   
            <td>Match End Time</td>   
            <td>Stadium</td>   

        </tr>
                <%=getWhileLoopData()%>

    </table>
            </div>
    </form>
</body>
</html>