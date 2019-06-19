using System;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Tailwind.Traders.Rewards.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                ViewState["LoginErrors"] = 0;
        }

        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            if (IsValidUser(LoginComponent.UserName, LoginComponent.Password))
            {
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(LoginComponent.UserName, LoginComponent.RememberMeSet);
            }
            else
            {
                e.Authenticated = false;
                LoginComponent.FailureText = "Username or password incorrect";
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