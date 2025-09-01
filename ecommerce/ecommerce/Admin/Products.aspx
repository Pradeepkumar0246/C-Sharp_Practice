<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="ecommerce.Admin.Products" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Manage Products</title>
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
            <h3>Add / Update Product</h3>

            <asp:HiddenField ID="hfProductId" runat="server" />

            <div class="mb-2">
                <label>Product Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-2">
                <label>Description</label>
                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-2">
                <label>Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-2">
                <label>Image URL</label>
                <asp:TextBox ID="txtImage" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-2">
                <label>Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select" />
            </div>

            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block mt-2" />

            <hr />
            <h4 class="mt-4">Product List</h4>
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="true" CssClass="table table-striped" />
        </div>
    </form>
</body>
</html>
