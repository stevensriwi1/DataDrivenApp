<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertNewProductGetId.aspx.cs" Inherits="DataDrivenApp.Pages.InsertNewProductGetId" %>

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
            <asp:Button ID="addButton" runat="server" Text="Add Product To DB" OnClick="addButton_Click" />
            <br />
            <asp:Label ID="IdLabel" runat="server" Text="ID of new Product"></asp:Label>
        </div>
    </form>
</body>
</html>
