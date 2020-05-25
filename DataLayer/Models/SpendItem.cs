﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class SpendItem
    {
        public int SpendItemId { get; set; }
        public decimal AmountSpent { get; set; }
        public int SpendCategoryId { get; set; }
        public SpendCategory SpendCategory { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
