<!-- File: Admin/Dashboard.aspx -->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="ecommerce.Admin.Dashboard" %>
<!DOCTYPE html>
<html>
<head>
    <title>Admin Dashboard</title>
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
    <div class="container mt-5">
        <h2>Welcome, Admin</h2>
        <p>Use the links below to manage:</p>
        <ul>
            <li><a href="Products.aspx">Manage Products</a></li>
            <li><a href="Categories.aspx">Manage Categories</a></li>
            <li><a href="Orders.aspx">View Orders</a></li>
        </ul>
    </div>
</form>
</body>
</html>
