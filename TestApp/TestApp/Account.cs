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
        public string first_name { get; set; }

        [BsonElement("last_name")]
        public string last_name { get; set; }

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

        /* deprecated
        public void GetAccount()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:<sob123>@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var dbList = dbClient.ListDatabases().ToList();
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<BsonDocument>("accounts");
        }
        */

        public string LogIn(string username, string password)
        {

            string result = string.Empty;

            if (username == null || password == null)
            {
                result = "Both username and password are required inputs. Try again.";
            }
            else
            {
                // compare given username to usernames in database
                // if username is found in db, compare the given and stored passwords, else print no user error
                // if passwords match, log the user in (create access token and store in db?), else print invalid credentials
                MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
                var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
                var accounts = mongodb.GetCollection<Account>("accounts");

                var myAccount = accounts.Find(a => a.email == username).ToList();
                if (myAccount != null)
                {
                    if (myAccount[0].password == password)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "Failed. Wrong password.";
                    }
                }
                else
                {
                    result = "Failed. No account found with this username.";
                }
            }

            return result;
        }

        public string CreateAccount(string firstName_, string lastName_, string role_, string email_, string username_, string password_, string avail_days_)
        {
            string result = string.Empty;
            bool emailFound = true; // debug
            bool userFound = true; // debug

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:<sob123>@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            if (firstName_ == null || lastName_ == null || email_ == null || username_ == null || password_ == null)
            {
                result = "All fields are required. Try again.";
                return result;
            }

            // check if the given email and username are both unique (not already in the db)
            // if the email or username is in the db, return an error (don't store their info in the db)
            var testEmail = accounts.Find(a => a.email == email_).ToList();
            if ( (testEmail != null) && (!testEmail.Any()) )
            { } else { emailFound = false; }

            var testUsername = accounts.Find(a => a.username == username_).ToList();
            if ( (testUsername != null) && (!testUsername.Any()) )
            { } else { userFound = false; }

            if (emailFound && userFound)
            {
                result = "That email and username is already associated with an account.";
            }
            else if (emailFound)
            {
                result = "That email is already associated with an account.";
            }
            else if (userFound)
            {
                result = "That username is already associated with an account.";
            }
            else
            {
                // if the email and username are both unique, store all their info in the db
                result = "Account Creation Successful!";
                var newAccount = new Account
                {
                    first_name = firstName_,
                    last_name = lastName_,
                    role = role_,
                    email = email_,
                    username = username_,
                    password = password_,
                    avail_days = avail_days_,
                };
                accounts.InsertOne(newAccount);
            }

            return result;
        }

        // This function updates the new value for selected field in database
        public void updateDB_field(BsonObjectId Id_, string field_name, string value)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:<sob123>@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var filter = Builders<Account>.Filter.Eq("_id", Id_);
            var update = Builders<Account>.Update.Set(field_name, value);
            accounts.UpdateOne(filter, update);
        }

        public string EditAccount(BsonObjectId Id_, string firstName_, string lastName_, string email_, string username_, string password_, string avail_days_)
        {
            string result = string.Empty;

            updateDB_field(Id_, "first_name", firstName_);
            updateDB_field(Id_, "last_name", lastName_);
            updateDB_field(Id_, "email", email_);
            updateDB_field(Id_, "username", username_);
            updateDB_field(Id_, "password", password_);
            updateDB_field(Id_, "avail_days", avail_days_);
            result = "Success";

            return result;
        }

        public string ResetPassword(string username_, string password_)
        {
            string result = string.Empty;

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:<sob123>@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var myAccount = accounts.Find(a => a.username == username_).ToList();
            if (myAccount != null)
            {
                if (myAccount[0].password == password_)
                {
                    var filter = Builders<Account>.Filter.Eq("username", username_);
                    var update = Builders<Account>.Update.Set("password", "temp123");
                    accounts.UpdateOne(filter, update);
                    result = "Success";
                }
                else
                {
                    result = "Failed. Wrong password.";
                }
            }
            else
            {
                result = "Failed. No account found with this username.";
            }

            return result;
        }

        public string LogOut()
        {
            string result = string.Empty;

            // log the user out (delete the user's access token from the db?)
            result = "You have successfully logged out!";

            return result;
        }
    }
}
