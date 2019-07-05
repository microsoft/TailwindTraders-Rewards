using System;
using System.Configuration;
using System.Web.Security;

namespace Tailwind.Traders.Rewards.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectFromLoginPage(Page.User.Identity.Name, true);
            }
        }

        protected void ValidateUser(object sender, EventArgs e)
        {
            if (IsValidUser(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text.Trim(), chkRememberMe.Checked);
            }
            else
            {
                dvMessage.Visible = true;
                lblMessage.Text = "Username or password incorrect";
            }
        }

        private bool IsValidUser(string userName, string password)
        {
            var adminUser = GetValidUsername();
            var adminPassword = GetValidPassword();

            return (userName == adminUser) && (password == adminPassword);
        }

        private string GetValidUsername()
        {
            var adminUser = Environment.GetEnvironmentVariable("AdminUsername");

            if (string.IsNullOrEmpty(adminUser))
            {
                adminUser = ConfigurationManager.AppSettings["AdminUsername"];
            }

            return adminUser;
        }

        private string GetValidPassword()
        {
            var adminUser = Environment.GetEnvironmentVariable("AdminPassword");

            if (string.IsNullOrEmpty(adminUser))
            {
                adminUser = ConfigurationManager.AppSettings["AdminPassword"];
            }

            return adminUser;
        }
    }
}