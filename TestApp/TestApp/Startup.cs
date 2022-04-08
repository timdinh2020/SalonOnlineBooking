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
            /**************************
             * Database testing END
             */
        }
    }
}
