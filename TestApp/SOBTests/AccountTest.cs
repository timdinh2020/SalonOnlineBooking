using TestApp;
using MongoDB.Bson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace SOBTests
{
    [TestClass]
    public class AccountTest
    {
        // Source: https://www.apriorit.com/dev-blog/697-qa-measuring-code-coverage
        
        // Vstest console: D:\Visual Studio 2022\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe
        // SOBTest: D:\Git\SalonOnlineBooking\TestApp\SOBTests\bin\Debug\net6.0\SOBTests.dll
        // OpenCover: D:\Git\SalonOnlineBooking\TestApp\packages\OpenCover.4.7.1221\tools\OpenCover.Console.exe
        // ReportGen: D:\Git\SalonOnlineBooking\TestApp\packages\ReportGenerator.5.1.4\tools\net6.0\ReportGenerator.exe

        /* Open Cover
          "D:\Git\SalonOnlineBooking\TestApp\packages\OpenCover.4.7.1221\tools\OpenCover.Console.exe" -target:"D:\Visual Studio 2022\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" -targetargs:"D:\Git\SalonOnlineBooking\TestApp\SOBTests\bin\Debug\net6.0\SOBTests.dll" -output:"D:\Git\SalonOnlineBooking\TestApp\TestCov\CoverageResults.xml" -register:user
         */

        /* Report Gen: 
          "D:\Git\SalonOnlineBooking\TestApp\packages\ReportGenerator.5.1.4\tools\net6.0\ReportGenerator.exe" -reports:"D:\Git\SalonOnlineBooking\TestApp\TestCov\CoverageResults.xml" -targetdir:"D:\Git\SalonOnlineBooking\TestApp\TestCov\CoverageResults"
         */

        [TestMethod]
        public void CreateAccountTest()
        {
            // Arrange
            string expectedRight = "Your account has been successfully created!";
            string expectedWrong = "That email is already associated with an account. Try again.";

            var newAcc = new Account();

            // Act
            // string actualRight = newAcc.CreateAccount("Alexis", "Peoples", "member", "alexSOBpe@gmail.com", "password123", string.Empty);
            string actualWrong = newAcc.CreateAccount("Alexis", "Peoples", "member", "alexisSOBpe@gmail.com", "pass123", string.Empty);

            // Assert
            // Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
        }

        [TestMethod]
        public void LogInTest()
        {
            // Arrange
            string expectedRight = "You have been successfully logged in!";
            string expectedWrong = "Login Failed. Incorrect password.";
            string expectedWrong2 = "Login Failed. No account found with this email.";

            Account account = new Account();

            // Act
            string actualRight = account.LogIn("timSOB@gmail.com", "admin");
            string actualWrong = account.LogIn("timSOB@gmail.com", "admi");
            string actualWrong2 = account.LogIn("holyfishcakes333@ku.com", "cake");

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
            Assert.AreEqual(expectedWrong2, actualWrong2);
        }

        [TestMethod]
        public void EditAccountTest()
        {
            // Arrange
            string expectedRight = "Your account has been successfully updated!";
            string expectedWrong = "Account update failed due to incorrect password. Try again.";

            mongodb db = new mongodb();

            var owner = db.db_getAcctByEmail("timSOB@gmail.com");

            // Act
            string actualRight = owner[0].EditAccount(owner[0].Id, null, null, null, null, null, "admin");
            string actualWrong = owner[0].EditAccount(owner[0].Id, null, null, null, null, null, "admi");

            // Assert
            Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
        }

        [TestMethod]
        public void ResetPasswordTest()
        {
            // Arrange
            string expectedRight = "Your password has been successfully updated!";
            string expectedWrong = "Your current password is incorrect. Try again.";

            mongodb db = new mongodb();

            var acc = db.db_getAcctByEmail("alexisSOBpe@gmail.com");

            // Act
            //string actualRight = acc[0].ResetPassword(acc[0].Id, "pass1234", "test123");
            string actualWrong = acc[0].ResetPassword(acc[0].Id, "admin", "testing2");

            // Assert
            //Assert.AreEqual(expectedRight, actualRight);
            Assert.AreEqual(expectedWrong, actualWrong);
        }
    }
}