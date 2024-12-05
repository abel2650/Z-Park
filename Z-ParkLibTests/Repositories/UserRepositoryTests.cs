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
        public void UserRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}