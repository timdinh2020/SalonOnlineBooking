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
            string userEmail = email.Value;
            string userPassword = password.Value;

            BsonObjectId Id_ = (BsonObjectId)"5bf142459b72e12b2b1b2cd";
            Account userAccount = new Account();
            String result = userAccount.EditAccount(Id_, firstName, lastName, userEmail, "Username", userPassword, "Monday", userPassword);

            if (result == "Your account has been successfully updated.")
            {
                StatusMessage.Text = "Account information successfully updated.";
            }
            else
            {
                StatusMessage.Text = "Account information could not be updated.";
            }

            
        }

        protected void homePageClick(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/HomePage.aspx", true);
        }
    }
}