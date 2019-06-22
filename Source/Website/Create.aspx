<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin.Master" CodeBehind="Create.aspx.cs" Inherits="Tailwind.Traders.Rewards.Web.Create" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Create" runat="server">

    <div id="dvScroll" class="container">
        <div class="content__text admin-header">
            <asp:Label ID="LabelName" runat="server"></asp:Label>
            <div>
                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" OnClick="OnClickSignout" Text="Log out" />
            </div>
        </div>

        <div class="admin-message">
            <p class="content__title">Create Customer</p>
        </div>

        <asp:Panel ID="dvMessageCreate" runat="server" visible="false" >
            <asp:Label ID="lblMessageCreate" runat="server" />
        </asp:Panel>

        <div>
            <fieldset class="admin-form">
                <div class="checkbox-wrapper">
                    <asp:CheckBox ID="Customer_Active" Text="Active" runat="server" AutoPostBack="true" />
                </div>
                <label>Email<span class="form-required">[Required]</span></label>
                <asp:TextBox ID="Customer_Email" type="Email" CssClass="admin-form-input" runat="server" placeholder="email@email.com" />
                <label>Account Code</label>
                <asp:TextBox ID="Customer_AccountCode" runat="server" CssClass="admin-form-input" type="text" placeholder="4A3Dc8" />
                <label>First Name</label>
                <asp:TextBox ID="Customer_FirstName" runat="server" CssClass="admin-form-input" type="text" placeholder="john"/>
                <label>Last Name</label>
                <asp:TextBox ID="Customer_LastName" runat="server" CssClass="admin-form-input" type="text" placeholder="Doe Doe"/>
                <label>Address</label>
                <asp:TextBox ID="Customer_FirstAddress" runat="server" CssClass="admin-form-input" type="text" placeholder="385 Akuehe Trail"/>
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
         
                <asp:Button ID="btnSaveCustomer" runat="server" OnClick="OnClickAddCustomer" Text="Save customer" CssClass="btn btn-success" />
                <asp:Button ID="btnCancelCreate" runat="server" OnClick="OnClickCancel" Text="Cancel" CssClass="btn" />
            </fieldset>
        </div>
            
        



</asp:Content>
