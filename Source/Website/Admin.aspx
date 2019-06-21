<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin.Master" CodeBehind="Admin.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="List" runat="server">

<div class="container admin-container">
    <div class="content__text admin-header">
        <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" OnClick="OnClickSignout" Text="Log out" />
        <asp:Button ID="btnCreateCustomer" CssClass="btn btn-primary" runat="server" Text="Create Customer" OnClick="OnClickBtnCreateCustomer" />
    </div>

    <asp:Panel ID="dvMessageDelete" runat="server" visible="false" >
        <asp:Label ID="lblMessageDelete" runat="server" />
    </asp:Panel>

    <asp:ListView ID="customersList" ItemPlaceholderID="itemPlaceHolder" runat="server" ItemType="Tailwind.Traders.Rewards.Web.Models.Customer">
        <EmptyDataTemplate>
            <table class="table table-striped admin-table">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <table class="table table-striped admin-table">
                <tr>
                    <th>EMAIL</th>
                    <th>FIRST NAME</th>
                    <th>LAST NAME</th>
                    <th>FIRST ADDRESS</th>
                    <th>CITY</th>
                    <th>ACTIVE</th>
                    <th>ENRROLLMENT</th>
                    <th>Operations</th>
                </tr>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label
                        Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>'
                        runat="server"/>
                </td>
                <td>
                    <asp:Label
                        Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'
                        runat="server"/>
                </td>
                <td>
                    <asp:Label
                        Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'
                        runat="server"/>
                </td>
                <td>
                    <asp:Label
                        Text='<%# DataBinder.Eval(Container.DataItem, "FirstAddress") %>'
                        runat="server"/>
                </td>
                <td>
                    <asp:Label
                        Text='<%# DataBinder.Eval(Container.DataItem, "City") %>'
                        runat="server"/>
                </td>
                <td>
                    <asp:Label
                        Text='<%# DataBinder.Eval(Container.DataItem, "Active") %>'
                        runat="server"/>
                </td>
                <td>
                    <asp:Label
                        Text='<%# DataBinder.Eval(Container.DataItem, "Enrrolled") %>'
                        runat="server"/>
                </td>
                <td>
                    <asp:Button CssClass="btn btn-success" ID="Button2" runat="server" Text="Update"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerId") %>'  
                        OnClick="OnClickUpdateCustomer"/>
                    <asp:Button CssClass="btn btn-danger" ID="Button3" runat="server" Text="Delete" 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerId") %>'  
                        OnClick="OnClickDeleteCustomer"/>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>
