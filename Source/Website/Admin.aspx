<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Admin.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Login" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </div>

    <asp:Button ID="Button1" runat="server" OnClick="OnClickSignout" Text="Salir" />
</asp:Content>
