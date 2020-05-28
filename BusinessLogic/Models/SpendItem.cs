using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Shared.Enums;

namespace BusinessLogic.Models
{
    public class SpendItem
    {
        public decimal AmountSpent { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Date { get; set; }
    }
}
