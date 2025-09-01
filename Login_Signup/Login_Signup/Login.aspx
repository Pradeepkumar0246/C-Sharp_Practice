<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <style>
        body {
            background-color: #1e1e2f;
            color: #fff;
            font-family: Arial;
            text-align: center;
            padding-top: 100px;
        }
        .box {
            background-color: #2c2c3e;
            padding: 40px;
            margin: auto;
            width: 400px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.5);
        }
        input, button {
            margin: 10px 0;
            padding: 10px;
            width: 90%;
            border-radius: 5px;
            border: none;
        }
        button {
            background: crimson;
            color: white;
            cursor: pointer;
        }
        .error {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h2>Login</h2>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" />
            <br />
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="error" />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <asp:HyperLink ID="lnkSignup" runat="server" NavigateUrl="Signup.aspx">Don't have an account? Sign up</asp:HyperLink>
        </div>
    </form>
</body>
</html>
