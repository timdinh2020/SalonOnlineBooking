using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class AddService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addService(object sender, EventArgs e)
        {
            string title = titleTB.Value;
            string descr = descrTB.Value;
            double price;


            try
            {
                price = Convert.ToDouble(priceTB.Value);
            }
            catch
            {
                StatusMessage.Text = "Price must be a decimal value.";
                return;
            }

            Service hairCutting = new Service("Hair Cutting", "Different kinds of hair cutting services!", -1, null);

            Service newService = new Service(title, descr, price, "Hair Cutting");

            string result = hairCutting.AddNewService(newService);

            if (result == "Success")
            {
                StatusMessage.Text = result;
            }

            else 
            {
                StatusMessage.Text = result;
            }

        }


        protected void homePageClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/HomePage.aspx", true);
        }
    }
}