using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Productivity_Tool.Models
{
    public class SpendItemViewModel
    {
        public string Description { get; set; }
        public decimal AmountSpent { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public Category Category { get; set; }
    }
}
