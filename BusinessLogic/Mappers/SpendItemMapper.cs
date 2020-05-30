using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Helpers;
using BusinessLogic.Models;

namespace BusinessLogic.Mappers
{
    public class SpendItemMapper
    {
        private readonly EmailHelper _emailHelper;

        public SpendItemMapper(EmailHelper emailHelper)
        {
            _emailHelper = emailHelper;
        }
        public DataLayer.Models.SpendItem MapSpendItem(SpendItem spendItem)
        {
            return new DataLayer.Models.SpendItem()
            {
                AmountSpent = spendItem.AmountSpent,
                Category = spendItem.Category,
                Date = spendItem.Date,
                Description = spendItem.Description,
                UserId = _emailHelper.GetUserId(spendItem.EmailAddress),
                Id = spendItem.SpendItemId
            };
        }

        public SpendItem MapSpendItem(DataLayer.Models.SpendItem spendItem)
        {
            return new SpendItem()
            {
                AmountSpent = spendItem.AmountSpent,
                Category = spendItem.Category,
                Date = spendItem.Date,
                Description = spendItem.Description,
                SpendItemId = spendItem.Id
            };
        }
    }
}
