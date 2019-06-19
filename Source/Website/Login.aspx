<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/bootstrap.css" rel="stylesheet" type="text/css"  runat="server"/>
    <title>Login</title>
</head>
<body>
    <h2>Admin login</h2>
    <form class="form-horizontal" runat="server">
        <div class="control-group">
            <label for="txtUsername" class="control-label">Username</label>
            <div class="controls">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username" required />
            </div>            
        </div>
        <div class="control-group">
            <label for="txtPassword" class="control-label">Password</label>
            <div class="controls">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Password" required />
            </div>         
        </div>
        <div class="control-group">
            <div class="controls">
                <label class="checkbox">
                    <asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" />    
                </label>
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="ValidateUser" Class="btn btn-primary" />
            </div>            
        </div>
        <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
            <strong>Error!</strong>
            <asp:Label ID="lblMessage" runat="server" />
        </div>
    </form>
</body>
</html>
