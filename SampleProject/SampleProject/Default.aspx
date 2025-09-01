<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerceWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Our Products</h2>
    
    <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
    <HeaderTemplate>
        <div class="product-grid">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="product-item">
            <img src='<%# Eval("ImageURL") %>' alt='<%# Eval("Name") %>' />
            <h3><%# Eval("Name") %></h3>
            <p><%# Eval("Description") %></p>
            <div class="price">$<%# Eval("Price", "{0:N2}") %></div>
            <asp:Button ID="btnAddToCart" runat="server" 
                      CommandName="AddToCart" 
                      CommandArgument='<%# Eval("ProductID") %>'
                      Text="Add to Cart" 
                      CssClass="btn btn-primary" />
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
        <asp:Label ID="lblEmpty" runat="server" Visible='<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>'
                  Text="No products available at this time." CssClass="alert alert-info"></asp:Label>
    </FooterTemplate>
</asp:Repeater>
</asp:Content>