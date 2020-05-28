using System.Linq;
using BusinessLogic.Helpers;
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
        private const string MarkEmail = "marksussex6@gmail.com";
        private const string DerekEmail = "derekjuicebox@gmail.com";
        private EmailHelper _emailHelper;
        [TestInitialize]
        public void Setup()
        {
            _spendItemRepository = new FakeRepository<SpendItem>();
            _userRepository = new FakeRepository<User>();
            _sut = new SpendItemService(_spendItemRepository, _userRepository);
            _emailHelper = new EmailHelper(_userRepository);
            _userRepository.Add(new User()
            {
                EmailAddress = MarkEmail
            });

            _userRepository.Add(new User()
            {
                EmailAddress = DerekEmail
            });
        }
        
        [TestMethod]
        public void GivenIAddASpendItem_WhenICallAdd_ThenTheSpendItemIsInTheDatabase()
        {
            const decimal amountSpent = (decimal) 1.25;
            const Category category = Category.Snacks;
            const string description = "Sour Cream and Onion Pringles";


            _sut.Add(new Models.SpendItem()
            {
                AmountSpent = (decimal) amountSpent,
                Category = category,
                Description = description,
                EmailAddress = MarkEmail
            });

            var spendItem = _spendItemRepository.List().First();
            var user = _userRepository.List(u => u.EmailAddress == MarkEmail).First();
            Assert.AreEqual(amountSpent, spendItem.AmountSpent);
            Assert.AreEqual(category, spendItem.Category);
            Assert.AreEqual(description, spendItem.Description);
            Assert.AreEqual(user.Id, spendItem.UserId);
            Assert.IsNotNull(spendItem.Id);
        }

        [TestMethod]
        public void GivenManySpendItems_WhenICallSumCategorySpendAmounts_ThenIGetSpendTotalPerCategory()
        {
            _spendItemRepository.Add(new SpendItem()
            {
                AmountSpent = 3,
                Category = Category.Snacks,
                Description = "Drumstick choose",
                UserId = _emailHelper.GetUserId(MarkEmail)
            });

            _spendItemRepository.Add(new SpendItem()
            {
                AmountSpent = 4,
                Category = Category.Snacks,
                UserId = _emailHelper.GetUserId(DerekEmail)
            });

            var sumCategoryAmounts = _sut.SumCategorySpendAmounts(MarkEmail);
            Assert.AreEqual( (decimal) 3, sumCategoryAmounts.First(sca => sca.Category == Category.Snacks).TotalAmount);
            Assert.AreEqual( 0, sumCategoryAmounts.First(sca => sca.Category == Category.Gaming).TotalAmount);
        }

        [TestMethod]
        public void GivenIWantAListOfSpendItems_WhenICallGetSpendItems_ThenIGetAListOfSpendItems()
        {
            var spendItem1 = new SpendItem()
            {
                AmountSpent = (decimal) 5.99,
                Category = Category.Rent,
                Description = "I love paying rent!",
                UserId = _emailHelper.GetUserId(MarkEmail)
            };

            var spendItem2 = new SpendItem()
            {
                AmountSpent = (decimal) 5.99,
                Category = Category.Technology,
                Description = "Sick gizmo!",
                UserId = _emailHelper.GetUserId(MarkEmail)
            };

            var spendItem3 = new SpendItem()
            {
                AmountSpent = (decimal)5.99,
                Category = Category.Technology,
                Description = "Sick gizmo!",
                UserId = _emailHelper.GetUserId(DerekEmail)
            };

            _spendItemRepository.Add(spendItem1);
            _spendItemRepository.Add(spendItem2);
            _spendItemRepository.Add(spendItem3);

            var spendItems = _sut.GetSpendItems(MarkEmail);
            Assert.AreEqual(2, spendItems.Count);
        }
    }
}
