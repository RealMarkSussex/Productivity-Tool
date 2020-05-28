using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace Productivity_Tool.Models
{
    public class SpendHistoryViewModel
    {
        public IEnumerable<SpendItem> SpendItems { get; set; }
    }
}
