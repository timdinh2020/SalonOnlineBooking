using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApp
{
    public class Account
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }

        [BsonElement("first_name")]
        public string firstName { get; set; }

        [BsonElement("last_name")]
        public string lastName { get; set; }

        [BsonElement("role")]
        public string role { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("avail_days")]
        public string avail_days { get; set; }

        public string LogIn(string email_, string password_)
        {
            string result = string.Empty;

            // if the user didn't enter an email or a password
            if (email_ == null || password_ == null || email_ == string.Empty || password_ == string.Empty)
            {
                // don't try to log them in, inform the user that both must be entered to continue
                result = "Both email and password are required inputs. Try again.";
            }
            else // if the user did enter an email and password
            {
                // create a new mongo object
                mongodb db = new mongodb();

                // search for an account with the given email in the database
                var user = db.db_getAcctByEmail(email_);

                // if a matching account is found in db (count is not 0)
                if (user != null)
                {
                    // if the password of the stored account matches the given password
                    if (user.password == password_)
                    {
                        // log the user in (update their access token field in the db to a valid token)

                        // make a success message
                        result = "Success";
                    }
                    else // if the passwords don't match
                    {
                        // don't log the user in, make a failure message
                        result = "Login Failed. Incorrect password.";
                    }
                }
                else // if a matching account is not found in the database
                {
                    // don't log the user in, make a failure message
                    result = "Login Failed. No account found with this email.";
                }
            }

            // return the message
            return result;
        }

        public string CreateAccount(string firstName_, string lastName_, string role_, string email_, string password_, string avail_days_)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // if the user didn't enter a value for one of the fields
            if (firstName_ == null || lastName_ == null || email_ == null || password_ == null ||
                firstName_ == string.Empty || lastName_ == string.Empty || email_ == string.Empty ||
                password_ == string.Empty)
            {
                // make a failure message and return it immediately
                result = "All fields are required. Try again.";
                return result;
            }

            // search for an account with the given email in the database
            var user = db.db_getAcctByEmail(email_);

            // if a matching account is found in db (count is not 0)
            if (user != null)
            {
                // don't create the new account, make a failure message
                result = "That email is already associated with an account. Try again.";
            }
            else // if a matching account is not found in the database
            {
                // create a new account object using the given information
                var newAccount = new Account
                {
                    firstName = firstName_,
                    lastName = lastName_,
                    role = role_,
                    email = email_,
                    password = password_,
                    avail_days = string.Empty
                };

                // add the new account to the database
                db.db_createAcct(newAccount);

                // make a success message
                result = "Success";
            }

            // return the message
            return result;
        }

        public string EditAccount(string token, string firstName_, string lastName_, string email_, string new_pass, string avail_days_, string password_)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // if an account ID was not entered
            if (token == null)
            {
                // make a failure message and return it immediately
                result = "No account found to update. Try again.";
                return result;
            }

            // used for testing
            //Account account = new Account {
            //    firstName = "Tim",
            //        lastName = "Dinh",
            //        role = "owner",
            //        email = "timSOB@gmail.com",
            //        password = "admin",
            //        avail_days = "mon,tues,wed,thurs,fri"
            //};

            //// set the account array to include the above account
            //Account[] user = new Account[1] {account};

            // search for an account with the given ID in the database
            var user = db.db_getAcctByEmail(token);

            // if a matching account is not found in db (count is 0)
            if (user == null)
            {
                // make a failure message and return it immediately
                result = "That account doesn't exist. Try again.";
                return result;
            }

            // if the password of the stored account doesn't match the given password
            if (user.password != password_)
            {
                // don't update the user's account, make a failure message
                result = "Account update failed due to incorrect password. Try again.";
            }
            else // if the passwords do match
            {
                // if the user entered a new first name
                if (firstName_ != null && firstName_ != string.Empty)
                {
                    // update the user's stored first name in the db
                    db.db_updateAcctById(user.Id, "first_name", firstName_);
                }

                // if the user entered a new last name
                if (lastName_ != null && lastName_ != string.Empty)
                {
                    // update the user's stored last name in the db
                    db.db_updateAcctById(user.Id, "last_name", lastName_);
                }

                // if the user entered a new email
                if (email_ != null && email_ != string.Empty)
                {
                    var existingUser = db.db_getAcctByEmail(email_);

                    if (existingUser == null)
                    {
                        // update the user's stored email in the db
                        db.db_updateAcctById(user.Id, "email", email_);
                    }
                    else
                    {
                        result = "That email is already associated with an account. Try again.";
                        return result;
                    }
                }

                // if the user entered a new password
                if (new_pass != null && new_pass != string.Empty)
                {
                    // update the user's stored password in the db
                    db.db_updateAcctById(user.Id, "password", new_pass);
                }

                // if the user (hairdresser) entered a new list of available days
                if (avail_days_ != null && avail_days_ != string.Empty)
                {
                    // update the user's stored list of available days in the db
                    db.db_updateAcctById(user.Id, "avail_days", avail_days_);
                }

                // make a success message
                result = "Success";
            }

            // return the message
            return result;
        }

        public string ResetPassword(string token, string password_, string new_pass)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            //Account account = new Account
            //{
            //    firstName = "Tim",
            //    lastName = "Dinh",
            //    role = "owner",
            //    email = "timSOB@gmail.com",
            //    password = "admin",
            //    avail_days = "mon,tues,wed,thurs,fri"
            //};


            //// set the account array to include the above account
            //Account[] user = new Account[1] { account }; // db.db_getAcctById(Id_);

            // search for an account with the given ID in the database
            var user = db.db_getAcctByEmail(token);

            // if a matching account is found in db (count is not 0)
            if (user != null)
            {
                // if the password of the stored account matches the given password
                if (user.password == password_)
                {
                    // update the user's stored password in the db
                    db.db_updateAcctById(user.Id, "password", new_pass);

                    // make a success message
                    result = "Success";
                }
                else // if the passwords don't match
                {
                    // make a failure message
                    result = "Your current password is incorrect. Try again.";
                }
            }
            else // if a matching account is not found in the database
            {
                // make a failure message
                result = "Password reset failed. No account found.";
            }

            // return the message
            return result;
        }

        public string LogOut(BsonObjectId Id_)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // log the user out by clearing the user's access token column in the database
            // db.db_updateAcctById(Id_, "access_token", "");

            // make a success message
            result = "Success";

            // return the message
            return result;
        }
    }
}
