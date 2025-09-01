<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>
<!DOCTYPE html>
<html>
<head>
    <title>Signup</title>
    <style>
        body {
            background-color: #1f1f2e;
            font-family: Arial;
            color: white;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .signup-box {
            background-color: #2e2e3e;
            padding: 30px 40px;
            border-radius: 12px;
            box-shadow: 0 0 10px rgba(0,0,0,0.7);
            width: 400px;
        }
        .signup-box h2 {
            margin-bottom: 20px;
        }
        .signup-box input[type="text"],
        .signup-box input[type="password"],
        .signup-box textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 12px;
            border: none;
            border-radius: 6px;
        }
        .signup-box input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: crimson;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }
        .link {
            margin-top: 10px;
        }
        .link a {
            color: #00e6e6;
            text-decoration: none;
        }
        .error {
            color: #ff4d4d;
        }
        .success {
            color: #00e676;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="signup-box">
            <h2>Signup</h2>

            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name"></asp:TextBox><br />
            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name"></asp:TextBox><br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox><br />
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox><br />
            <asp:TextBox ID="txtContact" runat="server" placeholder="Contact"></asp:TextBox><br />
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" placeholder="Address"></asp:TextBox><br />

            <asp:Button ID="btnSignup" runat="server" Text="Sign Up" OnClick="btnSignup_Click" /><br /><br />
            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label><br />

            <div class="link">
                Already have an account? <a href="Login.aspx">Login here</a>
            </div>
        </div>
    </form>
</body>
</html>
