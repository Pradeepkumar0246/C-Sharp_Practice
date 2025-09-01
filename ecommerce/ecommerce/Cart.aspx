<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="ecommerce.Cart" %>

<!DOCTYPE html>
<html runat="server">
<head>
    <title>Your Cart</title>
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
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger btn-sm" OnClick="btnLogout_Click" />
        </nav>

        <div class="container mt-5">
            <h3>Your Cart</h3>
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                OnRowCommand="gvCart_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product" />
                    <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:ButtonField ButtonType="Button" CommandName="Remove" Text="Remove" />
                </Columns>
            </asp:GridView>

            <h5 class="text-end">Total: ₹ <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold text-success" /></h5>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger fw-bold"></asp:Label>
        </div>
    </form>
</body>
</html>
