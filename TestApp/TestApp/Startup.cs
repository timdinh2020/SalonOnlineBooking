using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

[assembly: OwinStartup(typeof(TestApp.Startup))]

namespace TestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            /**************************
             * Database testing
             */
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();
            var mongodb = dbClient.GetDatabase("Salon_Online_Booking");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var owner = accounts.Find(a => a.role == "owner").ToList();
            var myAccount = accounts.Find(a => a.username == "tdinh123").ToList();

            // test insert an account
            /*
            var newAccount = new Account
            {
                first_name = "a",
                last_name = "a",
                role = "a",
                email = "a",
                username = "a",
                password = "a",
                avail_days = "a",
            };
            accounts.InsertOne(newAccount);
            */

            // test update password
            /*
            var filter = Builders<Account>.Filter.Eq("username", "tdinh123");
            var update = Builders<Account>.Update.Set("password", "temp123");
            accounts.UpdateOne(filter, update);
            var myAccount2 = accounts.Find(a => a.username == "tdinh123").ToList();
            */

            /**************************
             * Database testing END
             */
        }
    }
}
