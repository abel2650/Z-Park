using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z_ParkLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace Z_ParkLib.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserLicensePlateOk()
        {
            //Arrange
            User user = new User();
            string expectedLicensePlate = "AB12345";

            //Act
            user.LicensePlate = "AB12345";

            //Assert
            Assert.AreEqual(expectedLicensePlate, user.LicensePlate);
        }

        [TestMethod()]
        public void UserTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}