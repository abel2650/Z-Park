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
        [DataRow("AB12345")]
        [DataRow("CD12345")]
        [DataRow("EF12394")]
        public void UserLicenseplateOk(string licenseplate)
        {
            //Arrange
            User user = new User();
            string expectedLicenseplate = licenseplate;

            //Act
            user.Licenseplate = licenseplate;

            //Assert
            Assert.AreEqual(expectedLicenseplate, user.Licenseplate);
        }

        [TestMethod()]
        [DataRow("A")]
        [DataRow("B12345")]
        [DataRow("AB412345")]
        public void UserLicenseplateNotOk(string licenseplate)
        {
            //Arrange
            User user = new User();
            string expectedLicenseplate = licenseplate;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => user.Licenseplate = licenseplate);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}