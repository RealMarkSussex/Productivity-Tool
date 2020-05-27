using System;
using System.Collections.Generic;
using System.Text;
using Shared.Enums;

namespace BusinessLogic.Models
{
    public class SumCategoryAmount
    {
        public decimal TotalAmount { get; set; }
        public Category Category { get; set; }
    }
}
