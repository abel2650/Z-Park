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
        private UserRepository _repo3users;
        private User _User2;

        [TestInitialize]

        public void BeforeEachTest()
        {
            _emptyRepo = new UserRepository();

            _repo3users = new UserRepository();
            _repo3users.Add(new User("AB12345", "Bobby", "Olsen", "Bobby@mail.dk", "BobbyO", "Kodeord123"));
            _repo3users.Add(new User("CD12345", "Frank", "Hvam", "Frank@mail.com", "FrankHvam", "Frank007"));
            _repo3users.Add(new User("EF12345", "Søren", "Lerby", "Lerby@mail.dk", "ForSøren", "Danmark!"));

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
            int actual3Count = _repo3users.GetAll().Count;

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
            User fundet = _repo3users.GetById(licenseplate);

            //Assert
            Assert.AreEqual(expectedLicenseplate, fundet.Licenseplate);
            Assert.AreEqual(expectedName, fundet.Name);
            Assert.AreEqual(expectedSurname, fundet.Surname);
            Assert.AreEqual(expectedMail, fundet.Mail);
            Assert.AreEqual(expectedUsername, fundet.Username);
        }



        [TestMethod()]
        [DataRow("4")]
        public void UserRepositoryGetByIdNotFoundTest(string licenseplate)
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<KeyNotFoundException>(() => _emptyRepo.GetById(licenseplate));
            Assert.ThrowsException<KeyNotFoundException>(() => _repo3users.GetById(licenseplate));
        }

        /*
         * 
         * Add
         * 
         */

        [TestMethod()]
        [DataRow("AA11122", "NewUser", "User","umail@mail.dk", "EUserame", "EPassword")]
        public void UserRepositoryAddTest(string newLicenseplate, string newName, string newSurname, string newMail, string newUsername, string newPassword) 
        {
            //Arrange
            User newUserEmpty = new User(newLicenseplate, newName, newSurname, newMail, newUsername, newPassword);
            int expectedLengthEmpty = 1;

            User newUser3User = new User(newLicenseplate, newName, newSurname, newMail, newUsername, newPassword);
            int expectedLength3User = 4;

            //Act
            User addUserEmpty = _emptyRepo.Add(newUserEmpty);
            User addUser3User = _repo3users.Add(newUser3User);

            int actualLengthEmpty = _emptyRepo.GetAll().Count();
            int actualLength3User = _repo3users.GetAll().Count();

            //Assert
            Assert.AreEqual(expectedLengthEmpty, actualLengthEmpty);
            Assert.AreEqual(expectedLength3User, actualLength3User);
        }

        /*
         * 
         * Delete
         * 
         */

        [TestMethod()]
        public void UserRepositoryDeleteTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod()]
        public void UserRepositoryDeleteNotOkTest()
        {
            //Arrange
            int expectedLength1 = 2;
            int expectedLength2 = 1;

            //Act
            User deletedUser1 = _repo3users.Delete("CD12345");
            int actualLength1 = _repo3users.GetAll().Count;
            User deletedUser2 = _repo3users.Delete("EF12345");
            int actualLength2 = _repo3users.GetAll().Count;

            //Assert
            Assert.IsNotNull(deletedUser1);
            Assert.IsNotNull(deletedUser2);
            Assert.AreEqual(expectedLength1, actualLength1);
            Assert.AreEqual(expectedLength2, actualLength2);
        }

        /*
         * 
         * Update
         * 
         */

        [TestMethod()]
        public void UserRepositoryUpdateTest()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}