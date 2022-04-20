using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Member : Account
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