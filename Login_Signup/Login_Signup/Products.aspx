<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ec.Products" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Products</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f9f9f9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <% if (Session["mailid"] != null && Session["mailid"].ToString() == "admin@gmail.com") { %>
        <div class="container mt-3 d-flex justify-content-end">
            <a href="Default.aspx" class="btn btn-outline-primary me-2">Home</a>
            <a href="Categories.aspx" class="btn btn-outline-secondary me-2">Manage Categories</a>
        </div>
    <% } %>
        <div class="container mt-5">
            <h2 class="mb-4 text-primary">Product Management</h2>

            <div class="row g-3 mb-4">
                <div class="col-md-2">
                    <asp:TextBox ID="txtProductID" runat="server" CssClass="form-control" placeholder="Product ID (for Update/Delete)"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtPName" runat="server" CssClass="form-control" placeholder="Product Name"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Price"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" placeholder="Quantity"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" placeholder="Category"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtImagePath" runat="server" CssClass="form-control" placeholder="Image Path (URL)"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="btn btn-success me-2" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update Product" CssClass="btn btn-warning me-2" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete Product" CssClass="btn btn-danger me-2" OnClick="btnDelete_Click" />
                <asp:Button ID="btnCount" runat="server" Text="Count Products" CssClass="btn btn-info" OnClick="btnCount_Click" />
            </div>
            <asp:Label ID="lblCount" runat="server" CssClass="fw-bold text-primary"></asp:Label>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger fw-bold"></asp:Label>
            <asp:Label ID="Label1" runat="server" CssClass="fw-bold text-primary d-block mb-2"></asp:Label>

            <asp:GridView ID="gvProducts" runat="server" CssClass="table table-bordered mt-4" AutoGenerateColumns="true"></asp:GridView>
        </div>
    </form>
</body>
</html>
