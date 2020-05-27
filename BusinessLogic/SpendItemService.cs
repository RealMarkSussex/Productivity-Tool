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
    public class SpendItemService : ISpendItemService
    {
        private readonly IRepository<DataLayer.Models.SpendItem> _spendItemRepository;
        private readonly IRepository<DataLayer.Models.User> _userRepository;

        public SpendItemService()
        {
            _spendItemRepository = new Repository<DataLayer.Models.SpendItem>();
            _userRepository = new Repository<User>();
        }
        public IEnumerable<SpendItem> GetSpendItems()
        {
            throw new NotImplementedException();
        }

        public SpendItem GetSpendItem(int id)
        {
            throw new NotImplementedException();
        }

        public void AddSpendItem(SpendItem item)
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

        public bool TryUpdate(SpendItem item)
        {
            throw new NotImplementedException();
        }

        public bool TryDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
