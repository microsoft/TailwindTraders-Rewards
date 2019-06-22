using System;
using System.Web.Security;
using System.Web.UI;
using Tailwind.Traders.Rewards.Web.Data;
using Tailwind.Traders.Rewards.Web.Models;

namespace Tailwind.Traders.Rewards.Web
{
    public partial class Update : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }

                var customerId = Request.QueryString["customerId"];

                if (string.IsNullOrEmpty(customerId))
                {
                    Response.Redirect("Admin.aspx", true);
                }

                var customer = CustomerData.GetCustomerById(int.Parse(customerId));

                if (customer == null)
                {
                    Response.Redirect("Admin.aspx", true);
                }

                FillFields(customer);

                dvMessageUpdate.Visible = false;
                lblMessageUpdate.Text = string.Empty;
            }
        }

        private void FillFields(Customer customer)
        {
            CustomerUpdate_Email.Text = customer.Email;
            CustomerUpdate_FirstName.Text = customer.FirstName;
            CustomerUpdate_LastName.Text = customer.LastName;            
            CustomerUpdate_AccountCode.Text = customer.AccountCode;
            CustomerUpdate_FirstAddress.Text = customer.FirstAddress;
            CustomerUpdate_City.Text = customer.City;
            CustomerUpdate_Country.Text = customer.Country;
            CustomerUpdate_MobileNumber.Text = customer.MobileNumber;
            CustomerUpdate_PhoneNumber.Text = customer.PhoneNumber;
            CustomerUpdate_FaxNumber.Text = customer.FaxNumber;            
            CustomerUpdate_Website.Text = customer.Website;
            CustomerUpdate_ZipCode.Text = customer.ZipCode;
            CustomerUpdate_Active.Checked = customer.Active;
        }

        protected void OnClickSignout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx", true);
        }

        protected void OnClickUpdateCustomer(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                Email = CustomerUpdate_Email.Text.Trim(),
                AccountCode = CustomerUpdate_AccountCode.Text.Trim(),
                FirstName = CustomerUpdate_FirstName.Text.Trim(),
                LastName = CustomerUpdate_LastName.Text.Trim(),
                FirstAddress = CustomerUpdate_FirstAddress.Text.Trim(),
                City = CustomerUpdate_City.Text.Trim(),
                Country = CustomerUpdate_Country.Text.Trim(),
                ZipCode = CustomerUpdate_ZipCode.Text.Trim(),
                Website = CustomerUpdate_Website.Text.Trim(),
                Active = CustomerUpdate_Active.Checked,
                PhoneNumber = CustomerUpdate_PhoneNumber.Text.Trim(),
                MobileNumber = CustomerUpdate_MobileNumber.Text.Trim(),
                FaxNumber = CustomerUpdate_FaxNumber.Text.Trim(),
                CustomerId = int.Parse(Request.QueryString["customerId"])
            };

            try
            {
                CustomerData.UpdateCustomer(customer);
                Response.Redirect("Admin.aspx", true);
            }
            catch (Exception)
            {
                lblMessageUpdate.Text = "It was not possible to update the customer";
                dvMessageUpdate.CssClass = "alert alert-error";
                dvMessageUpdate.Visible = true;
            }
        }

        protected void OnClickCancel(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx", true);
        }
    }
}