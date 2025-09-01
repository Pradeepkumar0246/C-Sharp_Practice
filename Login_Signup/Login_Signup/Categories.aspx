<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ec.Categories" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Categories</title>
    <style>
        body {
            font-family: Arial;
            background-color: #f4f4f4;
            padding: 20px;
        }
        .form-group {
            margin-bottom: 10px;
        }
        input, button {
            padding: 8px;
            width: 250px;
        }
        table {
            width: 60%;
            margin-top: 20px;
            border-collapse: collapse;
        }
        th, td {
            border: 1px solid #ccc;
            padding: 10px;
            background: white;
        }
        .nav-buttons {
    margin-top: 10px;
    margin-bottom: 20px;
    text-align: right;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <% if (Session["mailid"] != null && Session["mailid"].ToString() == "admin@gmail.com") { %>
    <div class="nav-buttons text-end">
        <a href="Default.aspx" class="btn btn-outline-primary me-2">Home</a>
        <a href="Products.aspx" class="btn btn-outline-secondary">Manage Products</a>
    </div>
<% } %>
        <h2>Category Management</h2>

        <div class="form-group">
            <asp:Label Text="Category ID (for Update/Delete):" runat="server" />
            <asp:TextBox ID="txtCategoryID" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label Text="Category Name:" runat="server" />
            <asp:TextBox ID="txtCategoryName" runat="server" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add Category" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Category" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Category" OnClick="btnDelete_Click" />
        </div>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

        <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="true" />
    </form>
</body>
</html>
