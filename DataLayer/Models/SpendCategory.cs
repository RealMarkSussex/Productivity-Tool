using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Enums;

namespace DataLayer.Models
{
    public class SpendCategory : EntityBase
    {
        public Category Category { get; set; }
    }
}
