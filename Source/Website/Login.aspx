<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Login ID="LoginComponent" runat="server"
            OnAuthenticate="OnAuthenticate"
            >
        </asp:Login>
    </form>
</body>
</html>
