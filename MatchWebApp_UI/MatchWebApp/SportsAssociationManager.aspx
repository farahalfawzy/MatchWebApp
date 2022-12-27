<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SportsAssociationManager.aspx.cs" Inherits="MatchWebApp.sportsAssociationManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            to add a match please enter the hostclub name, guest club name,start and end time of the match then click add match <br />
            <br />
            host club:<br />
            <asp:TextBox ID="hostClub" runat="server"></asp:TextBox>
        <br />
            guest club:<br />
            <asp:TextBox ID="guestClub" runat="server"></asp:TextBox>
            <br />
            start time:<br />
            <asp:TextBox ID="startTime" runat="server" placeholder="From" type="time"></asp:TextBox>

        <br />
            end time:<br />
                    <asp:TextBox ID="endTime" runat="server" placeholder="From" type="time"></asp:TextBox>
         <br />
            Date of match:<br />
                    <asp:TextBox ID="DateOfMatch" runat="server" placeholder="From" type="date"></asp:TextBox>

      

            <asp:Button ID="Button1" runat="server" Text="add match" OnClick="Button1_Click" />

        <asp:label ID="label1" runat="server"></asp:label>
        <br />
        <br />
        <br />
        <br />
        <br />
         
      
        to delete a match please enter the hostclub name, guest club name,start and end time of the match then click add match <br />
              <br />
            host club:<br />
            <asp:TextBox ID="hostClub1" runat="server"></asp:TextBox>
        <br />
            guest club:<br />
            <asp:TextBox ID="guestClub1" runat="server"></asp:TextBox>
            <br />
            start time:<br />
            <asp:TextBox ID="startTime1" runat="server" placeholder="From" type="time"></asp:TextBox>

        <br />
            end time:<br />
            <asp:TextBox ID="endTime1" runat="server" placeholder="From" type="time"></asp:TextBox>
        <br />
            Date of match:<br />
                    <asp:TextBox ID="DateOfMatch1" runat="server" placeholder="From" type="date"></asp:TextBox>
         
            <asp:Button ID="Button2" runat="server" Text="delete match" />  
                  <asp:label ID="label2" runat="server"></asp:label>
        <div>
        </div>
    </form>
</body>
</html>