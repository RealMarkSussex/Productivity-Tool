using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
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
        private readonly SpendItemMapper _spendItemMapper;
        private readonly EmailHelper _emailHelper;

        public SpendItemService(IRepository<DataLayer.Models.SpendItem> spendItemRepository, IRepository<User> userRepository, SpendItemMapper spendItemMapper, EmailHelper emailHelper)
        {
            _spendItemRepository = spendItemRepository;
            _userRepository = userRepository;
            _spendItemMapper = spendItemMapper;
            _emailHelper = emailHelper;
        }

        public void Add(SpendItem spendItem)
        {
            _spendItemRepository.Add(_spendItemMapper.MapSpendItem(spendItem));
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
                            .List(si => si.Category == (Category)category && si.UserId == _emailHelper.GetUserId(email))
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
                    _spendItemMapper.MapSpendItem(spendItem))
                .ToList();
        }

        public SpendItem GetSpendItem(Guid id)
        {
            var spendItem = _spendItemRepository.GetById(id);
            return _spendItemMapper.MapSpendItem(spendItem);
        }

        public void Update(SpendItem spendItem)
        {
            _spendItemRepository.Edit(_spendItemMapper.MapSpendItem(spendItem));
        }

        public void Delete(Guid id)
        {
            _spendItemRepository.Delete(_spendItemRepository.GetById(id));
        }
    }
}
