using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class MakeAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void makeAppointment(object sender, EventArgs e)
        {
            string service = serviceTB.Value;
            string hairdresser = hairdresserTB.Value;
            string date = dateTB.Value;
            string time = timeTB.Value;

        }


        protected void homePageClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/HomePage.aspx", true);
        }
    }
}