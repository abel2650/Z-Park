﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [DataRow("Marcus")]
        [DataRow("Dårte")]
        [DataRow("Ib")]
        public void UserNameIsOk(string name)
        {
            //Arrange
            User user = new User();
            string expectedName = name;

            //Act
            user.Name = name;

            //Assert
            Assert.AreEqual(expectedName, user.Name);
        }

        [TestMethod()]
        [DataRow("A")]
        [DataRow("")]
        [DataRow("123")]
        [DataRow("Mathias!")]
        public void UserNameIsNotOk(string name)
        {
            //Arrange
            User user = new User();
            string expectedName = name;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>( () => user.Name = name);
        }

        [TestMethod()]
        [DataRow("Hartmann")]
        [DataRow("Mårtensen")]
        [DataRow("Bo")]
        public void UserSurnameIsOk(string surname)
        {
            //Arrange
            User user = new User();
            string expectedSurname = surname;

            //Act
            user.Surname = surname;

            //Assert
            Assert.AreEqual(expectedSurname, user.Surname);
        }

        [TestMethod()]
        [DataRow("A")]
        [DataRow("")]
        [DataRow("123")]
        [DataRow("!Frederiksen")]
        public void UserSurnameIsNotOk(string surname)
        {
            //Arrange
            User user = new User();
            string expectedSurname = surname;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => user.Surname = surname);
        }
    }
}