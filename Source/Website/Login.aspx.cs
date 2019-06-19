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
            var adminUser = ConfigurationManager.AppSettings["AdminUsername"];
            var adminPassword = ConfigurationManager.AppSettings["AdminPassword"];

            return (userName == adminUser) && (password == adminPassword);
        }
    }
}