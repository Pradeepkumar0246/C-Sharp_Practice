<%@ Page Title="Manage Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ECommerceWebApp.Admin.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Products</h2>
    
    <asp:Button ID="btnAddNew" runat="server" Text="Add New Product" 
                CssClass="btn btn-primary mb-3" OnClick="btnAddNew_Click" />
    
    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-striped" DataKeyNames="ProductID"
        OnRowEditing="gvProducts_RowEditing" OnRowDeleting="gvProducts_RowDeleting"
        OnRowUpdating="gvProducts_RowUpdating" OnRowCancelingEdit="gvProducts_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="true" />
            <asp:TemplateField HeaderText="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' 
                                 TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price", "{0:C}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock">
                <EditItemTemplate>
                    <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind("StockQuantity") %>' 
                                 TextMode="Number" CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStock" runat="server" Text='<%# Bind("StockQuantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="txtImage" runat="server" Text='<%# Bind("ImageURL") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <img src='<%# Eval("ImageURL") %>' height="50" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
            <asp:CommandField ShowEditButton="true" ButtonType="Button" 
                              EditText="Edit" UpdateText="Update" CancelText="Cancel"
                              ControlStyle-CssClass="btn btn-sm btn-outline-primary" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"
                                OnClientClick="return confirm('Are you sure you want to delete this product?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
</asp:Content>