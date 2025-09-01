<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ecommerce.ProductDetails" %>

<!DOCTYPE html>
<html>
<head>
    <title>Product Details</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5" style="max-width:600px;">
            <h3 class="text-center mb-4">Product Details</h3>

            <asp:Image ID="imgProduct" runat="server" CssClass="img-fluid mb-3" Style="height: 300px;" />

            <div class="mb-2 fw-bold">Name: <asp:Label ID="lblName" runat="server" /></div>
            <div class="mb-2 fw-bold">Price: ₹ <asp:Label ID="lblPrice" runat="server" /></div>
            <div class="mb-3">Description: <asp:Label ID="lblDescription" runat="server" /></div>

            <div class="mb-3">
                Quantity:
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" Text="1" />
            </div>

            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-primary" OnClick="btnAddToCart_Click" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success fw-bold" />
        </div>
    </form>
</body>
</html>
