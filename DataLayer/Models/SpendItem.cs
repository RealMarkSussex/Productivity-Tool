using System;
using System.Collections.Generic;
using System.Text;
using Shared.Enums;

namespace DataLayer.Models
{
    public class SpendItem : EntityBase
    {
        public decimal AmountSpent { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
