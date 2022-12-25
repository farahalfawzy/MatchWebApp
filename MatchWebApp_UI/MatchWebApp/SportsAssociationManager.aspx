<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sportsAssociationManager.aspx.cs" Inherits="MatchWebApp.sportsAssociationManager" %>

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
             <asp:TextBox type="date" ID="startTime" runat="server" ></asp:TextBox>

        <br />
            end time:<br />
            <asp:TextBox type="date" ID="endTime" runat="server" ></asp:TextBox>
         
        <asp:Button id="b1" Text="add match" runat="server" OnClick="b1_Click" />
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
             <asp:TextBox type="date" ID="endTime1" runat="server" ></asp:TextBox>

        <br />
            end time:<br />
            <asp:TextBox type="date" ID="startTime1" runat="server" ></asp:TextBox>
         
             <asp:Button ID="Button1" runat="server" Text="delete match" OnClick="Button1_Click" />




                
                  <asp:label ID="label2" runat="server"></asp:label>

        <div>
        </div>
    </form>
</body>
</html>