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
            Service hairCutting = new Service("Hair Cutting", "Different kinds of hair cutting services!", -1, null);

            // initialize regular services with the correct master service (the master service must exist in the db already)
            Service trimServ = new Service("Trim", "Clean up those dead ends!", 12.99, "Hair Cutting");
            Service fadeServ = new Service("Fade", "Get that smooth transition!", 10.99, "Hair Cutting");
            Service shapeServ = new Service("Shape Up", "Make your hairline look neat and crisp!", 9.99, "Hair Cutting");

            // Act

            // adds these three services to the hair cutting master service's sub service list
            string actualRight = hairCutting.AddNewService(trimServ);
            string actualRight2 = hairCutting.AddNewService(fadeServ);
            string actualRight3 = hairCutting.AddNewService(shapeServ);

            // doesn't work because trim service can't be its own master service
            string actualWrong = trimServ.AddNewService(trimServ);

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
            string expectedTitle = "Trim";
            string expectedDesc = "Clean up those dead ends!";
            double expectedPrice = 12.99;

            mongodb db = new mongodb();

            var trim = db.db_getServByTitle("Trim");

            // returns the trim service's details in an object list
            var serv = trim.ViewServiceDetails();

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
            string expectedTitle = "Trim";
            string expectedTitle2 = "Fade";

            mongodb db = new mongodb();

            var hair = db.db_getServByTitle("Hair Cutting");

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

            var shaveServ = new Service("Shave It All", "Get rid of all that pesky hair on your head!", 5.99, "Hair Cutting");

            // you MUST get the master/regular services like this before calling any of its service functions
            var hair = db.db_getServByTitle("Hair Cutting");

            // add the created service (shave it all) to the list of sub services for its master service (hair cutting)
            hair.AddNewService(shaveServ);

            var shave = db.db_getServByTitle("Shave It All");

            // Act

            // changes the service name
            string actualRight = shave.ModifyService("Bald Shave", "", 6.50, null, null);

            // changes nothing
            string actualRight2 = shave.ModifyService("Bald Shave", "", 6.50, null, null); 

            // doesn't work since Hair Loss isn't an existing master service
            string actualWrong = shave.ModifyService("Bald Shave", "", 6.50, "Hair Loss", null);

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
            var hair = db.db_getServByTitle("Hair Cutting");

            // Act

            // removes the fade service, (false because we are removing it from the db)
            string actualRight = hair.RemoveService("Fade", false);

            // doesn't work because test is not a service
            string actualWrong = hair.RemoveService("Test", false);

            string actualRight2 = hair.RemoveService("Trim", false);
            string actualRight3 = hair.RemoveService("Shape Up", false);
            string actualRight4 = hair.RemoveService("Bald Shave", false);

            // removes the hair cutting service
            string actualRight5 = hair.RemoveService("Hair Cutting", false);

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