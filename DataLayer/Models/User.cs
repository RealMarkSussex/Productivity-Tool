using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class User : EntityBase
    {
        public string EmailAddress { get; set; }
        public List<SpendItem> SpendItems { get; set; }
    }
}
