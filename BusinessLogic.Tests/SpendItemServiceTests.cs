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
            _userRepository.Add(new User()
            {
                EmailAddress = email
            });

            _sut.Add(new Models.SpendItem()
            {
                AmountSpent = (decimal) 1.25,
                Category = Category.Snacks,
                Description = "Sour Cream and Onion Pringles",
                EmailAddress = email
            });
        }
    }
}
