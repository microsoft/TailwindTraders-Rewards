<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin.Master" CodeBehind="Admin.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Login" runat="server">

    <div class="container">
        <div class="content__text admin-header">
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <div>
                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" OnClick="OnClickSignout" Text="Log out" />
            </div>
        </div>

        <div class="admin-message">
            <p class="content__title">Create customers or Orders</p>
        </div>

        <div class="tabbable">
            <%--<!-- Only required for left/right tabs -->--%>
            <ul class="nav nav-tabs admin-tabs">
                <li class="active"><a href="#tab1" data-toggle="tab">Customers</a></li>
                <li><a href="#tab2" data-toggle="tab">Orders</a></li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane active" id="tab1">
                    <fieldset class="admin-form">
                        <h2 class="title">Customers</h2>
                        <label>Email</label>
                        <asp:TextBox ID="Customer_Email" type="Email" CssCssClass="admin-form-input" runat="server" placeholder="email@email.com" required />
                        <label>Account Code</label>
                        <asp:TextBox ID="Customer_AccountCode" runat="server" CssCssClass="admin-form-input" type="text" placeholder="4A3Dc8" />
                        <label>First Name</label>
                        <asp:TextBox ID="Customer_FirstName" runat="server" CssCssClass="admin-form-input" type="text" placeholder="john"/>
                        <label>Last Name</label>
                        <asp:TextBox ID="Customer_LastName" runat="server" CssCssClass="admin-form-input" type="text" placeholder="Doe Doe"/>
                        <label>Address</label>
                        <asp:TextBox ID="Customer_FirstAddress" runat="server" CssCssClass="admin-form-input" type="text" placeholder="385 Akuehe Trail"/>
                        <label>City</label>
                        <asp:TextBox ID="Customer_City" runat="server" CssClass="admin-form-input" type="text" placeholder="Hobart"/>
                        <label>Country</label>
                        <asp:TextBox ID="Customer_Country" runat="server" CssClass="admin-form-input" type="text" placeholder="Australia"/>
                        <label>Zip Code</label>
                        <asp:TextBox ID="Customer_ZipCode" runat="server" CssClass="admin-form-input" type="text" placeholder="038278"/>
                        <label>Website</label>
                        <asp:TextBox ID="Customer_Website" runat="server" CssClass="admin-form-input" type="text" placeholder="http://workingdata.com"/>
                        <label>Phone number</label>
                        <asp:TextBox ID="Customer_PhoneNumber" runat="server" CssClass="admin-form-input" type="text" placeholder="00-35-9876-98-98"/>
                        <label>Mobile number</label>
                        <asp:TextBox ID="Customer_MobileNumber" runat="server" CssClass="admin-form-input" type="text" placeholder="01-35-9876-98-98"/>
                        <label>Fax number</label>
                        <asp:TextBox ID="Customer_FaxNumber" runat="server" CssClass="admin-form-input" type="text" placeholder="02-35-9876-98-98"/>
                        <div class="checkbox-wrapper">
                            <asp:CheckBox ID="Customer_Active" Text="Active" runat="server" AutoPostBack="true" />
                            <%--<label runat="server" id="lblCheckbox" for="Customer_Active">Active</label>--%>
                        </div>
                        <asp:Button ID="btnSaveCustomer" runat="server" OnClick="OnClickAddCustomer" Text="Save customer" CssClass="btn btn-primary" />
                    </fieldset>
                </div>
                <div class="tab-pane" id="tab2">
                    <fieldset class="admin-form">
                        <h2 class="title"">Orders</h2>
                        <label>Order code</label>
                        <asp:TextBox runat="server" CssClass="admin-form-input" type="email" placeholder="192384529EC"/>
                        <label>Type</label>
                        <asp:TextBox runat="server" CssClass="admin-form-input" type="text" placeholder="Retail"/>
                        <label>Item name</label>
                        <asp:TextBox runat="server" CssClass="admin-form-input" type="text" placeholder="Hammer"/>
                        <div class="checkbox-wrapper">
                            <asp:CheckBox ID="CheckBoxStatus" runat="server" AutoPostBack="true" />
                            <label runat="server" id="Label3" for="EnrollCheckbox">Status</label>
                        </div>
                        <label>Total</label>
                        <asp:TextBox runat="server" CssClass="admin-form-input" type="text" placeholder="100.00"/>
                        <button class="btn btn-primary" type="submit" >Submit form</button>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
