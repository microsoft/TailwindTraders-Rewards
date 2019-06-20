<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/bootstrap.css" rel="stylesheet" type="text/css"  runat="server"/>
        <link href="~/Content/styles/login.css" rel="stylesheet" type="text/css" runat="server" />
    <title>Login</title>
</head>
<body>
    <div class="container login-container row">
        <h2>Admin login</h2>
        <form class="form-horizontal login-form span6" runat="server">
            <div>
                <label for="txtUsername">Username</label>
                <div>
                    <asp:TextBox ID="txtUsername" CssClass="login-input" runat="server" placeholder="Enter Username" required />
                </div>            
            </div>
            <div>
                <label for="txtPassword">Password</label>
                <div>
                    <asp:TextBox ID="txtPassword" CssClass="login-input" runat="server" TextMode="Password" placeholder="Enter Password" required />
                </div>         
            </div>
            <div>
                <div class="login-checkbox">
                    <asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" />    
                </div>       
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="ValidateUser" Class="btn btn-primary" />
            </div>
            <div id="dvMessage" runat="server" visible="false" class="alert alert-danger login-message">
                <strong>Error!</strong>
                <asp:Label ID="lblMessage" runat="server" />
            </div>
        </form>
    </div>
</body>
</html>
