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
            string userEmail = Session["userEmail"] as string;
        }
        protected void editAccountClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/EditAccountPage.aspx", true);
        }
        protected void signOutClick(object sender, EventArgs e)
        {
            Session["userEmail"] = "";
            Page.Response.Redirect("~/LoginPage.aspx", true);
        }

        protected void servicesClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/ServiceList.aspx", true);
        }

        protected void addServiceClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/AddService.aspx", true);
        }

        protected void modifyServiceClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/ModifyService.aspx", true);
        }

        protected void viewHairDressersClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Hairdressers.aspx", true);
        }

        protected void modifyAvailability(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/modifyAvailability.aspx", true);
        }

        protected void addHairdresserClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/AddHairdresser.aspx", true);
        }
    }
}