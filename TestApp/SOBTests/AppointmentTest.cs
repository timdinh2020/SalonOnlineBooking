using TestApp;
using MongoDB.Bson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace SOBTests
{
    [TestClass]
    public class AppointmentTest
    {

        [TestMethod]
        public void MakeAppointmentTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "Appointment creation failed. You already have a scheduled appointment for this date and time.";
            string expectedWrong2 = "Appointment creation failed. This hairdresser already has a scheduled appointment for this date and time.";

            mongodb db = new mongodb();

            Appointment appt = new Appointment();

            var justin = db.db_getAcctByEmail("justinsobtest@gmail.com");
            var mary = db.db_getAcctByEmail("marysobtest@gmail.com");
            var hannah = db.db_getAcctByEmail("hannahsobtest@gmail.com");
            var levi = db.db_getAcctByEmail("levisobtest@gmail.com");

            var service1 = db.db_getServByTitle("Root Touch Up");
            var service2 = db.db_getServByTitle("Individual Braids");
            var service3 = db.db_getServByTitle("Bleaching");

            List<Service> maryS = new List<Service>();
            List<Service> jusS = new List<Service>();

            maryS.Add(service1);
            maryS.Add(service2);

            jusS.Add(service3);

            var date1 = new DateTime(2022, 5, 11, 15, 30, 0);
            var date2 = new DateTime(2022, 5, 18, 13, 0, 0);
            var date3 = new DateTime(2022, 6, 1, 10, 45, 0);

            // Act
            string actualRight = appt.MakeAppointment(date1, levi, mary, maryS);
            string actualRight2 = appt.MakeAppointment(date3, hannah, mary, maryS);
            string actualWrong = appt.MakeAppointment(date1, hannah, mary, maryS);
            string actualWrong2 = appt.MakeAppointment(date2, hannah, justin, jusS);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedRight, actualRight2);
            Assert.AreEqual(expectedWrong, actualWrong);
            Assert.AreEqual(expectedWrong2, actualWrong2);
        }

        [TestMethod]
        public void ViewAppointmentsTest()
        {
            // Arrange
            string expectedRightDate = "5/18/2022";
            string expectedRightTime = "1:00 PM";
            string expectedRightDate2 = "6/3/2022";
            string expectedRightTime2 = "8:00 AM";

            mongodb db = new mongodb();

            Appointment appointment = new Appointment();

            var tabitha = db.db_getAcctByEmail("tabithasobtest@gmail.com");

            // Act
            var appt = appointment.ViewAppointments(tabitha.email);

            string actualRightDate = appt[0].date;
            string actualRightTime = appt[0].time;
            string actualRightDate2 = appt[1].date;
            string actualRightTime2 = appt[1].time;

            // Assert
            Assert.AreEqual(expectedRightDate, actualRightDate);
            Assert.AreEqual(expectedRightTime, actualRightTime);
            Assert.AreEqual(expectedRightDate2, actualRightDate2);
            Assert.AreEqual(expectedRightTime2, actualRightTime2);
        }

        [TestMethod]
        public void ModifyAppointmentTest()
        {
            // Arrange
            string expectedRight = "You already have a scheduled appointment for this date and time. Appointment services successfully updated.";
            string expectedRight2 = "Appointment date and time successfully updated. Appointment services successfully updated.";
            string expectedWrong = "Your hairdresser already has a scheduled appointment for this date and time. Old appointment services match the new services; services not updated.";
            
            mongodb db = new mongodb();

            Appointment appointment = new Appointment();

            var mary = db.db_getAcctByEmail("marysobtest@gmail.com");

            var appts = db.db_getApptsByEmail(mary.email);

            var appt1 = appts[0];
            var appt2 = appts[1];

            var service1 = db.db_getServByTitle("Root Touch Up");
            var service2 = db.db_getServByTitle("Individual Braids");
            var service3 = db.db_getServByTitle("Bleaching");
            var service4 = db.db_getServByTitle("Split Dye");
            var service5 = db.db_getServByTitle("Sew In");

            List<Service> mary1 = new List<Service>();
            List<Service> mary2 = new List<Service>();
            List<Service> mary3 = new List<Service>();

            mary1.Add(service3);
            mary1.Add(service5);

            mary2.Add(service4);

            mary3.Add(service5);
            mary3.Add(service3);

            var date1 = new DateTime(2022, 5, 11, 15, 30, 0);
            var date2 = new DateTime(2022, 5, 18, 13, 0, 0);
            var date3 = new DateTime(2022, 5, 25, 12, 0, 0);
            var date4 = new DateTime(2022, 6, 1, 10, 45, 0);

            // Act
            string actualRight = appointment.ModifyAppointment(appt2.Id, date1, mary1);
            string actualRight2 = appointment.ModifyAppointment(appt1.Id, date3, mary2);
            string actualWrong = appointment.ModifyAppointment(appt2.Id, date2, mary3);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedRight2, actualRight2);
            Assert.AreEqual(expectedWrong, actualWrong);
        }

        [TestMethod]
        public void CancelAppointmentTest()
        {
            // Arrange
            string expectedRight = "Success";
            string expectedWrong = "Appointment cancellation failed. No appointment exists with that Id.";

            mongodb db = new mongodb();

            Appointment appointment = new Appointment();

            var mary = db.db_getAcctByEmail("marysobtest@gmail.com");

            var appts = db.db_getApptsByEmail(mary.email);

            var appt1 = appts[0];
            var appt2 = appts[1];

            // Act
            string actualRight = appointment.CancelAppointment(appt1.Id);
            string actualRight2 = appointment.CancelAppointment(appt2.Id);
            string actualWrong = appointment.CancelAppointment(appt1.Id);

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedRight, actualRight2);
            Assert.AreEqual(expectedWrong, actualWrong);
        }
    }
}