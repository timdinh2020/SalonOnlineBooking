using TestApp;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace SOBTests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void AddServiceTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "Sub service addition failed. Cannot make this service a sub service of itself.";

            // initialize master services with -1 starting price (since they aren't an actual bookable service)
            Service hairTest = new Service("Hair Test", "Different kinds of hair cutting services!", -1, null);

            // initialize regular services with the correct master service (the master service must exist in the db already)
            Service testServ = new Service("Test 1", "Test description number 1.", 12.99, "Hair Test");
            Service testServ2 = new Service("Test 2", "Test description number 2.", 10.99, "Hair Test");
            Service testServ3 = new Service("Test 3", "Test description number 3.", 9.99, "Hair Test");

            // Act

            // adds these three services to the hair test master service's sub service list
            string actualRight = hairTest.AddNewService(testServ);
            string actualRight2 = hairTest.AddNewService(testServ2);
            string actualRight3 = hairTest.AddNewService(testServ3);

            // doesn't work because test service can't be its own master service
            string actualWrong = testServ.AddNewService(testServ);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedRight, actualRight2);
            Assert.AreEqual(expectedRight, actualRight3);
            Assert.AreEqual(expectedWrong, actualWrong);
        }

        [TestMethod]
        public void ViewServiceDetailsTest()
        {
            // Arrange
            string expectedTitle = "Test 1";
            string expectedDesc = "Test description number 1.";
            double expectedPrice = 12.99;

            mongodb db = new mongodb();

            var test = db.db_getServByTitle("Test 1");

            // returns the test service's details in an object list
            var serv = test.ViewServiceDetails();

            // Act

            /* you MUST cast each element in the object list back to its original type be for use
                  The original types for each element in order are:
                        1. string
                        2. string
                        3. double
                        4. string
                        5. List<Service>
            */
            string actualTitle = (string)serv[0];
            string actualDesc = (string)serv[1];
            double actualPrice = (double)serv[2];

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void ViewAvailableServicesTest()
        {
            // Arrange
            string expectedTitle = "Test 1";
            string expectedTitle2 = "Test 2";

            mongodb db = new mongodb();

            var hair = db.db_getServByTitle("Hair Test");

            // returns all the sub services in a list (Only use this function on Master services like Hair Cutting)
            var services = hair.ViewAvailableServices();

            // Act
            string actualTitle = services[0].title;
            string actualTitle2 = services[1].title;

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedTitle2, actualTitle2);
        }

        [TestMethod]
        public void ModifyServiceTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "Modification failed. The given master service does not exist.";

            mongodb db = new mongodb();

            var testServ4 = new Service("Test 5", "Test description number 4.", 5.99, "Hair Test");

            // you MUST get the master/regular services like this before calling any of its service functions
            var hair = db.db_getServByTitle("Hair Test");

            // add the created service (shave it all) to the list of sub services for its master service (hair cutting)
            hair.AddNewService(testServ4);

            var test4 = db.db_getServByTitle("Test 5");

            // Act

            // changes the service name and price
            string actualRight = test4.ModifyService("Test 4", "", 6.50, null, null);

            // changes nothing
            string actualRight2 = test4.ModifyService("Test 4", "", 6.50, null, null); 

            // doesn't work since Hair Loss isn't an existing master service
            string actualWrong = test4.ModifyService("Test 4", "", 6.50, "Hair Loss", null);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedRight, actualRight2);
            Assert.AreEqual(expectedWrong, actualWrong);
        }

        [TestMethod]
        public void RemoveServiceTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "Service removal failed. That service does not exist.";

            mongodb db = new mongodb();

            // you MUST get the master/regular services like this before calling any of its service functions
            var hair = db.db_getServByTitle("Hair Test");

            // Act

            // removes the test 2 service, (false because we are removing it from the db)
            string actualRight = hair.RemoveService("Test 2", false);

            // doesn't work because test 10 is not a service
            string actualWrong = hair.RemoveService("Test 10", false);

            string actualRight2 = hair.RemoveService("Test 1", false);
            string actualRight3 = hair.RemoveService("Test 3", false);
            string actualRight4 = hair.RemoveService("Test 4", false);

            // removes the hair test service
            string actualRight5 = hair.RemoveService("Hair Test", false);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedRight, actualRight2);
            Assert.AreEqual(expectedRight, actualRight3);
            Assert.AreEqual(expectedRight, actualRight4);
            Assert.AreEqual(expectedRight, actualRight5);
            Assert.AreEqual(expectedWrong, actualWrong);
        }
    }
}