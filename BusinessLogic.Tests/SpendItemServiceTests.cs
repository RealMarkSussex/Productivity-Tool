using System.Linq;
using BusinessLogic.Tests.Fakes;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Enums;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class SpendItemServiceTests
    {
        private IRepository<SpendItem> _spendItemRepository;
        private IRepository<User> _userRepository;
        private SpendItemService _sut;
        [TestInitialize]
        public void Setup()
        {
            _spendItemRepository = new FakeRepository<SpendItem>();
            _userRepository = new FakeRepository<User>();
            _sut = new SpendItemService(_spendItemRepository, _userRepository);
        }
        
        [TestMethod]
        public void GivenIAddASpendItem_WhenICallAdd_ThenTheSpendItemIsInTheDatabase()
        {
            var email = "marksussex6@gmail.com";
            var amountSpent = (decimal) 1.25;
            var category = Category.Snacks;
            var description = "Sour Cream and Onion Pringles";

            _userRepository.Add(new User()
            {
                EmailAddress = email
            });

            _sut.Add(new Models.SpendItem()
            {
                AmountSpent = (decimal) amountSpent,
                Category = category,
                Description = description,
                EmailAddress = email
            });

            var spendItem = _spendItemRepository.List().First();
            var user = _userRepository.List(u => u.EmailAddress == email).First();
            Assert.AreEqual(amountSpent, spendItem.AmountSpent);
            Assert.AreEqual(category, spendItem.Category);
            Assert.AreEqual(description, spendItem.Description);
            Assert.AreEqual(user.Id, spendItem.UserId);
            Assert.IsNotNull(spendItem.Id);
        }
    }
}
