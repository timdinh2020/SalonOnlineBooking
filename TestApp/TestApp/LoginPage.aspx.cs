using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginClick(object sender, EventArgs e)
        {
            Account userAccount = new Account();
            string username = inputEmail.Value.ToString();
            string password = inputPassword.Value.ToString();
            String result = userAccount.LogIn(username, password);


            if (result == "Success")
            {
                Session["userEmail"] = username;
                Page.Response.Redirect("~/HomePage.aspx", true);
            }
            else
            {
                StatusMessage.Text = result;
            }
            return;
        }

        protected void createAccountClick(object sender, EventArgs e)
        {

            string firstName = fNameHidden.Value;
            string lastName = lNameHidden.Value;
            string userEmail = emailHidden.Value;
            string userPassword = passwordHidden.Value;

            Account userAccount = new Account();

            string result = userAccount.CreateAccount(firstName, lastName, "User", userEmail, userPassword, "Monday");

            if (result == "Account Creation Successful!")
            {
                StatusMessage.Text = "Account successfully created.";
            }
            else
            {
                StatusMessage.Text = result;
            }

        }
    }
}