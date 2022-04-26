using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void editAccountClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/EditAccountPage.aspx", true);
        }
        protected void signOutClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/LoginPage.aspx", true);
        }

        protected void servicesClick(object sender, EventArgs e)
        {

        }
    }
}