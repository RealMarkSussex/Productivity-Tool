using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface ISpendItemService
    {
        IEnumerable<SpendItem> GetSpendItems();
        SpendItem GetSpendItem(int id);
        void AddSpendItem(SpendItem item);
        bool TryUpdate(SpendItem item);
        bool TryDelete(int id);
    }
}
