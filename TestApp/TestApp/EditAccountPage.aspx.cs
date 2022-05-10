using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;

namespace TestApp
{
    public partial class EditAccountPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updateAccountInformation(object sender, EventArgs e)
        {
            string firstName = fName.Value;
            string lastName = lName.Value;
            string userEmail = Session["userEmail"] as string;
            string newPassword = password.Value;
            string currentPassword = curPassword.Value;

            Account userAccount = new Account();
            string result = userAccount.EditAccount(userEmail, firstName, lastName, "", newPassword, "Monday", currentPassword);

            if (result == "Your account has been successfully updated.")
            {
                StatusMessage.Text = "Account information successfully updated.";
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