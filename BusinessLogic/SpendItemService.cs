using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataLayer;
using DataLayer.Interfaces;
using Shared.Enums;
using SpendItem = BusinessLogic.Models.SpendItem;
using User = DataLayer.Models.User;

namespace BusinessLogic
{
    public class SpendItemService : IService<SpendItem>
    {
        private readonly IRepository<DataLayer.Models.SpendItem> _spendItemRepository;
        private readonly IRepository<DataLayer.Models.User> _userRepository;
        private readonly EmailHelper _emailHelper;

        public SpendItemService(IRepository<DataLayer.Models.SpendItem> spendItemRepository, IRepository<User> userRepository)
        {
            _spendItemRepository = spendItemRepository;
            _userRepository = userRepository;
            _emailHelper = new EmailHelper(_userRepository);
        }

        public void Add(SpendItem item)
        {
            var userId = _emailHelper.GetUserId(item.EmailAddress);
            var dataSpendItem = new DataLayer.Models.SpendItem()
            {
                AmountSpent = item.AmountSpent,
                Description = item.Description,
                UserId = userId,
                Category = item.Category,
                Date = item.Date
            };
            _spendItemRepository.Add(dataSpendItem);
        }

        public List<SumCategoryAmount> SumCategorySpendAmounts(string email)
        {
            var categories = Enum.GetValues(typeof(Category));
            var totalSpendAmounts = new List<SumCategoryAmount>();
            foreach (var category in categories)
            {
                totalSpendAmounts
                    .Add(new SumCategoryAmount()
                    {
                        Category = (Category) category,
                        TotalAmount = _spendItemRepository
                            .List(si => si.Category == (Category)category)
                            .Where(si => si.UserId == _emailHelper.GetUserId(email))
                            .Sum(si => si.AmountSpent)
                    });
            }
            return totalSpendAmounts;
        }

        public List<SpendItem> GetSpendItems(string email)
        {
            var user = _userRepository.List(u => u.EmailAddress == email).First();
            var spendItems = _spendItemRepository.List(si => si.UserId == user.Id).ToList();

            return spendItems
                .Select(spendItem => 
                    new SpendItem()
                    {
                        AmountSpent = spendItem.AmountSpent, 
                        Category = spendItem.Category, 
                        Description = spendItem.Description,
                        Date = spendItem.Date
                    }).ToList();
        }
    }
}
