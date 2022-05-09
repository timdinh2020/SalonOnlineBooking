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

        // Accounts Collection *************************************************************************************************************************
        /*
         * Function:     db_getAcctByEmail
         * 
         * Description:  Get the account object that matches the email
         * 
         * Parameters:   string email_: to be used to identify Account object in database
         * 
         * Return value: Account - returns the account object found in database 
         * 
         */
        public Account db_getAcctByEmail(string email_)
        {
            // MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            // var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var myAccount = accounts.Find(a => a.email == email_).FirstOrDefault();

            return myAccount;
        }

        /*
         * 
         * Function:     db_getAcctById
         * 
         * Description:  Get the account object that matches the Id
         * 
         * Parameters:   BsonObjectId Id_: to be used to identify Account object in database
         * 
         * Return value: Account - returns the account object found in database 
         * 
         */
        public Account db_getAcctById(BsonObjectId Id_)
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var myAccount = accounts.Find(a => a.Id == Id_).FirstOrDefault();

            return myAccount;
        }

        /*
         * 
         * Function:     db_getAcctsByRole
         * 
         * Description:  Get the account objects that match the given role
         * 
         * Parameters:   string role_: to be used to identify Account objects in database
         * 
         * Return value: List<Account> - returns the account objects found in database 
         * 
         */
        public List<Account> db_getAcctsByRole(string role_)
        {
            // MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            // var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var myAccount = accounts.Find(a => a.role == role_).ToList();

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
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
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
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
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
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var accounts = mongodb.GetCollection<Account>("accounts");

            accounts.DeleteOne(a => a.email == email_);
        }

        /* "T" Source: https://stackoverflow.com/questions/5886875/let-method-take-any-data-type-in-c-sharp
         * 
         * Function:     db_updateAcctById
         * 
         * Description:  Update the given field in the database for the given account
         * 
         * Parameters:   BsonObjectId Id_ - to be used to identify Account object in database
         *               string field_name - the field name of the account object
         *               T value - new value to add to the given field of the account object (value type changes depending on field type)
         *               
         * Return value: None
         * 
         */
        public void db_updateAcctById<T>(BsonObjectId Id_, string field_name, T value)
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var accounts = mongodb.GetCollection<Account>("accounts");

            var filter = Builders<Account>.Filter.Eq("_id", Id_);
            var update = Builders<Account>.Update.Set(field_name, value);
            accounts.UpdateOne(filter, update);
        }

        // Services Collection *************************************************************************************************************************
        /*
         * Function:     db_getServByTitle
         * 
         * Description:  Get the service object that matches the title
         * 
         * Parameters:   string title_: to be used to identify Service object in database
         * 
         * Return value: Service - returns the service object found in database 
         * 
         */
        public Service db_getServByTitle(string title_)
        {
            // MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            // var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var services = mongodb.GetCollection<Service>("services");

            var theService = services.Find(a => a.title == title_).FirstOrDefault();

            return theService;
        }

        /*
         * 
         * Function:     db_getServById
         * 
         * Description:  Get the service object that matches the Id
         * 
         * Parameters:   BsonObjectId Id_: to be used to identify Service object in database
         * 
         * Return value: Service - returns the service object found in database 
         * 
         */
        public Service db_getServById(BsonObjectId Id_)
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var services = mongodb.GetCollection<Service>("services");

            var theService = services.Find(a => a.Id == Id_).FirstOrDefault();

            return theService;
        }

        /*
         * 
         * Function:     db_createServ
         * 
         * Description:  Insert new service into the database
         * 
         * Parameters:   Service newServ - contains new service info
         * 
         * Return value: None
         * 
         */
        public void db_createServ(Service newServ)
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var services = mongodb.GetCollection<Service>("services");

            services.InsertOne(newServ);
        }

        /*
         * 
         * Function:     db_deleteServById
         * 
         * Description:  Delete a service from the database
         * 
         * Parameters:   BsonObjectId Id_: to be used to identify Service object in database
         * 
         * Return value: None
         * 
         */
        public void db_deleteServById(BsonObjectId Id_)
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var services = mongodb.GetCollection<Service>("services");

            services.DeleteOne(a => a.Id == Id_);
        }

        /*
         * 
         * Function:     db_deleteServByTitle
         * 
         * Description:  Delete a service from the database
         * 
         * Parameters:   string title: to be used to identify Service object in database
         * 
         * Return value: None
         * 
         */
        public void db_deleteServByTitle(string title_)
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var services = mongodb.GetCollection<Service>("services");

            services.DeleteOne(a => a.title == title_);
        }

        /*
         * 
         * Function:     db_updateServById
         * 
         * Description:  Update the given field in the database for the given service
         * 
         * Parameters:   BsonObjectId Id_ - to be used to identify Service object in database
         *               string field_name - the field name of the service object
         *               T value - new value to add to the given field of the account object (value type changes depending on field type)
         *               
         * Return value: None
         * 
         */
        public void db_updateServById<T>(BsonObjectId Id_, string field_name, T value)
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://admin:sob123@cluster1.8dqvn.mongodb.net/Salon_Online_Booking?retryWrites=true&w=majority");
            //var mongodb = dbClient.GetDatabase("Salon_Online_Booking");

            MongoClient dbClient = new MongoClient("mongodb+srv://admin:sobAppADMIN@salon-online-booking.fqtv2.mongodb.net/SOB?retryWrites=true&w=majority");
            var mongodb = dbClient.GetDatabase("SOB");
            var services = mongodb.GetCollection<Service>("services");

            var filter = Builders<Service>.Filter.Eq("_id", Id_);
            var update = Builders<Service>.Update.Set(field_name, value);
            services.UpdateOne(filter, update);
        }

        // Appointments Collection *************************************************************************************************************************
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
