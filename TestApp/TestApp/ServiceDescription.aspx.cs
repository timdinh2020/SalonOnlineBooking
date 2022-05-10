using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class ServiceDescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string serviceName = Request.QueryString["service"];

            serviceLabel.Text = "<h3>" + serviceName + "</h3>";

            mongodb db = new mongodb();
            var service = db.db_getServByTitle(serviceName);

            List<object> serviceDetails = service.ViewServiceDetails();

            string title = (string)serviceDetails[0];
            string desc = (string)serviceDetails[1];
            double price = (double)serviceDetails[2];


            descriptionLabel.Text = desc + "<br>" + price;




        }

        protected void serviceList(object sender, EventArgs e)
        {
            Response.Redirect("~/ServiceList.aspx");
        }
    }
}