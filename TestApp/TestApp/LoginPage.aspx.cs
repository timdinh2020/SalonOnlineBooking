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
            Account testAccount = new Account();
            string username = inputEmail.Value.ToString();
            string password = inputPassword.Value.ToString();

            String result = testAccount.LogIn(username, password);

            if (result == "Success")
            {
                LoginSuccess.Text = "Login Succeeded";
            }
            else
            {
                LoginSuccess.Text = "Login Failed";
            }
            return;
        }
    }
}