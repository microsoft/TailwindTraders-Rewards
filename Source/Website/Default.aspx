<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:CheckBox ID="EnrollCheckbox" runat="server" AutoPostBack="true" OnCheckedChanged="EnrollChckedChanged" />
    <asp:TextBox ID="FilterTextBox" runat="server"></asp:TextBox><asp:Button ID="FilterCustomerButton" runat="server" Text="Find" OnClick="FilterCustomer"/>--%>

    <aside class="grid__aside">
        <h1>
            <img class="logo" src="/Content/img/logo.svg" alt="Tailwind Trader's blue logo" />
        </h1>
        <asp:PlaceHolder runat="server" ID="spanCustomer" Visible="true">
            <h2 class="title">Contact info</h2>
            <div class="content">
                <p class="content__row">
                    <span class="content__text">Name</span>
                    <span id="Name" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Last Name</span>
                    <span id="LastName" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Email Address</span>
                    <span id="Email" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Phone No</span>
                    <span id="PhoneNumber" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Fax No</span>
                    <span id="FaxNumber" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Mobile No</span>
                    <span id="MobileNumber" class="content__title" runat="server"></span>
                </p>
            </div>

              <div class="checkbox-wrapper">
                <asp:CheckBox ID="EnrollCheckbox" runat="server" AutoPostBack="true" OnCheckedChanged="EnrollChckedChanged" />
                <label runat="server" id="lblCheckbox" for="EnrollCheckbox"></label>
            </div>

            <h2 class="title">Client Info</h2>
            <div class="content">
                <asp:HiddenField ID="CustomerId" runat="server" />
                <p class="content__row">
                    <span class="content__text">Client's Acc No</span>
                    <span id="AccNo" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Address</span>
                    <span id="Address1" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">City</span>
                    <span id="City" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Country</span>
                    <span id="Country" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Zip Code</span>
                    <span id="ZipCode" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Website</span>
                    <span id="Website" class="content__title" runat="server"></span>
                </p>
                <p class="content__row">
                    <span class="content__text">Active</span>
                    <span id="Active" class="content__title" runat="server"></span>
                </p>
            </div>            

            <br />
            <br />
        </asp:PlaceHolder>
    </aside>

    <main class="grid__main">
        <div class="searchbox">
            <asp:TextBox class="cbx-input" ID="SearchTextBox" runat="server" OnTextChanged="SearchCustomer" placeholder="View another client"></asp:TextBox>
            <label class="u-visually-hidden" for="searchbox">Search:</label>
        </div>
        <asp:PlaceHolder runat="server" ID="spanCustomer2" Visible="true">
            <h2 class="title">Order history</h2>
            <asp:ListView ID="orderList" ItemPlaceholderID="itemPlaceHolder" runat="server" ItemType="Tailwind.Traders.Rewards.Web.Models.Order">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <div class="table__header">
                        <div class="table__item">ORDER NUMBER</div>
                        <div class="table__item">ORDER DATE</div>
                        <div class="table__item">ORDER TYPE</div>
                        <div class="table__item">ITEM NAME</div>
                        <div class="table__item">STATUS</div>
                        <div class="table__item">TOTAL</div>
                    </div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>

                </LayoutTemplate>
                <ItemTemplate>
                    <div class="table__row">
                        <div class="table__item">
                            <asp:Label
                                Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>'
                                runat="server"/>
                        </div>
                        <div class="table__item">
                            <asp:Label
                                Text='<%# DataBinder.Eval(Container.DataItem, "Date") %>'
                                runat="server"/>
                        </div>
                        <div class="table__item">
                            <asp:Label
                                Text='<%# DataBinder.Eval(Container.DataItem, "Type") %>'
                                runat="server"/>
                        </div>
                        <div class="table__item">
                            <asp:Label
                                Text='<%# DataBinder.Eval(Container.DataItem, "ItemName") %>'
                                runat="server"/>
                        </div>
                        <div class="table__item">
                            <asp:Label
                                Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'
                                runat="server"/>
                        </div>
                        <div class="table__item">
                            <asp:Label
                                Text='<%# DataBinder.Eval(Container.DataItem, "Total") %>'
                                runat="server"/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="spanNotFound" Visible="false">
            <h2>No customer found.</h2>
        </asp:PlaceHolder>
    </main>
</asp:Content>
