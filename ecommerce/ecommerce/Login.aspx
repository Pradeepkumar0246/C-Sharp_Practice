<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="ecommerce.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5" style="max-width:400px;">
            <h3 class="text-center mb-4">Login</h3>

            <div class="mb-3">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Password" />
            </div>

            <div class="mb-3 text-center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />
            </div>

            <div class="text-center">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger fw-bold"></asp:Label>
            </div>

            <div class="text-center mt-3">
                <a href="Register.aspx">Don't have an account? Register</a>
            </div>
        </div>
    </form>
</body>
</html>
