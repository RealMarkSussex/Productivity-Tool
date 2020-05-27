using System.Linq;
using BusinessLogic.Tests.Fakes;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private IRepository<User> _userRepository;
        private UserService _sut; 
        [TestInitialize]
        public void Setup()
        {
            _userRepository = new FakeRepository<User>();
            _sut = new UserService(_userRepository);
        }

        [TestMethod]
        public void GivenIAddAUser_WhenICallAdd_ThenTheUserIsInTheDatabase()
        {
            var email = "marksussex6@gmail.com";

            _sut.Add(new Models.User()
            {
                EmailAddress = email
            });
            var user = _userRepository.List(u => u.EmailAddress == email).First();

            Assert.AreEqual(email, user.EmailAddress);
            Assert.IsNotNull(user.Id);
        }
    }
}
