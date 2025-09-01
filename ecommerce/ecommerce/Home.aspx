<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="ecommerce.Home" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html>
<html runat="server">
<head>
    <title>Home</title>
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
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger btn-sm" />
        </nav>

        <div class="container mt-4">
            <h4>Welcome, <asp:Label ID="lblWelcome" runat="server" CssClass="fw-bold text-primary" /></h4>

            <div class="input-group mb-4 mt-3">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search products..." />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
            </div>

            <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div class="card d-inline-block m-2" style="width: 18rem;">
                        <img src='<%# Eval("ImageUrl") %>' class="card-img-top" style="height:180px;" />
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Name") %></h5>
                            <p class="card-text">₹ <%# Eval("Price") %></p>
                            <a href='ProductDetails.aspx?pid=<%# Eval("ProductId") %>' class="btn btn-sm btn-outline-primary">View</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
