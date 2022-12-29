<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allAvailableStadiums.aspx.cs" Inherits="MatchWebApp.allAvailableStadiums" %>

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
            All Available Stadiums
    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >                      
            <td class="auto-style2">Name</td> 
            <td>Loc</td>   
            <td>Capacity</td> 

        </tr>
                <%=getWhileLoopData()%> 

    </table>
            </div>
    </form>
</body>
</html>

