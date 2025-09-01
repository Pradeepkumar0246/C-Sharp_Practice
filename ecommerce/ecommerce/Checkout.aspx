<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="ecommerce.Checkout" %>

<!DOCTYPE html>
<html>
<head>
    <title>Checkout</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h3>Checkout Summary</h3>
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                </Columns>
            </asp:GridView>

            <div class="mt-3">
                <strong>Total: ₹</strong> <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold" />
            </div>

            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" CssClass="btn btn-success mt-3" OnClick="btnPlaceOrder_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success fw-bold mt-2 d-block" />
        </div>
    </form>
</body>
</html>
