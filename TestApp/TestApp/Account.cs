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

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("avail_days")]
        public string avail_days { get; set; }

        [BsonElement("avail_times")]
        public string avail_times { get; set; }

        public string LogIn(string email_, string password_)
        {
            string result = string.Empty;

            // if the user didn't enter an email or a password
            if (email_ == null || password_ == null || email_ == string.Empty || password_ == string.Empty)
            {
                // don't try to log them in, inform the user that both must be entered to continue
                result = "Both username and password are required inputs. Try again.";
            }
            else // if the user did enter an email and password
            {   
                // create a new mongo object
                mongodb db = new mongodb();

                // search for an account with the given email in the database
                var user = db.db_getAcctByEmail(email_);

                // if a matching account is found in db (not null)
                if (user != null)
                {
                    // if the password of the stored account matches the given password
                    if (user[0].password == password_)
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

        public string CreateAccount(string firstName_, string lastName_, string role_, string email_, string username_, string password_, string avail_days_)
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

            // if a matching account is found in db (not null)
            if(user != null && !user.Any())
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
                    username = username_,
                    password = password_,
                    avail_days = string.Empty
                };

                // add the new account to the database
                db.db_createAcct(newAccount);

                // make a success message
                result = "Account Creation Successful!";
            }

            // return the message
            return result;
        }

        public string EditAccount(BsonObjectId Id_, string firstName_, string lastName_, string email_, string username_, string new_pass, string avail_days_, string password_)
        {
            string result = string.Empty;
            
            mongodb db = new mongodb();

            // if an account ID was not entered
            if(Id_ == null)
            {
                // make a failure message and return it immediately
                result = "No account to update. Try again.";
                return result;
            }

            // used for testing
            //Account account = new Account {
            //    firstName = "Tim",
            //        lastName = "Dinh",
            //        role = "owner",
            //        email = "timSOB@gmail.com",
            //        username = "timSOB@gmail.com",
            //        password = "admin",
            //        avail_days = "mon,tues,wed,thurs,fri"
            //};

            //// set the account array to include the above account
            //Account[] user = new Account[1] {account};

            // search for an account with the given ID in the database
            var user = db.db_getAcctById(Id_);

            // if a matching account is not found in the db
            if (user == null && user.Any())
            {
                // make a failure message and return it immediately
                result = "That account doesn't exist. Try again.";
                return result;
            }

            // if the password of the stored account doesn't match the given password
            if (user[0].password != password_)
            {
                // don't update the user's account, make a failure message
                result = "Login Failed. Incorrect password.";
            }
            else // if the passwords do match
            {
                // if the user entered a new first name
                if (firstName_ != null && firstName_ != string.Empty)
                {
                    // update the user's stored first name in the db
                    db.db_updateFieldById(Id_, "first_name", firstName_);
                }

                // if the user entered a new last name
                if (lastName_ != null && lastName_ != string.Empty)
                {
                    // update the user's stored last name in the db
                    db.db_updateFieldById(Id_, "last_name", lastName_);
                }

                // if the user entered a new email
                if (email_ != null && email_ != string.Empty)
                {
                    // update the user's stored email in the db
                    db.db_updateFieldById(Id_, "email", email_);
                }

                // if the user entered a new username
                if (username_ != null && username_ != string.Empty)
                {
                    // update the user's stored username in the db
                    db.db_updateFieldById(Id_, "username", username_);
                }

                // if the user entered a new password
                if (new_pass != null && new_pass != string.Empty)
                {
                    // update the user's stored password in the db
                    db.db_updateFieldById(Id_, "password", new_pass);
                }

                // if the user (hairdresser) entered a new list of available days
                if(avail_days_ != null && avail_days_ != string.Empty)
                {
                    // update the user's stored list of available days in the db
                    db.db_updateFieldById(Id_, "avail_days", avail_days_);
                }

                // make a success message
                result = "Your account has been successfully updated.";
            }

            // return the message
            return result;
        }

        public string ResetPassword(BsonObjectId Id_, string password_, string new_pass)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            //Account account = new Account
            //{
            //    firstName = "Tim",
            //    lastName = "Dinh",
            //    role = "owner",
            //    email = "timSOB@gmail.com",
            //    username = "timSOB@gmail.com",
            //    password = "admin",
            //    avail_days = "mon,tues,wed,thurs,fri"
            //};

            
            //// set the account array to include the above account
            //Account[] user = new Account[1] { account }; // db.db_getAcctById(Id_);

            // search for an account with the given ID in the database
            var user = db.db_getAcctById(Id_);

            // if a matching account is found in db (not null)
            if (user != null && !user.Any())
            {
                // if the password of the stored account matches the given password
                if (user[0].password == password_)
                {
                    // update the user's stored password in the db
                    db.db_updateFieldById(Id_, "password", new_pass);

                    // make a success message
                    result = "You password has been successfully updated.";
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
                result = "Failed. No account found with this username.";
            }

            // return the message
            return result;
        }

        public string LogOut(BsonObjectId Id_)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // log the user out by clearing the user's access token column in the database
            // db.db_updateFieldById(Id_, "access_token", "");

            // make a success message
            result = "You have been successfully logged out!";

            // return the message
            return result;
        }
    }
}
