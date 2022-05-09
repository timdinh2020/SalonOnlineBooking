using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Hairdresser : Account
    {
        public List<DateTime> ViewAvailability(string email)
        {
            List<DateTime> result = new List<DateTime>();

            mongodb db = new mongodb();

            // get the account that matches the given email
            var haird = db.db_getAcctByEmail(email);

            // if a matching account is found in the db
            if (haird != null)
            {
                // if the account's role is not hair-dresser
                if (haird.role != "hair-dresser")
                {
                    // set the result to null (a non-hair-dresser shouldn't have availability)
                    result = null;
                }
                else // if the account's role is hair-dresser
                {
                    // store the account's list of available dates
                    List<string> availability = haird.avail_days;

                    // if the account's list of available dates is not null
                    if (availability != null)
                    {
                        // loop over the available dates list
                        for (int i = 0; i < availability.Count; i++)
                        {
                            // convert the current date string to a DateTime variable
                            DateTime date = DateTime.Parse(availability[i]);

                            // add this DateTime variable to the result list
                            result.Add(date);
                        }
                    }
                    else // if the account's list of available dates is null
                    {
                        // set the result to null
                        result = null;
                    }
                }
            }
            else // if a matching account is not found in db
            {
                // set the result to null
                result = null;
            }

            return result;
        }
        public string ModifyAvailability(string email, List<DateTime> availableDays)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            var haird = db.db_getAcctByEmail(email);

            // if a matching account is found in db and it's role is hair-dresser
            if (haird != null && haird.role == "hair-dresser")
            {
                // create the new list for the strings of the account's available dates
                List<string> availability = new List<string>();

                // if the given list of available dates is not null
                if (availableDays != null)
                {
                    // loop over the given list of available dates
                    for (int i = 0; i < availableDays.Count(); i++)
                    {
                        // convert the current date to a string
                        string date = availableDays[i].ToShortDateString();

                        // add the date string to the new available dates list
                        availability.Add(date);
                    }
                }
                else // if the given list of available dates is null
                {
                    // set the new available dates list to null
                    availability = null;
                }

                // update the available dates list of the account
                db.db_updateAcctById(haird.Id, "avail_days", availability);

                result = "Success";
            }
            else if (haird == null) // if a matching account is not found in the database
            {
                // make a failure message
                result = "There is no account with that email. Try again.";
            }
            else // if the matching account's role is not hair-dresser
            {
                // make failure message
                result = "That account is not labeled as a hair-dresser.";
            }

            return result;
        }
        public string AddNewHairdresser(string email, List<DateTime> availableDays)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            var haird = db.db_getAcctByEmail(email);

            // if a matching account is found in db and it's role is not hair-dresser
            if (haird != null && haird.role != "hair-dresser")
            {
                // change the role of the account to hairdresser
                db.db_updateAcctById(haird.Id, "role", "hair-dresser");

                List<string> availability = new List<string>();

                if (availableDays != null)
                {
                    for (int i = 0; i < availableDays.Count(); i++)
                    {
                        string date = availableDays[i].ToShortDateString();

                        availability.Add(date);
                    }
                }
                else
                {
                    availability = null;
                }

                db.db_updateAcctById(haird.Id, "avail_days", availability);

                result = "Success";
            }
            else if (haird == null)
            {
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
            if (haird != null && haird.role == "hair-dresser")
            {
                // demote the hair-dresser to a member account
                db.db_updateAcctById(haird.Id, "role", "member");

                // remove the availability from the account
                db.db_updateAcctById(haird.Id, "avail_days", (List <string>)null);

                // make a success message
                result = "Success";
            }
            else if(haird == null)
            {
                result = "There is no account with that email. Try again.";
            }
            else
            {
                result = "Removal failed. The given account is not a hair-dresser account.";
            }

            return result;
        }
    }
}