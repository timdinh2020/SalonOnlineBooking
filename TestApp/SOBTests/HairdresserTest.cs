using TestApp;
using MongoDB.Bson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace SOBTests
{
    [TestClass]
    public class HairdresserTest
    {

        [TestMethod]
        public void AddNewHairdresserTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "That account is already labeled as a hair-dresser.";

            mongodb db = new mongodb();

            var newAcc = new Account();

            Hairdresser hairdresser = new Hairdresser();

            string email = "janedoe123@gmail.com";

            string created = newAcc.CreateAccount("Jane", "Doe", "member", email, "pass123");

            List<DateTime> available = new List<DateTime>();

            DateTime may9 = new DateTime(2022, 5, 9);
            DateTime may10 = new DateTime(2022, 5, 10);
            DateTime may13 = new DateTime(2022, 5, 13);
            DateTime may18 = new DateTime(2022, 5, 18);

            available.Add(may9);
            available.Add(may10);
            available.Add(may13);
            available.Add(may18);

            // Act
            string actualRight = hairdresser.AddNewHairdresser(email, available);
            string actualWrong = hairdresser.AddNewHairdresser(email, available);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
        }

        [TestMethod]
        public void RemoveHairdresserTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "There is no account with that email. Try again.";
            string expectedWrong2 = "Removal failed. The given account is not a hair-dresser account.";

            Hairdresser hairdresser = new Hairdresser();

            string email = "janedoe123@gmail.com";

            // Act
            string actualRight = hairdresser.RemoveHairdresser(email);
            string actualWrong = hairdresser.RemoveHairdresser("test@test.test");
            string actualWrong2 = hairdresser.RemoveHairdresser("alexisSOBpe@gmail.com");

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
            Assert.AreEqual(expectedWrong2, actualWrong2);
        }

        [TestMethod]
        public void ViewAvailabilityTest()
        {
            // Arrange
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

            List<DateTime> expectedRight = original;
            List<DateTime> expectedWrong = null;

            List<DateTime> actualRight = new List<DateTime>();
            List<DateTime> actualWrong = new List<DateTime>();
            List<DateTime> actualWrong2 = new List<DateTime>();

            var accounts = db.db_getAcctsByRole("hair-dresser");

            var acc = db.db_getAcctByEmail("alexisSOBpe@gmail.com");

            // Act
            for (int i = 0; i < accounts.Count; i++)
            {
                actualRight = hairdresser.ViewAvailability(accounts[i].email);
            }

            actualWrong = hairdresser.ViewAvailability(acc.email);
            actualWrong2 = hairdresser.ViewAvailability("tets@test.test");

            // Assert
            CollectionAssert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
            Assert.AreEqual(expectedWrong, actualWrong2);
        }

        [TestMethod]
        public void ModifyAvailabilityTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "There is no account with that email. Try again.";
            string expectedWrong2 = "That account is not labeled as a hair-dresser.";

            mongodb db = new mongodb();

            Hairdresser hairdresser = new Hairdresser();

            List<DateTime> newAvail = new List<DateTime>();

            DateTime may10 = new DateTime(2022, 5, 10);
            DateTime may18 = new DateTime(2022, 5, 18);
            DateTime june1 = new DateTime(2022, 6, 1);
            DateTime june2 = new DateTime(2022, 6, 2);
            DateTime june3 = new DateTime(2022, 6, 3);
            DateTime june8 = new DateTime(2022, 6, 8);

            newAvail.Add(may10);
            newAvail.Add(may18);
            newAvail.Add(june1);
            newAvail.Add(june2);
            newAvail.Add(june3);
            newAvail.Add(june8);

            var acc = db.db_getAcctByEmail("janedoe123@gmail.com");

            // Act
            string actualRight = hairdresser.ModifyAvailability(acc.email, newAvail);
            string actualWrong = hairdresser.ModifyAvailability("tets@test.test", newAvail);
            string actualWrong2 = hairdresser.ModifyAvailability("alexisSOBpe@gmail.com", newAvail);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
            Assert.AreEqual(expectedWrong2, actualWrong2);
        }
    }
}