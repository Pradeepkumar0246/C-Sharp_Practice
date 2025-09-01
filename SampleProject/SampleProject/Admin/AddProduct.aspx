<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ECommerceWebApp.Admin.AddProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Product</h2>
    
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtDescription" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" CssClass="form-control" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPrice" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPrice" TextMode="Number" step="0.01" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrice" ErrorMessage="Price is required." />
                <asp:RangeValidator runat="server" ControlToValidate="txtPrice" Type="Currency" 
                    MinimumValue="0.01" MaximumValue="10000" ErrorMessage="Price must be between 0.01 and 10,000" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtStock" CssClass="col-md-2 control-label">Stock Quantity</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStock" TextMode="Number" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStock" ErrorMessage="Stock is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtImage" CssClass="col-md-2 control-label">Image URL</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtImage" CssClass="form-control" />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:CheckBox runat="server" ID="chkActive" Checked="true" Text=" Active Product" />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnSave_Click" Text="Save Product" CssClass="btn btn-primary" />
                <asp:HyperLink runat="server" NavigateUrl="~/Admin/Products.aspx" Text="Cancel" CssClass="btn btn-default" />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Label runat="server" ID="lblMessage" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>