<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin.Master" CodeBehind="Update.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Update" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Update" runat="server">

    <div class="container">
        <div class="content__text admin-header">
            <div>
                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" OnClick="OnClickSignout" Text="Log out" />
            </div>
        </div>

        <div class="admin-message">
            <p class="content__title">Edit customer</p>
        </div>

        <asp:Panel ID="dvMessageUpdate" runat="server" visible="false" >
            <asp:Label ID="lblMessageUpdate" runat="server" />
        </asp:Panel>

        <div class="tabbable">
            <ul class="nav nav-tabs admin-tabs">
                <li class="active"><a href="#tab1" data-toggle="tab">Customers</a></li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane active" id="tab1">
                    <fieldset class="admin-form">
                        <h2 class="title">Customers</h2>
                         <div class="checkbox-wrapper">
                            <asp:CheckBox ID="CustomerUpdate_Active" Text="Active" runat="server" AutoPostBack="false" />
                        </div>
                        <label>Email</label>
                        <asp:TextBox ID="CustomerUpdate_Email" type="Email" CssClass="admin-form-input" runat="server" placeholder="email@email.com" required />
                        <label>Account Code</label>
                        <asp:TextBox ID="CustomerUpdate_AccountCode" runat="server" CssClass="admin-form-input" type="text" placeholder="4A3Dc8" />
                        <label>First Name</label>
                        <asp:TextBox ID="CustomerUpdate_FirstName" runat="server" CssClass="admin-form-input" type="text" placeholder="john"/>
                        <label>Last Name</label>
                        <asp:TextBox ID="CustomerUpdate_LastName" runat="server" CssClass="admin-form-input" type="text" placeholder="Doe Doe"/>
                        <label>Address</label>
                        <asp:TextBox ID="CustomerUpdate_FirstAddress" runat="server" CssClass="admin-form-input" type="text" placeholder="385 Akuehe Trail"/>
                        <label>City</label>
                        <asp:TextBox ID="CustomerUpdate_City" runat="server" CssClass="admin-form-input" type="text" placeholder="Hobart"/>
                        <label>Country</label>
                        <asp:TextBox ID="CustomerUpdate_Country" runat="server" CssClass="admin-form-input" type="text" placeholder="Australia"/>
                        <label>Zip Code</label>
                        <asp:TextBox ID="CustomerUpdate_ZipCode" runat="server" CssClass="admin-form-input" type="text" placeholder="038278"/>
                        <label>Website</label>
                        <asp:TextBox ID="CustomerUpdate_Website" runat="server" CssClass="admin-form-input" type="text" placeholder="http://workingdata.com"/>
                        <label>Phone number</label>
                        <asp:TextBox ID="CustomerUpdate_PhoneNumber" runat="server" CssClass="admin-form-input" type="text" placeholder="00-35-9876-98-98"/>
                        <label>Mobile number</label>
                        <asp:TextBox ID="CustomerUpdate_MobileNumber" runat="server" CssClass="admin-form-input" type="text" placeholder="01-35-9876-98-98"/>
                        <label>Fax number</label>
                        <asp:TextBox ID="CustomerUpdate_FaxNumber" runat="server" CssClass="admin-form-input" type="text" placeholder="02-35-9876-98-98"/>
                        <asp:Button ID="btnSaveCustomer" runat="server" OnClick="OnClickUpdateCustomer" Text="Update customer" CssClass="btn btn-success" />
                        <asp:Button ID="btnCancelSave" runat="server" OnClick="OnClickCancel" Text="Cancel" CssClass="btn" />
                    </fieldset>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
