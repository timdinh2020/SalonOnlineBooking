using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Hairdresser : Account
    {
        public string Role = "hair-dresser";
        public string AvailableDays { get; set; }

        public string ViewAvailability()
        {
            // return the string of available days
            return AvailableDays;
        }
        public string ModifyAvailability(string availableDays)
        {
            string result = string.Empty;

            return result;
        }
        public string AddNewHairdresser(string email, string availableDays)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // get the account that matches the given email
            var haird = db.db_getAcctByEmail(email);

            // if a matching account is found in db and it's role is not hair-dresser
            if (haird.Count != 0 && haird[0].role != "hair-dresser")
            {
                // change the role of the account to hairdresser
                db.db_updateFieldById(haird[0].Id, "role", "hair-dresser");

                // update the available days of the account
                db.db_updateFieldById(haird[0].Id, "avail_days", availableDays);

                result = "This hair-dresser has been successfully created!";
            }
            else if (haird.Count == 0) // if a matching account is not found in the database
            {
                // make a failure message
                result = "There is no account with that email. Try again.";
            }
            else // if the matching account's role is hair-dresser
            {
                // make failure message
                result = "That account is already labeled as a hair-dresser.";
            }

            return result;
        }
        public string RemoveHairdresser(string email)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // get the account that matches the given email
            var haird = db.db_getAcctByEmail(email);

            // if a matching account is found in db and it's role is hair-dresser
            if (haird.Count != 0 && haird[0].role == "hair-dresser")
            {
                // delete the account
                db.db_deleteAcctByEmail(email);

                // make a success message
                result = "Hair-dresser has been successfully removed!";
            }
            else if(haird.Count == 0) // if a matching account is not found in the database
            {
                // make a failure message
                result = "There is no hair-dresser with that email. Try again.";
            }
            else // if the matching account's role is not hair-dresser
            {
                result = "Removal failed. The given account is not a hair-dresser account.";
            }

            return result;
        }
    }
}