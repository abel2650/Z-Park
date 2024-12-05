using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z_ParkLib.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_ParkLib.repositories.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private UserRepository _emptyRepo;
        private UserRepository _repo3members;
        private User _User2;

        [TestInitialize]

        public void BeforeEachTest()
        {
            _emptyRepo = new UserRepository();

            _repo3members = new UserRepository();
            _repo3members.Add(new User("AB12345", "Bobby", "Olsen", "Bobby@mail.dk", "BobbyO", "Kodeord123"));
            _repo3members.Add(new User("CD12345", "Frank", "Hvam", "Frank@mail.com", "FrankHvam", "Frank007"));
            _repo3members.Add(new User("EF12345", "Søren", "Lerby", "Lerby@mail.dk", "ForSøren", "Danmark!"));

            _User2 = new User("GH12345", "Anja", "Andersen", "Anja@mail.dk", "AnjaAndersen", "Håndbold");
        }

        /*
         * 
         * GetAll
         * 
         */

        [TestMethod()]
        public void UserRepositoryGetAllTest()
        {
            //Arrange
            int expectedEmptyCount = 0;
            int expected3Count = 3;

            //Act
            int actualEmptyCount = _emptyRepo.GetAll().Count;
            int actual3Count = _repo3members.GetAll().Count;

            //Assert
            Assert.AreEqual(expectedEmptyCount, actualEmptyCount);
            Assert.AreEqual(expected3Count, actual3Count);
        }
        /*
         * 
         * GetAllByLicenseplate
         * 
         */
        [TestMethod()]
        [DataRow("AB12345", "Bobby", "Olsen", "Bobby@mail.dk", "BobbyO", "Kodeord123")]
        public void UserRepositoryGetByIdTest(string licenseplate, string expectedName, string expectedSurname, string expectedMail, string expectedUsername, string expectedPassword)
        {
            //Arrange
            string expectedLicenseplate = licenseplate;

            //Act
            User fundet = _repo3members.GetById(licenseplate);

            //Assert
            Assert.AreEqual(expectedLicenseplate, fundet.Licenseplate);
            Assert.AreEqual(expectedName, fundet.Name);
            Assert.AreEqual(expectedSurname, fundet.Surname);
            Assert.AreEqual(expectedMail, fundet.Mail);
            Assert.AreEqual(expectedUsername, fundet.Username);
        }



        [TestMethod()]
        public void UserRepositoryAddTest()
        {
            //Arrange

            //Act

            //Assert
        }




        [TestMethod()]
        public void UserRepositoryUpdateTest()
        {
            //Arrange

            //Act

            //Assert
        }




        [TestMethod()]
        public void UserRepositoryDeleteTest()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}