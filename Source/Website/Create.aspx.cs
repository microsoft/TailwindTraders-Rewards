using System;
using System.Web.Security;
using Tailwind.Traders.Rewards.Web.Data;
using Tailwind.Traders.Rewards.Web.Models;

namespace Tailwind.Traders.Rewards.Web
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer_Active.Checked = true;

                if (Page.User.Identity.IsAuthenticated)
                {
                    LabelName.Text = "Logged " + Page.User.Identity.Name;
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }

            dvMessageCreate.Visible = false;
            lblMessageCreate.Text = string.Empty;
        }

        protected void OnClickSignout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx", true);
        }

        protected void OnClickAddCustomer(object sender, EventArgs e)
        {
            if (!IsValidCustomer())
            {
                dvMessageCreate.Visible = true;
                lblMessageCreate.Text = "It was not possible to create a customer";
                dvMessageCreate.CssClass = "alert alert-error";
                return;
            }

            var customer = new Customer
            {
                Email = Customer_Email.Text.Trim(),
                RowVersion = new byte[] { },
                AccountCode = Customer_AccountCode.Text.Trim(),
                FirstName = Customer_FirstName.Text.Trim(),
                LastName = Customer_LastName.Text.Trim(),
                FirstAddress = Customer_FirstAddress.Text.Trim(),
                City = Customer_City.Text.Trim(),
                Country = Customer_Country.Text.Trim(),
                ZipCode = Customer_ZipCode.Text.Trim(),
                Website = Customer_Website.Text.Trim(),
                Active = true,
                Enrrolled = EnrollmentStatusEnum.Uninitialized,
                PhoneNumber = Customer_PhoneNumber.Text.Trim(),
                MobileNumber = Customer_MobileNumber.Text.Trim(),
                FaxNumber = Customer_FaxNumber.Text.Trim()
            };

            try
            {
                CustomerData.AddCustomer(customer);

                dvMessageCreate.Visible = true;
                lblMessageCreate.Text = "Customer created successfully";
                dvMessageCreate.CssClass = "alert alert-success";
            }
            catch (Exception)
            {
                dvMessageCreate.Visible = true;
                lblMessageCreate.Text = "It was not possible to create a customer";
                dvMessageCreate.CssClass = "alert alert-error";
            }
        }        

        protected void OnClickDeleteCustomer(object sender, EventArgs e)
        {
            CustomerData.DeleteCustomer(1);
        }

        protected void OnClickCancel(object sender, EventArgs e)
        {
            RedirectToList();
        }

        private void RedirectToList()
        {
            Response.Redirect("Admin.aspx", true);
        }

        private bool IsValidCustomer()
        {
            if (!IsValidEmail(Customer_Email.Text.Trim()))
            {
                return false;
            }

            if (ExistsCustomer(Customer_Email.Text.Trim()))
            {
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (email == string.Empty)
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ExistsCustomer(string email)
        {
            var user = CustomerData.GetCustomerByEmailOrName(email);

            return (user != null);
        }
    }
}