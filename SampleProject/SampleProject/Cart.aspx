<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ECommerceWebApp.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Shopping Cart</h2>
    
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-striped" OnRowCommand="gvCart_RowCommand"
        EmptyDataText="Your cart is empty">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Product" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' 
                                Width="40" TextMode="Number" min="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                                CommandName="UpdateItem" 
                                CommandArgument='<%# Eval("ProductID") %>'
                                CssClass="btn btn-sm btn-info" />
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" 
                                CommandName="RemoveItem" 
                                CommandArgument='<%# Eval("ProductID") %>'
                                CssClass="btn btn-sm btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <div class="text-right">
        <h4>Total: <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label></h4>
        <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Pay" 
                    CssClass="btn btn-success btn-lg" OnClick="btnCheckout_Click" />
    </div>
</asp:Content>