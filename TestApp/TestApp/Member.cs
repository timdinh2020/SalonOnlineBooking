using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Member : Account
    {
        public string ResetMemberPassword(string email, string password)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // get the member's account using the given email
            var member = db.db_getAcctByEmail(email);

            // if the member exists in the db
            if(member != null)
            {
                // update the member's password to the given password
                db.db_updateAcctById(member.Id, "password", password);

                // report successful password reset message
                result = "Success";
            }
            else // if the member doesn't exist in the db
            {
                // report non-existing account error message
                result = "Password reset failed. There is no account with that email.";
            }

            return result;
        }
    }
}