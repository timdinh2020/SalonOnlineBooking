using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class ServiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            mongodb db = new mongodb();
            var hair = db.db_getServByTitle("Hair Cutting");


            List<Service> services = hair.ViewAvailableServices();


            int i = 0;

            foreach (Service serv in services)
            {
                i++;
                LinkButton lnk = new LinkButton();
                lnk.ID = "Service" + i;
                lnk.Text = serv.title;
                lnk.Click += new EventHandler(this.serviceClick);
                this.Panel1.Controls.Add(lnk);
                this.Panel1.Controls.Add(new Label() { Text = "<br/>" });
            }
        }

        protected void serviceClick(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect(string.Format("~/ServiceDescription.aspx?service={0}", lnk.Text));
        }
    }
}