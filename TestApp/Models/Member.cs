using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Member : Models.Account
    {
        public string Role = "member";

        public string ResetMemberPassword(string password)
        {
            string result = string.Empty;

            // update the user's password in the db to the given password

            return result;
        }
    }
}
