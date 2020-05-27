using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public SpendItemService(IRepository<DataLayer.Models.SpendItem> spendItemRepository, IRepository<User> userRepository)
        {
            _spendItemRepository = spendItemRepository;
            _userRepository = userRepository;
        }

        public void Add(SpendItem item)
        {
            var userId = _userRepository.List(u => u.EmailAddress == item.EmailAddress).First().Id;
            var dataSpendItem = new DataLayer.Models.SpendItem()
            {
                AmountSpent = item.AmountSpent,
                Description = item.Description,
                UserId = userId,
                Category = item.Category
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
                        TotalAmount = _spendItemRepository.List(si => si.Category == (Category)category).Sum(si => si.AmountSpent)
                    });
            }
            return totalSpendAmounts;
        }
    }
}
