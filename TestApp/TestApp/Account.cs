using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TestApp
{
    public class Account
    {
        //[BsonElement("_id")]
        public BsonObjectId Id { get; set; }

        //[BsonElement("first_name")]
        public string first_name { get; set; }

        //[BsonElement("last_name")]
        public string last_name { get; set; }

        //[BsonElement("role")]
        public string role { get; set; }

        //[BsonElement("email")]
        public string email { get; set; }

        //[BsonElement("username")]
        public string username { get; set; }

        //[BsonElement("password")]
        public string password { get; set; }

        //[BsonElement("avail_days")]
        public string avail_days { get; set; }

        public void GetAccount()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:<sob123>@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<BsonDocument>("accounts");

            /*
            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
            */
        }

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
            }

            return result;
        }

        public string CreateAccount(string firstName, string lastName, string email, string username, string password)
        {
            string result = string.Empty;
            bool emailFound = true; // debug
            bool userFound = true; // debug

            if (firstName == null || lastName == null || email == null || username == null || password == null)
            {
                result = "All fields are required. Try again.";
                return result;
            }

            // check if the given email and username are both unique (not already in the db)
            // if the email or username is in the db, return an error (don't store their info in the db)
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
            }

            return result;
        }

        public string EditAccount(string firstName, string lastName, string email, string username, string password)
        {
            string result = string.Empty;

            if (firstName == null && lastName == null && email == null && username == null && password == null)
            {
                result = "No changes to be made.";
            }
            else
            {

            }

            return result;
        }

        public string ResetPassword(string username, string password)
        {
            string result = string.Empty;

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
