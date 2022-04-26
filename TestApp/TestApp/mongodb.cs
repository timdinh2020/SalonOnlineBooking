using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApp
{
    public class mongodb
    {

        // accounts Collection **************************************************
        /*
         * Function:     db_getAcctByEmail
         * 
         * Description:  Get the account obj that matches the email
         * 
         * Parameters:   string email_: to be used to identify Account object in database
         * 
         * Return value: List<Account> - returns the list of account obj found in database 
         * 
         */
        public List<Account> db_getAcctByEmail(string email_)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var myAccount = accounts.Find(a => a.email == email_).ToList();

            return myAccount;
        }

        /*
         * 
         * Function:     db_getAcctById
         * 
         * Description:  Get the account obj that matches the Id
         * 
         * Parameters:   BsonObjectId Id_: to be used to identify Account object in database
         * 
         * Return value: List<Account> - returns the list of account obj found in database 
         * 
         */
        public List<Account> db_getAcctById(BsonObjectId Id_)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var myAccount = accounts.Find(a => a.Id == Id_).ToList();

            return myAccount;
        }

        /*
         * 
         * Function:     db_createAcct
         * 
         * Description:  Insert new account to the database
         * 
         * Parameters:   Account newAcct - contains new account info
         * 
         * Return value: None
         * 
         */
        public void db_createAcct(Account newAcct)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            accounts.InsertOne(newAcct);
        }

        /*
         * 
         * Function:     db_deleteAcctById
         * 
         * Description:  delete an account in the database
         * 
         * Parameters:   BsonObjectId Id_: to be used to identify Account object in database
         * 
         * Return value: None
         * 
         */
        public void db_deleteAcctById(BsonObjectId Id_)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            accounts.DeleteOne(a => a.Id == Id_);
        }

        /*
         * 
         * Function:     db_deleteAcctByEmail
         * 
         * Description:  delete an account in the database
         * 
         * Parameters:   string email_: to be used to identify Account object in database
         * 
         * Return value: None
         * 
         */
        public void db_deleteAcctByEmail(string email_)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            accounts.DeleteOne(a => a.email == email_);
        }

        /*
         * 
         * Function:     db_updateFieldById
         * 
         * Description:  Get the account obj that matches the email
         * 
         * Parameters:   BsonObjectId Id_ - to be used to identify Account object in database
         *               string field_name - the field name of the account obj
         *               string value - new value to the field name
         *               
         * Return value: None
         * 
         */
        public void db_updateFieldById(BsonObjectId Id_, string field_name, string value)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var filter = Builders<Account>.Filter.Eq("_id", Id_);
            var update = Builders<Account>.Update.Set(field_name, value);
            accounts.UpdateOne(filter, update);
        }

        // appointments Collection **************************************************
        /*
        public List<Appointment> db_getApptsByEmail(string email_)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var appointments = mongodb.GetCollection<Account>("appointments");

            var myAppts = appointments.Find(a => a.email == email_).ToList();

            return myAppts;
        }
        */

    }
}
