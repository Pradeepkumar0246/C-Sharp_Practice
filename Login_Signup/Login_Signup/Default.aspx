<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ec._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eCommerce Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f4f4f4;
            font-family: Arial, sans-serif;
        }

        .card-img-top {
            height: 180px;
            object-fit: cover;
        }

        .admin-links a {
            color: white;
            text-decoration: none;
        }

        .admin-links a:hover {
            text-decoration: underline;
        }

        .admin-links .btn {
            margin-right: 10px;
        }

        #btnTop {
            position: fixed;
            bottom: 30px;
            right: 30px;
            display: none;
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 50%;
            cursor: pointer;
            z-index: 9999;
        }

        body.dark-mode {
            background-color: #121212 !important;
            color: #e0e0e0 !important;
        }

        body.dark-mode .card {
            background-color: #1e1e1e;
            color: white;
            border: 1px solid #444;
        }

        body.dark-mode .btn-primary,
        body.dark-mode .btn-outline-primary {
            background-color: #0d6efd;
            color: white;
            border-color: #0d6efd;
        }

        body.dark-mode .form-control {
            background-color: #2c2c2c;
            color: #fff;
            border: 1px solid #666;
        }

        body.dark-mode .form-check-label {
            color: #e0e0e0 !important;
        }

        .form-check-label {
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-4">
            <div class="d-flex justify-content-between align-items-center mb-4 flex-wrap">
                <h2 class="text-primary">Welcome, <asp:Label ID="lblUser" runat="server" CssClass="fw-bold"></asp:Label></h2>

                <div class="d-flex align-items-center">
                    <% if (Session["mailid"] != null && Session["mailid"].ToString() == "admin@gmail.com") { %>
                        <div class="admin-links me-3 d-flex">
                            <a href="Categories.aspx" class="btn btn-secondary btn-sm me-2">Manage Categories</a>
                            <a href="Products.aspx" class="btn btn-secondary btn-sm">Manage Products</a>
                        </div>
                    <% } %>
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger btn-sm" OnClick="btnLogout_Click" />
                </div>
            </div>

            <div class="input-group mb-4 w-50 mx-auto">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by category or product..." />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-outline-primary" OnClick="btnSearch_Click" />
            </div>

            <div class="row">
                <asp:Repeater ID="rptProducts" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card h-100 shadow-sm">
                                <img src='<%# Eval("ResolvedImageUrl") %>' alt='<%# Eval("PName") %>' class="card-img-top" />
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("PName") %></h5>
                                    <p class="card-text">Category: <%# Eval("Category") %></p>
                                    <p class="card-text">Price: ₹<%# Eval("Price") %></p>
                                    <p class="card-text">Quantity: <%# Eval("Qty") %></p>
                                    <button class="btn btn-primary btn-sm">Add to Cart</button>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <!-- Scroll to Top -->
        <button id="btnTop" title="Go to top">↑</button>

        <!-- Dark Mode Toggle -->
        <div class="position-fixed bottom-0 start-0 m-3 z-3">
            <div class="form-check form-switch">
                <input class="form-check-input" type="checkbox" id="toggleMode" />
                <label class="form-check-label" for="toggleMode">Dark Mode</label>
            </div>
        </div>
    </form>

    <!-- Scripts -->
    <script>
        const btnTop = document.getElementById("btnTop");

        window.onscroll = function () {
            btnTop.style.display = (document.body.scrollTop > 200 || document.documentElement.scrollTop > 200) ? "block" : "none";
        };

        btnTop.onclick = function () {
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
        };

        
        const toggle = document.getElementById('toggleMode');
        const label = toggle.nextElementSibling;

        toggle.addEventListener('change', function () {
            document.body.classList.toggle('dark-mode');
            label.textContent = this.checked ? "Light Mode" : "Dark Mode";
        });
    </script>
</body>
</html>
