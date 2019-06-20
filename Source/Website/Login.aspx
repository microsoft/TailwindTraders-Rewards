<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Login.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Login" runat="server">
        <asp:Login ID="LoginComponent" runat="server"
            OnAuthenticate="OnAuthenticate" DestinationPageUrl="Admin.aspx"
            >
        </asp:Login>
</asp:Content>