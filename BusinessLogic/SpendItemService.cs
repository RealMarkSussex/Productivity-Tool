using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Models;
using SpendItem = BusinessLogic.Models.SpendItem;

namespace BusinessLogic
{
    public class SpendItemService : IService<SpendItem>
    {
        private readonly IRepository<DataLayer.Models.SpendItem> _spendItemRepository;
        private readonly IRepository<DataLayer.Models.User> _userRepository;

        public SpendItemService()
        {
            _spendItemRepository = new Repository<DataLayer.Models.SpendItem>();
            _userRepository = new Repository<User>();
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
    }
}
