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
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();
            var mongodb = dbClient.GetDatabase("SOB");
            //var accounts = mongodb.GetCollection<Account>("accounts");
            //var services = mongodb.GetCollection<Service>("services");

            mongodb db = new mongodb();

            Hairdresser hairdresser = new Hairdresser();

            List<DateTime> original = new List<DateTime>();

            DateTime may9 = new DateTime(2022, 5, 9);
            DateTime may10 = new DateTime(2022, 5, 10);
            DateTime may13 = new DateTime(2022, 5, 13);
            DateTime may18 = new DateTime(2022, 5, 18);

            original.Add(may9);
            original.Add(may10);
            original.Add(may13);
            original.Add(may18);

            List<DateTime> available = new List<DateTime>();
            List<DateTime> memAvail = new List<DateTime>();
            List<DateTime> noAvail = new List<DateTime>();

            var accounts = db.db_getAcctsByRole("hair-dresser");

            var acc = db.db_getAcctByEmail("alexisSOBpe@gmail.com");

            // Act
            for (int i = 0; i < accounts.Count; i++)
            {
                available = hairdresser.ViewAvailability(accounts[i].email);
            }

            memAvail = hairdresser.ViewAvailability(acc.email);
            noAvail = hairdresser.ViewAvailability("tets@test.test");

            if(original == available)
            {
                original = null;
            }
            else
            {
                noAvail = null;
            }

            //var hairCutting = services.Find(s => s.title == "Hair Cutting").FirstOrDefault();

            //hairCutting.RemoveService("Fade", false);

            //hairCutting.ViewAvailableServices();

            //var owner = accounts.Find(a => a.role == "owner").ToList();

            //var newAcc = new Account();
            //var resp = newAcc.CreateAccount("Alexis", "Peoples", "member", "alexisSOBpe@gmail.com", "pass123");

            //var acc = accounts.Find(a => a.email == "alexisSOBpe@gmail.com").ToList();
            //var resp = acc[0].LogIn("alexisSOBpe@gmail.com", "pass123");
            //var resp = acc[0].EditAccount(acc[0].Id, "Nikole", "", "", "", "pass123");
            //var resp = acc[0].ResetPassword(acc[0].Id, "pass123", "pass1234");
            //var resp = acc[0].LogOut(acc[0].Id);

            //var response = owner[0].EditAccount(owner[0].Id, null, null, null, null, null, "admin");

            //var myAccount = accounts.Find(a => a.email == "alexisSOBpe@gmail.com").FirstOrDefault();

            // test insert an account
            /*
            var newAccount = new Account
            {
                firstName = "a",
                lastName = "a",
                role = "a",
                email = "a",
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
