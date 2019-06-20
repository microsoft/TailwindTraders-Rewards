<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin.Master" CodeBehind="Admin.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Login" runat="server">

    <div class="container">
        <div class="content__text admin-header">
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <div>
                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" OnClick="OnClickSignout" Text="Log Out" />
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
                        <input class="admin-form-input" type="email" placeholder="email@email.com">
                        <label>Account Code</label>
                        <input class="admin-form-input" type="text" placeholder="4A3Dc8">
                        <label>First Name</label>
                        <input class="admin-form-input" type="text" placeholder="john">
                        <label>Last Name</label>
                        <input class="admin-form-input" type="text" placeholder="Doe Doe">
                        <label>Address</label>
                        <input class="admin-form-input" type="text" placeholder="385 Akuehe Trail">
                        <label>City</label>
                        <input class="admin-form-input" type="text" placeholder="Hobart">
                        <label>Country</label>
                        <input class="admin-form-input" type="text" placeholder="Australia">
                        <label>Zip Code</label>
                        <input class="admin-form-input" type="text" placeholder="038278">
                        <label>Website</label>
                        <input class="admin-form-input" type="text" placeholder="http://workingdata.com">
                        <label>Phone number</label>
                        <input class="admin-form-input" type="text" placeholder="00-35-9876-98-98">
                        <label>Mobile number</label>
                        <input class="admin-form-input" type="text" placeholder="01-35-9876-98-98">
                        <label>Fax number</label>
                        <input class="admin-form-input" type="text" placeholder="02-35-9876-98-98">
                        <div class="checkbox-wrapper">
                            <asp:CheckBox ID="ActiveCheckbox" runat="server" AutoPostBack="true" />
                            <label runat="server" id="lblCheckbox" for="EnrollCheckbox">Active</label>
                        </div>
                        <div class="checkbox-wrapper">
                            <asp:CheckBox ID="EnrollCheckbox" runat="server" AutoPostBack="true" />
                            <label runat="server" id="Label2" for="EnrollCheckbox">Enroll</label>
                        </div>
                        <button class="btn btn-primary" type="submit" >Submit form</button>
                    </fieldset>
                </div>
                <div class="tab-pane" id="tab2">
                    <fieldset class="admin-form">
                        <h2 class="title"">Orders</h2>
                        <label>Order code</label>
                        <input class="admin-form-input" type="email" placeholder="192384529EC">
                        <label>Type</label>
                        <input class="admin-form-input" type="text" placeholder="Retail">
                        <label>Item name</label>
                        <input class="admin-form-input" type="text" placeholder="Hammer">
                        <div class="checkbox-wrapper">
                            <asp:CheckBox ID="CheckBoxStatus" runat="server" AutoPostBack="true" />
                            <label runat="server" id="Label3" for="EnrollCheckbox">Status</label>
                        </div>
                        <label>Total</label>
                        <input class="admin-form-input" type="text" placeholder="100.00">
                        <button class="btn btn-primary" type="submit" >Submit form</button>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
