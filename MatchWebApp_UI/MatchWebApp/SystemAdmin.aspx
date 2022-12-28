<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemAdmin.aspx.cs" Inherits="MatchWebApp.SystemAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            System Admin Page
            <br />
            <br />
            <br />
            <br />
            <br />
            Add Club
            <br />
            <br />
Name
            <br />
            <asp:TextBox ID="Club_name" runat="server" OnTextChanged="Club_name_TextChanged"></asp:TextBox>
      
            <br />
Location
            <br />
            <asp:TextBox ID="Location" runat="server" OnTextChanged="Location_TextChanged"></asp:TextBox>
        
            <asp:Button ID="add_new_club" runat="server" Text="Add" OnClick="add_new_club_Click" />
            <br />
            <br />
            <br />
            <br />
            Delete Club
            <br />
            <br />
            
            Name
            <br />
            <asp:TextBox ID="delete_club" runat="server" OnTextChanged="delete_club_TextChanged"></asp:TextBox>
            
            <asp:Button ID="delete" runat="server" Text="delete" OnClick="delete_Click" />
            <br />
            <br />
            <br />
            Add new Stadium
            <br />
            <br />
            Stadium name
            <br />
            <asp:TextBox ID="Stadium_name" runat="server" OnTextChanged="Stadium_name_TextChanged"></asp:TextBox>
            <br />
            Location
            <br />
            <asp:TextBox ID="Stadium_location" runat="server" OnTextChanged="Stadium_location_TextChanged"></asp:TextBox>
            <br />
            Capacity 
            <br />
            <asp:TextBox ID="Stadium_capacity" runat="server" OnTextChanged="Stadium_capacity_TextChanged"></asp:TextBox>
        
            <asp:Button ID="add_stadium" runat="server" Text="add" OnClick="add_stadium_Click" />
            <br />
            <br />
            <br />
            <br />
            Delete Stadium
            <br />
            <br />
            Stadium name
            <br />
            <asp:TextBox ID="Delete_stadium_name" runat="server" OnTextChanged="Delete_stadium_name_TextChanged"></asp:TextBox>
            
            <asp:Button ID="delete_stadium" runat="server" Text="delete" OnClick="delete_stadium_Click" />
            <br />
            <br />
            <br />
            <br />
            Block Fan<br />
            <br />
            National ID
            <br />
            <asp:TextBox ID="Block_national_id" runat="server" OnTextChanged="Block_national_id_TextChanged"></asp:TextBox>
        
            <asp:Button ID="Block_fan" runat="server" Text="Block" OnClick="Block_fan_Click" />
        </div>
        <p>
            &nbsp;</p>
        <p style="height: 146px">
            &nbsp;</p>
        <p style="height: 146px">
            &nbsp;</p>
        <p style="height: 146px">
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>