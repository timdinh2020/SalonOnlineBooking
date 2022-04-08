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
    }
}
