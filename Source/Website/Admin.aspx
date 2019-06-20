<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Admin.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Login" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </div>

    <asp:Button ID="Button1" runat="server" OnClick="OnClickSignout" Text="Salir" />

    <asp:Button ID="btnAddCustomer" runat="server" OnClick="OnClickAddCustomer" Text="Add Customer" />
    <asp:Button ID="btnUpdateCustomer" runat="server" OnClick="OnClickUpdateCustomer" Text="Update Customer" />
    <asp:Button ID="btnDeleteCustomer" runat="server" OnClick="OnClickDeleteCustomer" Text="Delete Customer" />

    <asp:Button ID="btnAddOrder" runat="server" OnClick="OnClickAddOrder" Text="Add Order" />
    <asp:Button ID="btnUpdateOrder" runat="server" OnClick="OnClickUpdateOrder" Text="Update Order" />
    <asp:Button ID="btnDeleteOrder" runat="server" OnClick="OnClickDeleteOrder" Text="Delete Order" />

</asp:Content>
