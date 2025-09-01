<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ecommerce._Default" %>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="text-align:center; margin: 20px 0;">All Products</h2>

    <div class="product-grid">
        <asp:Repeater ID="rptProducts" runat="server">
            <ItemTemplate>
                <div class="product-card">
                    <img src='<%# Eval("ImageUrl") %>' alt="Product Image" class="product-img" />
                    <h3><%# Eval("ProductName") %></h3>
                    <p class="price">₹ <%# Eval("Price") %></p>
                    <a href='ProductDetails.aspx?id=<%# Eval("ProductID") %>' class="btn-primary">View</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
