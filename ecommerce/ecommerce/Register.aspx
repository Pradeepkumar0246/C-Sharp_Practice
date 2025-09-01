<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="ecommerce.Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Register</title>
    <link href="Styles/site.css" rel="stylesheet" /> <!-- Adjust path if needed -->
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar">
            <div class="nav-left">
                <a href="Default.aspx">Home</a>
                <a href="Login.aspx">Login</a>
                <a href="Register.aspx">Register</a>
                <a href="Cart.aspx">Cart</a>
                <a href="Checkout.aspx">Checkout</a>
                <a href="Admin/Dashboard.aspx">Admin</a>
            </div>
            <div class="nav-right">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn-primary" />
            </div>
        </nav>

        <div class="register-container">
            <h2>Register</h2>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="input-box" placeholder="First Name"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="input-box" placeholder="Last Name"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-box" placeholder="Email"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input-box" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input-box" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>

            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-primary" OnClick="btnRegister_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label" />
        </div>

    </form>
</body>
</html>
