using System;
using System.Web.Security;

namespace Tailwind.Traders.Rewards.Web
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.User.Identity.IsAuthenticated)
            {
                Label1.Text = "Logado " + Page.User.Identity.Name;
            }
            else
            {
                Label1.Text = "NO Logado";
            }
        }

        protected void OnClickSignout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx", true);
        }
    }
}