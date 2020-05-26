using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataLayer;
using DataLayer.Interfaces;

namespace BusinessLogic
{
    public class SpendItemService : ISpendItemService
    {
        private readonly IRepository<DataLayer.Models.SpendItem> _repository;
        public SpendItemService()
        {
            _repository = new Repository<DataLayer.Models.SpendItem>();
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
            var dataSpendItem = new DataLayer.Models.SpendItem()
            {
                AmountSpent = item.AmountSpent,
                Description = item.Description,
                //UserId = item.UserId, // TODO (need to add users and spend categories to db first)
                //SpendCategoryId = item.SpendCategoryId
            };
            _repository.Add(dataSpendItem);
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
