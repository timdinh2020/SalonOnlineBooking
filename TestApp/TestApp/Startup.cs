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
            //var appointments = mongodb.GetCollection<Appointment>("appointments");

            mongodb db = new mongodb();

            //// initialize master services with -1 starting price (since they aren't an actual bookable service)
            //Service hairCutting = new Service("Hair Cutting", "Different kinds of hair cutting services!", -1, null);

            //// initialize regular services with the correct master service (the master service must exist in the db already)
            //Service cutServ = new Service("Haircut", "Quality haircuts for everyone.", 19.99, "Hair Cutting");
            //Service bTrimServ = new Service("Beard Trim", "Quick touch-up to keep your beard looking sharp.", 11.99, "Hair Cutting");
            //Service shapeServ = new Service("Shape Up", "Test description number 3.", 10.50, "Hair Cutting");

            //hairCutting.AddNewService(cutServ);
            //hairCutting.AddNewService(bTrimServ);
            //hairCutting.AddNewService(shapeServ);

            //Appointment appointment = new Appointment();

            //var mary = db.db_getAcctByEmail("marysobtest@gmail.com");

            //var appts = db.db_getApptsByEmail(mary.email);

            //var appt1 = appts[0];
            //var appt2 = appts[1];

            //var service1 = db.db_getServByTitle("Root Touch Up");
            //var service2 = db.db_getServByTitle("Individual Braids");
            //var service3 = db.db_getServByTitle("Bleaching");
            //var service4 = db.db_getServByTitle("Split Dye");
            //var service5 = db.db_getServByTitle("Sew In");

            //List<Service> mary1 = new List<Service>();
            //List<Service> mary2 = new List<Service>();
            //List<Service> mary3 = new List<Service>();

            //mary1.Add(service4);

            //mary2.Add(service3);
            //mary2.Add(service5);

            //mary3.Add(service2);
            //mary3.Add(service1);

            //var date1 = new DateTime(2022, 5, 11, 15, 30, 0);
            //var date2 = new DateTime(2022, 5, 18, 13, 0, 0);
            //var date3 = new DateTime(2022, 5, 25, 12, 0, 0);
            //var date4 = new DateTime(2022, 6, 1, 10, 45, 0);

            // Act
            //string actualRight = appointment.ModifyAppointment(appt2.Id, date1, mary1);
            //string actualRight2 = appointment.ModifyAppointment(appt1.Id, date3, mary2);
            //string actualWrong = appointment.ModifyAppointment(appt2.Id, date2, mary3);

            //var newAcc = new Account();
            //newAcc.CreateAccount("Justin", "Harris", "member", "justinsobtest@gmail.com", "jus123"); // member account
            //newAcc.CreateAccount("Tabitha", "Schneider", "member", "tabithasobtest@gmail.com", "tab123"); // member account
            //newAcc.CreateAccount("Mary", "Peeps", "member", "marysobtest@gmail.com", "mary123"); // member account
            //newAcc.CreateAccount("Hannah", "Nimble", "member", "hannahsobtest@gmail.com", "han123"); // hairdresser account
            //newAcc.CreateAccount("Levi", "Martin", "member", "levisobtest@gmail.com", "levi123"); // hairdresser account
            //newAcc.CreateAccount("Kait", "Blum", "member", "kaitsobtest@gmail.com", "kait123"); // hairdresser account
            //newAcc.CreateAccount("Tanya", "Smith", "member", "tanyasobtest@gmail.com", "tan123"); // hairdresser account
            //newAcc.CreateAccount("Baxter", "Jones", "member", "baxtersobtest@gmail.com", "bax123"); // hairdresser account
            //newAcc.CreateAccount("Pierre", "Domino", "member", "pierresobtest@gmail.com", "pie123"); // hairdresser account

            //var hairColor = new Service("Hair Coloring", "Color your hair!", -1, null);
            //var bleach = new Service("Bleaching", "Bleach your hair to become blonde!", 29.99, "Hair Coloring");
            //var rootTU = new Service("Root Touch Up", "Re-dye your natural roots to match the rest of your hair!", 9.99, "Hair Coloring");
            //var split = new Service("Split Dye", "Dye half of your hair one color and dye the other half a different color!", 34.99, "Hair Coloring");
            //var hairAdd = new Service("Hair Additions", "Add more hair to your hair!", -1, null);
            //var indivB = new Service("Individual Braids", "Add braiding hair to your natural hair in the form of individual braids!", 80.00, "Hair Additions");
            //var fauxL = new Service("Faux Locks", "Add faux dreadlocks hair to your natural hair!", 150.00, "Hair Additions");
            //var sewIn = new Service("Sew In", "Sew hair bundles into your natural hair!", 350.00, "Hair Additions");
            //var exten = new Service("Extensions", "Add extensions into your natural hair!", 110.00, "Hair Additions");

            //hairColor.AddNewService(bleach);
            //hairColor.AddNewService(rootTU);
            //hairColor.AddNewService(split);

            //hairAdd.AddNewService(indivB);
            //hairAdd.AddNewService(fauxL);
            //hairAdd.AddNewService(sewIn);
            //hairAdd.AddNewService(exten);

            //Hairdresser hairdresser = new Hairdresser();

            //List<DateTime> hannahAvail = new List<DateTime>();
            //List<DateTime> leviAvail = new List<DateTime>();
            //List<DateTime> kaitAvail = new List<DateTime>();
            //List<DateTime> tanyaAvail = new List<DateTime>();
            //List<DateTime> baxterAvail = new List<DateTime>();
            //List<DateTime> pierreAvail = new List<DateTime>();

            //hannahAvail.Add(new DateTime(2022, 5, 10));
            //hannahAvail.Add(new DateTime(2022, 5, 11));
            //hannahAvail.Add(new DateTime(2022, 5, 12));
            //hannahAvail.Add(new DateTime(2022, 5, 13));
            //hannahAvail.Add(new DateTime(2022, 5, 16));
            //hannahAvail.Add(new DateTime(2022, 5, 17));
            //hannahAvail.Add(new DateTime(2022, 5, 18));
            //hannahAvail.Add(new DateTime(2022, 5, 19));
            //hannahAvail.Add(new DateTime(2022, 5, 20));
            //hannahAvail.Add(new DateTime(2022, 5, 23));
            //hannahAvail.Add(new DateTime(2022, 5, 24));
            //hannahAvail.Add(new DateTime(2022, 5, 25));
            //hannahAvail.Add(new DateTime(2022, 5, 26));
            //hannahAvail.Add(new DateTime(2022, 5, 27));
            //hannahAvail.Add(new DateTime(2022, 5, 30));
            //hannahAvail.Add(new DateTime(2022, 5, 31));
            //hannahAvail.Add(new DateTime(2022, 5, 1));
            //hannahAvail.Add(new DateTime(2022, 5, 2));
            //hannahAvail.Add(new DateTime(2022, 5, 3));

            //leviAvail.AddRange(hannahAvail);
            //leviAvail.RemoveRange(0, 5);

            //kaitAvail.AddRange(hannahAvail);
            //kaitAvail.RemoveRange(hannahAvail.Count()-5, 4);

            //tanyaAvail.AddRange(hannahAvail);
            //tanyaAvail.RemoveRange(5, 3);

            //baxterAvail.AddRange(hannahAvail);

            //pierreAvail.AddRange(hannahAvail);
            //pierreAvail.RemoveAt(16);

            //hairdresser.AddNewHairdresser("hannahsobtest@gmail.com", hannahAvail);
            //hairdresser.AddNewHairdresser("levisobtest@gmail.com", leviAvail);
            //hairdresser.AddNewHairdresser("kaitsobtest@gmail.com", kaitAvail);
            //hairdresser.AddNewHairdresser("tanyasobtest@gmail.com", tanyaAvail);
            //hairdresser.AddNewHairdresser("baxtersobtest@gmail.com", baxterAvail);
            //hairdresser.AddNewHairdresser("pierresobtest@gmail.com", pierreAvail);

            //Appointment appt = new Appointment();

            //var justin = db.db_getAcctByEmail("justinsobtest@gmail.com");
            //var tabitha = db.db_getAcctByEmail("tabithasobtest@gmail.com");
            //var mary = db.db_getAcctByEmail("marysobtest@gmail.com");
            //var hannah = db.db_getAcctByEmail("hannahsobtest@gmail.com");
            //var levi = db.db_getAcctByEmail("levisobtest@gmail.com");
            //var kait = db.db_getAcctByEmail("kaitsobtest@gmail.com");
            //var tanya = db.db_getAcctByEmail("tanyasobtest@gmail.com");
            //var baxter = db.db_getAcctByEmail("baxtersobtest@gmail.com");
            //var pierre = db.db_getAcctByEmail("pierresobtest@gmail.com");

            //var service1 = db.db_getServByTitle("Root Touch Up");
            //var service2 = db.db_getServByTitle("Extensions");

            //List<Service> tabS = new List<Service>();
            //List<Service> jusS = new List<Service>();

            //tabS.Add(service1);
            //tabS.Add(service2);

            //jusS.Add(service1);

            //var result = appt.MakeAppointment(new DateTime(2022, 5, 18, 13, 0, 0), baxter, tabitha, tabS);

            //if(result == "Success")
            //{
            //    var ph = "yes";
            //}
            //else
            //{
            //    var ph = "no";
            //}

            //result = appt.MakeAppointment(new DateTime(2022, 6, 3, 8, 0, 0), baxter, tabitha, tabS);

            //if (result == "Success")
            //{
            //    var ph = "yes";
            //}
            //else
            //{
            //    var ph = "no";
            //}

            //result = appt.MakeAppointment(new DateTime(2022, 5, 18, 13, 0, 0), hannah, justin, jusS);

            //if (result == "Success")
            //{
            //    var ph = "yes";
            //}
            //else
            //{
            //    var ph = "no";
            //}

            //hairdresser.AddNewHairdresser("", );

            //List<DateTime> original = new List<DateTime>();

            //DateTime may9 = new DateTime(2022, 5, 9);
            //DateTime may10 = new DateTime(2022, 5, 10);
            //DateTime may13 = new DateTime(2022, 5, 13);
            //DateTime may18 = new DateTime(2022, 5, 18);

            //original.Add(may9);
            //original.Add(may10);
            //original.Add(may13);
            //original.Add(may18);

            //List<DateTime> available = new List<DateTime>();
            //List<DateTime> memAvail = new List<DateTime>();
            //List<DateTime> noAvail = new List<DateTime>();

            //var accounts = db.db_getAcctsByRole("hair-dresser");

            //var acc = db.db_getAcctByEmail("alexisSOBpe@gmail.com");

            //// Act
            //for (int i = 0; i < accounts.Count; i++)
            //{
            //    available = hairdresser.ViewAvailability(accounts[i].email);
            //}

            //memAvail = hairdresser.ViewAvailability(acc.email);
            //noAvail = hairdresser.ViewAvailability("tets@test.test");

            //if(original == available)
            //{
            //    original = null;
            //}
            //else
            //{
            //    noAvail = null;
            //}

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
