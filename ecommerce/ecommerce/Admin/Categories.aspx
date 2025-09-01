<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="ecommerce.Admin.Categories" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Manage Categories</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav style="background-color:#f8f9fa; padding:10px;">
        <a href="Home.aspx">Home</a> |
        <a href="Login.aspx">Login</a> |
        <a href="Register.aspx">Register</a> |
        <a href="Cart.aspx">Cart</a> |
        <a href="Checkout.aspx">Checkout</a> |
        <a href="Admin/Dashboard.aspx">Admin</a> |
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    </nav>
        <div class="container mt-5 w-50">
            <h3 class="mb-4">Manage Categories</h3>
            <div class="mb-3">
                <label>Category Name</label>
                <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" CssClass="btn btn-success" OnClick="btnAddCategory_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block mt-2" />
            <hr />
            <asp:GridView ID="gvCategories" runat="server" CssClass="table table-bordered mt-3" AutoGenerateColumns="True" />
        </div>
    </form>
</body>
</html>
