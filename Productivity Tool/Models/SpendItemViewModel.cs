using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Enums;

namespace Productivity_Tool.Models
{
    public class SpendItemViewModel
    {
        public string Description { get; set; }
        [Required]
        public decimal AmountSpent { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
    }
}
