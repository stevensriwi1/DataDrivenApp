<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="DataDrivenApp.Pages.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="name" runat="server" Text="name: "></asp:Label>
            <asp:TextBox ID="nameTextbox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="description" runat="server" Text="description: "></asp:Label>
            <asp:TextBox ID="descriptionTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="price" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="priceTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="addButton" runat="server" Text="Add To Session" OnClick="addButton_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="List of products in session"></asp:Label>
            <asp:Button ID="saveButton" runat="server" Text="save to DB" OnClick="saveButton_Click" />
            <br />
            <asp:BulletedList ID="productBulletedList" runat="server"></asp:BulletedList>
            <br />
            
        </div>
        
    </form>
</body>
</html>
