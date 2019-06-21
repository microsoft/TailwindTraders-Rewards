using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using Tailwind.Traders.Rewards.Web.Data;

namespace Tailwind.Traders.Rewards.Web
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (!Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }

                BindCustomersToListView();
            }
        }

        protected void OnClickBtnCreateCustomer(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx", true);
        }

        protected void OnClickSignout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx", true);
        }

        protected void OnClickUpdateCustomer(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var customerId = btn.CommandArgument.ToString();
            Response.Redirect("Update.aspx?customerid=" + customerId);

        }
        
        protected void OnClickDeleteCustomer(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var customerId = int.Parse(btn.CommandArgument.ToString());

            try
            {
                CustomerData.DeleteCustomer(customerId);

                BindCustomersToListView();

                lblMessageDelete.Text = "Customer created successfully";
                dvMessageDelete.CssClass = "alert alert-success";
                dvMessageDelete.Visible = true;

            }
            catch (Exception)
            {
                lblMessageDelete.Text = "It was not possible to delete the customer";
                dvMessageDelete.CssClass = "alert alert-error";
                dvMessageDelete.Visible = true;
            }         
        }

        private void BindCustomersToListView()
        {
            var customers = CustomerData.GetCustomers();

            customersList.DataSource = customers;
            customersList.DataBind();
        }
    }
}