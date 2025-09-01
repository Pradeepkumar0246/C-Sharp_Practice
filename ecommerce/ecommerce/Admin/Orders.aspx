<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="ecommerce.Admin.Orders" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>All Orders</title>
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
            <h3 class="mb-4">Customer Orders</h3>
            <asp:GridView ID="gvOrders" runat="server" CssClass="table table-bordered" AutoGenerateColumns="true" />
        </div>
    </form>
</body>
</html>
